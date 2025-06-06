# TaskManager - WPF Task Management Application
## Software Engineering Course Project

### Title Page
**Student Information:**
- Full Name: [Your Name]
- Student Number: [Your Student Number]
- Administrative Group: [Your Group]

**Project Information:**
- Course: Software Engineering
- Topic: Task Management Application using WPF and MVVM Pattern

### Table of Contents
1. Introduction
2. Analysis of Existing Solutions
3. Design
4. Implementation
5. User Guide
6. Conclusion
7. References
8. Appendix

### 1. Introduction
TaskManager is a Windows desktop application designed to help users manage their daily tasks efficiently. The application is built using WPF (Windows Presentation Foundation) and follows the MVVM (Model-View-ViewModel) architectural pattern. It provides features for creating, editing, and managing tasks with different priority levels and checklists.

### 2. Analysis of Existing Solutions
Several task management applications were analyzed:

1. **Microsoft To Do**
   - Advantages:
     - Clean, intuitive interface
     - Integration with Microsoft ecosystem
     - Cross-platform availability
   - Disadvantages:
     - Requires Microsoft account
     - Limited customization options
     - Complex for simple task management

2. **Todoist**
   - Advantages:
     - Feature-rich
     - Natural language input
     - Project organization
   - Disadvantages:
     - Premium features behind paywall
     - Steep learning curve
     - Overwhelming for basic users

3. **Wunderlist (Discontinued)**
   - Advantages:
     - Simple interface
     - Easy to use
     - Good for basic task management
   - Disadvantages:
     - No longer maintained
     - Limited features
     - No cloud sync

Our solution aims to provide a balance between simplicity and functionality, focusing on essential features while maintaining a clean, user-friendly interface.

### 3. Design

#### 3.1 Target Users
The application is designed for:
- Individual users managing personal tasks
- Students organizing assignments and deadlines
- Professionals tracking work-related tasks
- Anyone needing a simple, efficient task management solution

#### 3.2 Data Structure
The application uses the following data models:

1. **Task Model**
```csharp
public class Task
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime DueDate { get; set; }
    public TaskImportance Importance { get; set; }
    public List<TaskCheckList> CheckList { get; set; }
}
```

2. **TaskCheckList Model**
```csharp
public class TaskCheckList
{
    public string Item { get; set; }
    public bool IsCompleted { get; set; }
}
```

3. **TaskImportance Enum**
```csharp
public enum TaskImportance
{
    Low,
    Medium,
    High,
    Critical
}
```

#### 3.3 User Interface Design
The application features:

1. **Main Window**
   - Task list view
   - Add new task button
   - Task filtering options
   - Color-coded priority indicators

2. **New Task Window**
   - Task title and description input
   - Due date selection
   - Priority level selection
   - Checklist management

#### 3.4 Software Architecture
The application follows the MVVM pattern:

1. **Model Layer**
   - Task and TaskCheckList classes
   - Data persistence using JSON

2. **View Layer**
   - XAML-based user interface
   - Data templates for task display
   - Custom controls for task management

3. **ViewModel Layer**
   - Task management logic
   - Command implementations
   - Data binding

4. **Services Layer**
   - TaskStorageService for data persistence
   - JSON serialization/deserialization

### 4. Implementation

#### 4.1 Data Storage
Tasks are stored in a JSON file located at:
```
%APPDATA%\TaskManager\tasks.json
```

The TaskStorageService handles all data operations:
```csharp
public class TaskStorageService
{
    private readonly string _storagePath;
    
    public TaskStorageService()
    {
        string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        string appFolder = Path.Combine(appDataPath, "TaskManager");
        Directory.CreateDirectory(appFolder);
        _storagePath = Path.Combine(appFolder, "tasks.json");
    }
}
```

#### 4.2 User Interface Implementation
The application uses XAML for UI definition:
```xaml
<Window x:Class="TaskManager.Views.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        Title="Task Manager" Height="450" Width="800">
    <Grid>
        <ListView ItemsSource="{Binding Tasks}">
            <ListView.ItemTemplate>
                <DataTemplate>
                    <local:TaskListItem />
                </DataTemplate>
            </ListView.ItemTemplate>
        </ListView>
    </Grid>
</Window>
```

#### 4.3 ViewModel Implementation
The MainWindowViewModel implements the application logic:
```csharp
public class MainWindowViewModel : INotifyPropertyChanged
{
    private ObservableCollection<Task> _tasks;
    public ObservableCollection<Task> Tasks
    {
        get => _tasks;
        set
        {
            _tasks = value;
            OnPropertyChanged();
        }
    }

    public ICommand AddTaskCommand { get; }
    public ICommand EditTaskCommand { get; }
    public ICommand DeleteTaskCommand { get; }
}
```

### 5. User Guide

#### 5.1 Creating a New Task
1. Click the "Add Task" button
2. Enter task details:
   - Title
   - Description
   - Due date
   - Priority level
3. Add checklist items if needed
4. Click "Save" to create the task

#### 5.2 Managing Tasks
- View all tasks in the main window
- Click a task to edit its details
- Use the delete button to remove tasks
- Mark checklist items as complete

#### 5.3 Task Priority
Tasks are color-coded based on priority:
- Green: Low priority
- Yellow: Medium priority
- Orange: High priority
- Red: Critical priority

### 6. Conclusion
The TaskManager application successfully implements a functional task management solution using WPF and MVVM. The application meets the initial design goals by providing:
- Clean, intuitive user interface
- Efficient task management
- Data persistence
- Priority-based organization
- Checklist functionality

Future improvements could include:
- Task categories
- Search functionality
- Task reminders
- Data export/import
- Cloud synchronization

### 7. References
1. Microsoft. (2023). WPF Documentation. https://docs.microsoft.com/en-us/dotnet/desktop/wpf/
2. Newtonsoft. (2023). Json.NET Documentation. https://www.newtonsoft.com/json
3. Microsoft. (2023). MVVM Pattern. https://docs.microsoft.com/en-us/dotnet/architecture/maui/mvvm

### 8. Appendix
[Include relevant code snippets and diagrams here] 