using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace MOBMAP.Triangulation
{
    public class DelaunayListEventListener
    {
        private Form1 parentForm = null;
        private DelaunayEventChanged triangulation;

        public DelaunayListEventListener(Form1 parentForm, DelaunayEventChanged triangulation )
        {
            this.parentForm = parentForm;
            this.triangulation = triangulation;

            this.triangulation.Changed += new ChangedEventHandler(TriangulationChanged);
        }

        // TRIANGULATION LIST CHANGED.
        private void TriangulationChanged(object sender, EventArgs args)
        {
            onChanged(args);
        }

        public void Detach()
        {
            // Detach EVENT
            if (this.triangulation != null)
            {
                this.triangulation.Changed -= new ChangedEventHandler(TriangulationChanged);
                this.triangulation = null;
            }
        }

        public void onChanged(EventArgs args)
        { 
            parentForm.map.mapDraw.setTriangulateData(parentForm.delaunayTriangulation);
        }
    }
}
