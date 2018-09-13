namespace gg_planering
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.groupAddFlights = new System.Windows.Forms.GroupBox();
            this.cbxBKort = new System.Windows.Forms.CheckBox();
            this.timeSTD = new System.Windows.Forms.DateTimePicker();
            this.timeSTA = new System.Windows.Forms.DateTimePicker();
            this.cbxHela = new System.Windows.Forms.CheckBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxFlightNoOut = new System.Windows.Forms.TextBox();
            this.tbxFlightNoIn = new System.Windows.Forms.TextBox();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.groupFlights = new System.Windows.Forms.GroupBox();
            this.btnDebug = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.listFlights = new System.Windows.Forms.ListView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.numDrivers = new System.Windows.Forms.NumericUpDown();
            this.btnReset = new System.Windows.Forms.Button();
            this.groupAddFlights.SuspendLayout();
            this.groupFlights.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDrivers)).BeginInit();
            this.SuspendLayout();
            // 
            // groupAddFlights
            // 
            this.groupAddFlights.Controls.Add(this.cbxBKort);
            this.groupAddFlights.Controls.Add(this.timeSTD);
            this.groupAddFlights.Controls.Add(this.timeSTA);
            this.groupAddFlights.Controls.Add(this.cbxHela);
            this.groupAddFlights.Controls.Add(this.btnAdd);
            this.groupAddFlights.Controls.Add(this.label5);
            this.groupAddFlights.Controls.Add(this.label4);
            this.groupAddFlights.Controls.Add(this.label3);
            this.groupAddFlights.Controls.Add(this.label2);
            this.groupAddFlights.Controls.Add(this.label1);
            this.groupAddFlights.Controls.Add(this.tbxFlightNoOut);
            this.groupAddFlights.Controls.Add(this.tbxFlightNoIn);
            this.groupAddFlights.Location = new System.Drawing.Point(12, 12);
            this.groupAddFlights.Name = "groupAddFlights";
            this.groupAddFlights.Size = new System.Drawing.Size(479, 84);
            this.groupAddFlights.TabIndex = 0;
            this.groupAddFlights.TabStop = false;
            this.groupAddFlights.Text = "Lägg till flighter";
            // 
            // cbxBKort
            // 
            this.cbxBKort.AutoSize = true;
            this.cbxBKort.Location = new System.Drawing.Point(336, 42);
            this.cbxBKort.Name = "cbxBKort";
            this.cbxBKort.Size = new System.Drawing.Size(54, 17);
            this.cbxBKort.TabIndex = 14;
            this.cbxBKort.Text = "B-kort";
            this.cbxBKort.UseVisualStyleBackColor = true;
            this.cbxBKort.CheckedChanged += new System.EventHandler(this.cbxBKort_CheckedChanged);
            // 
            // timeSTD
            // 
            this.timeSTD.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.timeSTD.Location = new System.Drawing.Point(221, 40);
            this.timeSTD.Name = "timeSTD";
            this.timeSTD.Size = new System.Drawing.Size(53, 20);
            this.timeSTD.TabIndex = 13;
            // 
            // timeSTA
            // 
            this.timeSTA.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.timeSTA.Location = new System.Drawing.Point(162, 40);
            this.timeSTA.Name = "timeSTA";
            this.timeSTA.Size = new System.Drawing.Size(53, 20);
            this.timeSTA.TabIndex = 12;
            // 
            // cbxHela
            // 
            this.cbxHela.AutoSize = true;
            this.cbxHela.Location = new System.Drawing.Point(284, 42);
            this.cbxHela.Name = "cbxHela";
            this.cbxHela.Size = new System.Drawing.Size(48, 17);
            this.cbxHela.TabIndex = 11;
            this.cbxHela.Text = "Hela";
            this.cbxHela.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(404, 39);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(61, 23);
            this.btnAdd.TabIndex = 10;
            this.btnAdd.Text = "Lägg till";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(281, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Pos.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(218, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "STD";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(162, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "STA";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(82, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Flight nr. (ut)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Flight nr. (in)";
            // 
            // tbxFlightNoOut
            // 
            this.tbxFlightNoOut.Location = new System.Drawing.Point(83, 40);
            this.tbxFlightNoOut.Name = "tbxFlightNoOut";
            this.tbxFlightNoOut.Size = new System.Drawing.Size(73, 20);
            this.tbxFlightNoOut.TabIndex = 1;
            this.tbxFlightNoOut.Text = "DK1796";
            // 
            // tbxFlightNoIn
            // 
            this.tbxFlightNoIn.Location = new System.Drawing.Point(13, 40);
            this.tbxFlightNoIn.Name = "tbxFlightNoIn";
            this.tbxFlightNoIn.Size = new System.Drawing.Size(64, 20);
            this.tbxFlightNoIn.TabIndex = 0;
            this.tbxFlightNoIn.Text = "DK1797";
            // 
            // groupFlights
            // 
            this.groupFlights.Controls.Add(this.btnReset);
            this.groupFlights.Controls.Add(this.btnRemove);
            this.groupFlights.Controls.Add(this.listFlights);
            this.groupFlights.Location = new System.Drawing.Point(12, 118);
            this.groupFlights.Name = "groupFlights";
            this.groupFlights.Size = new System.Drawing.Size(479, 228);
            this.groupFlights.TabIndex = 2;
            this.groupFlights.TabStop = false;
            this.groupFlights.Text = "Flighter";
            // 
            // btnDebug
            // 
            this.btnDebug.Location = new System.Drawing.Point(390, 42);
            this.btnDebug.Name = "btnDebug";
            this.btnDebug.Size = new System.Drawing.Size(75, 23);
            this.btnDebug.TabIndex = 4;
            this.btnDebug.Text = "Debug";
            this.btnDebug.UseVisualStyleBackColor = true;
            this.btnDebug.Visible = false;
            this.btnDebug.Click += new System.EventHandler(this.btnDebug_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Enabled = false;
            this.btnRemove.Location = new System.Drawing.Point(390, 25);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 3;
            this.btnRemove.Text = "Ta bort";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // listFlights
            // 
            this.listFlights.FullRowSelect = true;
            this.listFlights.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listFlights.Location = new System.Drawing.Point(13, 25);
            this.listFlights.Name = "listFlights";
            this.listFlights.Size = new System.Drawing.Size(361, 186);
            this.listFlights.TabIndex = 2;
            this.listFlights.UseCompatibleStateImageBehavior = false;
            this.listFlights.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listFlights_ItemSelectionChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnGenerate);
            this.groupBox3.Controls.Add(this.btnDebug);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.numDrivers);
            this.groupBox3.Location = new System.Drawing.Point(12, 367);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(479, 84);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Skapa planering";
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(115, 42);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(75, 23);
            this.btnGenerate.TabIndex = 2;
            this.btnGenerate.Text = "Skapa";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Antal C-förare";
            // 
            // numDrivers
            // 
            this.numDrivers.Location = new System.Drawing.Point(13, 44);
            this.numDrivers.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.numDrivers.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numDrivers.Name = "numDrivers";
            this.numDrivers.Size = new System.Drawing.Size(64, 20);
            this.numDrivers.TabIndex = 0;
            this.numDrivers.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // btnReset
            // 
            this.btnReset.Enabled = false;
            this.btnReset.Location = new System.Drawing.Point(390, 188);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 3;
            this.btnReset.Text = "Återställ";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(503, 465);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupFlights);
            this.Controls.Add(this.groupAddFlights);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gate Gourmet - Planering";
            this.groupAddFlights.ResumeLayout(false);
            this.groupAddFlights.PerformLayout();
            this.groupFlights.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDrivers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupAddFlights;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxFlightNoOut;
        private System.Windows.Forms.TextBox tbxFlightNoIn;
        private System.Windows.Forms.Button btnAdd;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.GroupBox groupFlights;
        private System.Windows.Forms.CheckBox cbxHela;
        private System.Windows.Forms.DateTimePicker timeSTA;
        private System.Windows.Forms.DateTimePicker timeSTD;
        private System.Windows.Forms.ListView listFlights;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numDrivers;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnDebug;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.CheckBox cbxBKort;
        private System.Windows.Forms.Button btnReset;
    }
}

