using DataBinding.Collection.ViewModels;

namespace DataBinding.Collection.Views;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
		BindingContext = new MainViewModel();
	}
}