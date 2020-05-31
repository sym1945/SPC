using IMPLC.Service;

namespace SPC.Core
{
    public class Implc : SpcCommunication
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

        public override short BlockRead(EDevice device, int deviceNo, int size, ref short[] buf)
        {
            return ServiceObject?.ReadBlock((short)device, (short)deviceNo, (short)size, ref buf) ?? 99;
        }

        public override short BlockWrite(EDevice device, int deviceNo, int size, ref short[] buf)
        {
            return ServiceObject?.WriteBlock((short)device, (short)deviceNo, (short)size, ref buf) ?? 99;
        }

        public override short SetBit(EDevice device, int devno, bool set)
        {
            return ServiceObject?.SetBit((short)device, (short)devno, set) ?? 99;
        }
    }
}