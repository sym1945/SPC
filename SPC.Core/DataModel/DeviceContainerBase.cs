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
        public eDevice Device { get; set; }
        public eDeviceType DeviceType { get; set; }
        public short StartAddress { get; set; }
        public string Description { get; set; }

        public int Count => throw new NotImplementedException();

        public bool IsReadOnly => throw new NotImplementedException();

        public void Add(IDevice item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(IDevice item)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
