using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Microsoft.WindowsMobile.Samples.Location;
using System.Threading;
using System.Windows.Forms;

namespace MOBMAP.GPS
{
    public class GpsConnector
    {
        #region members
        //parent form - on this form will be executing update on change location
        public Form1 parentForm = null;

        //gpsEvents contains events using in GpsConnector
        private GpsEvents gpsEvents = null;

        //gps handler to check existing gps device and operation system(gps intermediate driver)
        private Hardware.Hardware.IGps _gps;

        //gps
        private Gps gps;
        private GpsDeviceState deviceState = null;

        //list of position pepare to be save to database
        private List<GpsPosition> _tmpPositionList;

        //contain data to display on satelliteSignalVisualization in parent form
        public SatelliteView satView = null;

        //triangulation
        //private Triangulation.Delaunay _triangulation;

        public bool isClosingGps = false;
        //events
        private delegate void DrawDelegate();
        #endregion


        #region constructor

        public GpsConnector(Form1 parentForm)
        {
            //signed parent to gpsConnector
            this.parentForm = parentForm;

            //initialize gps hardware handler
            _gps = Hardware.Hardware.GetGpsHandler();

            //initialize list to contain position info
            _tmpPositionList = new List<GpsPosition>();
            //initialize satelliteView to contain satellite info
            satView = new SatelliteView();

            //if gps hardware exist and gpsIntermediateDriver exist
            //initialize gps connection and events
            if (_gps.hasGPS)
            {
                gps = new Gps();

                gpsEvents = new GpsEvents(this);
                
                if (!gps.Opened)
                {
                    gps.Open();
                    gpsEvents.newLocationReceived += new EventHandler<LocationChangedEventArgs>(gpsEvents.Form1_NewLocationReceived);
       
                    gps.LocationChanged += new LocationChangedEventHandler(gpsEvents.gps_LocationChanged);
                    
                }
            }
        }

        #endregion

        #region getters & setters
        #endregion


        //open gps
        public void openGps()
        {
            if (!gps.Opened)
            {
                gps.Open();
            }
            parentForm.gpsStatus = Form1.GpsStatus.GPS_OPEN;
        }

        //close gps
        public void close()
        {
            isClosingGps = true;
            parentForm.gpsStatus = Form1.GpsStatus.GPS_CLOSE;
            if (gps.Opened)
            {         
                gpsEvents.newLocationReceived -= gpsEvents.Form1_NewLocationReceived;
                gps.LocationChanged -= gpsEvents.gps_LocationChanged;
                gps.Close();
 
            }
        }

        //retrive gps position to save into database and display in parent form
        public void retrivePosition(GpsPosition position)
        {
            try
            {
                //if satellite info is avaliable  
                if (position.SatellitesInSolutionValid && position.SatelliteCountValid && position.SatellitesInViewValid)
                {
                    if (position.PositionDilutionOfPrecisionValid && position.PositionDilutionOfPrecision<7)
                    {
                        //add position to position list
                        parentForm.gpsPositionList.Add(position);
                    }
                    //set satellite data in satView
                    satView.setSatellite(position);
                    //display on form components
                    parentForm.updateForm(position);
                }
            }catch (Exception ex)
            {
                MessageBox.Show("mess retr" + ex.Message);
            }


        }
    }
}
