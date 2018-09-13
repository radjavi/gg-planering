using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gg_planering
{
    class Flight
    {
        public String flightNoIn;
        public String flightNoOut;
        public DateTime sta;
        public DateTime std;
        public String pos;

        public Flight(String flightNoIn, String flightNoOut, DateTime sta, DateTime std, String pos)
        {
            this.flightNoIn = flightNoIn;
            this.flightNoOut = flightNoOut;
            this.sta = sta;
            this.std = std;
            this.pos = pos;
        }
    }
}
