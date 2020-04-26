namespace SPC.Core
{
    public abstract class PlcCommandBase<T> : IPlcCommand
        where T : SPCBase
    {
        public DeviceManager Devices => SPCContainer.GetSPC<T>().DeviceManager;
    }

}
