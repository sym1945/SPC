using System;
using System.ComponentModel;
using System.Windows.Input;

namespace SPC.Core
{
    public abstract class DeviceBase : IDevice, INotifyPropertyChanged, ICommand
    {
        public string FullAddress => $"{Device}{Address:X4}";

        public eDevice Device { get; set; }

        public eDeviceType DeviceType { get; set; }
        
        public string Key { get; set; }

        public short Address { get; set; }

        public short Offset { get; set; }

        public string Desc { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler CanExecuteChanged;

        

        public virtual bool CanExecute(object parameter)
        {
            return true;
        }

        public virtual void Execute(object parameter = null)
        {
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event Func<PlcWriteInfo, bool> WriteToPlc;

        protected virtual void OnWriteToPlc(PlcWriteInfo plcWriteInfo)
        {
            WriteToPlc?.Invoke(plcWriteInfo);
        }

    }
}
