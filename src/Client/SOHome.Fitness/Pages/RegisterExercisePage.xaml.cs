using SOHome.Fitness.ViewModels;

namespace SOHome.Fitness.Pages;

public partial class RegisterExercisePage : ContentPage
{
	private readonly RegisterExerciseViewModel viewModel;

	public RegisterExercisePage(RegisterExerciseViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
		this.viewModel = viewModel;
	}
}