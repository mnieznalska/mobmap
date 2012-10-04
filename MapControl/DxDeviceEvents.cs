using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

using Microsoft.WindowsMobile.DirectX;
using Microsoft.WindowsMobile.DirectX.Direct3D;

namespace MapControl
{
    public delegate void RenderEventHandler(object sender, DxDeviceEvents e);
    public delegate void CreateDeviceEventHandler(object sender, DxDeviceEvents e);

    public class DxDeviceEvents : EventArgs
    {
        private Device _device;

        public Device Device
        {
            get
            {
                return _device;
            }
        }

        public DxDeviceEvents(Device device)
        {
            _device = device;
        }
    }

}
