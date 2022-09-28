using CommunityToolkit.Mvvm.Input;
using SOHome.Common.DataModels;
using SOHome.Common.Services;
using System.Collections.ObjectModel;

namespace SOHome.Fitness.ViewModels;

public partial class ExercisesViewModel : BaseViewModel
{
    private readonly IExerciseService exerciseService;

    [RelayCommand]
    async Task GoToCreateExercisePage()
    {
        await Shell.Current.GoToAsync(Routes.RegisterExercisePage);
    }
    public ObservableCollection<ExerciseDto> Exercises { get; }

    public ExercisesViewModel(IExerciseService exerciseService)
    {
        Exercises = new();
        this.exerciseService = exerciseService;
    }

    public async Task Init()
    {
        var exercises = await exerciseService.GetExercises();
        Exercises.Clear();
        foreach (var item in exercises)
        {
            Exercises.Add(item);
        }

    }

}
