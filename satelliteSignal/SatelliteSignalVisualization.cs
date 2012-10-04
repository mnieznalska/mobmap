using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.WindowsMobile.Samples.Location;


namespace SatelliteSignalVisualization
{
    public partial class SatelliteSignalVisualization : Control
    {
        private int width = 17;
        private List<Satellite> _satelliteData = new List<Satellite>();
        private Image satSignalImage;
        private Color satColor = Color.Teal;
        private List<Rectangle> strengthRectList;
        private Rectangle line0;
        private Rectangle line1;
        private Rectangle line2;
        private Rectangle line3;

       public void setSatelliteData(List<Satellite> sat)
        {
           this.satelliteData = sat;
        }
       #region getters & setters
       public List<Satellite> satelliteData
       {
           get { return _satelliteData; }
           set { _satelliteData = value; }
       }
       #endregion
       public SatelliteSignalVisualization()
        {
            InitializeComponent();
            satSignalImage = new Bitmap(Properties.Resources.satSignalImage);
            strengthRectList = new List <Rectangle>();
           
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
           
            try
            {
                // Calling the base class OnPaint
                base.OnPaint(pe);

                // Draw the control image (and scale to client area)
                pe.Graphics.DrawImage(satSignalImage,
                    this.ClientRectangle,
                    new Rectangle(0, 0, satSignalImage.Width, satSignalImage.Height),
                    GraphicsUnit.Pixel);
            
                //Draw scale lines
                line0 = new Rectangle(0, satSignalImage.Height - 40, satSignalImage.Width, 1);
                line1 = new Rectangle(0, (satSignalImage.Height - 40) / 4, satSignalImage.Width, 1);
                line2 = new Rectangle(0, 2*(satSignalImage.Height - 40) / 4, satSignalImage.Width, 1);
                line3 = new Rectangle(0, 3*(satSignalImage.Height - 40) / 4, satSignalImage.Width, 1);

                using (SolidBrush b = new SolidBrush(Color.Black))
                {
                    pe.Graphics.FillRectangle(b, line0);
                    pe.Graphics.FillRectangle(b, line1);
                    pe.Graphics.FillRectangle(b, line2);
                    pe.Graphics.FillRectangle(b, line3);
                }

                //Draw Signal Strength
          
                strengthRectList.Clear();
                if (satelliteData != null && satelliteData.Count != 0)
                {
                    for (int i = 0; i < satelliteData.Count; i++)
                    {
                        strengthRectList.Add(new Rectangle(4 + (19 * i), satSignalImage.Height - 40 - satelliteData[i].SignalStrength, width, satelliteData[i].SignalStrength));
                    }

                    using (SolidBrush b = new SolidBrush(satColor))
                    {
                        for (int i = 0; i < strengthRectList.Count; i++)
                        {
                            pe.Graphics.FillRectangle(b, strengthRectList[i]);
                            pe.Graphics.DrawString(satelliteData[i].Id.ToString(),
                                new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular),
                                new SolidBrush(Color.Black),
                                new RectangleF(strengthRectList[i].X, satSignalImage.Height - 35,
                                    strengthRectList[i].Width, 30));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("draw ex:" + ex.Message);
            }
        }

    }
}
