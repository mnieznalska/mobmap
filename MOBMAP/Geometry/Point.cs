using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace MOBMAP.Geometry
{
    public class Point
    {
        private float _X;
        private float _Y;
        private float _Z;

        public Point(float x, float y, float z)
        {
            _X = x;
            _Y = y;
            _Z = z;
        }

        public Point(float x, float y)
        {
            _X = x;
            _Y = y;
            _Z = 0;
        }

        public Point()
        {

        }

        #region getters & setters

        //get x value of the point
        public float X
        {
            get { return _X; }
            set { _X = value; }
        }

        //get y value of the point
        public float Y
        {
            get { return _Y; }
            set { _Y = value; }
        }

        //get z value of the point
        public float Z
        {
            get { return _Z; }
            set { _Z = value; }
        }

        #endregion

        public bool Equals2D(Point compare)
        {
            return (X == compare.X && Y == compare.Y);
        }

        public bool Equals3D(Point compare)
        {
            return (X == compare.X && Y == compare.Y && Z == compare.Z);
        }
    }
}
