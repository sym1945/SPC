using SPC.Core;

namespace SampleEqp
{
    public class PlcHandler : SPC.Core.SPC
    {
        public PlcHandler()
        {
            //_Spc = new SPC.Core.SPC();
            //_Spc.SetUp(
            //    PlcWatcherFactory.Make(),
            //    DeviceManagerFactory.Make(),
            //    PlcCommandFactory.Make()
            //    ) ;
            //_Spc.CommandManager.AddCommandActions(
            //    new GlassLoadCommand(),
            //    new GlassUnloadCommand(),
            //    new ProcessEndCommand()
            //    );
        }

        public override PlcCommandManager BuildPlcCommandManger()
        {
            return new PlcCommandManagerBuilder()
                .Build();
        }

        public override PlcWatcher BuildPlcWatcher()
        {
            return PlcWatcherFactory.Make();
        }

        public override DeviceManager BuildDeviceManager()
        {
            return DeviceManagerFactory.Make();
        }






        public void WriteProcessState(Prst prst)
        {
            var processStateDevice = DeviceManager.W("EQP_STATUS")["ProcessState"].AsUShort();
            processStateDevice.Value = (ushort)prst;
        }

        public void CommandGlassLoad(GlassData glassData)
        {
            SendCommand("GlassLoadCommand", new GlassCommandParam(glassData));
        }

        public void CommandGlassUnload(GlassData glassData)
        {
            SendCommand("GlassUnloadCommand", new GlassCommandParam(glassData));
        }

        public void CommandProcessEnd()
        {
            SendCommand("ProcessEndCommand", new PlcCommandParameter());
        }


    }
}
