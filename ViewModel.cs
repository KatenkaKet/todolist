using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
/*
using CoreNFC;
using todolist.Modelll;
*/

namespace todolist.ViewModel;

public class ViewModel: INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    public Color colortask;
    public Modelll.Modelll task;
    public ICommand CommandAddTask { get;  }
    public ICommand CommandDeleteTask { get; }
    public ICommand CommandChangeColor { get; set; }
    public ICommand CommandChooseColor { get; set; }
    
    public ObservableCollection<Modelll.Modelll> ListTaskItems 
                                                { get; set; } = new ();
    
    

    public ViewModel()
    {
        task = new Modelll.Modelll();
        CommandAddTask = new Command<string>(AddTask);
        CommandDeleteTask = new Command<Modelll.Modelll>(DeleteTask);
        CommandChangeColor = new Command<string>(ChangeColor);
        CommandChooseColor = new Command<Modelll.Modelll>(ChooseColor);
        CheckColor = Colors.Aqua;
    }

    private void AddTask(string entry)
    {
        ListTaskItems.Add(new Modelll.Modelll()
        {
            TaskName = entry,
            TaskCompleted = false,
            TaskColor = colortask
        });
        CheckColor = Colors.Aqua;
    }

    private void DeleteTask(Modelll.Modelll task)
    {
        ListTaskItems.Remove(task);
    }
    
    public Color CheckColor
    {
        get => colortask;
        set
        {
            if (Equals(value, colortask)) return;
            colortask = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CheckColor)));
        }
    }

    private void ChangeColor(string text)
    {
        CheckColor = text switch
        {
            "Red" => Colors.Red,
            "Blue" => Colors.Blue,
            "Yellow" => Colors.Yellow,
            _ => CheckColor
        };
    }

    private async void ChooseColor(Modelll.Modelll task)
    {
        if (Application.Current == null) return;
        if (Application.Current.MainPage == null) return;
        var text = await Application.Current.MainPage.DisplayActionSheet(
            "Choose color", "Exit", null,
            "Red", "Yellow", "Blue");
        task.TaskColor = text switch
        {
            "Red" => Colors.Red,
            "Blue" => Colors.Blue,
            "Yellow" => Colors.Yellow,
            _ => task.TaskColor
        };
    }

    public Modelll.Modelll SelectTask
    {
        get => task;
        set
        {
            if (task != value)
            {
                task = value;
                if (task != null)
                {
                    EditTask();
                }
            }
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectTask)));
        }
    }
    
    
    private async void EditTask()
    {
        if (Application.Current == null) return;
        if (Application.Current.MainPage == null) return;
        var text = await Application.Current.MainPage.DisplayPromptAsync(
            title: "Edit task", message: " ",
            initialValue: SelectTask.TaskName);
        SelectTask.TaskName = text;
        
        SelectTask = null;
        
    }
}