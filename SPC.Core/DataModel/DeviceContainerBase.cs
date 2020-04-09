using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPC.Core
{
    public abstract class DeviceContainerBase : ICollection<DeviceBase>
    {
        private Dictionary<string, DeviceBase> _Devices;

        

        public eDevice Device { get; set; }
        public eDeviceType DeviceType { get; set; }
        public short StartAddress { get; set; }
        public string Key { get; set; }
        public int ReadBlockKey { get; set; }
        internal PlcReadWriter PlcReadWriter { get; set; }


        public int Count => _Devices.Count;

        public bool IsReadOnly => true;

        

        protected DeviceBase this[string key]
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

        public DeviceContainerBase()
        {
            _Devices = new Dictionary<string, DeviceBase>();
        }


        public void Add(DeviceBase item)
        {
            lock (_Devices)
            {
                item.Device = Device;
                item.Address = (short)(StartAddress + item.Offset);
                item.WriteToPlc += WriteToPlc;
                item.ReadFromPlc += ReadFromPlc;

                _Devices.Add(item.Key, item);
            }
        }

        

        public bool Remove(DeviceBase item)
        {
            lock (_Devices)
            {
                var key = item.Key;
                if (_Devices.ContainsKey(key))
                {
                    item.WriteToPlc -= WriteToPlc;
                    item.ReadFromPlc -= ReadFromPlc;

                    return _Devices.Remove(key);
                }
                else
                {
                    return false;
                }
            }
        }


        public void Clear()
        {
            lock (_Devices)
            {
                _Devices.Clear();
            }
        }

        public bool Contains(DeviceBase item)
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

        public void CopyTo(DeviceBase[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<DeviceBase> GetEnumerator()
        {
            return _Devices.Values.GetEnumerator();
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


        protected void WriteToPlc(DeviceReadWriteInfo writeInfo)
        {
            PlcReadWriter?.WriteToPlc(writeInfo);
        }
        protected void ReadFromPlc(DeviceReadWriteInfo readInfo)
        {
            PlcReadWriter?.ReadFromPlc(readInfo);
        }

    }
}
