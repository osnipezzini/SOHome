using SOHome.Common.DataModels.Requests;
using SOHome.Common.DataModels.Responses;

using System.Threading;
using System.Threading.Tasks;

namespace SOHome.Common.Services
{
    public interface IExerciseService
    {
        Task<ExerciseResponse> CreateExercise(ExerciseCreateModel createModel, CancellationToken cancellationToken = default);
    }
}
