using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace MOBMAP.Hardware
{
    class Hardware
    {
        public interface IGps
        {
            //gps exist?
            bool hasGPS
            {
                get;
            }
            IntPtr getGpsHandle();

        }

        static IGps _gpsHandler = null;

        //check if  GPSID exist(in WM 5.0 and later)
        public static IGps GetGpsHandler()
        {
            if (_gpsHandler == null)
            {
                if (Environment.OSVersion.Version.Major >= 5)
                {
                    //"Version 5 or later";
                    _gpsHandler = new PostWm5GpsHandler();
                }
                else
                {
                    //"Version before 5";
                    _gpsHandler = new PreWm5GpsHandler();
                }
            }

            return _gpsHandler;
        }
       
    }
}
