using IMPLC.Core;
using IMPLC.Service;
using SPC.Core;
using System;
using System.Collections.Generic;

namespace IMPLC.Monitor
{
    public class SpcHandleConfiguration : SpcConfiguration
    {
        private readonly Implc _Implc;

        public string Uri { get; private set; }

        public List<PLCServiceDeviceInfo> ServiceDevices { get; private set; }


        public SpcHandleConfiguration(string uri)
        {
            // TODO: 너무 날림으로 함... 수정 필요
            Uri = uri;
            _Implc = new Implc(Uri);
            var serviceObject = _Implc.ServiceObject;
            ServiceDevices = serviceObject?.GetServiceDeviceInfo() ?? null;
        }


        public override SpcCommunication BuildCommunication()
        {
            return _Implc;
        }

        public override SpcDeviceManager BuildDeviceManager()
        {
            var serviceDevices = ServiceDevices;
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
                        devManager.Add(new BitDeviceArrayContainer(device, serviceDevice.Length, device.ToString(), device.ToString()));
                    }
                    else
                    {
                        devManager.Add(new WordDeviceArrayContainer<WordShortDevice>(device, serviceDevice.Length, device.ToString(), device.ToString()));
                    }
                }

                return devManager;
            }
        }

        public override SpcDeviceWatcher BuildDeviceWatcher()
        {
            var serviceDevices = ServiceDevices;
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

        private bool ConvertDevice(Device device, out EDevice convertDevice)
        {
            return Enum.TryParse(((int)device).ToString(), out convertDevice);
        }


    }
}
