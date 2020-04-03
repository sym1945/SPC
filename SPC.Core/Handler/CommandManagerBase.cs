using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPC.Core
{
    public abstract class CommandManagerBase : ICollection<PlcCommand>
    {
        private List<PlcCommand> _PlcCommands = new List<PlcCommand>();

        public int Count => _PlcCommands.Count;

        public bool IsReadOnly => true;

        public void Add(PlcCommand item)
        {
            _PlcCommands.Add(item);
        }

        public void Clear()
        {
            _PlcCommands.Clear();
        }

        public bool Contains(PlcCommand item)
        {
            return _PlcCommands.Contains(item);
        }

        public void CopyTo(PlcCommand[] array, int arrayIndex)
        {
            _PlcCommands.CopyTo(array, arrayIndex);
        }

        public IEnumerator<PlcCommand> GetEnumerator()
        {
            return _PlcCommands.GetEnumerator();
        }

        public bool Remove(PlcCommand item)
        {
            return _PlcCommands.Remove(item);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
