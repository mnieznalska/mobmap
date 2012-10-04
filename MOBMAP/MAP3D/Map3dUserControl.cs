using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

using Microsoft.WindowsMobile.DirectX;
using Microsoft.WindowsMobile.DirectX.Direct3D;

namespace MOBMAP.MAP
{
    public class MapUserControl
    {
        #region members
        
        private Map _map = null;
        //move step
        private float _step = 0.2f;
        private float _stepZ = 0.2f;

        private float _angleZ = 0.0f;// -3.08999753f;
        private float _angleY = 0.0f;//-0.329999983f;
        private float _angleX = 0.0f;//-3.29999733f;

        #endregion


        public MapUserControl(Map map)
        {
            this.map = map;
        }

        #region getters & setters
        public Map map
        {
            get { return _map; }
            set { _map = value; }
        }
        public float step
        {
            get { return _step; }
            set { _step = value; }
        }
        public float stepZ
        {
            get { return _stepZ; }
            set { _stepZ = value; }
        }
        public float angleZ
        {
            get { return _angleZ; }
            set { _angleZ = value; }
        }
        public float angleY
        {
            get { return _angleY; }
            set { _angleY = value; }
        }
        public float angleX
        {
            get { return _angleX; }
            set { _angleX = value; }
        }
        #endregion

        public void setStepZ(float deltaZ)
        {
            this.stepZ = (float)(deltaZ * 0.5);
        }

        public void resetMap()
        {
            map.mapDraw.isConstView = true;
            if (!map.mapDraw.drawFromStatus.Equals(MAP.MapDraw.DrawFromStatus.DRAW_SIMULATION))
            {
                angleZ = 0.0f;//3.08999753f;
                angleY = (float)Math.PI;//0.329999983f;
                angleX = 0.0f;//3.29999733f;

                map.mapView.xPos = 0.0f;
                map.mapView.yPos = 0.0f;
                map.mapView.zPos = 0.0f;

                map.mapView.cameraX = 0.0f;
                map.mapView.cameraY = 0.0f;
            }
        }



        public void moveLeft()
        { 
            map.mapView.cameraX -= (float)(map.mapView.deltaZ / 30.0f);
            map.mapView.cameraPosition = new Vector3(map.mapView.cameraX, map.mapView.cameraY, map.mapView.deltaZ);
            map.mapView.cameraTarget = new Vector3(map.mapView.cameraX, map.mapView.cameraY, 0.0f);
            map.mapView.setCamera();
        }

        public void moveRight()
        {
            map.mapView.cameraX += (float)(map.mapView.deltaZ / 30.0f);
            map.mapView.cameraPosition = new Vector3(map.mapView.cameraX, map.mapView.cameraY, map.mapView.deltaZ);
            map.mapView.cameraTarget = new Vector3(map.mapView.cameraX, map.mapView.cameraY, 0.0f);
            map.mapView.setCamera();
        }

        public void moveUp()
        {
            map.mapView.cameraY -= (float)(map.mapView.deltaZ / 30.0f);
            map.mapView.cameraPosition = new Vector3(map.mapView.cameraX, map.mapView.cameraY, map.mapView.deltaZ);
            map.mapView.cameraTarget = new Vector3(map.mapView.cameraX, map.mapView.cameraY, 0.0f);
            map.mapView.setCamera();
            map.mapView.yPos += 5*step;
        }

        public void moveDown()
        {
            map.mapView.cameraY += (float)(map.mapView.deltaZ / 30.0f);
            map.mapView.cameraPosition = new Vector3(map.mapView.cameraX, map.mapView.cameraY, map.mapView.deltaZ);
            map.mapView.cameraTarget = new Vector3(map.mapView.cameraX, map.mapView.cameraY, 0.0f);
            map.mapView.setCamera();
            map.mapView.yPos -= 5*step;
        }

        public void moveTowards()
        {
            map.mapDraw.isConstView = false;
            map.mapView.deltaZ -= (float)(map.mapView.deltaZ * 0.3);
            map.mapView.cameraPosition = new Vector3(map.mapView.cameraX, map.mapView.cameraY, map.mapView.deltaZ);
            map.mapView.setCamera();
        }

        public void moveAway()
        {
            map.mapDraw.isConstView = false;
            map.mapView.deltaZ += (float)(map.mapView.deltaZ * 0.5);
            map.mapView.cameraPosition = new Vector3(map.mapView.cameraX, map.mapView.cameraY, map.mapView.deltaZ);
            map.mapView.setCamera();
        }

        public void zRotationPlus()
        {
            //if(angleZ<=(Math.PI*(11/6)))
                angleZ += (float)(Math.PI/9);
        }
        public void zRotationMinus()
        {
            //if (angleZ >= (float)(Math.PI / 6))
                angleZ -= (float)(Math.PI/9);
        }

        public void yRotationPlus()
        { 
            angleY += (float)(Math.PI / 9);
        }
        public void yRotationMinus()
        { 
            angleY -= (float)(Math.PI / 9);
        }
        public void xRotationPlus()
        { 
            angleX += (float)(Math.PI / 9);
        }
        public void xRotationMinus()
        {
            angleX -= (float)(Math.PI / 9);
        }

    }
}
