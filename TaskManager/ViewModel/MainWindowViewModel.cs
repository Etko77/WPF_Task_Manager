using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TaskManager.Views;

namespace TaskManager.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand IOpenNewWindow => new RelayCommand(OpenNewWindow);

        private void OpenNewWindow()
        {
            NewTaskWindow newTaskWindow = new NewTaskWindow();
            newTaskWindow.Show();
        }


        //public ICommand IOpenNewWindow => new RelayCommand(OpenNewWindow);
        //private void OpenNewWindow()
        //{
        //    NewTaskWindow newTaskWindow = new NewTaskWindow();
        //    newTaskWindow.Show();
        //}

        protected virtual void OnPropertChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
