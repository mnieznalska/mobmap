using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Microsoft.WindowsMobile.DirectX;
using Microsoft.WindowsMobile.DirectX.Direct3D;
using System.Drawing;

namespace MOBMAP.MAP
{
    public class MapView
    {
        #region members
        private Map _map = null;
        private Viewport _viewport;
        float aspectRatio;

        public Matrix projection;
        //device color
        private Color _deviceColor = Color.White;      

        // position of the map - translation
        private float _xPos = 0.0f;
        private float _yPos = 0.0f;
        private float _zPos = 0.0f;

        float _zNear = 1.0f;
        float _zFar = 100.0f;

        //position of camera
        private Vector3 _cameraPosition = new Vector3(0.0f, 0.0f, 100.0f);//new Vector3(5571043.0f, 2232348.0f, -100.0f);
        private Vector3 _cameraTarget = new Vector3(0.0f, 0.0f, 0.0f);
        private Vector3 _cameraUp = new Vector3(0.0f, 1.0f, 0.0f);

        public float deltaX = 0.0f;
        public float deltaY = 0.0f;
        public float deltaZ = 0.0f;

        public float cameraX = 0.0f;
        public float cameraY = 0.0f;

        public float radius = 1;
        public float moveDist = 1f;

        private float hRadians;
        private float vRadians;

        
        #endregion

        #region constructor
        public MapView(Map map)
        {
            this.map = map;
            this.viewport = new Viewport();
            
        }
        #endregion

        #region getters & setters
        public Map map
        {
            get { return _map; }
            set { _map = value; }
        }
        public Viewport viewport
        {
            get { return _viewport; }
            set { _viewport = value; }
        }
        public Color deviceColor
        {
            get { return _deviceColor; }
            set { _deviceColor = value; }
        }
        public float xPos
        {
            get { return _xPos; }
            set { _xPos = value; }
        }
        public float yPos
        {
            get { return _yPos; }
            set { _yPos = value; }
        }
        public float zPos
        {
            get { return _zPos; }
            set { _zPos = value; }
        }
        public float zNear
        {
            get { return _zNear; }
            set { _zNear = value; }
        }
        public float zFar
        {
            get { return _zFar; }
            set { _zFar = value; }
        }
        public Vector3 cameraPosition
        {
            get { return _cameraPosition; }
            set { _cameraPosition = value; }
        }
        public Vector3 cameraTarget
        {
            get { return _cameraTarget; }
            set { _cameraTarget = value; }
        }
        public Vector3 cameraUp
        {
            get { return _cameraUp; }
            set { _cameraUp = value; }
        }
        #endregion


        #region methods
        
        public void setCamera()
        {
            // Add the camera to our world and point it at the triangle
            map.device.Transform.View = Matrix.LookAtLH(
                this.cameraPosition,
                this.cameraTarget,
                this.cameraUp
                );
        }

        public void setProjection()
        {
            aspectRatio = 
         ((float)map.device.PresentationParameters.BackBufferWidth) /
         map.device.PresentationParameters.BackBufferHeight;
            // Set up the projection for our world

                projection =  Matrix.PerspectiveFovLH(
                (float)Math.PI / 2,     // field of view
                aspectRatio,                   // aspect ratio
                zNear,//21707299.0f,                   // near Z plane
                zFar//22486541.0f                  // far Z plane
                );

                map.device.Transform.Projection = projection;
        }

        #endregion
    }
}
