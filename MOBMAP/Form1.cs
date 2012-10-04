﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.WindowsMobile.Samples.Location;
using System.Threading;
using Microsoft.WindowsMobile.DirectX;
using System.Net;
using System.Globalization;

namespace MOBMAP
{
    public partial class Form1 : Form
    {
        #region members
        //gpsConnector - check operation system and existing gps device, 
        //execute operation on gps data 
        private GPS.GpsConnector gpsConnector = null;

        //events
        private delegate void UpdateDelegate();
        
        //database handler
        private Database.Database.IDatabase _db;

        private GPS.Position<GpsPosition> _gpsPositionList;
        private MapGoogle.MapGoogle mapGoogle;
        private Coordinates.CoordinateSystem _coordinates;
        private MAP.MapSimulation mapSimulation;
        private Triangulation.DelaunayEventChanged _delaunayTriangulation;
        private Triangulation.DelaunayListEventListener delaunayListener;
        private Thread simulationThread;
        public enum DrawStatus
        {
            DRAW_TERRAIN_3D = 1,
            DRAW_POINTS = 2,
            DRAW_TERRAIN_3D_POINTS = 3,
            NOT_DRAW = 4
            
        }

        public enum GpsStatus
        {
            GPS_OPEN = 1,
            GPS_CLOSE = 2
        }

        public enum D3dRenderStatus
        {
            D3D_RENDER =1,
            D3D_NOT_RENDER=2
        }

        public enum MapStatus
        {
            MAP_VISIBLE = 1,
            TABS_VISIBLE = 2
        }

        public enum LegendSatus
        {
            LEGEND_VISIBLE = 1,
            LEGEND_NOT_VISIBLE=2
        }

        public enum MouseGoogleMapSatus
        {
            MOUSE_DOWN = 1,
            MOUSE_UP = 2,
            MOUSE_MOVE = 3,
            NOT_MOUSE
        }

        public DrawStatus drawStatus = DrawStatus.DRAW_TERRAIN_3D;
        public GpsStatus gpsStatus = GpsStatus.GPS_CLOSE;
        public D3dRenderStatus d3dRenderStatus = D3dRenderStatus.D3D_NOT_RENDER;
        public MapStatus mapStatus = MapStatus.MAP_VISIBLE;
        public LegendSatus legendStatus = LegendSatus.LEGEND_NOT_VISIBLE;
        public MouseGoogleMapSatus mouseGoogleMapStatus = MouseGoogleMapSatus.NOT_MOUSE;


        Coordinates.Coordinate projCoordMD;
        Coordinates.Coordinate geoCoordMD;
        Coordinates.Coordinate projCoordMU;
        Coordinates.Coordinate geoCoordMU;
     
        #endregion



        #region constructor

        public Form1()
        {
            InitializeComponent();
            
            //take databaseHandler
            _db = Database.Database.getDatabaseHandler();
            
            //if database doesn't exist initialize database
            if (!_db.hasDatabase)
            {
                _db.initDatabase();
            }
            
         
            setCBoxTrackID();
            mapGoogle = new MOBMAP.MapGoogle.MapGoogle(this.pBoxMap.Width, this.pBoxMap.Height);
        }

        
        #endregion
        
        #region getters & setters
        public MapGoogle.MapGoogle gMap
        {
            get { return mapGoogle; }
        }

        public MAP.Map map 
        {
            get { return map1; }
            set { map1 = value; }
        }

        public Database.Database.IDatabase db
        {
            get { return _db; }
            set { _db = value; }
        }

        public Coordinates.CoordinateSystem coordinates
        {
            get { return _coordinates; }
            set { _coordinates = value; }
        }
        public GPS.Position<GpsPosition> gpsPositionList
        {
            get { return _gpsPositionList; }
            set { _gpsPositionList = value; }
        }

        public Triangulation.DelaunayEventChanged delaunayTriangulation
        {
            get { return _delaunayTriangulation; }
            set { _delaunayTriangulation = value; }
        }

