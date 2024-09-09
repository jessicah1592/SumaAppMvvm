using SumaAppMvvm.ViewModel;

namespace SumaAppMvvm;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        BindingContext = new MainViewModel();
    }
}
