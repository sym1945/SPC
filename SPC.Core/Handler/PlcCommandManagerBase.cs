using System.Collections;
using System.Collections.Generic;

namespace SPC.Core
{
    public abstract class PlcCommandManagerBase : ICollection<ISpcCommand>
    {
        private readonly List<ISpcCommand> _PlcCommands = new List<ISpcCommand>();

        public int Count => _PlcCommands.Count;

        public bool IsReadOnly => true;

        public void Add(ISpcCommand item)
        {
            _PlcCommands.Add(item);
        }

        public void Clear()
        {
            _PlcCommands.Clear();
        }

        public bool Contains(ISpcCommand item)
        {
            return _PlcCommands.Contains(item);
        }

        public void CopyTo(ISpcCommand[] array, int arrayIndex)
        {
            _PlcCommands.CopyTo(array, arrayIndex);
        }

        public IEnumerator<ISpcCommand> GetEnumerator()
        {
            return _PlcCommands.GetEnumerator();
        }

        public bool Remove(ISpcCommand item)
        {
            return _PlcCommands.Remove(item);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