        public UI.LegendPanel legendPanel
        {
            get { return this.PnLegend; }
        }
        #endregion

        #region Form events

        private void Form1_Load(object sender, EventArgs e)
        {
            //initialize map
            map.dxInit(this);
        }

        private void Form1_Closing(object sender, CancelEventArgs e)
        {
            //if gps is running close gps
            if (gpsConnector != null)
                gpsConnector.close();

            if (coordinates != null)
                coordinates.close();
            if (delaunayListener != null)
                delaunayListener.Detach();
            //close map
            map.dxClose();
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
      
        }

        private void Form1_Deactivate(object sender, EventArgs e)
        {
       
        }

        
        #endregion


        #region mItMenu events

        private void mItExit_Click(object sender, EventArgs e)
        {
            try
            {
                timerCoordinates.Enabled = false;
                timerPositionSave.Enabled = false;
                timerSatelliteView.Enabled = false;
                if (coordinates != null)
                    coordinates.close();
                if (delaunayListener != null)
                    delaunayListener.Detach();
                //if gps is running close gps
                if (gpsConnector != null)
                    gpsConnector.close();

                //close map component and dispose map members
                map1.dxClose();

                //close window
                this.Close();
                this.Dispose();
                Application.Exit();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ex"+ex.Message);
            }
        }

        //start gps
        private void mItGpsStart_Click(object sender, EventArgs e)
        {
            map.mapDraw.isDbReading = false;
            if (coordinates != null)
                coordinates.close();
            if (delaunayListener != null)
                delaunayListener.Detach();
            coordinates = new Coordinates.CoordinateSystem(this);
            delaunayTriangulation = new MOBMAP.Triangulation.DelaunayEventChanged();
            delaunayListener = new MOBMAP.Triangulation.DelaunayListEventListener(this, delaunayTriangulation);
            map.mapDraw.drawFromStatus = MOBMAP.MAP.MapDraw.DrawFromStatus.DRAW_FROM_GPS;
            mapGoogle = new MOBMAP.MapGoogle.MapGoogle(this.pBoxMap.Width, this.pBoxMap.Height);

            //create gps connection
            gpsPositionList = new MOBMAP.GPS.Position<GpsPosition>(this);
            timerCoordinates.Enabled = true;
            timerPositionSave.Enabled = true;
            timerSatelliteView.Enabled = true;
            coordinates = new Coordinates.CoordinateSystem(this);
            gpsConnector = new GPS.GpsConnector(this);
            gpsConnector.isClosingGps = false;
            mItGpsStart.Enabled = false;
            mItGpsStop.Enabled = true;

        }
        //stop gps
        private void mItGpsStop_Click(object sender, EventArgs e)
        {
            gpsConnector.isClosingGps = true;
            timerCoordinates.Enabled = false;
            timerPositionSave.Enabled = false;
            timerSatelliteView.Enabled = false;
            map.mapDraw.drawFromStatus = MOBMAP.MAP.MapDraw.DrawFromStatus.NOT_DRAW_FROM;
            //close coordinates system
            if (coordinates != null)
                coordinates.close();
            if (delaunayListener != null)
                delaunayListener.Detach();
            //close gps connection
            if (gpsConnector != null)
                gpsConnector.close();
            gpsConnector = null;
            //clear data in form
            clearForm();

            mItGpsStart.Enabled = true;
            mItGpsStop.Enabled = false;

        }
        #endregion


        #region mItMap events

