using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SPC.Core
{
    public class SpcCommandManager : PlcCommandManagerBase
    {
        public void SetUp(Assembly assembly)
        {
            var commandTypes = (
                assembly
                .GetExportedTypes()
                .Where(d => d.IsSubclassOf(typeof(ISpcCommand)))
                .ToList()
            );

            foreach (var commandType in commandTypes)
            {
                Add(PlcCommandFactory.Make(commandType));
            }
        }

    }
}
