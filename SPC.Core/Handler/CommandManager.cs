using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SPC.Core
{
    public class CommandManager : CommandManagerBase
    {
        private List<PlcCommandActionBase> _CommandActions = new List<PlcCommandActionBase>();

        public IReadOnlyList<PlcCommandActionBase> CommandActions => _CommandActions;

        public void SetUp()
        {
            var commandActions = new List<PlcCommandActionBase>();
            var commandActionTypes = (
                Assembly
                .GetEntryAssembly()
                .GetExportedTypes()
                .Where(d => d.IsSubclassOf(typeof(PlcCommandActionBase)))
                .ToList()
            );

            foreach (var command in this)
            {
                var commandActionType = commandActionTypes.FirstOrDefault(d => d.Name == command.Command);
                if (commandActionType != null)
                {
                    var commandAction = (PlcCommandActionBase)Activator.CreateInstance(commandActionType);
                    commandAction.PlcCommand = command;
                    commandAction.Initialize();

                    _CommandActions.Add(commandAction);
                }
                    
            }
        }

    }
}
