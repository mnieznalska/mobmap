using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;


namespace MOBMAP.Triangulation
{
    public class Delaunay
    {
        private List<Geometry.Point> _pointList;
        private List<Geometry.Triangle> _triangleList;
        private List<Geometry.Edge> _edgeList;
        public float minX=0;
        public float minY = 0;
        public float minZ = 0;
        public float maxX = 0;
        public float maxY = 0;
        public float maxZ = 0;
        public float dx, dy, dz;
        public Delaunay()
        {
            pointList = new List<Geometry.Point>();
        }

        #region getters & setters

        public List<Geometry.Triangle> triangleList
        {
            get { return _triangleList; }
            set { _triangleList = value; }
        }

        public List<Geometry.Point> pointList
        {
            get { return _pointList; }
            set { _pointList = value; }
        }

        public List<Geometry.Edge> edgeList
        {
            get { return _edgeList; }
            set { _edgeList = value; }
        }

        #endregion

        public void triangulate()
        {
            triangleList = delaunayTriangulate(pointList);           
        }

        //Delaunay triangulation
        public List<Geometry.Triangle> delaunayTriangulate(List<Geometry.Point> vertList)
        {
            List<Geometry.Point> strPoint;
            int vertCount = vertList.Count;
            int maxTriangleCount = 4 * vertCount;

            if (vertCount < 3)
                throw new ArgumentException("VERTICES COUNT NOT ENV.");

            //calc supertriangle
            strPoint = calculateSupertriangle(vertList);
            vertList.Add(strPoint[0]);
            vertList.Add(strPoint[1]);
            vertList.Add(strPoint[2]);

            //create triangle list
            List<Geometry.Triangle> Triangle = new List<Geometry.Triangle>();
            //add supertriangle to triangle list
            Triangle.Add(new Geometry.Triangle(vertCount, vertCount + 1, vertCount + 2));

            // tr
            for (int i = 0; i < vertCount; i++)
            {
                //create edge list
                List<Geometry.Edge> Edges = new List<Geometry.Edge>(); 
                for (int j = 0; j < Triangle.Count; j++)
                {
                    if (InCircle(vertList[i], vertList[Triangle[j].indexP1], vertList[Triangle[j].indexP2], vertList[Triangle[j].indexP3]))
                    {
                        Edges.Add(new Geometry.Edge(Triangle[j].indexP1, Triangle[j].indexP2));
                        Edges.Add(new Geometry.Edge(Triangle[j].indexP2, Triangle[j].indexP3));
                        Edges.Add(new Geometry.Edge(Triangle[j].indexP3, Triangle[j].indexP1));
                        Triangle.RemoveAt(j);
                        j--;
                    }
                }
                if (i >= vertCount) continue; 

                // delete double edges

                for (int j = Edges.Count - 2; j >= 0; j--)
                {
                    for (int k = Edges.Count - 1; k >= j + 1; k--)
                    {
                        if (Edges[j].Equals(Edges[k]))
                        {
                            Edges.RemoveAt(k);
                            Edges.RemoveAt(j);
                            k--;
                            continue;
                        }
                    }
                }
                // create new triangles
                for (int j = 0; j < Edges.Count; j++)
                {
                    if (Triangle.Count >= maxTriangleCount)
                        throw new ApplicationException("MAX EDGE ");
                    Triangle.Add(new Geometry.Triangle(Edges[j].indexP1, Edges[j].indexP2, i));
                }
                Edges.Clear();
                Edges = null;
            }
            // delete triangles with point on supertriangle
            for (int i = Triangle.Count - 1; i >= 0; i--)
            {
                if (Triangle[i].indexP1 >= vertCount || Triangle[i].indexP2 >= vertCount || Triangle[i].indexP3 >= vertCount)
                    Triangle.RemoveAt(i);
            }
            //Remove SuperTriangle vertices
            vertList.RemoveAt(vertList.Count - 1);
            vertList.RemoveAt(vertList.Count - 1);
            vertList.RemoveAt(vertList.Count - 1);
            Triangle.TrimExcess();
            return Triangle;
        }


