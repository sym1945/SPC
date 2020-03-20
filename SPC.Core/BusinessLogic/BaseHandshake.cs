namespace SPC.Core
{
    public class BaseHandshake
    {
        #region Private Members

        protected DeviceHandler _DeviceHandler = null;

        #endregion

        #region Constructor

        public BaseHandshake(DeviceHandler deviceHandler)
        {
            _DeviceHandler = deviceHandler;
        }

        #endregion
    }
}
