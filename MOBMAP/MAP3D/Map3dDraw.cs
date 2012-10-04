using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Microsoft.WindowsMobile.DirectX.Direct3D;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Microsoft.WindowsMobile.DirectX;
using D3D = Microsoft.WindowsMobile.DirectX.Direct3D;

namespace MOBMAP.MAP
{
    public class MapDraw
    {
        #region members
        private Map _map = null;

        private Triangulation.Delaunay _triangulation;

        private VertexBuffer _vertBuffer;
        
        private CustomVertex.PositionColored[] _vertices;
        private CustomVertex.PositionColored[] _verticesPoint;
        public List<Geometry.Point> trackList;

        public bool isDbReading = false;
        public bool isConstView = true;
        private short[] indicesMesh;

        float sumX = 0.0f;
        float sumY = 0.0f;
        float sumZ = 0.0f;

        public float minX = 0;
        public float minY = 0;
        public float minZ = 0;
        public float maxX = 0;
        public float maxY = 0;
        public float maxZ = 0;
        public float dx, dy, dz;

        private int currentPosColor = Color.Black.ToArgb();
        private int pointsColor = Color.Blue.ToArgb();
 
        private float[] zValue;

        public Mesh meshTerrain;
        public Geometry.Point currentPosition; 


        public enum DrawFromStatus
        {
            DRAW_FROM_DB = 1,
            DRAW_FROM_GPS = 2,
            DRAW_SIMULATION = 3,
            NOT_DRAW_FROM = 4
        }

        public DrawFromStatus drawFromStatus = DrawFromStatus.NOT_DRAW_FROM;
        #endregion

        public MapDraw(Map map)
        {
            this.map = map;
            this.triangulation = map.parentForm.delaunayTriangulation;

        }

        #region getters & setters
        public Map map
        {
            get { return _map; }
            set { _map = value; }
        }
        public Triangulation.Delaunay triangulation
        {
            get { return _triangulation; }
            set { _triangulation = value; }
        }

        public VertexBuffer vertBuffer
        {
            get { return _vertBuffer; }
            set { _vertBuffer = value; }
        }

        public CustomVertex.PositionColored[] vertices
        {
            get { return _vertices; }
            set { _vertices = value; }
        }

        #endregion

        public void setCurrentPos(Coordinates.Coordinate projCoordinate)
        {
            currentPosition = projCoordinate.coordinatePoint;
        }
        public void setTrackData(List<Coordinates.Coordinate> projCoordinateList)
        {
            setVertices(projCoordinateList);
            setMap();       
        }

        
        public void setTriangulateData(Triangulation.Delaunay delaunayTriangulation)
        {
            this.triangulation = delaunayTriangulation;

            if (this.triangulation != null && this.triangulation.pointList != null && this.triangulation.triangleList != null
                && this.triangulation.pointList.Count != 0 && this.triangulation.triangleList.Count != 0)
            {

                setVertices(triangulation.pointList);
                setMap();
                setIndicesMesh();
                CreateMesh();

            }
        }

        private void setVerticesColor(CustomVertex.PositionColored[] vert, int color)
        {
            for(int i=0;i< vert.Length;i++)
            {
                vert[i].Color = color;
            }
        }

        public void updateVerticesColor()
        {
            if (this.vertices != null)
            {
                for (int i = 0; i < vertices.Length; i++)
                {
                    vertices[i].Color = map.parentForm.legendPanel.calculateColorFromLegend(-vertices[i].Z);
                    this.vertBuffer.SetData(this.vertices, 0, LockFlags.None);
                }
                CreateMesh();
            }
        }