        //add new points to pointList and triangulate
        public void addNewPoints(List<Coordinates.Coordinate> newProjCoordinateList)
        {
            pointList.Clear();
            foreach (Coordinates.Coordinate c in newProjCoordinateList)
            {
                pointList.Add(c.coordinatePoint);
            }                
            triangulate();
        }

        //add new points to pointList and triangulate
        public void addNewPoint(Geometry.Point newPoint)
        {
            pointList.Add(newPoint);
            triangulate();
        }


        private static bool InCircle(Geometry.Point p, Geometry.Point a, Geometry.Point b, Geometry.Point c)
        {
            double DM1, DM2, DMX1, DMX2, DMY1, DMY2;
            double centerX, centerY;

            if (System.Math.Abs(a.Y - b.Y) < double.Epsilon && System.Math.Abs(b.Y - c.Y) < double.Epsilon)
            {
                return false;
            }

            if (System.Math.Abs(b.Y - a.Y) < double.Epsilon)
            {
                DM2 = -(c.X - b.X) / (c.Y - b.Y);
                DMX2 = (b.X + c.X) * 0.5;
                DMY2 = (b.Y + c.Y) * 0.5;

                centerX = (b.X + a.X) * 0.5;
                centerY = DM2 * (centerX - DMX2) + DMY2;
            }
            else if (System.Math.Abs(c.Y - b.Y) < double.Epsilon)
            {
                DM1 = -(b.X - a.X) / (b.Y - a.Y);
                DMX1 = (a.X + b.X) * 0.5;
                DMY1 = (a.Y + b.Y) * 0.5;

                centerX = (c.X + b.X) * 0.5;
                centerY = DM1 * (centerX - DMX1) + DMY1;
            }
            else
            {
                DM1 = -(b.X - a.X) / (b.Y - a.Y);
                DM2 = -(c.X - b.X) / (c.Y - b.Y);
                DMX1 = (a.X + b.X) * 0.5;
                DMX2 = (b.X + c.X) * 0.5;
                DMY1 = (a.Y + b.Y) * 0.5;
                DMY2 = (b.Y + c.Y) * 0.5;

                centerX = (DM1 * DMX1 - DM2 * DMX2 + DMY2 - DMY1) / (DM1 - DM2);
                centerY = DM1 * (centerX - DMX1) + DMY1;
            }

            double dx = b.X - centerX;
            double dy = b.Y - centerY;

            double sqR = dx * dx + dy * dy;

            dx = p.X - centerX;
            dy = p.Y - centerY;

            double sqDTR = dx * dx + dy * dy;

            return (sqDTR <= sqR);
        }

        private List<Geometry.Point> calculateSupertriangle(List<Geometry.Point> vertList)
        {

            // Find the max and min
            float dMax;
            float xmin = vertList[0].X;
            float ymin = vertList[0].Y;
            float zmin = vertList[0].Z;
            float xmax = xmin;
            float ymax = ymin;
            float zmax = zmin;
            for (int i = 1; i < vertList.Count; i++)
            {
                if (vertList[i].X < xmin) xmin = vertList[i].X;
                if (vertList[i].X > xmax) xmax = vertList[i].X;
                if (vertList[i].Y < ymin) ymin = vertList[i].Y;
                if (vertList[i].Y > ymax) ymax = vertList[i].Y;
                if (vertList[i].Z < zmin) zmin = vertList[i].Z;
                if (vertList[i].Z > zmax) zmax = vertList[i].Z;
            }

            minX = xmin;
            minY = ymin;
            minZ = zmin;
            maxX = xmax;
            maxY = ymax;
            maxZ = zmax;

            dx = xmax - xmin;
            dy = ymax - ymin;
            dz = zmax - zmin;

            if (dx > dy)
            {
                dMax = dx;
            }
            else
            {
                dMax = dy;
            }
            

            float xCent = (float)((xmax + xmin) * 0.5);
            float yCent= (float)((ymax + ymin) * 0.5);

            List<Geometry.Point> strPoint = new List<Geometry.Point> ();
            strPoint.Add(new Geometry.Point((xCent - 2 * dMax), (yCent - dMax)));
            strPoint.Add(new Geometry.Point(xCent, (yCent + 2 * dMax)));
            strPoint.Add(new Geometry.Point((xCent + 2 * dMax), (yCent - dMax)));


            return strPoint;
        }
    }
}
