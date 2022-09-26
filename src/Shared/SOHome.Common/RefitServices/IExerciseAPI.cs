using Refit;
using SOHome.Common.DataModels;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SOHome.Common.RefitServices;

public interface IExerciseAPI
{
    [Get("/api/exercises")]
    Task<List<ExerciseDto>> GetAll(CancellationToken cancellationToken = default);
}