        public void setVertices(List<Coordinates.Coordinate> projCoordinateList)
        {
            this.vertices = new CustomVertex.PositionColored[projCoordinateList.Count];
            this._verticesPoint = new CustomVertex.PositionColored[projCoordinateList.Count];
            
       
            zValue = new float[projCoordinateList.Count];
            int indexOfPoint = 0;
            foreach (Coordinates.Coordinate c in projCoordinateList)
            {
                indexOfPoint = projCoordinateList.IndexOf(c);

                this.vertices[indexOfPoint].X = this._verticesPoint[indexOfPoint].X = (float)c.coordinatePoint.X;
                this.vertices[indexOfPoint].Y = this._verticesPoint[indexOfPoint].Y = (float)c.coordinatePoint.Y;
                this.vertices[indexOfPoint].Z = this._verticesPoint[indexOfPoint].Z = -(float)c.coordinatePoint.Z; 

            }
            // Create a vertex buffer to hold vertices
            this.vertBuffer = new VertexBuffer(
                typeof(CustomVertex.PositionColored),   // type of the buffer
                this.vertices.Length * CustomVertex.PositionColored.StrideSize,//size                                      
                map.device,                                 //device
                Usage.WriteOnly,                        // write only
                CustomVertex.PositionColored.Format,    // format required
                Pool.SystemMemory);                     
            
            this.vertBuffer.SetData(this.vertices, 0, LockFlags.None);
        
        }
        public void setVertices(List<Geometry.Point> pointList)
        {
            this.vertices = new CustomVertex.PositionColored[pointList.Count];
            this._verticesPoint = new CustomVertex.PositionColored[pointList.Count];
         
            zValue = new float[pointList.Count];
            int indexOfPoint = 0;
            foreach (Geometry.Point p in pointList)
            {
                indexOfPoint = pointList.IndexOf(p);

                this.vertices[indexOfPoint].X = this._verticesPoint[indexOfPoint].X = (float)p.X;
                this.vertices[indexOfPoint].Y = this._verticesPoint[indexOfPoint].Y =(float)p.Y;
                zValue[indexOfPoint] = this.vertices[indexOfPoint].Z = this._verticesPoint[indexOfPoint].Z = - (float)p.Z;// *10.0f; tu
                //calculate color of vertices
                this.vertices[indexOfPoint].Color =  map.parentForm.legendPanel.calculateColorFromLegend(p.Z); //calculateVerticesColor(vertices[indexOfPoint].Z*(-10));//tu
                this._verticesPoint[indexOfPoint].Color = pointsColor;
            }

            // Create a vertex buffer to hold vertices
            this.vertBuffer = new VertexBuffer(
                typeof(CustomVertex.PositionColored),   // type of the buffer
                vertices.Length*CustomVertex.PositionColored.StrideSize, //size
                map.device,                             // device
                Usage.WriteOnly,                        // write only
                CustomVertex.PositionColored.Format,    // format required
                Pool.SystemMemory);                    

            // Set the data in the vertex buffeR
            this.vertBuffer.SetData(this.vertices, 0, LockFlags.None);
        }

      
        public void setIndicesMesh()
        {

            this.indicesMesh = new short[3 * triangulation.triangleList.Count];//mesh
            int indx = 0;

            foreach (Geometry.Triangle tr in triangulation.triangleList)
            {
                this.indicesMesh[indx] = (short)tr.indexP1;
                this.indicesMesh[indx + 1] = (short)tr.indexP2;
                this.indicesMesh[indx + 2] = (short)tr.indexP3;
                indx += 3;
            }
        }



       
        private void CreateMesh()
        {
            AttributeRange attributeRange = new AttributeRange();

            meshTerrain = new Mesh(indicesMesh.Length / 3, vertices.Length, MeshFlags.SystemMemory, CustomVertex.PositionColored.Format, map.device);
            attributeRange.AttributeId = 0;
            attributeRange.FaceStart = 0;
            attributeRange.FaceCount = indicesMesh.Length / 3;
            attributeRange.VertexStart = 0;
            attributeRange.VertexCount = vertices.Length;

            meshTerrain.VertexBuffer.SetData(vertices, 0, LockFlags.None);
            meshTerrain.IndexBuffer.SetData(indicesMesh, 0, LockFlags.None);
            meshTerrain.SetAttributeTable(new AttributeRange[] { attributeRange });

        }

        public void setCurrentPosition(CustomVertex.PositionColored[] vert)
        {
            if (vert != null)
            {
                int vertCount = vert.Length;
                sumX = 0.0f;
                sumY = 0.0f;
                sumZ = 0.0f;

                foreach (CustomVertex.PositionColored v in vert)
                {
                    sumX += v.X;
                    sumY += v.Y;
                    sumZ += v.Z;
                }

                if (isDbReading)
                {
                    map.mapView.xPos = -sumX / vertCount;
                    map.mapView.yPos = -sumY / vertCount;
                    map.mapView.zPos = -sumZ / vertCount;
                }
                else if (isConstView)//view after reading map without translation
                {
                    map.mapView.xPos = -vert[vertCount - 1].X;
                    map.mapView.yPos = -vert[vertCount - 1].Y;
                    map.mapView.zPos = vert[vertCount - 1].Z;
                }
            }
        }

