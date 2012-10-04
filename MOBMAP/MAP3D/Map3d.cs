using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using Microsoft.WindowsMobile.DirectX;
using Microsoft.WindowsMobile.DirectX.Direct3D;


namespace MOBMAP.MAP
{
    public partial class Map : UserControl
    {

        #region members
        private MapDraw _mapDraw = null;
        private MapView _mapView = null;
        private MapUserControl _mapUserControl = null;
        private Device _device;
         
        
        private Form1 _parentForm = null;
        private bool isCreated = false;

     

        #endregion

        public Map()
        {
            InitializeComponent();
            
        }

        #region getters & setters
        public MapDraw mapDraw
        {
            get { return _mapDraw; }
            set { _mapDraw = value; }
        }

        public MapView mapView
        {
            get { return _mapView; }
            set { _mapView = value; }
        }

        public MapUserControl mapUserControl
        {
            get { return _mapUserControl; }
            set { _mapUserControl = value; }
        }

        public Device device
        {
            get { return _device; }
            set { _device = value; }
        }

        
        public Form1 parentForm
        {
            get { return _parentForm; }
            set { _parentForm = value; }
        }
        #endregion


        public void dxInit(Form1 form)
        {
            try
            {
                this.parentForm = form;
                mapDraw = new MapDraw(this);
                mapView = new MapView(this);
                mapUserControl = new MapUserControl(this);

                InitializeGraphics();

                this.parentForm.Show();
                this.parentForm.Focus();

                while (isCreated)
                {
                    if(parentForm.d3dRenderStatus==Form1.D3dRenderStatus.D3D_RENDER)
                        Render();
                    
                    Application.DoEvents();

                }

            }
            catch (DirectXException ex)
            {
                throw new ArgumentException("Error: Couldn't initialize 3d graphics", ex);
            }
        }


        public void dxClose()
        {
            this.isCreated = false;
        }

        public void InitializeGraphics()
        {
            PresentParameters presentParams = new PresentParameters();
            presentParams.Windowed = true;
            presentParams.SwapEffect = SwapEffect.Discard;  
            device = new Device(0, DeviceType.Default, this.parentForm, CreateFlags.None | CreateFlags.MultiThreaded, presentParams);

            device.RenderState.FillMode = FillMode.Solid;
            this.setLighting();
            mapView.setCamera();
            mapView.setProjection();
            mapView.viewport = device.Viewport;
    
            this.isCreated = true;
        }


        public void Render()
        {
            try
            {
                // WHITE SCREEN
                device.Clear(ClearFlags.Target, mapView.deviceColor, 1.0f, 0);

                // Begin DRAW
                device.BeginScene();
       
                // Create a translation matrix to move TERRAIN
                device.Transform.World = Matrix.Translation(mapView.xPos, mapView.yPos, mapView.zPos) *Matrix.RotationX(mapUserControl.angleX) * Matrix.RotationY(mapUserControl.angleY) * Matrix.RotationZ(mapUserControl.angleZ);
       
                mapDraw.draw();
                // End DRAW
                device.EndScene();
       
                // PRESENT TERRAIN ON SCREEN
                device.Present();
            }catch (Exception ex)
            {
                 
            }
        }
     


        private void setLighting()
        {
            device.RenderState.CullMode = Cull.None; 
            device.RenderState.Lighting = false;
        }


        

        

        public void exitProgram()
        {
            Application.Exit();
        }


        private void InitializeComponent()
        {
            this.SuspendLayout();

            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.Name = "MapControl";
            this.Size = new System.Drawing.Size(26, 26);
            this.ResumeLayout(false);

        }

    }
}
