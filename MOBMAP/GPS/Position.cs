﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Microsoft.WindowsMobile.Samples.Location;

namespace MOBMAP.GPS
{
    public class Position<T>: List<GpsPosition>
    {
        #region members
        private Form1 parentForm = null;
        public List<Coordinates.Coordinate> geoCoordinateList;
        #endregion

        #region constructor
        public Position(Form1 parentForm)
        {
            this.parentForm = parentForm;
            this.geoCoordinateList = new List<MOBMAP.Coordinates.Coordinate>();
        }
        #endregion

        #region methods

        public void Add(GpsPosition position)
        {
            base.Add(position);

            if (position.LatitudeValid && position.LongitudeValid)
            {
                if (position.SeaLevelAltitudeValid)
                {
                    geoCoordinateList.Add(new Coordinates.Coordinate(new Geometry.Point((float)(position.Latitude), (float)(position.Longitude)), false));
                }
                else
                {
                    geoCoordinateList.Add(new Coordinates.Coordinate(new Geometry.Point((float)(position.Latitude), (float)(position.Longitude), (float)(position.SeaLevelAltitude)), true));
                }
            }
        }

        public void sendCoordinates()
        {//min 3 elements to triangulate
            if (parentForm.coordinates.geoCoordinates.Count > 2 || geoCoordinateList.Count > 2)
            {
                parentForm.coordinates.geoCoordinates.AddRange(geoCoordinateList);
                parentForm.map.mapDraw.setCurrentPos(parentForm.coordinates.projCoordinates[parentForm.coordinates.projCoordinates.Count - 1]);
                
                geoCoordinateList.RemoveAll(deleteAllCoordinates);
            }
        }

        public static bool deleteAllPosition(GpsPosition position)
        {
            return true;
        }

        public static bool deleteAllCoordinates(Coordinates.Coordinate coordinate)
        {
            return true;
        }

        #endregion
    }
}
