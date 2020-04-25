namespace SPC.Core
{
    public abstract class PlcCommandBase<T> : IPlcCommand
        where T : SPC
    {
        public DeviceManager Devices => SPCContainer.GetSPC<T>().DeviceManager;
    }

}
