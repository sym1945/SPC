namespace SPC.Core
{
    public interface IPlcComm : IPlcReadWriter
    {
        bool IsOpen { get; }

        short Open();

        short Close();
    }

}
