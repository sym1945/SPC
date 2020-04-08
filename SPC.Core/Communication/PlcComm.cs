using System;
using System.ComponentModel;

namespace SPC.Core
{
    public abstract class PlcComm : IPlcComm
    {

        #region Private Members
        private bool _IsOpen = false;
        #endregion


        #region Public Members
        public bool IsOpen
        {
            get => _IsOpen;
            internal set
            {
                if (_IsOpen == value)
                    return;
                _IsOpen = value;

                if (_IsOpen)
                    OnPlcConnected();
                else
                    OnPlcDisconnected();
            }
        }
        #endregion


        #region Public Methods
        public abstract short Open();

        public abstract short Close();

        public abstract short BlockRead(eDevice device, short deviceNo, short size, ref short[] buf);

        public abstract short BlockWrite(eDevice device, short deviceNo, short size, ref short[] buf);

        public abstract short SetBit(eDevice device, short devno, bool set);
        #endregion


        #region Event
        public event Action PlcConnected;
        public event Action PlcDisconnected;

        private void OnPlcConnected()
        {
            PlcConnected?.Invoke();
        }

        private void OnPlcDisconnected()
        {
            PlcDisconnected?.Invoke();
        }
        #endregion

    }
}
