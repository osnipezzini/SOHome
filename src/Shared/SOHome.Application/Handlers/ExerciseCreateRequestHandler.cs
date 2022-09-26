using MediatR;

using SOHome.Common.DataModels.Requests;
using SOHome.Common.DataModels.Responses;
using SOHome.Common.Services;

namespace SOHome.Application.Handlers
{
    internal class ExerciseCreateRequestHandler : IRequestHandler<ExerciseCreateModel>
    {
        private readonly IExerciseService exerciseService;

        public ExerciseCreateRequestHandler(IExerciseService exerciseService)
        {
            this.exerciseService = exerciseService;
        }
        public async Task<Unit> Handle(ExerciseCreateModel request, CancellationToken cancellationToken)
        {
            await exerciseService.CreateExercise(request, cancellationToken);
            return Unit.Value;
        }
    }
}
