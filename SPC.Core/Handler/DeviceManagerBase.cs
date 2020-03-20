using System;
using System.Collections;
using System.Collections.Generic;

namespace SPC.Core
{
    public class DeviceManagerBase : ICollection<IDeviceContainer>
    {
        public int Count => throw new NotImplementedException();

        public bool IsReadOnly => throw new NotImplementedException();

        public void Add(IDeviceContainer item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(IDeviceContainer item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(IDeviceContainer[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<IDeviceContainer> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool Remove(IDeviceContainer item)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
