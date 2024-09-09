using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsServiceNextiva.Entities
{
   public class Device
    {
        public int DeviceID { get; set; }
        public string DeviceIDE { get; set; }
        public string DeviceNameDescrip { get; set; }
        public int TypeDeviceID { get; set; }
        public int CustomerCompanyID { get; set; }
        public int DeviceChannel { get; set; }
        public string DeviceIDLogon { get; set; }
        public string DeviceIP { get; set; }
        public string DeviceUser { get; set; }
        public string DevicePass { get; set; }
        public string DevicePort { get; set; }
        public DateTime DeviceDateIng { get; set; }
        public int DeviceEstado { get; set; }
        public int SystemDeviceID { get; set; }
        public string TypeDeviceDescrip { get; set; }
        public string SystemDeviceDescrip { get; set; }
        public string CustomerCompanyDescrip { get; set; }
    }
}
