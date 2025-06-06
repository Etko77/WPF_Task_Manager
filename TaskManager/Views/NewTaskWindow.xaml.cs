using System;
using System.Windows;
using System.Windows.Controls;
using TaskManager.Models;

namespace TaskManager.Views
{
    /// <summary>
    /// Interaction logic for NewTaskWindow.xaml
    /// </summary>
    public partial class NewTaskWindow : Window
    {
        public Task NewTask { get; private set; }
        private readonly Task _existingTask;

        public NewTaskWindow(Task existingTask = null)
        {
            InitializeComponent();
            _existingTask = existingTask;

            if (existingTask != null)
            {
                Title = "Edit Task";
                TitleTextBox.Text = existingTask.Title;
                DescriptionTextBox.Text = existingTask.Description;
                DueDatePicker.SelectedDate = existingTask.DueDate;
                ImportanceComboBox.SelectedIndex = (int)existingTask.TaskImportance;
                CategoryComboBox.SelectedIndex = (int)existingTask.TaskCategory;
            }
            else
            {
                DueDatePicker.SelectedDate = DateTime.Today;
                ImportanceComboBox.SelectedIndex = 0;
                CategoryComboBox.SelectedIndex = 0;
            }
        }

        private void DueDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DueDatePicker.SelectedDate < DateTime.Today)
            {
                MessageBox.Show("Due date cannot be in the past.", "Invalid Date", MessageBoxButton.OK, MessageBoxImage.Warning);
                DueDatePicker.SelectedDate = DateTime.Today;
            }
        }

        private void ImportanceComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Handle importance selection if needed
        }

        private void CategoryComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Handle category selection if needed
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void CreateTaskButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TitleTextBox.Text))
            {
                MessageBox.Show("Please enter a task title.", "Missing Title", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!DueDatePicker.SelectedDate.HasValue)
            {
                MessageBox.Show("Please select a due date.", "Missing Due Date", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            NewTask = new Task
            {
                Id = _existingTask?.Id ?? 0,
                Title = TitleTextBox.Text,
                Description = DescriptionTextBox.Text,
                DueDate = DueDatePicker.SelectedDate.Value,
                StartDate = _existingTask?.StartDate ?? DateTime.Now,
                IsCompleye = _existingTask?.IsCompleye ?? false,
                TaskSate = _existingTask?.TaskSate ?? TaskState.NotStarted,
                TaskImportance = (TaskImportance)ImportanceComboBox.SelectedIndex,
                TaskCategory = (TaskCategory)CategoryComboBox.SelectedIndex
            };

            DialogResult = true;
            Close();
        }
    }
}
