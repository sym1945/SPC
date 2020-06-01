using SPC.Core;

namespace SampleEqp
{
    public class PlcHandler : Spc<PlcConfiguration, PlcDeviceManager>
    {
        public Equipment Eqp { get; private set; }


        public PlcHandler(Equipment eqp)
        {
            Eqp = eqp;
            Eqp.PrstChanged += Equipment_PrstChanged;
            Eqp.GlassDataAdded += Equipment_GlassDataAdded;
            Eqp.GlassDataRemoved += Equipment_GlassDataRemoved;
            Eqp.ProcessDone += Equipment_ProcessDone;
        }

        private void Equipment_PrstChanged(Equipment eqp)
        {
            Devices.PlcStatusWords.ProcessState.Value = (ushort)eqp.Prst;
        }

        private void Equipment_GlassDataAdded(Equipment eqp, GlassData glass)
        {
            SendCommand(nameof(GlassLoadCommand), new GlassCommandParam(glass));
        }

        private void Equipment_ProcessDone()
        {
            SendCommand(nameof(ProcessEndCommand), new SpcCommandParameter());
        }

        private void Equipment_GlassDataRemoved(Equipment eqp, GlassData glass)
        {
            SendCommand(nameof(GlassUnloadCommand), new GlassCommandParam(glass));
        }


    }
}
