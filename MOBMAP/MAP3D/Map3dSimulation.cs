﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MOBMAP.MAP
{
    class MapSimulation
    {
        #region members
        private Map map = null;
        private List<Coordinates.Coordinate> projCoordList;
        private Triangulation.Delaunay delaunayTr;
        #endregion

        public MapSimulation(Map map)
        {
            this.projCoordList = new List<Coordinates.Coordinate>();
            this.delaunayTr = new MOBMAP.Triangulation.Delaunay();
            this.map = map;
        }

 
        public void setSimulationData(List<Coordinates.Coordinate> projCoordList)
        {
            this.projCoordList = projCoordList;
        }

        public void simulate()
        {
            Triangulation.Delaunay tmpDelaunayTr = map.mapDraw.triangulation;
            List<Coordinates.Coordinate> tmpCoordinate = new List<MOBMAP.Coordinates.Coordinate>();
            MapDraw.DrawFromStatus tmpDrawFromStatus = map.mapDraw.drawFromStatus;
            map.mapDraw.drawFromStatus = MapDraw.DrawFromStatus.DRAW_SIMULATION;
            
            for (int i = 0; i < projCoordList.Count-10; i+=10)
            {
                tmpCoordinate.Add(projCoordList[i]);
                tmpCoordinate.Add(projCoordList[i + 1]);
                tmpCoordinate.Add(projCoordList[i + 2]);
                tmpCoordinate.Add(projCoordList[i + 3]);
                tmpCoordinate.Add(projCoordList[i + 4]);
                tmpCoordinate.Add(projCoordList[i + 5]);
                tmpCoordinate.Add(projCoordList[i + 6]);
                tmpCoordinate.Add(projCoordList[i + 7]);
                tmpCoordinate.Add(projCoordList[i + 8]);
                tmpCoordinate.Add(projCoordList[i + 9]);

                delaunayTr.addNewPoints(tmpCoordinate);
                map.mapDraw.setTriangulateData(delaunayTr);

                Thread.Sleep(0);
            }
          
            map.mapDraw.drawFromStatus = MapDraw.DrawFromStatus.DRAW_FROM_DB;
        }
    }
}
