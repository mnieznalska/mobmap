using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Globalization;

namespace MOBMAP.MapGoogle
{
    public class MapGoogle
    {
        private MapGoogleProperties _mapProperties;
        private MapGooglePath _mapPath;
        private MapGoogleMarkersList _mapMarkersList;
        private MapGoogleUrlBuilder _urlBuilder;
        private MapGoogleViewport _mapViewport;
        private int _width;
        private int _hight;

        public MapGoogle(int width, int hight)
        {
            this._width = width;
            this._hight = hight;
            _mapProperties = new MapGoogleProperties(_width, hight);
            _mapMarkersList = new MapGoogleMarkersList();
            _mapPath = new MapGooglePath();
            _mapViewport = new MapGoogleViewport();
            _urlBuilder = new MapGoogleUrlBuilder(this);
        }

        #region getters & setters

        public MapGoogleProperties mapProperties
        {
            get { return _mapProperties; }
        }
        public MapGoogleMarkersList mapMarkersList
        {
            get { return _mapMarkersList; }
        }
        public MapGoogleViewport mapViewport
        {
            get { return _mapViewport; }
        }
        public MapGooglePath mapPath
        {
            get { return _mapPath; }
            set { _mapPath = value; }
        }
        public MapGoogleUrlBuilder urlBuilder
        {
            get { return _urlBuilder; }
        }
        #endregion

        #region members

        public void setCoordinates( List<MOBMAP.Coordinates.Coordinate> geoCoordinates)
        {

            _mapMarkersList = new MapGoogleMarkersList();
            List<MapGooglePoint> tmpPathPoint = new List<MapGooglePoint>();
            _mapProperties = new MapGoogleProperties(this._width,this._hight);
            _urlBuilder = new MapGoogleUrlBuilder(this);
            _mapViewport = new MapGoogleViewport();

            if (geoCoordinates != null && geoCoordinates.Count > 0)
            {
                int countOfCoord = geoCoordinates.Count;
                int stepOfPoint = (int)countOfCoord / 50;
 
                //set markers
                 mapMarkersList.Add(new MapGoogleMarker(
                        new MapGooglePoint(geoCoordinates[0].coordinatePoint.X.ToString(CultureInfo.InvariantCulture.NumberFormat), geoCoordinates[0].coordinatePoint.Y.ToString(CultureInfo.InvariantCulture.NumberFormat)),
                        "B",
                        MapGoogleMarker.MarkerColor.green));

                 mapMarkersList.Add(new MapGoogleMarker(
                         new MapGooglePoint(geoCoordinates[countOfCoord - 1].coordinatePoint.X.ToString(CultureInfo.InvariantCulture.NumberFormat), geoCoordinates[countOfCoord - 1].coordinatePoint.Y.ToString(CultureInfo.InvariantCulture.NumberFormat)),
                         "E",
                         MapGoogleMarker.MarkerColor.red));
                //setPath
                 for (int i = 0; i < countOfCoord;i+=stepOfPoint )
                 {
                     tmpPathPoint.Add(new MapGooglePoint(geoCoordinates[i].coordinatePoint.X.ToString(CultureInfo.InvariantCulture.NumberFormat), geoCoordinates[i].coordinatePoint.Y.ToString(CultureInfo.InvariantCulture.NumberFormat)));
                 }
                 _mapPath = new MapGooglePath(tmpPathPoint);
                //setViewport
                 _mapViewport.centerPoint = mapViewport.setMapCenterPoint(_mapPath.pathPoint);
            }
        }

        

        private Bitmap downloadMap(string url)
        {
            Bitmap mapBtm = null;
            try
            {
                // Open connection
                System.Net.HttpWebRequest httpWebRequest = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(url);

                httpWebRequest.AllowWriteStreamBuffering = true;

                // timeout (20 seconds)
                httpWebRequest.Timeout = 20000;

                // Response:
                System.Net.WebResponse webResponse = httpWebRequest.GetResponse();

                // Open data stream:
                System.IO.Stream webStream = webResponse.GetResponseStream();

                // Create new bitmap from stream
                mapBtm = new Bitmap(webStream);

                // Close
                webStream.Close();
                webResponse.Close();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return null;
            }

            return mapBtm;
        }


        public Image showMap()
        {
            Bitmap _bm = null;
            Image _img = null;

            _urlBuilder.buildMapUrl();
            _bm = downloadMap(urlBuilder.mapUrl);
            // check for valid image
            if (_bm != null)
            {
                // show image in picturebox
                _img = (Image)_bm;
            }
            return _img;
        }

   
        #endregion
    }
}
