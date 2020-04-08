namespace SPC.Core
{
    public interface IPlcReadWriter
    {
        short BlockWrite(eDevice device, short deviceNo, short size, ref short[] buf);

        short BlockRead(eDevice device, short deviceNo, short size, ref short[] buf);

        short SetBit(eDevice device, short devno, bool set);
    }
}
