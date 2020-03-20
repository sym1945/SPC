namespace SPC.Core
{
    public interface IPlcComm
    {
        short Open();

        short Close();

        short BlockWrite(eDevice device, short deviceNo, short size, ref short[] buf);

        short BlockRead(eDevice device, short deviceNo, short size, ref short[] buf);

        short SetBit(eDevice device, short devno, bool set);
        
    }

}
