using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace MOBMAP.UI
{
    public partial class LegendPanel : UserControl
    {
        Image image;
        MAP.Map _map;
        private float minValue;
        private float maxValue;

        public LegendPanel()
        {
            InitializeComponent();
            
            minValue = (float)numUpDownMinHi.Value;
            maxValue = (float)numUpDownMaxHi.Value;
            calculateLegendScale();
        }


        public Image BImage
        {
            get
            {
                return this.image;
            }
            set
            {
                this.image = value;
            }
        }

        public MAP.Map map
        {
            get
            {
                return this._map;
            }
            set
            {
                this._map = value;
            }
        }

        

        private void calculateLegendScale()
        {
            float step = (maxValue - minValue) / 22.0f;


            labHi1.Text = String.Format("{0:0.00}", (minValue + 1 * step));
            labHi2.Text = String.Format("{0:0.00}", (minValue + 2 * step)); 
            labHi3.Text = String.Format("{0:0.00}", (minValue + 3 * step));
            labHi4.Text = String.Format("{0:0.00}", (minValue + 4 * step));
            labHi5.Text = String.Format("{0:0.00}", (minValue + 5 * step)); 
            labHi6.Text = String.Format("{0:0.00}", (minValue + 6 * step)); 
            labHi7.Text = String.Format("{0:0.00}", (minValue + 7 * step)); 
            labHi8.Text = String.Format("{0:0.00}", (minValue + 8 * step)); 
            labHi9.Text = String.Format("{0:0.00}", (minValue + 9 * step)); 
            labHi10.Text = String.Format("{0:0.00}", (minValue + 10 * step)); 
            labHi11.Text = String.Format("{0:0.00}", (minValue + 11 * step)); 
            labHi12.Text = String.Format("{0:0.00}", (minValue + 12 * step)); 
            labHi13.Text = String.Format("{0:0.00}", (minValue + 13 * step)); 
            labHi14.Text = String.Format("{0:0.00}", (minValue + 14 * step)); 
            labHi15.Text = String.Format("{0:0.00}", (minValue + 15 * step)); 
            labHi16.Text = String.Format("{0:0.00}", (minValue + 16 * step)); 
            labHi17.Text = String.Format("{0:0.00}", (minValue + 17 * step)); 
            labHi18.Text = String.Format("{0:0.00}", (minValue + 18 * step));
            labHi19.Text = String.Format("{0:0.00}", (minValue + 19 * step));
            labHi20.Text = String.Format("{0:0.00}", (minValue + 20 * step));
            labHi21.Text = String.Format("{0:0.00}", (minValue + 21 * step)); 

        }


        public int calculateColorFromLegend(float Z)
        {
            try
            {
                float step = (maxValue - minValue) / 22.0f;

                if (Z < minValue)
                {
                    return Color.FromArgb(0, 64, 0).ToArgb();
                }
                else if (Z >= minValue && Z < minValue + 1 * step)
                {
                    return Color.DarkGreen.ToArgb();
                }
                else if (Z >= minValue + 1 * step && Z < minValue + 2 * step)
                {
                    return Color.Green.ToArgb();
                }
                else if (Z >= minValue + 2 * step && Z < minValue + 3 * step)
                {
                    return Color.FromArgb(26, 157, 2).ToArgb();
                }
                else if (Z >= minValue + 3 * step && Z < minValue + 4 * step)
                {
                    return Color.FromArgb(17, 207, 1).ToArgb();
                }
                else if (Z >= minValue + 4 * step && Z < minValue + 5 * step)
                {
                    return Color.Lime.ToArgb();
                }
                else if (Z >= minValue + 5 * step && Z < minValue + 6 * step)
                {
                    return Color.LawnGreen.ToArgb();
                }
                else if (Z >= minValue + 6 * step && Z < minValue + 7 * step)
                {
                    return Color.GreenYellow.ToArgb();
                }
                else if (Z >= minValue + 7 * step && Z < minValue + 8 * step)
                {
                    return Color.FromArgb(202, 235, 44).ToArgb();
                }
                else if (Z >= minValue + 8 * step && Z < minValue + 9 * step)
                {
                    return Color.FromArgb(243, 243, 41).ToArgb();
                }
                else if (Z >= minValue + 9 * step && Z < minValue + 10 * step)
                {
                    return Color.Gold.ToArgb();
                }
                else if (Z >= minValue + 10 * step && Z < minValue + 11 * step)
                {
                    return Color.Goldenrod.ToArgb();
                }
                else if (Z >= minValue + 11 * step && Z < minValue + 12 * step)
                {
                    return Color.FromArgb(255, 184, 2).ToArgb();
                }
                else if (Z >= minValue + 12 * step && Z < minValue + 13 * step)
                {
                    return Color.Orange.ToArgb();
                }
                else if (Z >= minValue + 13 * step && Z < minValue + 14 * step)
                {
                    return Color.DarkOrange.ToArgb();
                }
                else if (Z >= minValue + 14 * step && Z < minValue + 15 * step)
                {
                    return Color.FromArgb(255, 110, 0).ToArgb();
                }
                else if (Z >= minValue + 15 * step && Z < minValue + 16 * step)
                {
                    return Color.OrangeRed.ToArgb();
                }
                else if (Z >= minValue + 16 * step && Z < minValue + 17 * step)
                {
                    return Color.FromArgb(255, 30, 0).ToArgb();
                }
                else if (Z >= minValue + 17 * step && Z < minValue + 18 * step)
                {
                    return Color.FromArgb(233, 0, 0).ToArgb();
                }
                else if (Z >= minValue + 18 * step && Z < minValue + 19 * step)
                {
                    return Color.FromArgb(221, 0, 0).ToArgb();
                }
                else if (Z >= minValue + 19 * step && Z < minValue + 20 * step)
                {
                    return Color.FromArgb(190, 0, 0).ToArgb();
                }
                else if (Z >= minValue + 20 * step && Z < minValue + 21 * step)
                {
                    return Color.FromArgb(155, 0, 0).ToArgb();
                }
                else if (Z >= minValue + 21 * step && Z < minValue + 22 * step)
                {
                    return Color.FromArgb(130, 0, 0).ToArgb();
                }
                else if (Z >= minValue + 22 * step && Z < minValue + 23 * step)
                {
                    return Color.FromArgb(100, 0, 0).ToArgb();
                }
                else// if (Z >= MAXVAL)
                {
                    return Color.FromArgb(64, 0, 0).ToArgb();
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        // Override the OnPaint method to draw the background image and the text.
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.DrawImage(this.image, 0, 0);

            base.OnPaint(e);
        }

        private void numUpDownMinHi_ValueChanged(object sender, EventArgs e)
        {
            labStartHi.Text = String.Format("{0:0.00}",numUpDownMinHi.Value);
            minValue = (float)numUpDownMinHi.Value;
            calculateLegendScale();
            
        }

        private void numUpDownMaxHi_ValueChanged(object sender, EventArgs e)
        {
            labStopHi.Text = String.Format("{0:0.00}",numUpDownMaxHi.Value);
            maxValue = (float)numUpDownMaxHi.Value;
            calculateLegendScale();
            
        }




    }
}
