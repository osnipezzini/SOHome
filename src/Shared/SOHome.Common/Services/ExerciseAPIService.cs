using SOHome.Common.DataModels;
using SOHome.Common.DataModels.Requests;
using SOHome.Common.DataModels.Responses;
using SOHome.Common.RefitServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SOHome.Common.Services;

public class ExerciseAPIService : IExerciseService
{
    private readonly IExerciseAPI exerciseAPI;

    public ExerciseAPIService(IExerciseAPI exerciseAPI)
    {
        this.exerciseAPI = exerciseAPI;
    }
    public Task<ExerciseResponse> CreateExercise(ExerciseCreateModel createModel, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<List<ExerciseDto>> GetExercises(CancellationToken cancellationToken = default)
    {
        try
        {
            return await exerciseAPI.GetAll(cancellationToken);
        }
        catch (Exception)
        {
            return new();
        }
    }
    
}
