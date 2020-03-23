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
            // Loop All Managend Device Container
            foreach (var devContainer in this)
            {
                // Find Target Device Block
                var devBlock = devBlocks
                    .Where(d => d.Device == devContainer.Device)
                    .Where(d => d.StartAddress == devContainer.StartAddress)
                    .FirstOrDefault();

                if (devBlock == null)
                    continue;

                // Update Devices from Device's block raw Data


            }
        }

    }
}
