using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace MapControl
{
    public class DrawParameters
    {
        private double latitude;
        private double longitude;
        private double altitude;
        private int fix;

         public DrawParameters(double latitude, double longitude, double altitude, int fix)
        {
            this.latitude = latitude;
            this.longitude = longitude;
            this.altitude = altitude;
            this.fix = fix;
        }
    }
}
