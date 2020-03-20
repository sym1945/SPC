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
        public IDeviceContainer GetDeviceContainer()
        {
            return null;
        }

        public void OnPlcConnected()
        { 

        }

        public void OnBeginReadCycle(IReadOnlyList<PlcReadBlock> devBlocks)
        {

        }

        public void OnEndReadCycle(IReadOnlyList<PlcReadBlock> devBlocks)
        {
            
        }

    }
}
