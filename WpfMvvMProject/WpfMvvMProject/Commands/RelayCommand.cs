﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfMvvMProject.Commands
{
    public class RelayCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private Action DoWork;
        public RelayCommand(Action work)
        {
            DoWork = work;

        }


        public void Execute(object parameter)
        {
            DoWork();
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }
    }
}
