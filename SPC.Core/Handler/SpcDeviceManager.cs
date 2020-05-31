namespace SPC.Core
{
    public class SpcDeviceManager : DeviceManagerBase
    {
        private bool _IsSetup = false;

       
        public bool IsSetUp => _IsSetup;


        #region Constructor

        public SpcDeviceManager()
        {
        } 

        #endregion




        public void SetUp()
        {
            if (_IsSetup)
                return;

            //foreach (DeviceContainerBase devContainer in this)
            //{
            //    foreach(var device in devContainer)
            //    {
            //        device.Device = devContainer.Device;
            //        device.Address = (short)(devContainer.StartAddress + device.Offset);
            //    }
            //}

            _IsSetup = true;
        }

    }
}
