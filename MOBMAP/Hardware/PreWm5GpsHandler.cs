using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace MOBMAP.Hardware
{
    class PreWm5GpsHandler : Hardware.IGps
    {
        #region IGps Members
        private IntPtr gpsHandle = IntPtr.Zero;
        public bool hasGPS
        {
            get
            {
                return false;
            }

        }

        public IntPtr getGpsHandle()
        {
            return gpsHandle;
        }
        #endregion
    }
}
