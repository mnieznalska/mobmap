using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MOBMAP.Coordinates
{
  
    public delegate void ChangedEventHandler(object sender, EventArgs e);

    public class CoordinateListEventChanged<T> : List<Coordinate>
    {
        #region members
        // Change event
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

        // Override methods

        public void Add(Coordinate geoCoordinate)
        {
            base.Add(geoCoordinate);
            OnChanged(EventArgs.Empty);
        }

        public void AddRange(List<Coordinate> coordinateList)
        {
            base.AddRange(coordinateList);
            OnChanged(EventArgs.Empty);
        }

        public void Clear()
        {
            base.Clear();
            OnChanged(EventArgs.Empty);
        }

        public Coordinate this[int index]
        {
            set
            {
                base[index] = value;
                OnChanged(EventArgs.Empty);
            }

            get { return base[index]; }
        }
        #endregion
    }
}
