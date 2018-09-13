using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OfficeOpenXml;
using System.IO;

namespace gg_planering
{
    public partial class Form1 : Form
    {
        List<Flight> flights = new List<Flight>();

        public Form1()
        {
            InitializeComponent();
            initTimePickers();
            initListView();
        }

        private void initTimePickers()
        {
            timeSTA.Format = DateTimePickerFormat.Custom;
            timeSTA.CustomFormat = "HH:mm"; // Only use hours and minutes
            timeSTA.ShowUpDown = true;

            timeSTD.Format = DateTimePickerFormat.Custom;
            timeSTD.CustomFormat = "HH:mm"; // Only use hours and minutes
            timeSTD.ShowUpDown = true;
        }

        private void initListView()
        {
            listFlights.View = View.Details;
            listFlights.Columns.Add("Flight no. (in)", 80, HorizontalAlignment.Left);
            listFlights.Columns.Add("Flight no. (out)", 80, HorizontalAlignment.Left);
            listFlights.Columns.Add("STA", 60, HorizontalAlignment.Left);
            listFlights.Columns.Add("STD", 60, HorizontalAlignment.Left);
            listFlights.Columns.Add("Pos.", 60, HorizontalAlignment.Left);
        }

        private String checkInput()
        {
            if (tbxFlightNoOut.Text.Equals("")) return "Please input an outgoing flight number";
            return null;
        }

