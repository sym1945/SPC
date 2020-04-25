using System.Collections;
using System.Collections.Generic;

namespace SPC.Core
{
    public abstract class PlcCommandManagerBase : ICollection<IPlcCommand>
    {
        private readonly List<IPlcCommand> _PlcCommands = new List<IPlcCommand>();

        public int Count => _PlcCommands.Count;

        public bool IsReadOnly => true;

        public void Add(IPlcCommand item)
        {
            _PlcCommands.Add(item);
        }

        public void Clear()
        {
            _PlcCommands.Clear();
        }

        public bool Contains(IPlcCommand item)
        {
            return _PlcCommands.Contains(item);
        }

        public void CopyTo(IPlcCommand[] array, int arrayIndex)
        {
            _PlcCommands.CopyTo(array, arrayIndex);
        }

        public IEnumerator<IPlcCommand> GetEnumerator()
        {
            return _PlcCommands.GetEnumerator();
        }

        public bool Remove(IPlcCommand item)
        {
            return _PlcCommands.Remove(item);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
