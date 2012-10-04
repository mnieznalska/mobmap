using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace MOBMAP.MapGoogle
{
    public class MapGooglePath
    {
        #region members
        private List<MapGooglePoint> _pathPoint;//required params
        private StringBuilder pathPointString;
        private string pathString = "";
        private bool isFirstPoint = true;
        public enum PathColor //optional params
        {
            black=0,
            brown=1,
            green=2,
            purple=3,
            yellow=4,
            blue=5,
            gray=6,
            orange=7,
            red=8,
            white=9,
            none = 10 //default color
        }

        public enum PathWidth //optional params
        {
            twoPx = 2,
            fourPx = 4,
            sixPx = 6,
            eightPx = 8,
            none = 5 //default width
        }

        public enum PathStatus
        {
            p = 0,
            pw = 1,
            pc = 2,
            pwc = 3,
            none = 4 //no path
        }

        private PathColor _pathColor = PathColor.none;
        private PathWidth _pathWidth = PathWidth.none;
        private PathStatus _pathStatus = PathStatus.none;
        #endregion

        #region constructors
        public MapGooglePath()
        {
            _pathPoint = new List<MapGooglePoint>();
            this._pathStatus = PathStatus.none;
        }
        public MapGooglePath(List<MapGooglePoint> pathPoint)
        {
            this._pathPoint = new List<MapGooglePoint>();
            this._pathPoint = pathPoint;
            this._pathStatus = PathStatus.p;
        }

        public MapGooglePath(List<MapGooglePoint> pathPoint, MapGooglePath.PathWidth pathWidth)
        {
            this._pathPoint = new List<MapGooglePoint>();
            this._pathPoint = pathPoint;
            this._pathWidth = pathWidth;
            this._pathStatus = PathStatus.pw;
        }

        public MapGooglePath(List<MapGooglePoint> pathPoint, MapGooglePath.PathColor pathColor)
        {
            this._pathPoint = new List<MapGooglePoint>();
            this._pathPoint = pathPoint;
            this._pathColor = pathColor;
            this._pathStatus = PathStatus.pc;
        }

        public MapGooglePath(List<MapGooglePoint> pathPoint, MapGooglePath.PathColor pathColor, MapGooglePath.PathWidth pathWidth)
        {
            this._pathPoint = new List<MapGooglePoint>();
            this._pathPoint = pathPoint;
            this._pathColor = pathColor;
            this._pathWidth = pathWidth;
            this._pathStatus = PathStatus.pwc;
        }
        #endregion

        #region getters & setters
        public List<MapGooglePoint> pathPoint
        {
            get { return _pathPoint; }
        }

        public PathColor pathColor
        {
            get { return _pathColor; }
        }

        public PathWidth pathWidth
        {
            get { return _pathWidth; }
        }
        #endregion

        #region methods
        public string pathStringBuild()
        {
            switch (_pathStatus)
            {
                case PathStatus.p:
                    {
                        pathString = String.Format(CultureInfo.InvariantCulture,
                        "&path={0}",
                        this.pathPointStringBuild());
                    }break;
                case PathStatus.pc:
                    {
                        pathString = String.Format(CultureInfo.InvariantCulture,
                        "&path=color:{0}|{1}",
                        this.pathColor, this.pathPointStringBuild());
                    }break;
                case PathStatus.pw:
                    {
                        pathString = String.Format(CultureInfo.InvariantCulture,
                        "&path=weight:{0}|{1}",
                        this.pathWidth, this.pathPointStringBuild());
                    }break;
                case PathStatus.pwc:
                    {
                        pathString = String.Format(CultureInfo.InvariantCulture,
                        "&path=color:{0}|weight:{1}|{2}",
                        this.pathColor, this.pathWidth, this.pathPointStringBuild());
                    }break;
                case PathStatus.none:
                    {
                        pathString = "";
                    } break;
            }

            return pathString;
        }
        private string pathPointStringBuild()
        {
            pathPointString = new StringBuilder();
            pathPointString.Append("");
            isFirstPoint = true;

            foreach (MapGooglePoint point in pathPoint)
            {
                if (!isFirstPoint)
                {
                    pathPointString.Append("|");
                }
                pathPointString.Append(point.latLong);
                isFirstPoint = false;
            }
            return pathPointString.ToString();
        }
        #endregion
    }
}