        public void setMapView(CustomVertex.PositionColored[] Vertex)
        {
            if (Vertex!=null && Vertex.Length>0)
            {
                float xmin = Vertex[0].X;
                float ymin = Vertex[0].Y;
                float zmin = Vertex[0].Z;
                float xmax = xmin;
                float ymax = ymin;
                float zmax = zmin;
                for (int i = 1; i < Vertex.Length; i++)
                {
                    if (Vertex[i].X < xmin) xmin = Vertex[i].X;
                    if (Vertex[i].X > xmax) xmax = Vertex[i].X;
                    if (Vertex[i].Y < ymin) ymin = Vertex[i].Y;
                    if (Vertex[i].Y > ymax) ymax = Vertex[i].Y;
                    if (Vertex[i].Z < zmin) zmin = Vertex[i].Z;
                    if (Vertex[i].Z > zmax) zmax = Vertex[i].Z;
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
                float dmax = (dx > dy) ? dx : dy;

                float xmid = (float)((xmax + xmin) * 0.5);
                float ymid = (float)((ymax + ymin) * 0.5);

                map.mapView.deltaX = (float)(xmax - (dx * 0.5));
                map.mapView.deltaY = (float)(ymax - (dy * 0.5));
                map.mapView.deltaZ = dx * 5.0f;

                map.mapView.cameraPosition = new Vector3(0, 0, map.mapView.deltaZ);
                map.mapView.cameraTarget = new Vector3(0, 0, 0);

                map.mapView.zNear = 0;
                map.mapView.zFar = 14000000;//triangulation.maxZ+300;

                map.mapView.setCamera();
                map.mapView.setProjection();

                map.mapUserControl.setStepZ(map.mapView.deltaZ);
            }
        }

        public void draw()
        {
            switch (map.parentForm.drawStatus)
            {
                case Form1.DrawStatus.DRAW_POINTS:
                    {
                        //draw frame
                        drawFrame();
                        //draw point
                        drawTrackPoint();
                    } break;
                case Form1.DrawStatus.DRAW_TERRAIN_3D:
                    {
                        if (meshTerrain != null && meshTerrain.VertexBuffer != null 
                            && meshTerrain.IndexBuffer != null)
                        {
                            //draw frame
                            drawFrame();
                            //draw terrain
                            drawTerrain3D();
                        
                        }
                    } break;
                case Form1.DrawStatus.DRAW_TERRAIN_3D_POINTS:
                    {
                        if (meshTerrain != null && meshTerrain.VertexBuffer != null
                            && meshTerrain.IndexBuffer != null)
                        {
                            //draw frame
                            drawFrame();
                            //draw terrain 3D
                            drawTerrain3D();
                            //draw points
                            drawTrackPoint();
                        }
                    } break;
                case Form1.DrawStatus.NOT_DRAW:
                    break;
                }

            }

        private void drawTerrain3D()
        {
            int numSubSets = meshTerrain.GetAttributeTable().Length;
            for (int i = 0; i < numSubSets; ++i)
            {
                meshTerrain.DrawSubset(i);
            }
        }

        
        private void drawFrame()
        {
        
            CustomVertex.PositionColored[] frameVertices = new CustomVertex.PositionColored[8];

            frameVertices[0].X = minX - (dx * 0.5f);
            frameVertices[0].Y = minY - (dy * 0.5f);
            frameVertices[0].Z = maxZ;
            frameVertices[0].Color = Color.Black.ToArgb();

            frameVertices[1].X = minX - (dx * 0.5f);
            frameVertices[1].Y = maxY + (dy * 0.5f);
            frameVertices[1].Z = maxZ;
            frameVertices[1].Color = Color.Black.ToArgb();

            frameVertices[2].X = minX - (dx * 0.5f);
            frameVertices[2].Y = maxY + (dy * 0.5f);
            frameVertices[2].Z = maxZ;
            frameVertices[2].Color = Color.Navy.ToArgb();

            frameVertices[3].X = maxX + (dx * 0.5f);
            frameVertices[3].Y = maxY + (dy * 0.5f);
            frameVertices[3].Z = maxZ;
            frameVertices[3].Color = Color.Navy.ToArgb();

            frameVertices[4].X = maxX + (dx * 0.5f);
            frameVertices[4].Y = maxY + (dy * 0.5f);
            frameVertices[4].Z = maxZ;
            frameVertices[4].Color = Color.Black.ToArgb();

            frameVertices[5].X = maxX + (dx * 0.5f);
            frameVertices[5].Y = minY - (dy * 0.5f);
            frameVertices[5].Z = maxZ;
            frameVertices[5].Color = Color.Black.ToArgb();

            frameVertices[6].X = maxX + (dx * 0.5f);
            frameVertices[6].Y = minY - (dy * 0.5f);
            frameVertices[6].Z = maxZ;
            frameVertices[6].Color = Color.Red.ToArgb();

            frameVertices[7].X = minX - (dx * 0.5f);
            frameVertices[7].Y = minY - (dy * 0.5f);
            frameVertices[7].Z = maxZ;
            frameVertices[7].Color = Color.Red.ToArgb();


            // Create a vertex buffer to hold vertices
            VertexBuffer frameVertBuffer = new VertexBuffer(
                typeof(CustomVertex.PositionColored),   // type of the buffer
                frameVertices.Length * CustomVertex.PositionColored.StrideSize, //size
                map.device,                             // device
                Usage.WriteOnly,                        // write only
                CustomVertex.PositionColored.Format,    // format required
                Pool.SystemMemory);

            // Set the data in the vertex buffer to our triangles
            frameVertBuffer.SetData(frameVertices, 0, LockFlags.None);

            map.device.SetStreamSource(0, frameVertBuffer, 0);
            map.device.DrawPrimitives(PrimitiveType.LineList, 0, 4);            

        }
        

        private void drawTrack()
        {
            //draw track

            this.vertBuffer.SetData(this.vertices, 0, LockFlags.None);
            map.device.SetStreamSource(0, this.vertBuffer, 0);
            
            short[] trackIndices = new short[vertices.Length];
            for (int i = 0; i < vertices.Length; i++)
            {
                trackIndices[i] = (short)i;
            }

            IndexBuffer trackIndexBuffer = new IndexBuffer(map.device, trackIndices.Length * CustomVertex.PositionColored.StrideSize, Usage.WriteOnly, Pool.SystemMemory, true);
            trackIndexBuffer.SetData(trackIndices, 0, LockFlags.None);

            map.device.Indices = trackIndexBuffer;

            map.device.DrawIndexedPrimitives(PrimitiveType.LineStrip, 0, 0, vertices.Length, 0, vertices.Length - 1);
        }

        private void drawTrackPoint()
        { 
            this.vertBuffer.SetData(this._verticesPoint, 0, LockFlags.None);

            map.device.SetStreamSource(0, this.vertBuffer, 0);
            map.device.DrawPrimitives(PrimitiveType.PointList, 0, _verticesPoint.Length); 
        
        }

        public void setMap()
        {
            if (vertices != null)
            {
                map.mapUserControl.resetMap();
                setMapView(vertices);
                setCurrentPosition(vertices);
            }
        }

        private void drawCurrentPos(Geometry.Point p)
        {
            CustomVertex.PositionColored[] currentPosVertices = new CustomVertex.PositionColored[1];

            currentPosVertices[0].X = p.X;
            currentPosVertices[0].Y = p.Y;
            currentPosVertices[0].Z = p.Z;
            currentPosVertices[0].Color = currentPosColor;

            // Create a vertex buffer to hold vertices
            VertexBuffer currentPosVertBuffer = new VertexBuffer(
                typeof(CustomVertex.PositionColored),   // type of the buffer
                currentPosVertices.Length * CustomVertex.PositionColored.StrideSize, //size
                map.device,                             // device
                Usage.WriteOnly,                        // write only
                CustomVertex.PositionColored.Format,    // format required
                Pool.SystemMemory);

            // Set the data in the vertex buffer to our triangles
            currentPosVertBuffer.SetData(currentPosVertices, 0, LockFlags.None);

            map.device.SetStreamSource(0, currentPosVertBuffer, 0);
            map.device.DrawPrimitives(PrimitiveType.PointList, 0, 1);            

        }
    }
}
