using System.Drawing;
namespace MOBMAP
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mainMenu1;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.mItMenu = new System.Windows.Forms.MenuItem();
            this.mItSimulation = new System.Windows.Forms.MenuItem();
            this.mItSimulStart = new System.Windows.Forms.MenuItem();
            this.mItSimulStop = new System.Windows.Forms.MenuItem();
            this.mItGps = new System.Windows.Forms.MenuItem();
            this.mItGpsStart = new System.Windows.Forms.MenuItem();
            this.mItGpsStop = new System.Windows.Forms.MenuItem();
            this.mItExit = new System.Windows.Forms.MenuItem();
            this.mItMap = new System.Windows.Forms.MenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPTest = new System.Windows.Forms.TabPage();
            this.buttRemoveTrack = new System.Windows.Forms.Button();
            this.panOptions = new System.Windows.Forms.Panel();
            this.chBoxDrawPoints = new System.Windows.Forms.CheckBox();
            this.chBoxDrawTerrain3D = new System.Windows.Forms.CheckBox();
            this.lOptions = new System.Windows.Forms.Label();
            this.buttOpenTrack = new System.Windows.Forms.Button();
            this.lTrackID = new System.Windows.Forms.Label();
            this.cBoxTrackID = new System.Windows.Forms.ComboBox();
            this.map1 = new MOBMAP.MAP.Map();
            this.tabPSatellite = new System.Windows.Forms.TabPage();
            this.pDetails = new System.Windows.Forms.Panel();
            this.lTimeSVal = new System.Windows.Forms.Label();
            this.lTimeMVal = new System.Windows.Forms.Label();
            this.lDateVal = new System.Windows.Forms.Label();
            this.lDate = new System.Windows.Forms.Label();
            this.lLongitudeSekVal = new System.Windows.Forms.Label();
            this.lLongitudeMinVal = new System.Windows.Forms.Label();
            this.lLatitudeSekVal = new System.Windows.Forms.Label();
            this.lLatitudeMinVal = new System.Windows.Forms.Label();
            this.lSpeedVal = new System.Windows.Forms.Label();
            this.lSpeed = new System.Windows.Forms.Label();
            this.lTimeHVal = new System.Windows.Forms.Label();
            this.lAltitudeVal = new System.Windows.Forms.Label();
            this.lLongitudeDegVal = new System.Windows.Forms.Label();
            this.lLatitudeDegVal = new System.Windows.Forms.Label();
            this.lTime = new System.Windows.Forms.Label();
            this.lAltitude = new System.Windows.Forms.Label();
            this.lLongitude = new System.Windows.Forms.Label();
            this.lLatitude = new System.Windows.Forms.Label();
            this.satelliteSignalVisualization1 = new SatelliteSignalVisualization.SatelliteSignalVisualization();
            this.tabPGoogleMap = new System.Windows.Forms.TabPage();
            this.buttImGMapTerrain = new MOBMAP.UI.ButtonImage();
            this.buttImGMapHybrid = new MOBMAP.UI.ButtonImage();
            this.buttImGMapStellite = new MOBMAP.UI.ButtonImage();
            this.buttImGMapRoad = new MOBMAP.UI.ButtonImage();
            this.buttImGMapMoveRight = new MOBMAP.UI.ButtonImage();
            this.buttImGMapMoveLeft = new MOBMAP.UI.ButtonImage();
            this.buttImGMapMoveDown = new MOBMAP.UI.ButtonImage();
            this.butImGMapMoveUp = new MOBMAP.UI.ButtonImage();
            this.tBarMapZoom = new System.Windows.Forms.TrackBar();
            this.buttShowMap = new System.Windows.Forms.Button();
            this.pBoxMap = new System.Windows.Forms.PictureBox();
            this.timerCoordinates = new System.Windows.Forms.Timer();
            this.timerPositionSave = new System.Windows.Forms.Timer();
            this.timerSatelliteView = new System.Windows.Forms.Timer();
            this.pLegend = new System.Windows.Forms.Panel();
            this.buttRedrawMap = new System.Windows.Forms.Button();
            this.PnLegend = new MOBMAP.UI.LegendPanel();
            this.buttImSimulation = new MOBMAP.UI.ButtonImage();
            this.buttImLegend = new MOBMAP.UI.ButtonImage();
            this.buttImMoveOut = new MOBMAP.UI.ButtonImage();
            this.buttImMoveIn = new MOBMAP.UI.ButtonImage();
            this.buttImMoveUp = new MOBMAP.UI.ButtonImage();
            this.buttImMoveDown = new MOBMAP.UI.ButtonImage();
            this.buttImMoveLeft = new MOBMAP.UI.ButtonImage();
            this.buttImMoveRight = new MOBMAP.UI.ButtonImage();
            this.buttImRotXPlus = new MOBMAP.UI.ButtonImage();
            this.buttImRotXMin = new MOBMAP.UI.ButtonImage();
            this.buttImRotYLeft = new MOBMAP.UI.ButtonImage();
            this.buttImRotYRigh = new MOBMAP.UI.ButtonImage();
            this.buttImRotZLeft = new MOBMAP.UI.ButtonImage();
            this.buttImRotZRight = new MOBMAP.UI.ButtonImage();
            this.buttImLocalization = new MOBMAP.UI.ButtonImage();
            this.tabControl1.SuspendLayout();
            this.tabPTest.SuspendLayout();
            this.panOptions.SuspendLayout();
            this.tabPSatellite.SuspendLayout();
            this.pDetails.SuspendLayout();
            this.tabPGoogleMap.SuspendLayout();
            this.pLegend.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.mItMenu);
            this.mainMenu1.MenuItems.Add(this.mItMap);
            // 
            // mItMenu
            // 
            this.mItMenu.MenuItems.Add(this.mItSimulation);
            this.mItMenu.MenuItems.Add(this.mItGps);
            this.mItMenu.MenuItems.Add(this.mItExit);
            this.mItMenu.Text = "MENU";
            // 
            // mItSimulation
            // 
            this.mItSimulation.MenuItems.Add(this.mItSimulStart);
            this.mItSimulation.MenuItems.Add(this.mItSimulStop);
            this.mItSimulation.Text = "SIMULATION";
            // 
            // mItSimulStart
            // 
            this.mItSimulStart.Text = "START";
            this.mItSimulStart.Click += new System.EventHandler(this.mItSimulStart_Click);
            // 
            // mItSimulStop
            // 
            this.mItSimulStop.Text = "STOP";
            this.mItSimulStop.Click += new System.EventHandler(this.mItSimulStop_Click);
            // 
            // mItGps
            // 
            this.mItGps.MenuItems.Add(this.mItGpsStart);
            this.mItGps.MenuItems.Add(this.mItGpsStop);
            this.mItGps.Text = "GPS";
            // 
            // mItGpsStart
            // 
            this.mItGpsStart.Text = "START";
            this.mItGpsStart.Click += new System.EventHandler(this.mItGpsStart_Click);
            // 
            // mItGpsStop
            // 
            this.mItGpsStop.Enabled = false;
            this.mItGpsStop.Text = "STOP";
            this.mItGpsStop.Click += new System.EventHandler(this.mItGpsStop_Click);
            // 
            // mItExit
            // 
            this.mItExit.Text = "EXIT";
            this.mItExit.Click += new System.EventHandler(this.mItExit_Click);
            // 
            // mItMap
            // 
            this.mItMap.Text = "PROPERTIES";
            this.mItMap.Click += new System.EventHandler(this.mItMap_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPTest);
            this.tabControl1.Controls.Add(this.tabPSatellite);
            this.tabControl1.Controls.Add(this.tabPGoogleMap);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(240, 268);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.Tag = "";
            this.tabControl1.Visible = false;
            // 
            // tabPTest
            // 
            this.tabPTest.BackColor = System.Drawing.SystemColors.Info;
            this.tabPTest.Controls.Add(this.buttRemoveTrack);
            this.tabPTest.Controls.Add(this.panOptions);
            this.tabPTest.Controls.Add(this.buttOpenTrack);
            this.tabPTest.Controls.Add(this.lTrackID);
            this.tabPTest.Controls.Add(this.cBoxTrackID);
            this.tabPTest.Controls.Add(this.map1);
            this.tabPTest.Location = new System.Drawing.Point(0, 0);
            this.tabPTest.Name = "tabPTest";
            this.tabPTest.Size = new System.Drawing.Size(240, 245);
            this.tabPTest.Text = "Track";
            // 
            // buttRemoveTrack
            // 
            this.buttRemoveTrack.Location = new System.Drawing.Point(73, 27);
            this.buttRemoveTrack.Name = "buttRemoveTrack";
            this.buttRemoveTrack.Size = new System.Drawing.Size(64, 22);
            this.buttRemoveTrack.TabIndex = 6;
            this.buttRemoveTrack.Text = "Remove";
            this.buttRemoveTrack.Click += new System.EventHandler(this.buttRemoveTrack_Click);
            // 
            // panOptions
            // 
            this.panOptions.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.panOptions.Controls.Add(this.chBoxDrawPoints);
            this.panOptions.Controls.Add(this.chBoxDrawTerrain3D);
            this.panOptions.Controls.Add(this.lOptions);
            this.panOptions.Location = new System.Drawing.Point(3, 52);
            this.panOptions.Name = "panOptions";
            this.panOptions.Size = new System.Drawing.Size(234, 110);
            // 
            // chBoxDrawPoints
            // 
            this.chBoxDrawPoints.Location = new System.Drawing.Point(2, 24);
            this.chBoxDrawPoints.Name = "chBoxDrawPoints";
            this.chBoxDrawPoints.Size = new System.Drawing.Size(119, 20);
            this.chBoxDrawPoints.TabIndex = 4;
            this.chBoxDrawPoints.Text = "Draw track points";
            this.chBoxDrawPoints.CheckStateChanged += new System.EventHandler(this.chBoxDrawPoints_CheckStateChanged);
            // 
            // chBoxDrawTerrain3D
            // 
            this.chBoxDrawTerrain3D.Checked = true;
            this.chBoxDrawTerrain3D.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chBoxDrawTerrain3D.Location = new System.Drawing.Point(2, 46);
            this.chBoxDrawTerrain3D.Name = "chBoxDrawTerrain3D";
            this.chBoxDrawTerrain3D.Size = new System.Drawing.Size(119, 20);
            this.chBoxDrawTerrain3D.TabIndex = 3;
            this.chBoxDrawTerrain3D.Text = "Draw terrain 3D";
            this.chBoxDrawTerrain3D.CheckStateChanged += new System.EventHandler(this.chBoxDrawTerrain_CheckStateChanged);
            // 
            // lOptions
            // 
            this.lOptions.Location = new System.Drawing.Point(3, 3);
            this.lOptions.Name = "lOptions";
            this.lOptions.Size = new System.Drawing.Size(98, 17);
            this.lOptions.Text = "Draw options:";
            // 
            // buttOpenTrack
            // 
            this.buttOpenTrack.Location = new System.Drawing.Point(8, 27);
            this.buttOpenTrack.Name = "buttOpenTrack";
            this.buttOpenTrack.Size = new System.Drawing.Size(54, 22);
            this.buttOpenTrack.TabIndex = 3;
            this.buttOpenTrack.Text = "Open";
            this.buttOpenTrack.Click += new System.EventHandler(this.buttOpenTrack_Click);
            // 
            // lTrackID
            // 
            this.lTrackID.Location = new System.Drawing.Point(8, 5);
            this.lTrackID.Name = "lTrackID";
            this.lTrackID.Size = new System.Drawing.Size(59, 18);
            this.lTrackID.Text = "Track ID:";
            // 
            // cBoxTrackID
            // 
            this.cBoxTrackID.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.cBoxTrackID.Location = new System.Drawing.Point(73, 1);
            this.cBoxTrackID.Name = "cBoxTrackID";
            this.cBoxTrackID.Size = new System.Drawing.Size(100, 22);
            this.cBoxTrackID.TabIndex = 1;
            this.cBoxTrackID.SelectedIndexChanged += new System.EventHandler(this.cBoxTrackID_SelectedIndexChanged);
            // 
            // map1
            // 
            this.map1.Location = new System.Drawing.Point(216, 251);
            this.map1.Name = "map1";
            this.map1.Size = new System.Drawing.Size(24, 14);
            this.map1.TabIndex = 0;
            // 
            // tabPSatellite
            // 
            this.tabPSatellite.BackColor = System.Drawing.SystemColors.Info;
            this.tabPSatellite.Controls.Add(this.pDetails);
            this.tabPSatellite.Controls.Add(this.satelliteSignalVisualization1);
            this.tabPSatellite.Location = new System.Drawing.Point(0, 0);
            this.tabPSatellite.Name = "tabPSatellite";
            this.tabPSatellite.Size = new System.Drawing.Size(232, 242);
            this.tabPSatellite.Text = "Satellite";
            // 
            // pDetails
            // 
            this.pDetails.BackColor = System.Drawing.SystemColors.Desktop;
            this.pDetails.Controls.Add(this.lTimeSVal);
            this.pDetails.Controls.Add(this.lTimeMVal);
            this.pDetails.Controls.Add(this.lDateVal);
            this.pDetails.Controls.Add(this.lDate);
            this.pDetails.Controls.Add(this.lLongitudeSekVal);
            this.pDetails.Controls.Add(this.lLongitudeMinVal);
            this.pDetails.Controls.Add(this.lLatitudeSekVal);
            this.pDetails.Controls.Add(this.lLatitudeMinVal);
            this.pDetails.Controls.Add(this.lSpeedVal);
            this.pDetails.Controls.Add(this.lSpeed);
            this.pDetails.Controls.Add(this.lTimeHVal);
            this.pDetails.Controls.Add(this.lAltitudeVal);
            this.pDetails.Controls.Add(this.lLongitudeDegVal);
            this.pDetails.Controls.Add(this.lLatitudeDegVal);
            this.pDetails.Controls.Add(this.lTime);
            this.pDetails.Controls.Add(this.lAltitude);
            this.pDetails.Controls.Add(this.lLongitude);
            this.pDetails.Controls.Add(this.lLatitude);
            this.pDetails.Location = new System.Drawing.Point(2, 110);
            this.pDetails.Name = "pDetails";
            this.pDetails.Size = new System.Drawing.Size(236, 129);
            // 
            // lTimeSVal
            // 
            this.lTimeSVal.BackColor = System.Drawing.SystemColors.Control;
            this.lTimeSVal.Location = new System.Drawing.Point(181, 65);
            this.lTimeSVal.Name = "lTimeSVal";
            this.lTimeSVal.Size = new System.Drawing.Size(53, 20);
            // 
            // lTimeMVal
            // 
            this.lTimeMVal.BackColor = System.Drawing.SystemColors.Control;
            this.lTimeMVal.Location = new System.Drawing.Point(142, 65);
            this.lTimeMVal.Name = "lTimeMVal";
            this.lTimeMVal.Size = new System.Drawing.Size(38, 20);
            // 
            // lDateVal
            // 
            this.lDateVal.BackColor = System.Drawing.SystemColors.Control;
            this.lDateVal.Location = new System.Drawing.Point(103, 86);
            this.lDateVal.Name = "lDateVal";
            this.lDateVal.Size = new System.Drawing.Size(131, 20);
            // 
            // lDate
            // 
            this.lDate.BackColor = System.Drawing.SystemColors.Control;
            this.lDate.Location = new System.Drawing.Point(2, 86);
            this.lDate.Name = "lDate";
            this.lDate.Size = new System.Drawing.Size(100, 20);
            this.lDate.Text = "Date (M/d/yyyy)";
            // 
            // lLongitudeSekVal
            // 
            this.lLongitudeSekVal.BackColor = System.Drawing.SystemColors.Control;
            this.lLongitudeSekVal.Location = new System.Drawing.Point(181, 23);
            this.lLongitudeSekVal.Name = "lLongitudeSekVal";
            this.lLongitudeSekVal.Size = new System.Drawing.Size(53, 20);
            // 
            // lLongitudeMinVal
            // 
            this.lLongitudeMinVal.BackColor = System.Drawing.SystemColors.Control;
            this.lLongitudeMinVal.Location = new System.Drawing.Point(142, 23);
            this.lLongitudeMinVal.Name = "lLongitudeMinVal";
            this.lLongitudeMinVal.Size = new System.Drawing.Size(38, 20);
            // 
            // lLatitudeSekVal
            // 
            this.lLatitudeSekVal.BackColor = System.Drawing.SystemColors.Control;
            this.lLatitudeSekVal.Location = new System.Drawing.Point(181, 2);
            this.lLatitudeSekVal.Name = "lLatitudeSekVal";
            this.lLatitudeSekVal.Size = new System.Drawing.Size(53, 20);
            // 
            // lLatitudeMinVal
            // 
            this.lLatitudeMinVal.BackColor = System.Drawing.SystemColors.Control;
            this.lLatitudeMinVal.Location = new System.Drawing.Point(142, 2);
            this.lLatitudeMinVal.Name = "lLatitudeMinVal";
            this.lLatitudeMinVal.Size = new System.Drawing.Size(38, 20);
            // 
            // lSpeedVal
            // 
            this.lSpeedVal.BackColor = System.Drawing.SystemColors.Control;
            this.lSpeedVal.Location = new System.Drawing.Point(103, 107);
            this.lSpeedVal.Name = "lSpeedVal";
            this.lSpeedVal.Size = new System.Drawing.Size(131, 20);
            // 
            // lSpeed
            // 
            this.lSpeed.BackColor = System.Drawing.SystemColors.Control;
            this.lSpeed.Location = new System.Drawing.Point(2, 107);
            this.lSpeed.Name = "lSpeed";
            this.lSpeed.Size = new System.Drawing.Size(100, 20);
            this.lSpeed.Text = "Speed (km/h)";
            // 
            // lTimeHVal
            // 
            this.lTimeHVal.BackColor = System.Drawing.SystemColors.Control;
            this.lTimeHVal.Location = new System.Drawing.Point(103, 65);
            this.lTimeHVal.Name = "lTimeHVal";
            this.lTimeHVal.Size = new System.Drawing.Size(38, 20);
            // 
            // lAltitudeVal
            // 
            this.lAltitudeVal.BackColor = System.Drawing.SystemColors.Control;
            this.lAltitudeVal.Location = new System.Drawing.Point(103, 44);
            this.lAltitudeVal.Name = "lAltitudeVal";
            this.lAltitudeVal.Size = new System.Drawing.Size(131, 20);
            // 
            // lLongitudeDegVal
            // 
            this.lLongitudeDegVal.BackColor = System.Drawing.SystemColors.Control;
            this.lLongitudeDegVal.Location = new System.Drawing.Point(103, 23);
            this.lLongitudeDegVal.Name = "lLongitudeDegVal";
            this.lLongitudeDegVal.Size = new System.Drawing.Size(38, 20);
            // 
            // lLatitudeDegVal
            // 
            this.lLatitudeDegVal.BackColor = System.Drawing.SystemColors.Control;
            this.lLatitudeDegVal.Location = new System.Drawing.Point(103, 2);
            this.lLatitudeDegVal.Name = "lLatitudeDegVal";
            this.lLatitudeDegVal.Size = new System.Drawing.Size(38, 20);
            // 
            // lTime
            // 
            this.lTime.BackColor = System.Drawing.SystemColors.Control;
            this.lTime.Location = new System.Drawing.Point(2, 65);
            this.lTime.Name = "lTime";
            this.lTime.Size = new System.Drawing.Size(100, 20);
            this.lTime.Text = "Time UTC";
            // 
            // lAltitude
            // 
            this.lAltitude.BackColor = System.Drawing.SystemColors.Control;
            this.lAltitude.Location = new System.Drawing.Point(2, 44);
            this.lAltitude.Name = "lAltitude";
            this.lAltitude.Size = new System.Drawing.Size(100, 20);
            this.lAltitude.Text = "Altitude (m)";
            // 
            // lLongitude
            // 
            this.lLongitude.BackColor = System.Drawing.SystemColors.Control;
            this.lLongitude.Location = new System.Drawing.Point(2, 23);
            this.lLongitude.Name = "lLongitude";
            this.lLongitude.Size = new System.Drawing.Size(100, 20);
            this.lLongitude.Text = "Longitude ";
            // 
            // lLatitude
            // 
            this.lLatitude.BackColor = System.Drawing.SystemColors.Control;
            this.lLatitude.Location = new System.Drawing.Point(2, 2);
            this.lLatitude.Name = "lLatitude";
            this.lLatitude.Size = new System.Drawing.Size(100, 20);
            this.lLatitude.Text = "Latitude";
            // 
            // satelliteSignalVisualization1
            // 
            this.satelliteSignalVisualization1.Location = new System.Drawing.Point(2, 4);
            this.satelliteSignalVisualization1.Name = "satelliteSignalVisualization1";
            this.satelliteSignalVisualization1.Size = new System.Drawing.Size(235, 100);
            this.satelliteSignalVisualization1.TabIndex = 0;
            this.satelliteSignalVisualization1.Text = "satelliteSignalVisualization1";
            // 
            // tabPGoogleMap
            // 
            this.tabPGoogleMap.BackColor = System.Drawing.SystemColors.Info;
            this.tabPGoogleMap.Controls.Add(this.buttImGMapTerrain);
            this.tabPGoogleMap.Controls.Add(this.buttImGMapHybrid);
            this.tabPGoogleMap.Controls.Add(this.buttImGMapStellite);
            this.tabPGoogleMap.Controls.Add(this.buttImGMapRoad);
            this.tabPGoogleMap.Controls.Add(this.buttImGMapMoveRight);
            this.tabPGoogleMap.Controls.Add(this.buttImGMapMoveLeft);
            this.tabPGoogleMap.Controls.Add(this.buttImGMapMoveDown);
            this.tabPGoogleMap.Controls.Add(this.butImGMapMoveUp);
            this.tabPGoogleMap.Controls.Add(this.tBarMapZoom);
            this.tabPGoogleMap.Controls.Add(this.buttShowMap);
            this.tabPGoogleMap.Controls.Add(this.pBoxMap);
            this.tabPGoogleMap.Location = new System.Drawing.Point(0, 0);
            this.tabPGoogleMap.Name = "tabPGoogleMap";
            this.tabPGoogleMap.Size = new System.Drawing.Size(232, 242);
            this.tabPGoogleMap.Text = "Google Map";
            // 
            // buttImGMapTerrain
            // 
            this.buttImGMapTerrain.BImage = ((System.Drawing.Image)(resources.GetObject("buttImGMapTerrain.BImage")));
            this.buttImGMapTerrain.ImagePress = ((System.Drawing.Image)(resources.GetObject("buttImGMapTerrain.ImagePress")));
            this.buttImGMapTerrain.Location = new System.Drawing.Point(147, 224);
            this.buttImGMapTerrain.Name = "buttImGMapTerrain";
            this.buttImGMapTerrain.Size = new System.Drawing.Size(20, 20);
            this.buttImGMapTerrain.TabIndex = 32;
            this.buttImGMapTerrain.Click += new System.EventHandler(this.buttImGMapTerrain_Click);
            // 
            // buttImGMapHybrid
            // 
            this.buttImGMapHybrid.BImage = ((System.Drawing.Image)(resources.GetObject("buttImGMapHybrid.BImage")));
            this.buttImGMapHybrid.ImagePress = ((System.Drawing.Image)(resources.GetObject("buttImGMapHybrid.ImagePress")));
            this.buttImGMapHybrid.Location = new System.Drawing.Point(125, 224);
            this.buttImGMapHybrid.Name = "buttImGMapHybrid";
            this.buttImGMapHybrid.Size = new System.Drawing.Size(20, 20);
            this.buttImGMapHybrid.TabIndex = 31;
            this.buttImGMapHybrid.Click += new System.EventHandler(this.buttImGMapHybrid_Click);
            // 
            // buttImGMapStellite
            // 
            this.buttImGMapStellite.BImage = ((System.Drawing.Image)(resources.GetObject("buttImGMapStellite.BImage")));
            this.buttImGMapStellite.ImagePress = ((System.Drawing.Image)(resources.GetObject("buttImGMapStellite.ImagePress")));
            this.buttImGMapStellite.Location = new System.Drawing.Point(103, 224);
            this.buttImGMapStellite.Name = "buttImGMapStellite";
            this.buttImGMapStellite.Size = new System.Drawing.Size(20, 20);
            this.buttImGMapStellite.TabIndex = 30;
            this.buttImGMapStellite.Click += new System.EventHandler(this.buttImGMapStellite_Click);
            // 
            // buttImGMapRoad
            // 
            this.buttImGMapRoad.BImage = ((System.Drawing.Image)(resources.GetObject("buttImGMapRoad.BImage")));
            this.buttImGMapRoad.ImagePress = ((System.Drawing.Image)(resources.GetObject("buttImGMapRoad.ImagePress")));
            this.buttImGMapRoad.Location = new System.Drawing.Point(81, 224);
            this.buttImGMapRoad.Name = "buttImGMapRoad";
            this.buttImGMapRoad.Size = new System.Drawing.Size(20, 20);
            this.buttImGMapRoad.TabIndex = 29;
            this.buttImGMapRoad.Click += new System.EventHandler(this.buttImGMapRoad_Click);
            // 
            // buttImGMapMoveRight
            // 
            this.buttImGMapMoveRight.BImage = ((System.Drawing.Image)(resources.GetObject("buttImGMapMoveRight.BImage")));
            this.buttImGMapMoveRight.ImagePress = ((System.Drawing.Image)(resources.GetObject("buttImGMapMoveRight.ImagePress")));
            this.buttImGMapMoveRight.Location = new System.Drawing.Point(217, 95);
            this.buttImGMapMoveRight.Name = "buttImGMapMoveRight";
            this.buttImGMapMoveRight.Size = new System.Drawing.Size(20, 20);
            this.buttImGMapMoveRight.TabIndex = 27;
            this.buttImGMapMoveRight.Click += new System.EventHandler(this.buttImGMapMoveRight_Click);
            // 
            // buttImGMapMoveLeft
            // 
            this.buttImGMapMoveLeft.BImage = ((System.Drawing.Image)(resources.GetObject("buttImGMapMoveLeft.BImage")));
            this.buttImGMapMoveLeft.ImagePress = ((System.Drawing.Image)(resources.GetObject("buttImGMapMoveLeft.ImagePress")));
            this.buttImGMapMoveLeft.Location = new System.Drawing.Point(4, 95);
            this.buttImGMapMoveLeft.Name = "buttImGMapMoveLeft";
            this.buttImGMapMoveLeft.Size = new System.Drawing.Size(20, 20);
            this.buttImGMapMoveLeft.TabIndex = 27;
            this.buttImGMapMoveLeft.Click += new System.EventHandler(this.buttImGMapMoveLeft_Click);
            // 
            // buttImGMapMoveDown
            // 
            this.buttImGMapMoveDown.BImage = ((System.Drawing.Image)(resources.GetObject("buttImGMapMoveDown.BImage")));
            this.buttImGMapMoveDown.ImagePress = ((System.Drawing.Image)(resources.GetObject("buttImGMapMoveDown.ImagePress")));
            this.buttImGMapMoveDown.Location = new System.Drawing.Point(110, 183);
            this.buttImGMapMoveDown.Name = "buttImGMapMoveDown";
            this.buttImGMapMoveDown.Size = new System.Drawing.Size(20, 20);
            this.buttImGMapMoveDown.TabIndex = 27;
            this.buttImGMapMoveDown.Click += new System.EventHandler(this.buttImGMapMoveDown_Click);
            // 
            // butImGMapMoveUp
            // 
            this.butImGMapMoveUp.BImage = ((System.Drawing.Image)(resources.GetObject("butImGMapMoveUp.BImage")));
            this.butImGMapMoveUp.ImagePress = ((System.Drawing.Image)(resources.GetObject("butImGMapMoveUp.ImagePress")));
            this.butImGMapMoveUp.Location = new System.Drawing.Point(110, 2);
            this.butImGMapMoveUp.Name = "butImGMapMoveUp";
            this.butImGMapMoveUp.Size = new System.Drawing.Size(20, 20);
            this.butImGMapMoveUp.TabIndex = 12;
            this.butImGMapMoveUp.Click += new System.EventHandler(this.butImGMapMoveUp_Click);
            // 
            // tBarMapZoom
            // 
            this.tBarMapZoom.LargeChange = 1;
            this.tBarMapZoom.Location = new System.Drawing.Point(5, 205);
            this.tBarMapZoom.Maximum = 21;
            this.tBarMapZoom.Name = "tBarMapZoom";
            this.tBarMapZoom.Size = new System.Drawing.Size(228, 14);
            this.tBarMapZoom.TabIndex = 3;
            this.tBarMapZoom.Value = 10;
            this.tBarMapZoom.ValueChanged += new System.EventHandler(this.tBarMapZoom_ValueChanged);
            // 
            // buttShowMap
            // 
            this.buttShowMap.Location = new System.Drawing.Point(7, 224);
            this.buttShowMap.Name = "buttShowMap";
            this.buttShowMap.Size = new System.Drawing.Size(72, 20);
            this.buttShowMap.TabIndex = 1;
            this.buttShowMap.Text = "Show Map";
            this.buttShowMap.Click += new System.EventHandler(this.buttShowMap_Click);
            // 
            // pBoxMap
            // 
            this.pBoxMap.BackColor = System.Drawing.Color.Black;
            this.pBoxMap.Location = new System.Drawing.Point(4, 2);
            this.pBoxMap.Name = "pBoxMap";
            this.pBoxMap.Size = new System.Drawing.Size(233, 201);
            // 
            // timerCoordinates
            // 
            this.timerCoordinates.Interval = 20000;
            this.timerCoordinates.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timerPositionSave
            // 
            this.timerPositionSave.Interval = 60000;
            this.timerPositionSave.Tick += new System.EventHandler(this.timerPositionSave_Tick);
            // 
            // timerSatelliteView
            // 
            this.timerSatelliteView.Interval = 6000;
            this.timerSatelliteView.Tick += new System.EventHandler(this.timerSatelliteView_Tick);
            // 
            // pLegend
            // 
            this.pLegend.BackColor = System.Drawing.SystemColors.Info;
            this.pLegend.Controls.Add(this.buttRedrawMap);
            this.pLegend.Controls.Add(this.PnLegend);
            this.pLegend.Location = new System.Drawing.Point(160, 1);
            this.pLegend.Name = "pLegend";
            this.pLegend.Size = new System.Drawing.Size(79, 267);
            // 
            // buttRedrawMap
            // 
            this.buttRedrawMap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            this.buttRedrawMap.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Bold);
            this.buttRedrawMap.ForeColor = System.Drawing.SystemColors.Info;
            this.buttRedrawMap.Location = new System.Drawing.Point(0, 246);
            this.buttRedrawMap.Name = "buttRedrawMap";
            this.buttRedrawMap.Size = new System.Drawing.Size(79, 21);
            this.buttRedrawMap.TabIndex = 25;
            this.buttRedrawMap.Text = "Redraw";
            this.buttRedrawMap.Click += new System.EventHandler(this.buttRedrawMap_Click);
            // 
            // PnLegend
            // 
            this.PnLegend.BImage = ((System.Drawing.Image)(resources.GetObject("PnLegend.BImage")));
            this.PnLegend.Location = new System.Drawing.Point(0, 0);
            this.PnLegend.Name = "PnLegend";
            this.PnLegend.Size = new System.Drawing.Size(80, 257);
            this.PnLegend.TabIndex = 24;
            // 
            // buttImSimulation
            // 
            this.buttImSimulation.BImage = ((System.Drawing.Image)(resources.GetObject("buttImSimulation.BImage")));
            this.buttImSimulation.ImagePress = ((System.Drawing.Image)(resources.GetObject("buttImSimulation.ImagePress")));
            this.buttImSimulation.Location = new System.Drawing.Point(118, 1);
            this.buttImSimulation.Name = "buttImSimulation";
            this.buttImSimulation.Size = new System.Drawing.Size(20, 20);
            this.buttImSimulation.TabIndex = 25;
            this.buttImSimulation.Click += new System.EventHandler(this.buttImSimulation_Click);
            // 
            // buttImLegend
            // 
            this.buttImLegend.BImage = ((System.Drawing.Image)(resources.GetObject("buttImLegend.BImage")));
            this.buttImLegend.ImagePress = ((System.Drawing.Image)(resources.GetObject("buttImLegend.ImagePress")));
            this.buttImLegend.Location = new System.Drawing.Point(139, 1);
            this.buttImLegend.Name = "buttImLegend";
            this.buttImLegend.Size = new System.Drawing.Size(20, 20);
            this.buttImLegend.TabIndex = 23;
            this.buttImLegend.Click += new System.EventHandler(this.buttImLegend_Click);
            // 
            // buttImMoveOut
            // 
            this.buttImMoveOut.BImage = ((System.Drawing.Image)(resources.GetObject("buttImMoveOut.BImage")));
            this.buttImMoveOut.ImagePress = ((System.Drawing.Image)(resources.GetObject("buttImMoveOut.ImagePress")));
            this.buttImMoveOut.Location = new System.Drawing.Point(2, 22);
            this.buttImMoveOut.Name = "buttImMoveOut";
            this.buttImMoveOut.Size = new System.Drawing.Size(20, 20);
            this.buttImMoveOut.TabIndex = 10;
            this.buttImMoveOut.Click += new System.EventHandler(this.buttImMoveOut_Click);
            // 
            // buttImMoveIn
            // 
            this.buttImMoveIn.BImage = ((System.Drawing.Image)(resources.GetObject("buttImMoveIn.BImage")));
            this.buttImMoveIn.ImagePress = ((System.Drawing.Image)(resources.GetObject("buttImMoveIn.ImagePress")));
            this.buttImMoveIn.Location = new System.Drawing.Point(2, 1);
            this.buttImMoveIn.Name = "buttImMoveIn";
            this.buttImMoveIn.Size = new System.Drawing.Size(20, 20);
            this.buttImMoveIn.TabIndex = 9;
            this.buttImMoveIn.Click += new System.EventHandler(this.buttImMoveIn_Click);
            // 
            // buttImMoveUp
            // 
            this.buttImMoveUp.BImage = ((System.Drawing.Image)(resources.GetObject("buttImMoveUp.BImage")));
            this.buttImMoveUp.ImagePress = ((System.Drawing.Image)(resources.GetObject("buttImMoveUp.ImagePress")));
            this.buttImMoveUp.Location = new System.Drawing.Point(21, 205);
            this.buttImMoveUp.Name = "buttImMoveUp";
            this.buttImMoveUp.Size = new System.Drawing.Size(20, 20);
            this.buttImMoveUp.TabIndex = 11;
            this.buttImMoveUp.Click += new System.EventHandler(this.buttImMoveUp_Click);
            // 
            // buttImMoveDown
            // 
            this.buttImMoveDown.BImage = ((System.Drawing.Image)(resources.GetObject("buttImMoveDown.BImage")));
            this.buttImMoveDown.ImagePress = ((System.Drawing.Image)(resources.GetObject("buttImMoveDown.ImagePress")));
            this.buttImMoveDown.Location = new System.Drawing.Point(21, 247);
            this.buttImMoveDown.Name = "buttImMoveDown";
            this.buttImMoveDown.Size = new System.Drawing.Size(20, 20);
            this.buttImMoveDown.TabIndex = 12;
            this.buttImMoveDown.Click += new System.EventHandler(this.buttImMoveDown_Click);
            // 
            // buttImMoveLeft
            // 
            this.buttImMoveLeft.BImage = ((System.Drawing.Image)(resources.GetObject("buttImMoveLeft.BImage")));
            this.buttImMoveLeft.ImagePress = ((System.Drawing.Image)(resources.GetObject("buttImMoveLeft.ImagePress")));
            this.buttImMoveLeft.Location = new System.Drawing.Point(0, 226);
            this.buttImMoveLeft.Name = "buttImMoveLeft";
            this.buttImMoveLeft.Size = new System.Drawing.Size(20, 20);
            this.buttImMoveLeft.TabIndex = 13;
            this.buttImMoveLeft.Click += new System.EventHandler(this.buttImMoveLeft_Click);
            // 
            // buttImMoveRight
            // 
            this.buttImMoveRight.BImage = ((System.Drawing.Image)(resources.GetObject("buttImMoveRight.BImage")));
            this.buttImMoveRight.ImagePress = ((System.Drawing.Image)(resources.GetObject("buttImMoveRight.ImagePress")));
            this.buttImMoveRight.Location = new System.Drawing.Point(42, 226);
            this.buttImMoveRight.Name = "buttImMoveRight";
            this.buttImMoveRight.Size = new System.Drawing.Size(20, 20);
            this.buttImMoveRight.TabIndex = 14;
            this.buttImMoveRight.Click += new System.EventHandler(this.buttImMoveRight_Click);
            // 
            // buttImRotXPlus
            // 
            this.buttImRotXPlus.BImage = ((System.Drawing.Image)(resources.GetObject("buttImRotXPlus.BImage")));
            this.buttImRotXPlus.ImagePress = ((System.Drawing.Image)(resources.GetObject("buttImRotXPlus.ImagePress")));
            this.buttImRotXPlus.Location = new System.Drawing.Point(86, 226);
            this.buttImRotXPlus.Name = "buttImRotXPlus";
            this.buttImRotXPlus.Size = new System.Drawing.Size(20, 20);
            this.buttImRotXPlus.TabIndex = 15;
            this.buttImRotXPlus.Click += new System.EventHandler(this.buttImRotXPlus_Click);
            // 
            // buttImRotXMin
            // 
            this.buttImRotXMin.BImage = ((System.Drawing.Image)(resources.GetObject("buttImRotXMin.BImage")));
            this.buttImRotXMin.ImagePress = ((System.Drawing.Image)(resources.GetObject("buttImRotXMin.ImagePress")));
            this.buttImRotXMin.Location = new System.Drawing.Point(86, 247);
            this.buttImRotXMin.Name = "buttImRotXMin";
            this.buttImRotXMin.Size = new System.Drawing.Size(20, 20);
            this.buttImRotXMin.TabIndex = 16;
            this.buttImRotXMin.Click += new System.EventHandler(this.buttImRotXMin_Click);
            // 
            // buttImRotYLeft
            // 
            this.buttImRotYLeft.BImage = ((System.Drawing.Image)(resources.GetObject("buttImRotYLeft.BImage")));
            this.buttImRotYLeft.ImagePress = ((System.Drawing.Image)(resources.GetObject("buttImRotYLeft.ImagePress")));
            this.buttImRotYLeft.Location = new System.Drawing.Point(65, 247);
            this.buttImRotYLeft.Name = "buttImRotYLeft";
            this.buttImRotYLeft.Size = new System.Drawing.Size(20, 20);
            this.buttImRotYLeft.TabIndex = 17;
            this.buttImRotYLeft.Click += new System.EventHandler(this.buttImRotYLeft_Click);
            // 
            // buttImRotYRigh
            // 
            this.buttImRotYRigh.BImage = ((System.Drawing.Image)(resources.GetObject("buttImRotYRigh.BImage")));
            this.buttImRotYRigh.ImagePress = ((System.Drawing.Image)(resources.GetObject("buttImRotYRigh.ImagePress")));
            this.buttImRotYRigh.Location = new System.Drawing.Point(65, 226);
            this.buttImRotYRigh.Name = "buttImRotYRigh";
            this.buttImRotYRigh.Size = new System.Drawing.Size(20, 20);
            this.buttImRotYRigh.TabIndex = 18;
            this.buttImRotYRigh.Click += new System.EventHandler(this.buttImRotYRigh_Click);
            // 
            // buttImRotZLeft
            // 
            this.buttImRotZLeft.BImage = ((System.Drawing.Image)(resources.GetObject("buttImRotZLeft.BImage")));
            this.buttImRotZLeft.ImagePress = ((System.Drawing.Image)(resources.GetObject("buttImRotZLeft.ImagePress")));
            this.buttImRotZLeft.Location = new System.Drawing.Point(107, 247);
            this.buttImRotZLeft.Name = "buttImRotZLeft";
            this.buttImRotZLeft.Size = new System.Drawing.Size(20, 20);
            this.buttImRotZLeft.TabIndex = 19;
            this.buttImRotZLeft.Click += new System.EventHandler(this.buttImRotZLeft_Click);
            // 
            // buttImRotZRight
            // 
            this.buttImRotZRight.BImage = ((System.Drawing.Image)(resources.GetObject("buttImRotZRight.BImage")));
            this.buttImRotZRight.ImagePress = ((System.Drawing.Image)(resources.GetObject("buttImRotZRight.ImagePress")));
            this.buttImRotZRight.Location = new System.Drawing.Point(107, 226);
            this.buttImRotZRight.Name = "buttImRotZRight";
            this.buttImRotZRight.Size = new System.Drawing.Size(20, 20);
            this.buttImRotZRight.TabIndex = 20;
            this.buttImRotZRight.Click += new System.EventHandler(this.buttImRotZRight_Click);
            // 
            // buttImLocalization
            // 
            this.buttImLocalization.BImage = ((System.Drawing.Image)(resources.GetObject("buttImLocalization.BImage")));
            this.buttImLocalization.ImagePress = ((System.Drawing.Image)(resources.GetObject("buttImLocalization.ImagePress")));
            this.buttImLocalization.Location = new System.Drawing.Point(21, 226);
            this.buttImLocalization.Name = "buttImLocalization";
            this.buttImLocalization.Size = new System.Drawing.Size(20, 20);
            this.buttImLocalization.TabIndex = 7;
            this.buttImLocalization.Click += new System.EventHandler(this.buttImLocalization_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.buttImSimulation);
            this.Controls.Add(this.buttImLegend);
            this.Controls.Add(this.pLegend);
            this.Controls.Add(this.buttImMoveOut);
            this.Controls.Add(this.buttImMoveIn);
            this.Controls.Add(this.buttImMoveUp);
            this.Controls.Add(this.buttImMoveDown);
            this.Controls.Add(this.buttImMoveLeft);
            this.Controls.Add(this.buttImMoveRight);
            this.Controls.Add(this.buttImRotXPlus);
            this.Controls.Add(this.buttImRotXMin);
            this.Controls.Add(this.buttImRotYLeft);
            this.Controls.Add(this.buttImRotYRigh);
            this.Controls.Add(this.buttImRotZLeft);
            this.Controls.Add(this.buttImRotZRight);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.buttImLocalization);
            this.Menu = this.mainMenu1;
            this.Name = "Form1";
            this.Text = "MOBMAP";
            this.Deactivate += new System.EventHandler(this.Form1_Deactivate);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Activated += new System.EventHandler(this.Form1_Activated);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.Form1_Closing);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.tabControl1.ResumeLayout(false);
            this.tabPTest.ResumeLayout(false);
            this.panOptions.ResumeLayout(false);
            this.tabPSatellite.ResumeLayout(false);
            this.pDetails.ResumeLayout(false);
            this.tabPGoogleMap.ResumeLayout(false);
            this.pLegend.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuItem mItMenu;
        private System.Windows.Forms.MenuItem mItMap;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPSatellite;
        private System.Windows.Forms.TabPage tabPTest;
        private System.Windows.Forms.MenuItem mItExit;
        private System.Windows.Forms.MenuItem mItGps;
        private System.Windows.Forms.MenuItem mItGpsStart;
        private System.Windows.Forms.MenuItem mItGpsStop;
        private System.Windows.Forms.MenuItem mItSimulation;
        private MOBMAP.MAP.Map map1;
        private System.Windows.Forms.Button buttOpenTrack;
        private System.Windows.Forms.Label lTrackID;
        private System.Windows.Forms.ComboBox cBoxTrackID;
        private System.Windows.Forms.Timer timerCoordinates;
        private System.Windows.Forms.Timer timerPositionSave;
        private System.Windows.Forms.Panel panOptions;
        private System.Windows.Forms.CheckBox chBoxDrawTerrain3D;
        private System.Windows.Forms.Label lOptions;
        private System.Windows.Forms.CheckBox chBoxDrawPoints;
        private System.Windows.Forms.Timer timerSatelliteView;
        private SatelliteSignalVisualization.SatelliteSignalVisualization satelliteSignalVisualization1;
        private System.Windows.Forms.Label lTimeSVal;
        private System.Windows.Forms.Label lTimeMVal;
        private System.Windows.Forms.Label lDateVal;
        private System.Windows.Forms.Label lDate;
        private System.Windows.Forms.Label lLongitudeSekVal;
        private System.Windows.Forms.Label lLongitudeMinVal;
        private System.Windows.Forms.Label lLatitudeSekVal;
        private System.Windows.Forms.Label lLatitudeMinVal;
        private System.Windows.Forms.Label lSpeedVal;
        private System.Windows.Forms.Label lSpeed;
        private System.Windows.Forms.Label lTimeHVal;
        private System.Windows.Forms.Label lAltitudeVal;
        private System.Windows.Forms.Label lLongitudeDegVal;
        private System.Windows.Forms.Label lLatitudeDegVal;
        private System.Windows.Forms.Label lTime;
        private System.Windows.Forms.Label lAltitude;
        private System.Windows.Forms.Label lLongitude;
        private System.Windows.Forms.Label lLatitude;
        public System.Windows.Forms.Panel pDetails;
        private MOBMAP.UI.ButtonImage buttImLocalization;
        private MOBMAP.UI.ButtonImage buttImMoveIn;
        private MOBMAP.UI.ButtonImage buttImMoveOut;
        private MOBMAP.UI.ButtonImage buttImRotXPlus;
        private MOBMAP.UI.ButtonImage buttImMoveRight;
        private MOBMAP.UI.ButtonImage buttImMoveLeft;
        private MOBMAP.UI.ButtonImage buttImMoveDown;
        private MOBMAP.UI.ButtonImage buttImMoveUp;
        private MOBMAP.UI.ButtonImage buttImRotZRight;
        private MOBMAP.UI.ButtonImage buttImRotZLeft;
        private MOBMAP.UI.ButtonImage buttImRotYRigh;
        private MOBMAP.UI.ButtonImage buttImRotYLeft;
        private MOBMAP.UI.ButtonImage buttImRotXMin;
        private System.Windows.Forms.Panel pLegend;
        private MOBMAP.UI.ButtonImage buttImLegend;
        private System.Windows.Forms.Button buttRemoveTrack;
        private MOBMAP.UI.ButtonImage buttImSimulation;
        private System.Windows.Forms.MenuItem mItSimulStart;
        private System.Windows.Forms.MenuItem mItSimulStop;
        private System.Windows.Forms.TabPage tabPGoogleMap;
        private System.Windows.Forms.PictureBox pBoxMap;
        private System.Windows.Forms.Button buttShowMap;
        private System.Windows.Forms.TrackBar tBarMapZoom;
        private MOBMAP.UI.ButtonImage butImGMapMoveUp;
        private MOBMAP.UI.ButtonImage buttImGMapMoveLeft;
        private MOBMAP.UI.ButtonImage buttImGMapMoveDown;
        private MOBMAP.UI.ButtonImage buttImGMapMoveRight;
        private MOBMAP.UI.ButtonImage buttImGMapRoad;
        private MOBMAP.UI.ButtonImage buttImGMapHybrid;
        private MOBMAP.UI.ButtonImage buttImGMapStellite;
        private MOBMAP.UI.ButtonImage buttImGMapTerrain;
        private MOBMAP.UI.LegendPanel PnLegend;
        private System.Windows.Forms.Button buttRedrawMap;
        
    }
}

