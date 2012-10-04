using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace MOBMAP.MapGoogle
{
    public class MapGoogleProperties
    {
        #region members
        private bool _sensor = true;//required params
        private int _zoomLevel = 10;
        private int _width;
        private int _hight;
   

        public enum MapTypes//optional params
        {
            ROADMAP = 0,
            SATATELLITE = 1,
            HYBRID = 2,
            TERRAIN = 3,
            NONE = 4//DEFAULT MAP TYPE(ROADMAP)
        }

        public enum MapImgFormats//optional params
        {
            PNG = 0,
            GIF = 1,
            JPG = 2,
            NONE = 3//DEFAULT IMAGE FORMAT(PNG)
        }

        private MapTypes _mapTypes = MapTypes.NONE;
        private MapImgFormats _mapImgFormats = MapImgFormats.NONE;
        #endregion

        #region constructor
        public MapGoogleProperties(int width, int hight)//Image img)
        {
            this._width = width;
            this._hight = hight;
        }
        #endregion

        #region getters & setters
        public bool sensor
        {
            get { return _sensor; }
            set { _sensor = value; }
        }

        public MapTypes mapTypes
        {
            get { return _mapTypes; }
            set { _mapTypes = value; }
        }

        public MapImgFormats mapImgFormats
        {
            get { return _mapImgFormats; }
            set { _mapImgFormats = value; }
        }

        public int zoomLevel
        {
            get { return _zoomLevel; }
            set { _zoomLevel = value; }
        }

        public string mapSize//required params
        {
            get { return "&size=" + this._width + "x" + this._hight; }
        }

        public string mapType//optional params
        {
            get { 
                if(this._mapTypes.Equals(MapTypes.NONE))
                    return "";
                else
                    return "&maptype=" + _mapTypes.ToString();
            }
        }

        public string mapImgFormat//optional params
        {
            get {
                if (this._mapImgFormats.Equals(MapImgFormats.NONE))
                    return "";
                else
                    return "&format=" + _mapImgFormats.ToString(); }
        }

        public string mapZoom//optional
        {
            get { return "&zoom=" + zoomLevel.ToString(); }
        }
        public string mapSensor//required
        {
            get { return "&sensor=" + _sensor.ToString(); }
        }
        #endregion
    }
}
