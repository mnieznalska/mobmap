using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace MOBMAP.UI
{
    public partial class ButtonImage : UserControl
    {
        Image image;
        Image imagePress;
        bool click = false;
        public ButtonImage()
        {
            InitializeComponent();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            this.click = true;
            this.Invalidate();
            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            this.click = false;
            this.Invalidate();
            base.OnMouseUp(e);
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

        public Image ImagePress
        {
            get
            {
                return this.imagePress;
            }
            set
            {
                this.imagePress = value;
            }
        }


        // Override the OnPaint method to draw the background image and the text.
        protected override void OnPaint(PaintEventArgs e)
        {
            if(click)
            e.Graphics.DrawImage(this.imagePress, 0, 0);
            else
            e.Graphics.DrawImage(this.image, 0, 0);

            e.Graphics.DrawRectangle(new Pen(Color.Black), 0, 0,
                this.ClientSize.Width - 1, this.ClientSize.Height - 1);

            base.OnPaint(e);
        }
    }

}
