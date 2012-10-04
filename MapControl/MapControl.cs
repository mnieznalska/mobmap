using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Microsoft.WindowsMobile.DirectX;
using Microsoft.WindowsMobile.DirectX.Direct3D;


namespace MapControl
{
    public class MapControl : UserControl
    {
        # region members

        //directX device
        private Device _dxDevice = null;
        //parent form for MapControl
        private Form _parentForm = null;
        //parent form created
        private bool _isCreated = false;

        private bool isActiveWindow = false;
        //event to start render scene
        public event RenderEventHandler OnRender;
     
        private VertexBuffer vertexBuffer = null;
        //device color
        private Color _deviceBackColor = Color.Black;

        public RetriveDrawParameters retriveDrawParameters;

        


        //camera
        //view
        private Vector3 userEye = new Vector3(0f, 0f, -5f);
        private Vector3 cameraLookPoint = new Vector3(0f, 0f, 0f);
        private Vector3 lookDirection = new Vector3(0f, 1f, 0f);
        //rotation
        private Vector3 rotationAxisVector = new Vector3(1, 1, 1); //rotation 45 degrees
        private static float rotationAngle;
        
        # endregion



        # region constructor

        public MapControl()
        {
           InitializeComponent();
          
           isActiveWindow = true;
           retriveDrawParameters = new RetriveDrawParameters();
           
        }
        # endregion


        # region directX init

        public void dxInit(Form parentForm)
        {
            try
            {
                _parentForm = parentForm;
                // dx stuff
                if (!init3dxGraphics())
                {
                    MessageBox.Show("Couldn't initialize 3d graphics");
                }

                OnCreateDevice(_dxDevice, null);//??

                parentForm.Show();
                parentForm.Focus();

                //while form is valid render view
                while (_isCreated)
                {
                    //render view
                    Render();

                    //
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
            _isCreated = false;
        }

        //initialize direct3d graphics
        private bool init3dxGraphics()
        {
            try
            {
                PresentParameters presentParams = new PresentParameters();
                
                //do not project as full screen
                presentParams.Windowed = true;
                
                //discard frame
                presentParams.SwapEffect = SwapEffect.Discard;
                
                //use z-buffer (depth) in graphics board
                presentParams.EnableAutoDepthStencil = true;
                
                //depth limit
                presentParams.AutoDepthStencilFormat = DepthFormat.D16;
                
                //clear old canvas if exist
                if (_dxDevice != null)
                    _dxDevice.Dispose();
                
                // create new device instance
                _dxDevice = new Device(0, DeviceType.Default, _parentForm, CreateFlags.None, presentParams);


                setCamera();
                return true;
            }
            catch (DirectXException)
            {
                return false;
            }
        }

        # endregion

           
        #region properties

           public Color DeviceBackColor
        {
            get { return _deviceBackColor; }
            set { _deviceBackColor = value; }
        }
        #endregion


        #region Rendering

        /// <summary>
        /// Rendering-method
        /// </summary>
        private void Render()
        {
            if (_dxDevice == null)
                return;

            //Clear the backbuffer
            _dxDevice.Clear(ClearFlags.Target, _deviceBackColor, 1.0f, 0);

            if (isActiveWindow)
            {
                //Begin the scene
                _dxDevice.BeginScene();
                //rotation();
                // Render of scene here
                if (OnRender != null)
                    OnRender(this, new DxDeviceEvents(_dxDevice));

                _dxDevice.RenderState.FillMode = FillMode.WireFrame;//brak wypelnienia
                _dxDevice.SetStreamSource(0, vertexBuffer, 0);
                _dxDevice.DrawPrimitives(PrimitiveType.TriangleList, 0, 1);

                //End the scene
                _dxDevice.EndScene();
                _dxDevice.Present();
            }
        }

        #endregion

        #region camera

        private void setCamera()
        {
            _dxDevice.Transform.View = Matrix.LookAtLH(
                userEye, //user view point at 5.0 in front of canvas  
                cameraLookPoint, //camera look at this point
                lookDirection); //up direction on y-axis
        }

        
        private void setCameraVector(Vector3 userEye, Vector3 cameraLookPoint, Vector3 lookDirection)
        {
            this.userEye = userEye;
            this.cameraLookPoint = cameraLookPoint;
            this.lookDirection = lookDirection;
        }

        private void zoomIn()
        {
        }

        private void zoomOut()
        {
        }

        public void rotation()
        {
            rotationAngle += 0.1f;
            _dxDevice.Transform.World = Matrix.RotationAxis(rotationAxisVector, rotationAngle);
        }
        #endregion


        #region events

        // Called whenever the device is created
        void OnCreateDevice(object sender, EventArgs e)
        {
            Pool vertexBufferPool;
            Caps caps;
            Device dev = (Device)sender;

            // Get the device capabilities
            caps = dev.DeviceCaps;

            if (caps.SurfaceCaps.SupportsVidVertexBuffer)
                vertexBufferPool = Pool.VideoMemory;
            else
                vertexBufferPool = Pool.SystemMemory;

            // Create the VBuffer
            vertexBuffer = new VertexBuffer(
                typeof(CustomVertex.TransformedColored), 3, dev, 0,
                CustomVertex.TransformedColored.Format, vertexBufferPool);

            vertexBuffer.Created += new System.EventHandler(
                this.OnCreateVertexBuffer);
            this.OnCreateVertexBuffer(vertexBuffer, null);

            _isCreated = true;

        }

        // Called whenever the vertex buffer is created (or recreated)
        void OnCreateVertexBuffer(object sender, EventArgs e)
        {
            // retrieve the vertex buffer
            VertexBuffer vb = (VertexBuffer)sender;

            // create an array of vertices
            CustomVertex.TransformedColored[] verts =
                new CustomVertex.TransformedColored[3];

            // initialize the vertex array with position and color data
            verts[0].X = 150;
            verts[0].Y = 50;
            verts[0].Z = 0;
            verts[0].Rhw = 5;
            verts[0].Color = System.Drawing.Color.Aqua.ToArgb();

            verts[1].X = 250;
            verts[1].Y = 250;
            verts[1].Z = 0;
            verts[1].Rhw = 5;
            verts[1].Color = System.Drawing.Color.Brown.ToArgb();

            verts[2].X = 0;
            verts[2].Y = 0;
            verts[2].Z = 0;
            verts[2].Rhw = 5;
            verts[2].Color = System.Drawing.Color.LightPink.ToArgb();

            vb.SetData(verts, 0, LockFlags.None);
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            // Render on each Paint
            this.Render();

            this.Invalidate();
        }

        protected override void OnKeyPress(System.Windows.Forms.KeyPressEventArgs e)
        {
            // Close on escape
            if ((int)(byte)e.KeyChar == (int)System.Windows.Forms.Keys.B)
                _parentForm.Close();
            // Close on escape
            if ((int)(byte)e.KeyChar == (int)System.Windows.Forms.Keys.A)
                rotation();
        }

        #endregion


        #region additional function

        public void setIsActiveWindow(bool isActiveWindow)
        {
            this.isActiveWindow = isActiveWindow;
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // MapControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.Name = "MapControl";
            this.Size = new System.Drawing.Size(26, 26);
            this.ResumeLayout(false);

        }

       /* public void addDrawParameters(DrawParameters param)
        {
            drawParametersList.Add(param);
        }

        public void clearDrawParameters()
        {
            drawParametersList.Clear();
        }*/
        #endregion
    }

}