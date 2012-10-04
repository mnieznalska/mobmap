﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;
using Microsoft.WindowsMobile.Samples.Location;

namespace MOBMAP.Database
{
    public class Database
    {

        public interface IDatabase
        {
            void setTrackId();
            void initDatabase();
            void addTrackData(GPS.Position<GpsPosition> positionList);
            List<Coordinates.Coordinate> readTrackData(int trackId);
            void removeTrack(int trackId);
            void readTrackIDs();
            bool hasDatabase
            {
                get;
            }
            List<int> trackIdList
            {
                get;
                set;
            }
            List<Coordinates.Coordinate> dbCoordinatesList
            {
                get;
                set;
            }
        }

        static IDatabase _databaseHandler = null;

        public static IDatabase getDatabaseHandler()
        {
            if (_databaseHandler == null)
            {
                _databaseHandler = new DatabaseHandler();
            }
            return _databaseHandler;
        }
    }
}
