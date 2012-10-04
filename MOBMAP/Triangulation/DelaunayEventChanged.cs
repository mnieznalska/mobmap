using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MOBMAP.Triangulation
{
  
    public delegate void ChangedEventHandler(object sender, EventArgs args);
   
    public class DelaunayEventChanged : Triangulation.Delaunay
    {
        #region members
        // EVENT HANDLER
        public event ChangedEventHandler Changed;

        #endregion

        #region constructors

        #endregion

        #region methods
        // Invoke the Changed event 
        protected virtual void OnChanged(EventArgs args)
        {
            if (Changed != null)
                Changed(this, args);
        }

        // Override METHODS
       
        public void addNewPoint(Geometry.Point point)
        {
            base.addNewPoint(point);
            OnChanged(EventArgs.Empty);
        }

        public void addNewPoints(List<Coordinates.Coordinate> projCoordinateList)
        {
            base.addNewPoints(projCoordinateList);
            OnChanged(EventArgs.Empty);
        }
        
        #endregion
    }
}
