﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TaskManager.ViewModel
{
    public class RelayCommand: ICommand
    {
        private readonly Action _execute;
        private readonly Func<bool> _canExecute;
        private Action openNewWindow;

        public RelayCommand(Action openNewWindow)
        {
            _execute = openNewWindow ?? throw new ArgumentNullException(nameof(openNewWindow));
            this.openNewWindow = openNewWindow;
        }


        public RelayCommand(Action execute, Func<bool> canExecute)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value;  }
        }
        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute();
        }
        public void Execute(object parameter)
        {
            _execute();
        }
    }
    public class RelayCommand<T> : ICommand
    {
        private readonly Action _execute;
        private readonly Func<bool> _canExecute;

        public RelayCommand(Action execute, Func<bool> canExecute)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute();
        }
        public void Execute(object parameter)
        {
            _execute();
        }
    }
}
