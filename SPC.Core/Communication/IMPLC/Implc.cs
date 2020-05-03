using IMPLC.Service;

namespace SPC.Core.Communication.IMPLC
{
    public class Implc : PlcComm
    {
        private IPLCServiceClient _Client;
        private IPLCServiceObject _PlcService;

        public Implc(string serviceUri = "ipc://localhost:9090")
        {
            _Client = PLCServiceProvider.GetServiceClient(PLCServiceType.IPC);
        }

        public override short Open()
        {
            _PlcService = _Client.Connect("ipc://localhost:9090");

            return _PlcService?.Open() ?? 99;
        }

        public override short Close()
        {
            if (_PlcService == null)
                return 99;

            return _PlcService.Close();
        }

        public override short BlockRead(eDevice device, short deviceNo, short size, ref short[] buf)
        {
            return _PlcService?.ReadBlock((short)device, deviceNo, size, ref buf) ?? 99;
        }

        public override short BlockWrite(eDevice device, short deviceNo, short size, ref short[] buf)
        {
            return _PlcService?.WriteBlock((short)device, deviceNo, size, ref buf) ?? 99;
        }

        public override short SetBit(eDevice device, short devno, bool set)
        {
            return _PlcService?.SetBit((short)device, devno, set) ?? 99;
        }
    }
}