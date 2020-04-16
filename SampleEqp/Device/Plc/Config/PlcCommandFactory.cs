using SPC.Core;

namespace SampleEqp
{
    public static class PlcCommandFactory
    {
        public static PlcCommandManager Make()
        {
            return new PlcCommandManager
            {
                new PlcCommand
                {
                    Container = "PLC_COMMAND",
                    Device = "GlassInspLoadStart",
                    Trigger = CommandTrigger.BitOn,
                    Command = "GlassLoadCommand"
                },
                new PlcCommand
                {
                    Container = "PLC_COMMAND",
                    Device = "UnloadStart",
                    Trigger = CommandTrigger.BitOn,
                    Command = "GlassUnloadCommand"
                },
                new PlcCommand
                {
                    Container = "PLC_COMMAND",
                    Device = "GlassInspLoadStart",
                    Trigger = CommandTrigger.BitOn,
                    Command = "ProcessEndCommand"
                },

            };
        }
    }
}