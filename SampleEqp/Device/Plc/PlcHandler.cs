using SPC.Core;

namespace SampleEqp
{
    public class PlcHandler
    {
        private SPC.Core.SPC _Spc;

        public PlcHandler()
        {
            _Spc = new SPC.Core.SPC();
            _Spc.SetUp(
                PlcWatcherFactory.Make(),
                DeviceManagerFactory.Make(),
                PlcCommandFactory.Make()
                ) ;
        }

        public void Start()
        {
            _Spc.Start();
        }


        public void WriteProcessState(Prst prst)
        {
            var processStateDevice = _Spc.DeviceManager.W("PLC_STATUS")["ProcessState"].AsUShort();
            processStateDevice.Value = (ushort)prst;
        }

        public void CommandGlassLoad(GlassData glassData)
        {
            _Spc.SendCommand("GlassLoadCommand", new GlassCommandParam(glassData));
        }

        public void CommandGlassUnload(GlassData glassData)
        {
            _Spc.SendCommand("GlassUnloadCommand", new GlassCommandParam(glassData));
        }

        public void CommandProcessEnd()
        {
            _Spc.SendCommand("ProcessEndCommand", null);
        }


    }
}
