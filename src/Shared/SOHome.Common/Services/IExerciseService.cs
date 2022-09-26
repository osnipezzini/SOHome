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
        Task<ExerciseDto?> GetExercise(string id);
        Task<List<ExerciseDto>> GetExercises(CancellationToken cancellationToken = default);
        Task Remove(int code);
        Task UpdateService(string id, ExerciseEditModel editModel);
        Task UpdateService(int code, ExerciseEditModel editModel);
    }
}