        //switch view between map and tabs with gps info
        private void mItMap_Click(object sender, EventArgs e)
        {

              if (mapStatus == MapStatus.MAP_VISIBLE)
              {
                  setVisibleImButtons(false);
                  tabControl1.Visible = true;
                  mapStatus = MapStatus.TABS_VISIBLE;
                  pLegend.Visible = false;
                  legendStatus = LegendSatus.LEGEND_NOT_VISIBLE;
              
                  d3dRenderStatus = D3dRenderStatus.D3D_NOT_RENDER;
                  mItMap.Text = "MAP";
                  if(gpsStatus==GpsStatus.GPS_OPEN)
                      timerSatelliteView.Enabled = true;
                  else
                      timerSatelliteView.Enabled = false;
              }
              else
              {

                  setVisibleImButtons(true);
                  tabControl1.Visible = false;
                  mapStatus = MapStatus.MAP_VISIBLE;
                  pLegend.Visible = false;
                  legendStatus = LegendSatus.LEGEND_NOT_VISIBLE;
         
                  mItMap.Text = "PROPERTIES";
                  if(drawStatus!= DrawStatus.NOT_DRAW)
                    d3dRenderStatus = D3dRenderStatus.D3D_RENDER;
                  timerSatelliteView.Enabled = false;
              }

        }

        #endregion

        #region additional methods

        private void setTrackData(int trackId)
        {
            this.coordinates.geoCoordinates.AddRange(db.readTrackData(trackId));
            this.mapSimulation.setSimulationData(coordinates.projCoordinates);
            this.mapGoogle.setCoordinates(coordinates.geoCoordinates);
            
        }
        //update data in form components
        public void updateForm(GpsPosition position)
        {
            if(mapStatus == MapStatus.TABS_VISIBLE && gpsStatus==GpsStatus.GPS_OPEN)
            Invoke((UpdateDelegate)delegate()
            {
                if (position.LatitudeValid)
                {
                    lLatitudeDegVal.Text = position.LatitudeInDegreesMinutesSeconds.Degrees.ToString() + "°";
                    lLatitudeMinVal.Text = position.LatitudeInDegreesMinutesSeconds.Minutes.ToString() + "'";
                    lLatitudeSekVal.Text = position.LatitudeInDegreesMinutesSeconds.Seconds.ToString() + "\"";
                }
                if (position.LongitudeValid)
                {
                    lLongitudeDegVal.Text = position.LongitudeInDegreesMinutesSeconds.Degrees.ToString() + "°";
                    lLongitudeMinVal.Text = position.LongitudeInDegreesMinutesSeconds.Minutes.ToString() + "'";
                    lLongitudeSekVal.Text = position.LongitudeInDegreesMinutesSeconds.Seconds.ToString() + "\"";
                }
                if (position.SeaLevelAltitudeValid)
                    lAltitudeVal.Text = position.SeaLevelAltitude.ToString();
                if (position.TimeValid)
                {
                    lTimeHVal.Text = position.Time.TimeOfDay.Hours.ToString() +"h";
                    lTimeMVal.Text = position.Time.TimeOfDay.Minutes.ToString() +"m";
                    lTimeSVal.Text = position.Time.TimeOfDay.Seconds.ToString() +"s";
                    lDateVal.Text = position.Time.ToShortDateString();

                }
                if (position.SpeedValid)
                    lSpeedVal.Text = knotToKm(position.Speed).ToString();
                
                lLatitudeDegVal.Invalidate();
                lLatitudeMinVal.Invalidate();
                lLatitudeSekVal.Invalidate();
                lLongitudeDegVal.Invalidate();
                lLongitudeMinVal.Invalidate();
                lLongitudeSekVal.Invalidate();
                lAltitudeVal.Invalidate();
                lTimeHVal.Invalidate();
                lTimeMVal.Invalidate();
                lTimeSVal.Invalidate();
                lDateVal.Invalidate();
                lSpeedVal.Invalidate();
               
                satelliteSignalVisualization1.Invalidate();
                satelliteSignalVisualization1.Update();
            });
        }
        //clear data in form components
        public void clearForm()
        {
            Invoke((UpdateDelegate)delegate()
            {
                lLatitudeDegVal.Text = "";
                lLatitudeDegVal.Invalidate();
                lLatitudeMinVal.Text = "";
                lLatitudeMinVal.Invalidate();
                lLatitudeSekVal.Text = "";
                lLatitudeSekVal.Invalidate();
                lLongitudeDegVal.Text = "";
                lLongitudeDegVal.Invalidate();
                lLongitudeMinVal.Text = "";
                lLongitudeMinVal.Invalidate();
                lLongitudeSekVal.Text = "";
                lLongitudeSekVal.Invalidate();
                lAltitudeVal.Text = "";
                lAltitudeVal.Invalidate();
                lTimeHVal.Text = "";
                lTimeHVal.Invalidate();
                lTimeMVal.Text = "";
                lTimeMVal.Invalidate();
                lTimeSVal.Text = "";
                lTimeSVal.Invalidate();
                lDateVal.Text = "";
                lDateVal.Invalidate();
                lSpeedVal.Text = "";
                lSpeedVal.Invalidate();
                satelliteSignalVisualization1.Invalidate();
                satelliteSignalVisualization1.Update();
            });
        }
        //set list of satellite to display on satelliteSignalVisualization
        public void setSatelliteSignalVisualization(List<Satellite> satelliteList)
        {
            satelliteSignalVisualization1.satelliteData = satelliteList;         
        }

