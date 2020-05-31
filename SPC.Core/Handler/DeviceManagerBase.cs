using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SPC.Core
{
    public class DeviceManagerBase : ICollection<SpcDeviceContainerBase>
    {
        private readonly List<SpcDeviceContainerBase> _DeviceContainers;

        protected PlcReadWriter _PlcReadWriter;


        private SpcCommunication _Comm;
        internal SpcCommunication Comm
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
            _DeviceContainers = new List<SpcDeviceContainerBase>();
        }

        #endregion


        public void Add(SpcDeviceContainerBase item)
        {
            lock (_DeviceContainers)
            {
                _DeviceContainers.Add(item);
            }
        }

        public bool Remove(SpcDeviceContainerBase item)
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

        public bool Contains(SpcDeviceContainerBase item)
        {
            lock (_DeviceContainers)
            {
                return _DeviceContainers.Contains(item);
            }
        }

        public void CopyTo(SpcDeviceContainerBase[] array, int arrayIndex)
        {
            lock (_DeviceContainers)
            {
                _DeviceContainers.CopyTo(array, arrayIndex);
            }
        }

        public IEnumerator<SpcDeviceContainerBase> GetEnumerator()
        {
            return _DeviceContainers.GetEnumerator();
        }


        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public T GetDeviceContainer<T>(string key)
            where T : SpcDeviceContainerBase
        {
            return GetDeviceContainer(key) as T;
        }

        public SpcDeviceContainerBase GetDeviceContainer(string key)
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
