namespace SPC.Core
{
    public interface IPlcReadWriter
    {
        short BlockWrite(EDevice device, int deviceNo, int size, ref short[] buf);

        short BlockRead(EDevice device, int deviceNo, int size, ref short[] buf);

        short SetBit(EDevice device, int devno, bool set);
    }
}
