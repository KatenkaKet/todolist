//using todolist.ViewModel;

namespace todolist;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        BindingContext = new ViewModel.ViewModel();
    }

}