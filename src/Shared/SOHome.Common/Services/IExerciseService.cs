using SOHome.Common.DataModels;
using SOHome.Common.DataModels.Requests;
using SOHome.Common.DataModels.Responses;

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SOHome.Common.Services
{
    public interface IExerciseService
    {
        Task<ExerciseResponse> CreateExercise(ExerciseCreateModel createModel, CancellationToken cancellationToken = default);
        Task<List<ExerciseDto>> GetExercises(CancellationToken cancellationToken = default);
    }
}
