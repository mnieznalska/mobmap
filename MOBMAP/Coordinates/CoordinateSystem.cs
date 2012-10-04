using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Microsoft.WindowsMobile.Samples.Location;
using System.Windows.Forms;

namespace MOBMAP.Coordinates
{
    public class CoordinateSystem
    {
        #region members
        //contains geographic coordinates
                
        private CoordinateListEventChanged <Coordinate> _geoCoordinates = null;
        private CoordinateListEventListener _coordinatesListener;
        private List<Coordinate> _projCoordinates = null;
        private Form _parentForm = null;
        #endregion

        #region constructors
        public CoordinateSystem(Form1 parentForm)
        {
            this.parentForm = parentForm;
            projCoordinates = new List<Coordinate>();
            geoCoordinates = new CoordinateListEventChanged <Coordinate>();
            coordinatesListener = new CoordinateListEventListener(parentForm, geoCoordinates, projCoordinates);
        }
        #endregion

        #region getters & setters
        public Form parentForm
        {
            get { return _parentForm; }
            set { _parentForm = value; }
        }
        public CoordinateListEventChanged <Coordinate> geoCoordinates
        {
            get { return _geoCoordinates; }
            set { _geoCoordinates = value; }
        }
        public List<Coordinate> projCoordinates
        {
            get { return _projCoordinates; }
            set { _projCoordinates = value; }
        }
        private CoordinateListEventListener coordinatesListener
        {
            get { return _coordinatesListener; }
            set { _coordinatesListener = value; }
        }
        #endregion


        public void close()
        {
            coordinatesListener.Detach();
        }
    }
}