        public void setCBoxTrackID()
        {
            cBoxTrackID.Items.Clear();
            _db.readTrackIDs();

            foreach (int id in _db.trackIdList)
            {
                cBoxTrackID.Items.Add(id);
            }
        }

        #endregion

        private void buttLeft_Click(object sender, EventArgs e)
        {
            map.mapUserControl.moveLeft();
        }

        private void buttRight_Click(object sender, EventArgs e)
        {
            map.mapUserControl.moveRight();
        }

        private void buttUp_Click(object sender, EventArgs e)
        {
            map.mapUserControl.moveUp();
        }

        private void buttDown_Click(object sender, EventArgs e)
        {
            map.mapUserControl.moveDown();
        }

        private void buttZoomIn_Click(object sender, EventArgs e)
        {
            map.mapUserControl.moveTowards();
        }

        private void buttZoomOut_Click(object sender, EventArgs e)
        {
            map.mapUserControl.moveAway();
        }

        private void cBoxTrackID_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
      
        private void buttOpenTrack_Click(object sender, EventArgs e)
        {
            if(coordinates!=null)
                coordinates.close();

            if (delaunayListener != null)
                delaunayListener.Detach();

            map.mapDraw.drawFromStatus = MOBMAP.MAP.MapDraw.DrawFromStatus.DRAW_FROM_DB;
            map.mapDraw.isDbReading = true;
            coordinates = new Coordinates.CoordinateSystem(this);
            delaunayTriangulation = new MOBMAP.Triangulation.DelaunayEventChanged();
            delaunayListener = new MOBMAP.Triangulation.DelaunayListEventListener(this, delaunayTriangulation);
            mapSimulation = new MOBMAP.MAP.MapSimulation(this.map);
            mapGoogle = new MOBMAP.MapGoogle.MapGoogle(this.pBoxMap.Width, this.pBoxMap.Height);

            if (cBoxTrackID.SelectedItem != null)
            {
                setTrackData((int)cBoxTrackID.SelectedItem);
                
            }
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (coordinates != null && gpsPositionList!=null && gpsPositionList.geoCoordinateList.Count>2)
                gpsPositionList.sendCoordinates();

        }

        private void timerPositionSave_Tick(object sender, EventArgs e)
        {
            if (gpsPositionList != null && gpsPositionList.Count > 2)
            {
                this.db.addTrackData(gpsPositionList); 
            } 
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            Coordinates.Coordinate projCoord = new MOBMAP.Coordinates.Coordinate(new Geometry.Point(e.X,e.Y),false);
            Vector3 position = new Vector3(0,0,0);
            position.Project(map.device.Viewport, map.device.Transform.Projection, map.device.Transform.View, map.device.Transform.World);
            position.X = e.X;
            position.Y = e.Y;
            position.Unproject(map.device.Viewport, map.device.Transform.Projection, map.device.Transform.View, map.device.Transform.World);
           
        }

