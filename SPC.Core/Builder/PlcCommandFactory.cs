using System;
using System.Linq;

namespace SPC.Core
{
    public static class PlcCommandFactory
    {
        public static IPlcCommand Make(Type plcCommandType)
        {
            IPlcCommand command = null;

            foreach (var ctor in plcCommandType.GetConstructors())
            {
                var ctorParams = ctor.GetParameters()
                    .Select(paramInfo =>
                    {
                        var paramInstance = SPCContainer.GetSingleton(paramInfo.ParameterType);
                        if (paramInstance == null)
                            throw new ArgumentNullException($"{paramInfo.ParameterType} not found");
                        else
                            return paramInstance;
                    });

                command = (IPlcCommand)Activator.CreateInstance(plcCommandType, ctorParams.ToArray());
                if (command != null)
                    break;
            }

            return command;
        }
    }
}