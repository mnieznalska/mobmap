using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace MOBMAP.MapGoogle
{
    //class contains mapGoogleMarkers list
    public class MapGoogleMarkersList : List<MapGoogleMarker>
    {
        #region members
        private StringBuilder markersString;

        #endregion

        #region constructors
        public MapGoogleMarkersList()
        {
        }

        #endregion

        #region methods
        public string markersStringBuild()
        {
            markersString = new StringBuilder();
            markersString.Append("");

            if(this.Count>0){
                foreach (MapGoogleMarker mrk in this)
                {
                    switch (mrk.markerStatus)
                    {
                        case MapGoogleMarker.MarkerStatus.p:
                            markersString.Append("&markers=" + mrk.markerPoint.latLong);
                            break;
                        case MapGoogleMarker.MarkerStatus.pc:
                            markersString.Append("&markers=color:" + mrk.markerColor.ToString() + "|" + mrk.markerPoint.latLong);
                            break;
                        case MapGoogleMarker.MarkerStatus.pl:
                            markersString.Append("&markers=label:" + mrk.label + "|" + mrk.markerPoint.latLong);
                            break;
                        case MapGoogleMarker.MarkerStatus.plc:
                            markersString.Append("&markers=color:" + mrk.markerColor.ToString() + "|label:" + mrk.label + "|" + mrk.markerPoint.latLong);
                            break;
                        case MapGoogleMarker.MarkerStatus.plsc:
                            markersString.Append("&markers=size:" + mrk.markerSize.ToString() + "|color:" + mrk.markerColor.ToString() + "|label:" + mrk.label + "|" + mrk.markerPoint.latLong);
                            break;
                        case MapGoogleMarker.MarkerStatus.ps:
                            markersString.Append("&markers=size:" + mrk.markerSize.ToString() + "|" + mrk.markerPoint.latLong);
                            break;
                        case MapGoogleMarker.MarkerStatus.psc:
                            markersString.Append("&markers=size:" + mrk.markerSize.ToString() + "|color:" + mrk.markerColor.ToString() + "|" + mrk.markerPoint.latLong);
                            break;
                    }
                }
            }

            return markersString.ToString();
        }
        #endregion
    }
}
