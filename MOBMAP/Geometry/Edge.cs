using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace MOBMAP.Geometry
{
    public class Edge : IEquatable<Edge>
    {
        private int _indexP1;
        private int _indexP2;

        public Edge(int indexP1, int indexP2)
        {
            _indexP1 = indexP1;
            _indexP2 = indexP2;
        }

        public Edge()
            : this(0, 0)
        {
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
        #endregion


        public bool Equals(Edge otherEdge)
        {
            return  ((this.indexP1 == otherEdge.indexP2) && (this.indexP2 == otherEdge.indexP1))
                || ((this.indexP1 == otherEdge.indexP1) && (this.indexP2 == otherEdge.indexP2));
        }
    }
}
