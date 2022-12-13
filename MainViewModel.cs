using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ToDoList;

public partial class MainViewModel : ObservableObject
{
    public MainViewModel()
    {
        Console.Write("Hello");
    }

    [ObservableProperty]
    string newTaskText;

    [ObservableProperty] 
    [NotifyPropertyChangedFor(nameof(IsNotBusy))]
    bool isBusy;

    [ObservableProperty]
    ObservableCollection<ToDoItem> taskList = new ObservableCollection<ToDoItem>();

    public bool IsNotBusy => !isBusy;

    [RelayCommand]
    void DeleteTask()
    {
        return;
    }

    [RelayCommand]
    void AddNewTask()
    {
        IsBusy = true;
        
        TaskList.Add(new ToDoItem(){TaskName = NewTaskText});
        NewTaskText = "";

        IsBusy = false;
    }
}

public partial class ToDoItem : ObservableObject
{
    [ObservableProperty]
    string taskName;

    [ObservableProperty]
    bool done = false;
}




