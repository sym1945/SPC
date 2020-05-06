using IMPLC.Core;
using IMPLC.Service;
using SPC.Core;
using System;
using System.Collections.Generic;

namespace IMPLC.Monitor
{
    public class SpcHandler : SPCBase
    {
        private Implc _Implc;

        public SpcHandler(Implc plcComm) : base(plcComm)
        {
            _Implc = plcComm;
        }


        public override PlcWatcher BuildPlcWatcher()
        {
            var serviceDevices = GetServiceDevices();
            if (serviceDevices == null)
                return null;
            else
            {
                var watcher = new PlcWatcher();
                foreach (var serviceDevice in serviceDevices)
                {
                    if (ConvertDevice(serviceDevice.Device, out eDevice device))
                    {
                        watcher.Add(new PlcReadBlock { Device = device, StartAddress = 0, Size = serviceDevice.Length, Key = (int)device });
                    }
                }

                return watcher;
            }
        }

        public override DeviceManager BuildDeviceManager()
        {
            var serviceDevices = GetServiceDevices();
            if (serviceDevices == null)
                return null;
            else
            {
                var devManager = new DeviceManager();
                foreach (var serviceDevice in serviceDevices)
                {
                    if (false == ConvertDevice(serviceDevice.Device, out eDevice device))
                        continue;

                    if (serviceDevice.Device.IsBitDevice())
                    {
                        devManager.Add(new BitDeviceArrayContainer(device, 0, serviceDevice.Length, device.ToString(), (int)device));
                    }
                    else
                    {
                        devManager.Add(new WordDeviceArrayContainer(device, 0, serviceDevice.Length, device.ToString(), (int)device));
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

        private bool ConvertDevice(Device device, out eDevice convertDevice)
        {
            return Enum.TryParse(((int)device).ToString(), out convertDevice);
        }




    }
}