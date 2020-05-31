namespace SPC.Core
{
    public sealed class PlcReadWriter
    {
        private SpcCommunication _Comm;


        public PlcReadWriter(SpcCommunication comm)
        {
            _Comm = comm;
        }

        public bool WriteToPlc(DeviceReadWriteInfo writeInfo)
        {
            switch (writeInfo)
            {
                default:
                    return false;

                case BitReadWriteInfo bInfo:
                    return _Comm.SetBit(bInfo.Device, bInfo.Address, bInfo.Value) == 0;

                case WordReadWriteInfo wInfo:
                    return _Comm.BlockWrite(wInfo.Device, wInfo.Address, wInfo.Size, ref wInfo.Value) == 0;

            }
        }


        public bool ReadFromPlc(DeviceReadWriteInfo readInfo)
        {
            switch (readInfo)
            {
                default:
                    return false;

                case WordReadWriteInfo wInfo:
                    return _Comm.BlockRead(wInfo.Device, wInfo.Address, wInfo.Size, ref wInfo.Value) == 0;

            }

        }

    }
}
