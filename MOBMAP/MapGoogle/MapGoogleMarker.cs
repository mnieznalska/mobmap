using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace MOBMAP.MapGoogle
{
    //class defines map marker
    public class MapGoogleMarker
    {
        #region members
        private string _label =""; //optional params
        private MapGooglePoint _markerPoint; //required params

        public enum MarkerSize//optional params
        {
            small = 0,//NOT POSSIBLE TO DISPLAY LABEL
            tiny = 1,//NOT POSSIBLE TO DISPLAY LABEL
            mid = 2,//POSSIBLE TO DISPLAY LABEL
            none= 3//NORMAL SIZE, POSSIBLE TO DOSPLAY
        }

        public enum MarkerColor //optional params
        {
            black = 0,
            brown = 1,
            green = 2,
            purple = 3,
            yellow = 4,
            blue = 5,
            gray = 6,
            orange = 7,
            red = 8,
            white = 9,
            none = 10 //default color
        }

        public enum MarkerStatus //starus
        {
            p = 0,
            pc = 1,
            pl = 2,
            ps = 3,
            plc = 4,
            plsc = 5,
            psc = 6
        }

        private MarkerSize _markerSize = MarkerSize.none;//optional params
        private MarkerColor _markerColor = MarkerColor.none;//optional params
        private MarkerStatus _markerStatus = MarkerStatus.p;//status

        #endregion

        #region constructors
        public MapGoogleMarker(MapGooglePoint markerPoint)
        {
            this._markerPoint = markerPoint;
            this._markerStatus = MarkerStatus.p;
        }

        public MapGoogleMarker(MapGooglePoint markerPoint, MarkerColor mColor)
        {
            this._markerPoint = markerPoint;
            this._markerColor = mColor;
            this._markerStatus = MarkerStatus.pc;
        }

        public MapGoogleMarker(MapGooglePoint markerPoint, string label)
        {

            this._markerPoint = markerPoint;
            this._label = label;
            this._markerStatus = MarkerStatus.pl;
        }

        public MapGoogleMarker(MapGooglePoint markerPoint, MarkerSize mSize)
        {
            this._markerPoint = markerPoint;
            this._markerSize = mSize;
            this._markerStatus = MarkerStatus.ps;
        }

        public MapGoogleMarker(MapGooglePoint markerPoint, string label, MarkerColor mColor)
        {
            this._label = label;
            this._markerPoint = markerPoint;
            this._markerColor = mColor;
            this._markerStatus = MarkerStatus.plc;
        }

        public MapGoogleMarker(MapGooglePoint markerPoint, string label, MarkerSize mSize, MarkerColor mColor)
        {
            this._markerPoint = markerPoint;
            this._label = label;
            this._markerSize = mSize;
            this._markerColor = mColor;
            this._markerStatus = MarkerStatus.plsc;
        }

        public MapGoogleMarker(MapGooglePoint markerPoint, MarkerSize mSize, MarkerColor mColor)
        {
            this._markerPoint = markerPoint;
            this._markerSize = mSize;
            this._markerColor = mColor;
            this._markerStatus = MarkerStatus.psc;
        }
        #endregion

        #region getters & setters
        public string label
        {
            get { return _label; }
        }

        public MapGooglePoint markerPoint
        {
            get { return _markerPoint; }
        }

        public MarkerSize markerSize
        {
            get { return _markerSize; }
        }

        public MarkerColor markerColor
        {
            get { return _markerColor; }
        }

        public MarkerStatus markerStatus
        {
            get { return _markerStatus; }
        }
        #endregion
    }
}
