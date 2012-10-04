using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace MOBMAP.Geometry
{
    public class Triangle
    {
        private int _indexP1;
        private int _indexP2;
        private int _indexP3;


        public Triangle(int indexP1, int IndexP2, int IndexP3)
        {
            
            _indexP1 = indexP1;
            _indexP2 = IndexP2;
            _indexP3 = IndexP3;
        }


        #region getters & setters

        public int indexP1
        {
            get { return _indexP1; }
            set { _indexP1 = value; }
        }

        public int indexP2
        {
            get { return _indexP2; }
            set { _indexP2 = value; }
        }

        public int indexP3
        {
            get { return _indexP3; }
            set { _indexP3 = value; }
        }

        #endregion
    }
}
