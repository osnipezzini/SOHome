namespace SOHome.Fitness.Pages;

public partial class ExercisesPage : ContentPage
{
	private readonly ExercisesViewModel viewModel;

	public ExercisesPage(ExercisesViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = this.viewModel = viewModel;		
	}
	protected override async void OnAppearing()
	{
		base.OnAppearing();
		await viewModel.Init();
	}
}