        private void buttLocalization_Click(object sender, EventArgs e)
        {
            map.mapDraw.setMap();
        }

        private void buttRotZ1_Click(object sender, EventArgs e)
        {
            map.mapUserControl.zRotationPlus();
        }

        private void buttRotZ2_Click(object sender, EventArgs e)
        {
            map.mapUserControl.zRotationMinus();
        }

        private void buttRotY1_Click(object sender, EventArgs e)
        {
            map.mapUserControl.yRotationPlus();
        }

        private void buttRotY2_Click(object sender, EventArgs e)
        {
            map.mapUserControl.yRotationMinus();
        }

        private void buttRotX1_Click(object sender, EventArgs e)
        {
            map.mapUserControl.xRotationPlus();
        }

        private void buttRotX2_Click(object sender, EventArgs e)
        {
            map.mapUserControl.xRotationMinus();
        }


        private void chBoxDrawTrack_CheckStateChanged(object sender, EventArgs e)
        {
            setDrawStatus();
        }

        private void chBoxDrawTerrain_CheckStateChanged(object sender, EventArgs e)
        {
            setDrawStatus();
        }

        private void chBoxDrawPoints_CheckStateChanged(object sender, EventArgs e)
        {
            setDrawStatus();
        }
       
        
        private void setDrawStatus()
        {
            if (chBoxDrawTerrain3D.Checked && chBoxDrawPoints.Checked)
            {
                drawStatus = DrawStatus.DRAW_TERRAIN_3D_POINTS;
            }
            else if (chBoxDrawTerrain3D.Checked)
            {
                drawStatus = DrawStatus.DRAW_TERRAIN_3D;
            }
            else if (chBoxDrawPoints.Checked)
            {
                drawStatus = DrawStatus.DRAW_POINTS;
            }
            else
            {
                drawStatus = DrawStatus.NOT_DRAW;
            }
        }

        private void timerSatelliteView_Tick(object sender, EventArgs e)
        {
            if(gpsConnector!=null && gpsConnector.satView!=null)
                setSatelliteSignalVisualization(gpsConnector.satView.getSatelliteList());
        }

        private void setVisibleImButtons(bool isVisible)
        {
            buttImSimulation.Visible = isVisible;
            buttImLegend.Visible = isVisible;
            buttImLocalization.Visible = isVisible;
            buttImMoveDown.Visible = isVisible;
            buttImMoveIn.Visible = isVisible;
            buttImMoveLeft.Visible = isVisible;
            buttImMoveOut.Visible = isVisible;
            buttImMoveRight.Visible = isVisible;
            buttImMoveUp.Visible = isVisible;
            buttImRotXMin.Visible = isVisible;
            buttImRotXPlus.Visible = isVisible;
            buttImRotYLeft.Visible = isVisible;
            buttImRotYRigh.Visible = isVisible;
            buttImRotZLeft.Visible = isVisible;
            buttImRotZRight.Visible = isVisible;
        }

        private void buttImLocalization_Click(object sender, EventArgs e)
        {
            map.mapDraw.setMap();
        }

        private void buttImMoveIn_Click(object sender, EventArgs e)
        {
            map.mapUserControl.moveTowards();
        }

        private void buttImMoveOut_Click(object sender, EventArgs e)
        {
            map.mapUserControl.moveAway();
        }

        private void buttImMoveUp_Click(object sender, EventArgs e)
        {
            map.mapUserControl.moveUp();
        }

        private void buttImMoveDown_Click(object sender, EventArgs e)
        {
            map.mapUserControl.moveDown();
        }

        private void buttImMoveLeft_Click(object sender, EventArgs e)
        {
            map.mapUserControl.moveLeft();
        }

