namespace SOHome.Fitness.Pages;

public partial class MyExercisesPage : ContentPage
{
	private readonly MyExercisesViewModel viewModel;

	public MyExercisesPage(MyExercisesViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = this.viewModel = viewModel;
	}

	protected override void OnAppearing()
	{
		base.OnAppearing();
		
	}
}