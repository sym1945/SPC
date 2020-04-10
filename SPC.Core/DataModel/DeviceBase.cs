using System;
using System.ComponentModel;
using System.Windows.Input;

namespace SPC.Core
{
    public abstract class DeviceBase : INotifyPropertyChanged, ICommand
    {
        #region Public Properties

        public string FullAddress => $"{Device}{Address:X4}";

        public eDevice Device { get; set; }

        public eDeviceType DeviceType { get; set; }

        public string Key { get; set; }

        public short Address { get; set; }

        public short Offset { get; set; }

        public string Desc { get; set; }

        #endregion


        #region Events

        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler CanExecuteChanged;
        internal event Action<DeviceReadWriteInfo> WriteToPlc;
        internal event Action<DeviceReadWriteInfo> ReadFromPlc;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public void OnCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
        protected virtual void OnWriteToPlc(DeviceReadWriteInfo writeInfo)
        {
            WriteToPlc?.Invoke(writeInfo);
        }
        protected virtual void OnReadFromPlc(DeviceReadWriteInfo readInfo)
        {
            ReadFromPlc?.Invoke(readInfo);
        }

        #endregion


        #region Public Methods

        public virtual bool CanExecute(object parameter)
        {
            return true;
        }

        public abstract void Execute(object parameter = null);

        #endregion

    }
}
