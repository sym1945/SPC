using IMPLC.Service;

namespace SPC.Core
{
    public class Implc : PlcComm
    {

        private readonly IPLCServiceClient _Client;

        public IPLCServiceObject ServiceObject { get; private set; }


        public Implc(string serviceUri = "ipc://localhost:9090")
        {
            _Client = PLCServiceProvider.GetServiceClient(PLCServiceType.IPC);
            ServiceObject = _Client.Connect(serviceUri);
        }

        public override short Open()
        {
            var result = (short)(ServiceObject != null ? 0 : 99);

            IsOpen = (result == 0);

            return result;
        }

        public override short Close()
        {
            ServiceObject = null;
            return (short)(_Client.Disconnect() ? 0 : 99);
        }

        public override short BlockRead(eDevice device, short deviceNo, short size, ref short[] buf)
        {
            return ServiceObject?.ReadBlock((short)device, deviceNo, size, ref buf) ?? 99;
        }

        public override short BlockWrite(eDevice device, short deviceNo, short size, ref short[] buf)
        {
            return ServiceObject?.WriteBlock((short)device, deviceNo, size, ref buf) ?? 99;
        }

        public override short SetBit(eDevice device, short devno, bool set)
        {
            return ServiceObject?.SetBit((short)device, devno, set) ?? 99;
        }
    }
}