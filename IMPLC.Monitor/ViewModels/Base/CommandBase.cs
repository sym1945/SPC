﻿using System;
using System.Windows.Input;

namespace IMPLC.Monitor
{
    public class CommandBase : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public Func<object, bool> CanExecuteFunction { get; set; }

        public Action<object> ExecuteAction { get; set; }

        public bool CanExecute(object parameter)
        {
            return CanExecuteFunction?.Invoke(parameter) ?? true;
        }

        public void Execute(object parameter)
        {
            ExecuteAction?.Invoke(parameter);
        }

        public void OnCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

    }
}