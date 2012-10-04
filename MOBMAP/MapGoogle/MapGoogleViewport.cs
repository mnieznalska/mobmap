using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace MOBMAP.MapGoogle
{
    public class MapGoogleViewport
    {
        #region members
        private static double GOOGLEOFFSET = 268435456;
        private static double GOOGLEOFFSET_RADIUS = GOOGLEOFFSET / Math.PI;
        private static double MATHPI_180 = Math.PI / 180;
        private static double preLonToX1 = GOOGLEOFFSET_RADIUS * (Math.PI / 180);

        MapGooglePoint _centerPoint;

        
        #endregion

        #region constructors
        public MapGoogleViewport(MapGooglePoint centerPoint)
        {
            this._centerPoint = centerPoint;
        }
        public MapGoogleViewport()
        {

        }
        #endregion

        #region getters&setters

        public MapGooglePoint centerPoint
        {
            get { return _centerPoint; }
            set { _centerPoint = value; }
        }

        public string mapCenter
        {
            get { return "&center=" + _centerPoint.latLong; }
        }

        #endregion

        #region methods

        private double LonToX(double lon)
        {
            return Math.Round(GOOGLEOFFSET + preLonToX1 * lon);
        }

        private double LatToY(double lat)
        {
            return Math.Round(GOOGLEOFFSET - GOOGLEOFFSET_RADIUS * Math.Log((1 + Math.Sin(lat * MATHPI_180)) / (1 - Math.Sin(lat * MATHPI_180))) / 2);
        }

        private double XToLon(double x)
        {
            return ((Math.Round(x) - GOOGLEOFFSET) / GOOGLEOFFSET_RADIUS) * 180 / Math.PI;
        }

        private double YToLat(double y)
        {
            return (Math.PI / 2 - 2 * Math.Atan(Math.Exp((Math.Round(y) - GOOGLEOFFSET) / GOOGLEOFFSET_RADIUS))) * 180 / Math.PI;
        }

        private double adjustLonByPixels(double lon, int delta, int zoom)
        {
            return XToLon(LonToX(lon) + (delta << (21 - zoom)));
        }

        private double adjustLatByPixels(double lat, int delta, int zoom)
        {
            return YToLat(LatToY(lat) + (delta << (21 - zoom)));
        }

        public MapGooglePoint setMapCenterPoint(List<MapGooglePoint> pathPoint)
        {
            float latMin = System.Convert.ToSingle(pathPoint[0].latitude, CultureInfo.InvariantCulture.NumberFormat);
            float lonMin = System.Convert.ToSingle(pathPoint[0].longitude, CultureInfo.InvariantCulture.NumberFormat);
            float latMax = latMin;
            float lonMax = lonMin;

            for (int i = 1; i < pathPoint.Count; i++)
            {
                if (System.Convert.ToSingle(pathPoint[i].latitude, CultureInfo.InvariantCulture.NumberFormat) < latMin) latMin = System.Convert.ToSingle(pathPoint[i].latitude, CultureInfo.InvariantCulture.NumberFormat);
                else if (System.Convert.ToSingle(pathPoint[i].latitude, CultureInfo.InvariantCulture.NumberFormat) > latMax) latMax = System.Convert.ToSingle(pathPoint[i].latitude, CultureInfo.InvariantCulture.NumberFormat);

                if (System.Convert.ToSingle(pathPoint[i].longitude, CultureInfo.InvariantCulture.NumberFormat) < lonMin) lonMin = System.Convert.ToSingle(pathPoint[i].longitude, CultureInfo.InvariantCulture.NumberFormat);
                else if (System.Convert.ToSingle(pathPoint[i].longitude, CultureInfo.InvariantCulture.NumberFormat) > lonMax) lonMax = System.Convert.ToSingle(pathPoint[i].longitude, CultureInfo.InvariantCulture.NumberFormat);
            }

            return new MapGooglePoint(((float)(latMax - ((latMax - latMin) / 2))).ToString(CultureInfo.InvariantCulture.NumberFormat), ((float)(lonMax - ((lonMax - lonMin) / 2))).ToString(CultureInfo.InvariantCulture.NumberFormat));
        }

        public void moveMap(int movePixelUpDown, int movePixelRightLeft, int currentZoomLevel)
        {
            MapGooglePoint tmpPoint = new MOBMAP.MapGoogle.MapGooglePoint(
            this.adjustLatByPixels(Convert.ToSingle(_centerPoint.latitude, CultureInfo.InvariantCulture.NumberFormat), movePixelUpDown, currentZoomLevel).ToString(CultureInfo.InvariantCulture.NumberFormat),
            this.adjustLonByPixels(Convert.ToSingle(_centerPoint.longitude, CultureInfo.InvariantCulture.NumberFormat), movePixelRightLeft, currentZoomLevel).ToString(CultureInfo.InvariantCulture.NumberFormat));

            _centerPoint = tmpPoint;
        }
        #endregion
    }
}