        private void flightsToList(Flight flight)
        {
            ListViewItem item = new ListViewItem(flight.flightNoIn);
            item.SubItems.Add(flight.flightNoOut);
            item.SubItems.Add(flight.sta.ToString("HH:mm"));
            item.SubItems.Add(flight.std.ToString("HH:mm"));
            item.SubItems.Add(flight.pos);
            listFlights.Items.Add(item);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (checkInput() != null)
            {
                MessageBox.Show(checkInput(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (cbxBKort.Checked)
                {
                    Flight flight = new Flight(tbxFlightNoIn.Text, tbxFlightNoOut.Text, timeSTA.Value, timeSTD.Value, "B-kort");
                    flights.Add(flight);
                    flightsToList(flight);
                }
                else
                {
                    if (cbxHela.Checked)
                    {
                        Flight flight = new Flight(tbxFlightNoIn.Text, tbxFlightNoOut.Text, timeSTA.Value, timeSTD.Value, "Hela");
                        flights.Add(flight);
                        flightsToList(flight);
                    }
                    else
                    {
                        Flight flightFwd = new Flight(tbxFlightNoIn.Text, tbxFlightNoOut.Text, timeSTA.Value, timeSTD.Value, "FWD");
                        Flight flightAft = new Flight(tbxFlightNoIn.Text, tbxFlightNoOut.Text, timeSTA.Value, timeSTD.Value, "AFT");
                        flights.Add(flightFwd);
                        flights.Add(flightAft);
                        flightsToList(flightFwd);
                        flightsToList(flightAft);
                    }
                }
                tbxFlightNoIn.Clear();
                tbxFlightNoOut.Clear();
            }
            if (flights.Count > 0 && listFlights.Items.Count > 0) btnReset.Enabled = true;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (listFlights.SelectedItems.Count > 0)
            {
                listFlights.BeginUpdate();
                foreach (ListViewItem item in listFlights.SelectedItems)
                {
                    flights.RemoveAt(item.Index);
                    listFlights.Items.Remove(item);
                }
                listFlights.EndUpdate();
            }
            if (flights.Count == 0 && listFlights.Items.Count == 0)
            {
                btnRemove.Enabled = false;
                btnReset.Enabled = false;
            }
        }

        private void btnDebug_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("------------------");
            for (int i=0; i < flights.Count; i++)
            {
                Flight flight = flights[i];
                System.Diagnostics.Debug.WriteLine(flight.flightNoIn + ", " + flight.flightNoOut + ", " + flight.sta.ToString("HH:mm") + ", " +
                    flight.std.ToString("HH:mm") + ", " + flight.pos);
            }
            System.Diagnostics.Debug.WriteLine("------------------");
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            btnGenerate.Enabled = false;
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel file|*.xlsx";
            saveFileDialog.Title = "Save Excel file";
            if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
            {
                btnGenerate.Enabled = true;
                return;
            }
            String fileName = saveFileDialog.FileName;

            //groupAddFlights.Enabled = false;
            //groupFlights.Enabled = false;

            // Sort by std
            for (int i=0; i<flights.Count-1; i++)
            {
                int minIndex = i;
                for (int j=i+1; j<flights.Count; j++)
                {
                    if (DateTime.Compare(flights[j].std, flights[minIndex].std) < 0) minIndex = j;
                }
                if (minIndex != i)
                {
                    Flight temp = flights[minIndex];
                    flights[minIndex] = flights[i];
                    flights[i] = temp;
                }
            }

            // Rearrange items in listview after sorting
            listFlights.Items.Clear();
            foreach (Flight flight in flights)
            {
                flightsToList(flight);
            }

            int n = (int) numDrivers.Value; // No. of drivers
            int counter = 0;

            List<Flight>[] driverFlights = new List<Flight>[n];
            for (int i=0; i<n; i++) driverFlights[i] = new List<Flight>();
            List<Flight> bDriverFlights = new List<Flight>();
            for (int i=0; i<flights.Count; i++)
            {
                if (flights[i].pos.Equals("B-kort"))
                {
                    bDriverFlights.Add(flights[i]);
                    continue;
                }
                driverFlights[counter % n].Add(flights[i]);
                counter++;
            }

            generateExcelFile(fileName, driverFlights, bDriverFlights);

            /*
            // Test printing
            System.Diagnostics.Debug.WriteLine("===================\n");
            for (int i = 0; i < driverFlights.Count(); i++)
            {
                System.Diagnostics.Debug.WriteLine("------------------");
                List<Flight> listFlight = driverFlights[i];
                for (int j=0; j < listFlight.Count; j++)
                {
                    Flight flight = listFlight.ElementAt(j);
                    System.Diagnostics.Debug.WriteLine(flight.flightNoIn + ", " + flight.flightNoOut + ", " + flight.sta.ToString("HH:mm") + ", " +
                    flight.std.ToString("HH:mm") + ", " + flight.pos);
                }
                System.Diagnostics.Debug.WriteLine("------------------");
            }

            System.Diagnostics.Debug.WriteLine("------------------");
            for (int j = 0; j < bDriverFlights.Count; j++)
            {
                Flight flight = bDriverFlights.ElementAt(j);
                System.Diagnostics.Debug.WriteLine(flight.flightNoIn + ", " + flight.flightNoOut + ", " + flight.sta.ToString("HH:mm") + ", " +
                flight.std.ToString("HH:mm") + ", " + flight.pos);
            }
            System.Diagnostics.Debug.WriteLine("------------------");
            System.Diagnostics.Debug.WriteLine("\n===================");
            */
        }

        private void generateExcelFile(String fileName, List<Flight>[] driverFlights, List<Flight> bDriverFlights)
        {
            ExcelPackage excel = new ExcelPackage();
            excel.Workbook.Worksheets.Add("GG-Planering");
            var worksheet = excel.Workbook.Worksheets["GG-Planering"];
            int row = 1;

            //--- Driver section ---//
            for (int i = 0; i < driverFlights.Count(); i++)
            {
                var headerRow = new List<string[]>()
                {
                    new string[] { "Flight nr. (in)", "Flight nr. (ut)", "STA", "STD", "Pos.", "Bil" }
                };
                string headerRange = "A" + row + ":F" + row;
                worksheet.Cells[headerRange].Style.Border.Top.Style = OfficeOpenXml.Style.ExcelBorderStyle.Medium;
                worksheet.Cells[headerRange].Style.Border.Left.Style = OfficeOpenXml.Style.ExcelBorderStyle.Medium;
                worksheet.Cells[headerRange].Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Medium;
                worksheet.Cells[headerRange].Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Medium;
                var cellData = new List<object[]>();

                List<Flight> listFlight = driverFlights[i];
                for (int j = 0; j < listFlight.Count; j++)
                {
                    Flight flight = listFlight.ElementAt(j);
                    cellData.Add(new object[] { flight.flightNoIn, flight.flightNoOut, flight.sta.ToString("HH:mm"), flight.std.ToString("HH:mm"), flight.pos });
                    worksheet.Cells["A" + (row + j + 1) + ":F" + (row + j + 1)].Style.Border.Left.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                    worksheet.Cells["A" + (row + j + 1) + ":F" + (row + j + 1)].Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                    worksheet.Cells["A" + (row + j + 1)].Style.Border.Left.Style = OfficeOpenXml.Style.ExcelBorderStyle.Medium;
                    worksheet.Cells["F" + (row + j + 1)].Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Medium;
                }
                
                worksheet.Cells["A" + (listFlight.Count + row) + ":F" + (listFlight.Count + row)].Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Medium;

                worksheet.Cells[headerRange].LoadFromArrays(headerRow);
                worksheet.Cells[headerRange].Style.Font.Bold = true;
                worksheet.Cells[row+1, 1].LoadFromArrays(cellData);
                row += listFlight.Count + 2;
            }
            //------------------//

            //--- B-driver section ---//
            if (bDriverFlights.Count > 0)
            {
                var headerRowB = new List<string[]>()
                {
                    new string[] { "Flight nr. (in)", "Flight nr. (ut)", "STA", "STD", "Pos.", "Bil" }
                };
                string headerRangeB = "A" + row + ":F" + row;
                worksheet.Cells[headerRangeB].Style.Border.Top.Style = OfficeOpenXml.Style.ExcelBorderStyle.Medium;
                worksheet.Cells[headerRangeB].Style.Border.Left.Style = OfficeOpenXml.Style.ExcelBorderStyle.Medium;
                worksheet.Cells[headerRangeB].Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Medium;
                worksheet.Cells[headerRangeB].Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Medium;
                var cellDataB = new List<object[]>();
                for (int i = 0; i < bDriverFlights.Count; i++)
                {
                    Flight flight = bDriverFlights.ElementAt(i);
                    cellDataB.Add(new object[] { flight.flightNoIn, flight.flightNoOut, flight.sta.ToString("HH:mm"), flight.std.ToString("HH:mm"), flight.pos });
                    worksheet.Cells["A" + (row + i + 1) + ":F" + (row + i + 1)].Style.Border.Left.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                    worksheet.Cells["A" + (row + i + 1) + ":F" + (row + i + 1)].Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                    worksheet.Cells["A" + (row + i + 1)].Style.Border.Left.Style = OfficeOpenXml.Style.ExcelBorderStyle.Medium;
                    worksheet.Cells["F" + (row + i + 1)].Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Medium;
                }
                worksheet.Cells["A" + (bDriverFlights.Count + row) + ":F" + (bDriverFlights.Count + row)].Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Medium;

                worksheet.Cells[headerRangeB].LoadFromArrays(headerRowB);
                worksheet.Cells[headerRangeB].Style.Font.Bold = true;
                worksheet.Cells[row + 1, 1].LoadFromArrays(cellDataB);
            }
            //------------------//
            worksheet.Cells["A1:F1"].AutoFitColumns();

            FileInfo excelFile = new FileInfo(@fileName);
            try
            {
                excel.SaveAs(excelFile);
                bool isExcelInstalled = Type.GetTypeFromProgID("Excel.Application") != null ? true : false;
                if (isExcelInstalled)
                {
                    System.Diagnostics.Process.Start(excelFile.ToString());
                }
            } catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            btnGenerate.Enabled = true;
        }

        private void cbxBKort_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxBKort.Checked) cbxHela.Enabled = false;
            else cbxHela.Enabled = true;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            listFlights.Items.Clear();
            flights.Clear();
            btnReset.Enabled = false;
            btnRemove.Enabled = false;
        }

        private void listFlights_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (listFlights.SelectedItems.Count > 0) btnRemove.Enabled = true;
            else btnRemove.Enabled = false;
        }
    }
}
