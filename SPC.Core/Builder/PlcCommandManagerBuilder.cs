﻿using System;
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
            where T : IPlcCommand
        {
            _PlcCommandTypes.Add(typeof(T));
            return this;
        }

        public PlcCommandManager Build()
        {
            var plcCommands = _PlcCommandTypes
                .Select(commandType => PlcCommandFactory.Make(commandType))
                .ToList();

            var plcCommandManager = new PlcCommandManager();

            foreach (var plcCommand in plcCommands)
            {
                plcCommandManager.Add(plcCommand);
            }

            return plcCommandManager;
        }


    }
}