using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace SPC.Core
{
    public class DeviceManagerBase : ICollection<DeviceContainerBase>
    {
        private List<DeviceContainerBase> _DeviceContainers;

        protected PlcReadWriter _PlcReadWriter;


        private PlcComm _Comm;
        internal PlcComm Comm
        {
            get => _Comm;
            set
            {
                if (_Comm == value)
                    return;

                _Comm = value;
                _PlcReadWriter = new PlcReadWriter(_Comm);
                foreach (var devContainer in this)
                {
                    devContainer.PlcReadWriter = _PlcReadWriter;
                }
            }
        }


        public int Count => _DeviceContainers.Count;

        public bool IsReadOnly => false;


        #region Constructor

        public DeviceManagerBase()
        {
            _DeviceContainers = new List<DeviceContainerBase>();
        }

        #endregion


        public void Add(DeviceContainerBase item)
        {
            lock (_DeviceContainers)
            {
                _DeviceContainers.Add(item);
            }
        }

        public bool Remove(DeviceContainerBase item)
        {
            lock (_DeviceContainers)
            {
                if (_DeviceContainers.Contains(item))
                {
                    return _DeviceContainers.Remove(item);
                }
                else
                {
                    return false;
                }
            }
        }


        public void Clear()
        {
            lock (_DeviceContainers)
            {
                _DeviceContainers.Clear();
            }
        }

        public bool Contains(DeviceContainerBase item)
        {
            lock (_DeviceContainers)
            {
                return _DeviceContainers.Contains(item);
            }
        }

        public void CopyTo(DeviceContainerBase[] array, int arrayIndex)
        {
            lock (_DeviceContainers)
            {
                _DeviceContainers.CopyTo(array, arrayIndex);
            }
        }

        public IEnumerator<DeviceContainerBase> GetEnumerator()
        {
            return _DeviceContainers.GetEnumerator();
        }


        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public T GetDeviceContainer<T>(short readBlockKey)
            where T : DeviceContainerBase
        {
            var devContainer = GetDeviceContainer(readBlockKey);
            if (devContainer != null)
                return (T)devContainer;
            else
                return default(T);
        }

        public DeviceContainerBase GetDeviceContainer(short readBlockKey)
        {
            return this.FirstOrDefault(container => container.ReadBlockKey == readBlockKey);
        }

        public BitDeviceContainer B(string key)
        {
            return this.OfType<BitDeviceContainer>().FirstOrDefault(d => d.Key == key);
        }

        public WordDeviceContainer W(string key)
        {
            return this.OfType<WordDeviceContainer>().FirstOrDefault(d => d.Key == key);
        }

    }
}
