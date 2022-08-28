using SOHome.Fitness.ViewModels;

namespace SOHome.Fitness.Pages;

public partial class MainPage : ContentPage
{
	private readonly MainViewModel viewModel;

	public MainPage(MainViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
		this.viewModel = viewModel;
	}
}