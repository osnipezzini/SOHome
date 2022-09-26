using CommunityToolkit.Mvvm.Input;
using SOHome.Common.DataModels;
using System.Collections.ObjectModel;

namespace SOHome.Fitness.ViewModels;

public partial class ExercisesViewModel : BaseViewModel
{
    [RelayCommand]
    async Task GoToCreateExercisePage()
    {
        await Shell.Current.GoToAsync(Routes.RegisterExercise);
    }
    public ObservableCollection<ExerciseDto> Exercises { get; }

    public ExercisesViewModel()
    {
        Exercises = new();
    }

    public Task Init()
    {
        return Task.CompletedTask;
    }

}