        private void buttImMoveRight_Click(object sender, EventArgs e)
        {
            map.mapUserControl.moveRight();
        }

        private void buttImRotXPlus_Click(object sender, EventArgs e)
        {
            map.mapUserControl.xRotationPlus();
        }

        private void buttImRotXMin_Click(object sender, EventArgs e)
        {
            map.mapUserControl.xRotationMinus();
        }

        private void buttImRotYLeft_Click(object sender, EventArgs e)
        {
            map.mapUserControl.yRotationPlus();
        }

        private void buttImRotYRigh_Click(object sender, EventArgs e)
        {
            map.mapUserControl.yRotationMinus();
        }

        private void buttImRotZLeft_Click(object sender, EventArgs e)
        {
            map.mapUserControl.zRotationMinus();
        }

        private void buttImRotZRight_Click(object sender, EventArgs e)
        {
            map.mapUserControl.zRotationPlus();
        }

        private void buttImLegend_Click(object sender, EventArgs e)
        {
            if (legendStatus==LegendSatus.LEGEND_VISIBLE)
            {
                pLegend.Visible = false;
                legendStatus = LegendSatus.LEGEND_NOT_VISIBLE;
            }
            else if (legendStatus == LegendSatus.LEGEND_NOT_VISIBLE)
            {
                pLegend.Visible = true;
                legendStatus = LegendSatus.LEGEND_VISIBLE;
            }
        }

        public float knotToKm(float knots)
        {
            float knotTOkmph = 0.539957f;
            float kmph = (float)(knots * knotTOkmph);
            return kmph;
        }

        private void buttRemoveTrack_Click(object sender, EventArgs e)
        {
            if (cBoxTrackID.SelectedItem != null)
            {
                db.removeTrack((int)cBoxTrackID.SelectedItem);
                cBoxTrackID.Items.Remove(cBoxTrackID.SelectedItem);
                cBoxTrackID.Refresh();
            }
        }

        private void buttImSimulation_Click(object sender, EventArgs e)
        {
            if (map.mapDraw.drawFromStatus.Equals(MOBMAP.MAP.MapDraw.DrawFromStatus.DRAW_FROM_DB))
            {
               
                simulationThread = new Thread(new ThreadStart((mapSimulation.simulate)));
                simulationThread.Start();
            }
        }

        private void mItSimulStart_Click(object sender, EventArgs e)
        {
            buttImSimulation_Click(sender, e);
        }

        private void mItSimulStop_Click(object sender, EventArgs e)
        {
            if (map.mapDraw.drawFromStatus.Equals(MOBMAP.MAP.MapDraw.DrawFromStatus.DRAW_SIMULATION))
            {
                simulationThread.Abort();
                map.mapDraw.drawFromStatus = MOBMAP.MAP.MapDraw.DrawFromStatus.DRAW_FROM_DB;
                map.mapDraw.setTriangulateData(this.delaunayTriangulation);
            }
        }

        private void buttShowMap_Click(object sender, EventArgs e)
        {

            if (this.coordinates != null && this.coordinates.geoCoordinates.Count > 0)
            {
                this.mapGoogle.setCoordinates(coordinates.geoCoordinates);

                tBarMapZoom.Value = 10;
                
                // show image in picturebox
                try
                {
                    this.pBoxMap.Image = mapGoogle.showMap();
                }
                catch (Exception ex)
                {
                    this.pBoxMap.Image = Properties.Resources.mapGoogleImg;
                }
            }
            else
            {
                this.pBoxMap.Image = Properties.Resources.mapGoogleImg;
            }
        }

        

