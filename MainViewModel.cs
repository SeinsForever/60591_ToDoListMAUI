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
    string newTaskAmount;

    [ObservableProperty] 
    [NotifyPropertyChangedFor(nameof(IsNotBusy))]
    bool isBusy;

    [ObservableProperty]
    ObservableCollection<ToDoItem> taskList = new ObservableCollection<ToDoItem>();

    [ObservableProperty]
    ToDoItem taskToDelete;

    public bool IsNotBusy => !isBusy;

    [RelayCommand]
    void DeleteList()
    {
        IsBusy = true;

        TaskList.Clear();

        IsBusy = false;
    }

    [RelayCommand]
    void DeleteItem(object item)
    {
        IsBusy = true;

        TaskList.Remove((ToDoItem)item);

        IsBusy = false;
    }

    [RelayCommand]
    void EditItem(ToDoItem item)
    {
        IsBusy = true;

        if(item.IsEditing == false)
        {
            item.IsEditing = true;
        }
        else
        {
            item.IsEditing = false;
        }

        IsBusy = false;
    }

    [RelayCommand]
    void AddNewTask()
    {
        IsBusy = true;

        if (!(string.IsNullOrEmpty(newTaskText?.Trim())))
        {
            if(NewTaskAmount == "")
            {
                TaskList.Add(new ToDoItem() { TaskName = NewTaskText, Amount = 0, Done = false });
            }
            else
            {
                TaskList.Add(new ToDoItem() { TaskName = NewTaskText, Amount = Convert.ToInt32(NewTaskAmount), Done = false });
            }

            NewTaskText = "";
            NewTaskAmount = "";

        }

        IsBusy = false;
    }
}

public partial class ToDoItem : ObservableObject
{
    [ObservableProperty]
    string taskName;

    [ObservableProperty]
    int amount = 0;

    [ObservableProperty]
    bool done = false;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsNotEditing))]
    bool isEditing = false;

    public bool IsNotEditing => !isEditing;
}




