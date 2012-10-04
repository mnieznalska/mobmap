using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Microsoft.WindowsMobile.Samples.Location;
using System.Windows.Forms;

namespace MOBMAP.GPS
{
    //class contains gps events 
    public class GpsEvents: EventArgs
    {
        #region members
        //if new location is received
        public event EventHandler<LocationChangedEventArgs> newLocationReceived;
        
        //element that used gps events 
        private GpsConnector gpsConnector;

        #endregion

        #region constructor

        public GpsEvents(GpsConnector gpsConnector)
        {
            this.gpsConnector = gpsConnector;
        }
        #endregion


        #region gps events
        //execute if current location is changed
        public void gps_LocationChanged(object sender, LocationChangedEventArgs args)
        {
            if(!gpsConnector.isClosingGps)
                onNewLocationReceiveEvent(args);
        }

        protected virtual void onNewLocationReceiveEvent(LocationChangedEventArgs args)
        {
            if (!gpsConnector.isClosingGps)
            if (newLocationReceived != null)
            {
                newLocationReceived(this, args);
            }
        }

        //execute if location is changed to update form component and save data to database
        public void Form1_NewLocationReceived(object sender, LocationChangedEventArgs e)
        {
            if (!gpsConnector.isClosingGps)
            {
                GpsPosition position = e.Position;
                try
                {
                    //check gps connection - if gps not open then open gps
                    gpsConnector.openGps();
                    
                    //retrive position to save gps data to database
                    gpsConnector.retrivePosition(position);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("new loc"+ex.Message);
                }
            }
        }
        #endregion


    }
}
