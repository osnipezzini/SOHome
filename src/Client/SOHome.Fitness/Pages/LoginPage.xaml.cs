using SOHome.Fitness.ViewModels;

namespace SOHome.Fitness.Pages;

public partial class LoginPage : ContentPage
{
	private readonly LoginViewModel viewModel;

	public LoginPage(LoginViewModel viewModel)
	{
		InitializeComponent();
		this.viewModel = viewModel;
		BindingContext = viewModel;
	}
}