using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace MOBMAP.MapGoogle
{
    public class MapGooglePoint
    {
        #region members
        private string _latitude = null;
        private string _longitude = null;
        #endregion

        #region constructor
        public MapGooglePoint(string latitude, string longitude)
        {
            this._latitude = latitude;
            this._longitude = longitude;
        }
        #endregion

        #region getters & setters
        public string latitude
        {
            get { return _latitude; }
        }

        public string longitude
        {
            get { return _longitude; }
        }

        public string latLong
        {
            get { return latitude + "," + longitude; }
        }
        #endregion
    }
}
