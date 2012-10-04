using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Microsoft.WindowsMobile.Samples.Location;

namespace MOBMAP.GPS
{
    public class SatelliteView
    {
        private List<Satellite> satelliteList;
 

        //return list of active satellites
        public List <Satellite> getSatelliteList()
        {
            return satelliteList;
        }
        
        //set list of active satellites
        public void setSatellite(GpsPosition position)
        {
            if (position.GetSatellitesInSolution() == null)
                satelliteList = new List <Satellite>();
            else      
                satelliteList =position.GetSatellitesInView().ToList();
        }
    }
}
