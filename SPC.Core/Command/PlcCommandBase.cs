namespace SPC.Core
{
    public abstract class PlcCommandBase<T> : IPlcCommand
        where T : SPCBase
    {
        public DeviceManager Devices => SPCContainer.GetSPC<T>().DeviceManager;

        // TODO : 임시로 추가... 
        public T SPCInstance => SPCContainer.GetSPC<T>();

    }

}
