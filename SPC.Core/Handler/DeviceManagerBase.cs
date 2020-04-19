using System.Collections;
using System.Collections.Generic;
using System.Linq;

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

        public T GetDeviceContainer<T>(string key)
            where T : DeviceContainerBase
        {
            return GetDeviceContainer(key) as T;
        }

        public DeviceContainerBase GetDeviceContainer(string key)
        {
            return this.FirstOrDefault(container => container.Key == key);
        }

        public BitDeviceContainer B(string key)
        {
            return this.OfType<BitDeviceContainer>().FirstOrDefault(container => container.Key == key);
        }

        public WordDeviceContainer W(string key)
        {
            return this.OfType<WordDeviceContainer>().FirstOrDefault(container => container.Key == key);
        }

    }
}
