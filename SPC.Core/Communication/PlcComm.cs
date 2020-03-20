using System.ComponentModel;

namespace SPC.Core
{
    public abstract class PlcComm : IPlcComm, INotifyPropertyChanged
    {

        #region Private Members
        private bool _IsOpen = false;
        #endregion


        #region Public Members
        public bool IsOpen
        {
            get => _IsOpen;
            set
            {
                if (_IsOpen == value)
                    return;
                _IsOpen = value;
                OnPropertyChanged(nameof(IsOpen));
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
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string PropertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        #endregion

    }
}
