using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using SOHome.Common.Models;

using System.Collections.ObjectModel;

namespace SOHome.Fitness.ViewModels;

public partial class RegisterExerciseViewModel : BaseViewModel
{
    [ObservableProperty]
    private string selectedExerciseType;
    [ObservableProperty]
    private string name;
    [ObservableProperty]
    private string description;

    public ObservableCollection<ImageSource> Images { get; }
    public List<ExerciseType> ExerciseTypes { get; }

    public RegisterExerciseViewModel()
    {
        ExerciseTypes = Enum.GetValues<ExerciseType>().ToList();
        Images = new ObservableCollection<ImageSource>();
    }

    [RelayCommand]
    async Task SelectImages()
    {
        var fileResults = await FilePicker.PickMultipleAsync();
        if (fileResults is null)
        {
            return;
        }
        foreach (var fileResult in fileResults)
        {
            var image = ImageSource.FromFile(fileResult.FullPath);
            Images.Add(image);

        }
    }

}
