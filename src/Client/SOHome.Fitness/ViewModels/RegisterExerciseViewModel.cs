using CommunityToolkit.Mvvm.ComponentModel;
using SOHome.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOHome.Fitness.ViewModels;

public partial class RegisterExerciseViewModel : BaseViewModel
{
	[ObservableProperty]
	private string selectedExerciseType;
    public List<ExerciseType> ExerciseTypes { get; }

	public RegisterExerciseViewModel()
	{
		ExerciseTypes = Enum.GetValues<ExerciseType>().ToList();
	}
}
