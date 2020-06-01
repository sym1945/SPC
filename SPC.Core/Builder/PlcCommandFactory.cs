using System;
using System.Linq;

namespace SPC.Core
{
    public static class PlcCommandFactory
    {
        public static ISpcCommand Make(Type plcCommandType)
        {
            ISpcCommand command = null;

            foreach (var ctor in plcCommandType.GetConstructors())
            {
                var ctorParams = ctor.GetParameters()
                    .Select(paramInfo =>
                    {
                        var paramInstance = SpcContainer.GetSingleton(paramInfo.ParameterType);
                        if (paramInstance == null)
                            throw new ArgumentNullException($"{paramInfo.ParameterType} not found");
                        else
                            return paramInstance;
                    });

                command = (ISpcCommand)Activator.CreateInstance(plcCommandType, ctorParams.ToArray());
                if (command != null)
                    break;
            }

            return command;
        }
    }
}