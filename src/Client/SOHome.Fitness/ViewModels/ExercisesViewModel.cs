using CommunityToolkit.Mvvm.Input;

namespace SOHome.Fitness.ViewModels
{
    public partial class ExercisesViewModel : BaseViewModel
    {
        [RelayCommand]
        async Task GoToCreateExercisePage()
        {
            await Shell.Current.GoToAsync(Routes.RegisterExercise);
        }
    }
}
