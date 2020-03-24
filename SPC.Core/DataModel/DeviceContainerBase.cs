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

        public int Count => throw new NotImplementedException();

        public bool IsReadOnly => throw new NotImplementedException();


        public DeviceContainerBase()
        {
            _Devices = new Dictionary<string, IDevice>();
        }


        public void Add(IDevice item)
        {
            lock (_Devices)
            {
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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}
