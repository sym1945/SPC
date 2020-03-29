using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace SPC.Core
{
    public class DeviceManagerBase : ICollection<IDeviceContainer>
    {
        private List<IDeviceContainer> _DeviceContainers;

        public int Count => _DeviceContainers.Count;

        public bool IsReadOnly => false;


        public DeviceManagerBase()
        {
            _DeviceContainers = new List<IDeviceContainer>();
        }



        public void Add(IDeviceContainer item)
        {
            lock (_DeviceContainers)
            {
                _DeviceContainers.Add(item);
            }
        }

        public bool Remove(IDeviceContainer item)
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

        public bool Contains(IDeviceContainer item)
        {
            lock (_DeviceContainers)
            {
                return _DeviceContainers.Contains(item);
            }
        }

        public void CopyTo(IDeviceContainer[] array, int arrayIndex)
        {
            lock (_DeviceContainers)
            {
                _DeviceContainers.CopyTo(array, arrayIndex);
            }
        }

        public IEnumerator<IDeviceContainer> GetEnumerator()
        {
            return _DeviceContainers.GetEnumerator();
        }


        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public T GetDeviceContainer<T>(short readBlockKey)
        {
            var devContainer = GetDeviceContainer(readBlockKey);
            if (devContainer != null)
                return (T)devContainer;
            else
                return default(T);
        }

        public IDeviceContainer GetDeviceContainer(short readBlockKey)
        {
            return this.FirstOrDefault(container => container.ReadBlockKey == readBlockKey);
        }

        public BitDeviceContainer B(string key)
        {
            return this.OfType<BitDeviceContainer>().FirstOrDefault(d => d.Description == key);
        }

        public WordDeviceContainer W(string key)
        {
            return this.OfType<WordDeviceContainer>().FirstOrDefault(d => d.Description == key);
        }

    }
}
