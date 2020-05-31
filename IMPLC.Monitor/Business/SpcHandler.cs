using IMPLC.Core;
using IMPLC.Service;
using SPC.Core;
using System;
using System.Collections.Generic;

namespace IMPLC.Monitor
{
    public class SpcHandler : SPCBase
    {
        private readonly Implc _Implc;

        public SpcHandler(Implc plcComm) : base(plcComm)
        {
            _Implc = plcComm;
        }


        public override SpcDeviceWatcher BuildPlcWatcher()
        {
            var serviceDevices = GetServiceDevices();
            if (serviceDevices == null)
                return null;
            else
            {
                var watcher = new SpcDeviceWatcher();
                foreach (var serviceDevice in serviceDevices)
                {
                    if (ConvertDevice(serviceDevice.Device, out EDevice device))
                    {
                        watcher.Add(new DeviceReadBlock { Device = device, StartAddress = 0, Size = serviceDevice.Length, Key = device.ToString() });
                    }
                }

                return watcher;
            }
        }

        public override SpcDeviceManager BuildDeviceManager()
        {
            var serviceDevices = GetServiceDevices();
            if (serviceDevices == null)
                return null;
            else
            {
                var devManager = new SpcDeviceManager();
                foreach (var serviceDevice in serviceDevices)
                {
                    if (false == ConvertDevice(serviceDevice.Device, out EDevice device))
                        continue;

                    if (serviceDevice.Device.IsBitDevice())
                    {
                        devManager.Add(new BitDeviceArrayContainer(device, 0, serviceDevice.Length, device.ToString(), device.ToString()));
                    }
                    else
                    {
                        devManager.Add(new WordDeviceArrayContainer(device, 0, serviceDevice.Length, device.ToString(), device.ToString()));
                    }
                }

                return devManager;
            }
        }


        private List<PLCServiceDeviceInfo> GetServiceDevices()
        {
            var serviceObject = _Implc.ServiceObject;
            return serviceObject?.GetServiceDeviceInfo() ?? null;
        }

        private bool ConvertDevice(Device device, out EDevice convertDevice)
        {
            return Enum.TryParse(((int)device).ToString(), out convertDevice);
        }




    }
}