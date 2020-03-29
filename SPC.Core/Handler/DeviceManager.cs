using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPC.Core
{
    public class DeviceManager : DeviceManagerBase
    {
        private bool _IsSetup = false;

        public bool IsSetUp => _IsSetup;

        


        public void SetUp()
        {
            if (_IsSetup)
                return;

            //foreach (DeviceContainerBase devContainer in this)
            //{
            //    foreach(var device in devContainer)
            //    {
            //        device.Device = devContainer.Device;
            //        device.Address = (short)(devContainer.StartAddress + device.Offset);
            //    }
            //}

            _IsSetup = true;
        }

    }
}
