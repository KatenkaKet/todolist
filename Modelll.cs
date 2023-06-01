using System.ComponentModel;
//using System.Runtime.CompilerServices;


namespace todolist.Modelll;

public class Modelll: INotifyPropertyChanged
{
    private string taskname;
    private bool taskcompleted;
    private Color taskcolor;

    public string TaskName
    {
        get => taskname;
        
         set
        {
            taskname = value;
            PropertyChanged?.Invoke(this,
                new PropertyChangedEventArgs(nameof(TaskName)));
        }
        
}
    
    public bool TaskCompleted
    {
        get => taskcompleted;
        
        set
        {
            taskcompleted = value;
            PropertyChanged?.Invoke(this,
                new PropertyChangedEventArgs(nameof(TaskCompleted)));
        }
        
    }
    
    public Color TaskColor
    {
        get => taskcolor;
        
        set
        {
            taskcolor = value;
            PropertyChanged?.Invoke(this,
                new PropertyChangedEventArgs(nameof(TaskColor)));
        }
        
    }

    public event PropertyChangedEventHandler PropertyChanged;
}