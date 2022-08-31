using MediatR;

using SOHome.Common.DataModels.Requests;
using SOHome.Common.DataModels.Responses;
using SOHome.Common.Services;

namespace SOHome.Application.Handlers
{
    internal class ExerciseCreateRequestHandler : IRequestHandler<ExerciseCreateModel, ExerciseResponse>
    {
        private readonly IExerciseService exerciseService;

        public ExerciseCreateRequestHandler(IExerciseService exerciseService)
        {
            this.exerciseService = exerciseService;
        }
        public Task<ExerciseResponse> Handle(ExerciseCreateModel request, CancellationToken cancellationToken)
        {
            return exerciseService.CreateExercise(request, cancellationToken);
        }
    }
}
