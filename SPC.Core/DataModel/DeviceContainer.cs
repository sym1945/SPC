namespace SPC.Core
{
    public class DeviceContainer<T> : DeviceContainerBase
        where T : DeviceBase
    {
        

        new public T this[string key]
        {
            get
            {
                return (T)base[key];
            }
        }


        public DeviceContainer()
        {
        }
        public DeviceContainer(eDevice device, eDeviceType deviceType, short startAddress, string desc = "") : this()
        {
            Device = device;
            DeviceType = deviceType;
            StartAddress = startAddress;
            Key = desc;
        }
    }
}
