using System;
using System.Collections.Generic;
using System.Linq;

namespace SPC.Core
{
    public class PlcCommandManagerBuilder
    {
        private readonly List<Type> _PlcCommandTypes;

        public PlcCommandManagerBuilder()
        {
            _PlcCommandTypes = new List<Type>();
        }

        public PlcCommandManagerBuilder AddPlcCommand<T>()
            where T : ISpcCommand
        {
            _PlcCommandTypes.Add(typeof(T));
            return this;
        }

        public SpcCommandManager Build()
        {
            var plcCommands = _PlcCommandTypes
                .Select(commandType => PlcCommandFactory.Make(commandType))
                .ToList();

            var plcCommandManager = new SpcCommandManager();

            foreach (var plcCommand in plcCommands)
            {
                plcCommandManager.Add(plcCommand);
            }

            _PlcCommandTypes.Clear();

            return plcCommandManager;
        }


    }
}