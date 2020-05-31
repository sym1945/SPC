using SPC.Core;

namespace SampleEqp
{
    public class PlcHandler : SPCBase
    {
        private Equipment _Eqp;

        public PlcHandler(Equipment eqp) : base(new Implc())
        {
            _Eqp = eqp;
            _Eqp.PrstChanged += Equipment_PrstChanged;
            _Eqp.GlassDataAdded += Equipment_GlassDataAdded;
            _Eqp.GlassDataRemoved += Equipment_GlassDataRemoved;
            _Eqp.ProcessDone += Equipment_ProcessDone;
        }

        public override SpcCommandManager BuildPlcCommandManger()
        {
            return new PlcCommandManagerBuilder()
                .AddPlcCommand<GlassLoadCommand>()
                .AddPlcCommand<ProcessEndCommand>()
                .AddPlcCommand<GlassUnloadCommand>()
                .Build();
        }

        public override SpcDeviceWatcher BuildPlcWatcher()
        {
            return PlcWatcherFactory.Make();
        }

        public override SpcDeviceManager BuildDeviceManager()
        {
            return DeviceManagerFactory.Make();
        }


        private void Equipment_PrstChanged(Equipment eqp)
        {
            var processStateDevice = DeviceManager.W("EQP_STATUS")["ProcessState"].AsUShort();
            processStateDevice.Value = (ushort)eqp.Prst;
        }

        private void Equipment_GlassDataAdded(Equipment eqp, GlassData glass)
        {
            SendCommand("GlassLoadCommand", new GlassCommandParam(glass));
        }

        private void Equipment_ProcessDone()
        {
            SendCommand("ProcessEndCommand", new PlcCommandParameter());
        }

        private void Equipment_GlassDataRemoved(Equipment eqp, GlassData glass)
        {
            SendCommand("GlassUnloadCommand", new GlassCommandParam(glass));
        }


    }
}
