﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MOBMAP.MapGoogle
{
    public class MapGoogleUrlBuilder
    {
        /*
         * http://maps.google.com/maps/api/staticmap?center=Brooklyn+Bridge,New+York,NY&zoom=14&size=512x512&maptype=roadmap
&markers=color:blue|label:S|40.702147,-74.015794&markers=color:green|label:G|40.711614,-74.012318
&markers=color:red|color:red|label:C|40.718217,-73.998284&sensor=false
         */
        #region members
     
        private StringBuilder _mapUrl = null;
        private MapGoogle mapGoogle;
        #endregion

        #region constructor
        public MapGoogleUrlBuilder(MapGoogle map)
        {
            this.mapGoogle = map;
        }
        #endregion

        #region getters & setters
        public string mapUrl
        {
            get { return _mapUrl.ToString(); }
        }

        #endregion


        public StringBuilder buildMapUrl()
        {  
            _mapUrl = new StringBuilder();
            _mapUrl.Append("http://maps.google.com/maps/api/staticmap?");
            _mapUrl.Append(mapGoogle.mapViewport.mapCenter);
            _mapUrl.Append(mapGoogle.mapProperties.mapSize);
            _mapUrl.Append(mapGoogle.mapProperties.mapType.ToLower());
            _mapUrl.Append(mapGoogle.mapProperties.mapZoom);
            _mapUrl.Append(mapGoogle.mapMarkersList.markersStringBuild());
            _mapUrl.Append(mapGoogle.mapPath.pathStringBuild());
          
            _mapUrl.Append(mapGoogle.mapProperties.mapImgFormat);
            _mapUrl.Append(mapGoogle.mapProperties.mapSensor.ToLower());
       
 

            return _mapUrl;
        }

    }
}
