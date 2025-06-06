using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using TaskManager.Models;
using TaskManager.Services;
using TaskManager.Views;

namespace TaskManager.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private readonly TaskStorageService _storageService;
        private ObservableCollection<Task> _tasks;
        public ObservableCollection<Task> Tasks
        {
            get => _tasks;
            set
            {
                _tasks = value;
                OnPropertyChanged(nameof(Tasks));
                SaveTasksAsync();
            }
        }

        private Task _selectedTask;
        public Task SelectedTask
        {
            get => _selectedTask;
            set
            {
                _selectedTask = value;
                OnPropertyChanged(nameof(SelectedTask));
            }
        }

        public ICommand OpenNewTaskCommand => new RelayCommand(OpenNewTaskWindow);
        public ICommand EditTaskCommand => new RelayCommand(EditTask, CanEditTask);
        public ICommand DeleteTaskCommand => new RelayCommand(DeleteTask, CanDeleteTask);
        public ICommand CompleteTaskCommand => new RelayCommand(CompleteTask, CanCompleteTask);

        public MainWindowViewModel()
        {
            _storageService = new TaskStorageService();
            LoadTasksAsync();
        }

        private async void LoadTasksAsync()
        {
            try
            {
                var tasks = await _storageService.LoadTasksAsync();
                Tasks = new ObservableCollection<Task>(tasks);
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show($"Failed to load tasks: {ex.Message}", "Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                Tasks = new ObservableCollection<Task>();
            }
        }

        private async void SaveTasksAsync()
        {
            try
            {
                await _storageService.SaveTasksAsync(Tasks.ToList());
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show($"Failed to save tasks: {ex.Message}", "Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }
        }

        private void OpenNewTaskWindow()
        {
            var newTaskWindow = new NewTaskWindow();
            if (newTaskWindow.ShowDialog() == true && newTaskWindow.NewTask != null)
            {
                Tasks.Add(newTaskWindow.NewTask);
            }
        }

        private void EditTask()
        {
            if (SelectedTask == null) return;

            var editTaskWindow = new NewTaskWindow(SelectedTask);
            if (editTaskWindow.ShowDialog() == true && editTaskWindow.NewTask != null)
            {
                var index = Tasks.IndexOf(SelectedTask);
                Tasks[index] = editTaskWindow.NewTask;
                SelectedTask = editTaskWindow.NewTask;
            }
        }

        private bool CanEditTask()
        {
            return SelectedTask != null;
        }

        private void DeleteTask()
        {
            if (SelectedTask == null) return;
            Tasks.Remove(SelectedTask);
            SelectedTask = null;
        }

        private bool CanDeleteTask()
        {
            return SelectedTask != null;
        }

        private void CompleteTask()
        {
            if (SelectedTask == null) return;
            SelectedTask.IsCompleye = true;
            SelectedTask.TaskSate = TaskState.Complete;
            OnPropertyChanged(nameof(SelectedTask));
        }

        private bool CanCompleteTask()
        {
            return SelectedTask != null && !SelectedTask.IsCompleye;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
