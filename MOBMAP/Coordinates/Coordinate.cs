using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace MOBMAP.Coordinates
{
    public class Coordinate
    {
        #region members
        private Geometry.Point _coordinatePoint = new MOBMAP.Geometry.Point();
        private bool _fix;
        #endregion

        #region constructors
        public Coordinate(Geometry.Point coordinatePoint, bool fix)
        {
            this.coordinatePoint = coordinatePoint;
            this.fix = fix;
        }

        public Coordinate()
        {
        }
        #endregion

        #region getters & setters

        public Geometry.Point coordinatePoint
        {
            get { return _coordinatePoint; }
            set { _coordinatePoint = value; }
        }
        public bool fix
        {
            get { return _fix; }
            set { _fix = value; }
        }
        #endregion
    }
}
