using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace MOBMAP.Coordinates
{
    public class CoordinateListEventListener
    {
        private CoordinateListEventChanged<Coordinate> geoCoordinateEvList;//geolist
        private List<Coordinate> projCoordinateList; //proj list
        private Triangulation.Delaunay triangulation;
        private Projection.PlateCaree plataCaree = new MOBMAP.Projection.PlateCaree();
        private int lastIndex = 0;
        private Form1 parentForm = null;

        public CoordinateListEventListener(Form1 parentForm, CoordinateListEventChanged<Coordinate> coordinateEvList, List<Coordinate> coordinateList)
        {
            this.parentForm = parentForm;
            this.geoCoordinateEvList = coordinateEvList;
            this.projCoordinateList = coordinateList;
            this.geoCoordinateEvList.Changed += new ChangedEventHandler(ListChanged);
        }

        // list changed
        private void ListChanged(object sender, EventArgs args)
        {
            onChanged(args);
        }

        public void Detach()
        {
            // Detach event
            if (geoCoordinateEvList != null)
            {
                geoCoordinateEvList.Changed -= new ChangedEventHandler(ListChanged);
                geoCoordinateEvList = null;
            }
        }

        public void onChanged(EventArgs args)
        {
            for (int i = lastIndex; i < geoCoordinateEvList.Count; i++)
            {
                //convert geoCoordinate to projectionCoordinate and ADD new projection coordinates to list
                this.projCoordinateList.Add(plataCaree.geoConvert(geoCoordinateEvList[i]));
            }

            for (int j = projCoordinateList.Count - 2; j >= 0; j--)
            {
                for (int k = projCoordinateList.Count - 1; k >= j + 1; k--)
                {
                    if (projCoordinateList[j].coordinatePoint.Equals2D(projCoordinateList[k].coordinatePoint))
                    {
                        projCoordinateList.RemoveAt(k);
                        k--;
                        continue;
                    }
                }
            }

            lastIndex = projCoordinateList.Count;

            parentForm.delaunayTriangulation.addNewPoints(this.projCoordinateList);
  
        }
    }
}
