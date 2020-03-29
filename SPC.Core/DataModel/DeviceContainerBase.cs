using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPC.Core
{
    public abstract class DeviceContainerBase : IDeviceContainer
    {
        private Dictionary<string, IDevice> _Devices;

        public eDevice Device { get; set; }
        public eDeviceType DeviceType { get; set; }
        public short StartAddress { get; set; }
        public string Description { get; set; }
        public int ReadBlockKey { get; set; }

        public int Count => _Devices.Count;

        public bool IsReadOnly => throw new NotImplementedException();

        protected IDevice this[string key]
        {
            get
            {
                try
                {
                    return _Devices[key];
                }
                catch
                {
                    return null;
                }
            }
        }

        private event Func<PlcWriteInfo, bool> _WriteToPlc;
        public event Func<PlcWriteInfo, bool> WriteToPlc
        {
            add
            {
                _WriteToPlc += value;
                foreach (DeviceBase dev in this)
                {
                    dev.WriteToPlc += value;
                }
            }
            remove
            {
                _WriteToPlc -= value;
                foreach (DeviceBase dev in this)
                {
                    dev.WriteToPlc -= value;
                }
            }
        }


        public DeviceContainerBase()
        {
            _Devices = new Dictionary<string, IDevice>();
        }


        public void Add(IDevice item)
        {
            lock (_Devices)
            {
                item.Device = Device;
                item.Address = (short)(StartAddress + item.Offset);

                _Devices.Add(item.Key, item);
            }
        }

        public void Clear()
        {
            lock (_Devices)
            {
                _Devices.Clear();
            }
        }

        public bool Contains(IDevice item)
        {
            return Contains(item.Key);
        }

        public bool Contains(string key)
        {
            lock (_Devices)
            {
                return _Devices.ContainsKey(key);
            }
        }

        public void CopyTo(IDevice[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<IDevice> GetEnumerator()
        {
            return _Devices.Values.GetEnumerator();
        }

        public bool Remove(IDevice item)
        {
            lock (_Devices)
            {
                var key = item.Key;
                if (_Devices.ContainsKey(key))
                {
                    return _Devices.Remove(key);
                }
                else
                {
                    return false;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }


        public virtual void PlcConnected()
        {

        }


        public virtual void BeforeRead(PlcReadBlock devBlock)
        {

        }

        public virtual void AfterRead(PlcReadBlock devBlock)
        {
        }

        protected void OnWriteToPlc(PlcWriteInfo writeInfo)
        {
            _WriteToPlc?.Invoke(writeInfo);
        }


    }
}
