using System;
using System.Windows.Input;

namespace SPC.WPF
{
    public class CommandBase : ICommand
    {
        public event Action<object> ExecuteAction;

        public event EventHandler CanExecuteChanged;


        public CommandBase(Action<object> executeAction)
        {
            ExecuteAction += executeAction;
        }


        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            OnExecute(parameter);
        }

        protected void OnExecute(object parameter)
        {
            ExecuteAction?.Invoke(parameter);
        }

        protected void OnCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

    }
}

