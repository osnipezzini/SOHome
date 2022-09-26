using AutoMapper;

using Microsoft.EntityFrameworkCore;

using SOHome.Common.DataModels.Requests;
using SOHome.Common.DataModels.Responses;
using SOHome.Common.Exceptions;
using SOHome.Common.Services;
using SOHome.Domain.Data;
using SOHome.Domain.Models;

namespace SOHome.Domain.Services
{
    public class ExerciseService : IExerciseService
    {
        private readonly SOHomeDbContext dbContext;
        private readonly IMapper mapper;

        public ExerciseService(SOHomeDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        public async Task<ExerciseResponse> CreateExercise(ExerciseCreateModel createModel, CancellationToken cancellationToken = default)
        {
            Exercise? exercise = null;
            if (createModel.Code.HasValue)
                exercise = await dbContext.Exercises
                    .Where(exercise => exercise.Code == createModel.Code)
                    .FirstOrDefaultAsync();

            if (exercise is not null)
                throw new ExerciseConflictException("Um exercício com o código informado já existe no sistema.");

            exercise = mapper.Map<Exercise>(createModel);

            dbContext.Exercises.Add(exercise);

            await dbContext.SaveChangesAsync();

            return mapper.Map<ExerciseResponse>(exercise);
        }
    }
}