        private void tBarMapZoom_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                mapGoogle.mapProperties.zoomLevel = tBarMapZoom.Value;
                this.pBoxMap.Image = mapGoogle.showMap();
            }
            catch (Exception ex)
            {
                this.pBoxMap.Image = Properties.Resources.mapGoogleImg;
            }
        }

    
        private void butImGMapMoveUp_Click(object sender, EventArgs e)
        {
            try
            {
                mapGoogle.mapViewport.moveMap(-20, 0, mapGoogle.mapProperties.zoomLevel);
                this.pBoxMap.Image = mapGoogle.showMap();
            }
            catch (Exception ex)
            {
                this.pBoxMap.Image = Properties.Resources.mapGoogleImg;
            }
       
        }

        private void buttImGMapMoveDown_Click(object sender, EventArgs e)
        {
            try
            {
                mapGoogle.mapViewport.moveMap(20, 0, mapGoogle.mapProperties.zoomLevel);
                this.pBoxMap.Image = mapGoogle.showMap();
            }
            catch (Exception ex)
            {
                this.pBoxMap.Image = Properties.Resources.mapGoogleImg;
            }
        }

        private void buttImGMapMoveLeft_Click(object sender, EventArgs e)
        {
            try
            {
                mapGoogle.mapViewport.moveMap(0, -20, mapGoogle.mapProperties.zoomLevel);
                this.pBoxMap.Image = mapGoogle.showMap();
            }
            catch (Exception ex)
            {
                this.pBoxMap.Image = Properties.Resources.mapGoogleImg;
            }
        }

        private void buttImGMapMoveRight_Click(object sender, EventArgs e)
        {
            try
            {
                mapGoogle.mapViewport.moveMap(0, 20, mapGoogle.mapProperties.zoomLevel);
                this.pBoxMap.Image = mapGoogle.showMap();
            }
            catch (Exception ex)
            {
                this.pBoxMap.Image = Properties.Resources.mapGoogleImg;
            }
        }

        private void buttImGMapTerrain_Click(object sender, EventArgs e)
        {
            try
            {
                mapGoogle.mapProperties.mapTypes = MOBMAP.MapGoogle.MapGoogleProperties.MapTypes.TERRAIN;//.mapViewport.moveMap(0, 20, mapGoogle.mapProperties.zoomLevel);
                this.pBoxMap.Image = mapGoogle.showMap();
            }
            catch (Exception ex)
            {
                this.pBoxMap.Image = Properties.Resources.mapGoogleImg;
            }
        }

        private void buttImGMapStellite_Click(object sender, EventArgs e)
        {
            try
            {
                mapGoogle.mapProperties.mapTypes = MOBMAP.MapGoogle.MapGoogleProperties.MapTypes.SATATELLITE;//.mapViewport.moveMap(0, 20, mapGoogle.mapProperties.zoomLevel);
                this.pBoxMap.Image = mapGoogle.showMap();
            }
            catch (Exception ex)
            {
                this.pBoxMap.Image = Properties.Resources.mapGoogleImg;
            }
        }

        private void buttImGMapRoad_Click(object sender, EventArgs e)
        {
            try
            {
                mapGoogle.mapProperties.mapTypes = MOBMAP.MapGoogle.MapGoogleProperties.MapTypes.NONE;//.mapViewport.moveMap(0, 20, mapGoogle.mapProperties.zoomLevel);
                this.pBoxMap.Image = mapGoogle.showMap();
            }
            catch (Exception ex)
            {
                this.pBoxMap.Image = Properties.Resources.mapGoogleImg;
            }
        }

        private void buttImGMapHybrid_Click(object sender, EventArgs e)
        {
            try
            {
                mapGoogle.mapProperties.mapTypes = MOBMAP.MapGoogle.MapGoogleProperties.MapTypes.HYBRID;//.mapViewport.moveMap(0, 20, mapGoogle.mapProperties.zoomLevel);
                this.pBoxMap.Image = mapGoogle.showMap();
            }
            catch (Exception ex)
            {
                this.pBoxMap.Image = Properties.Resources.mapGoogleImg;
            }
        }

        private void buttRedrawMap_Click(object sender, EventArgs e)
        {
            map.mapDraw.updateVerticesColor();
        }

  
       
    }

}