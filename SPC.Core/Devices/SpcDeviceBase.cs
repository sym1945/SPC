using System;
using System.ComponentModel;
using System.Windows.Input;

namespace SPC.Core
{
    public abstract class SpcDeviceBase : INotifyPropertyChanged, ICommand
    {
        #region Public Properties

        public string FullAddress
        {
            get
            {
                if (Address > ushort.MaxValue)
                    return $"{Device}{Address:X8}";
                else
                    return $"{Device}{Address:X4}";
            }
        }

        public EDevice Device { get; set; }

        public EDeviceType DeviceType { get; set; }

        public string Key { get; set; }

        public int Address { get; set; }

        public int Offset { get; set; }

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

        public virtual void OnValueChanged() { }

        #endregion

    }
}
