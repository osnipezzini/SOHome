using AutoMapper;

using Microsoft.EntityFrameworkCore;

using SOHome.Common.DataModels;
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

        public async Task<ExerciseDto?> GetExercise(string id)
        {
            var exercise = await dbContext.Exercises
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            if (exercise is null)
                return null;

            return mapper.Map<ExerciseDto>(exercise);
        }

        public async Task<List<ExerciseDto>> GetExercises(CancellationToken cancellationToken = default)
        {
            var exercises = await dbContext.Exercises
                .ToArrayAsync(cancellationToken);

            var exercisesDto = new List<ExerciseDto>();
            foreach (var exercise in exercises)
                exercisesDto.Add(mapper.Map<ExerciseDto>(exercise));

            return exercisesDto;
        }

        public async Task Remove(int code)
        {
            var exercise = await dbContext.Exercises
                .Where(x => x.Code == code)
                .FirstOrDefaultAsync();

            if (exercise is null)
                return;

            dbContext.Remove(exercise);
            await dbContext.SaveChangesAsync();
        }

        public async Task UpdateService(string id, ExerciseEditModel editModel)
        {
            var exercise = await dbContext.Exercises
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            if (exercise is null)
                return;

            mapper.Map(editModel, exercise);
            await dbContext.SaveChangesAsync();
        }

        public async Task UpdateService(int code, ExerciseEditModel editModel)
        {
            var exercise = await dbContext.Exercises
                .Where(x => x.Code == code)
                .FirstOrDefaultAsync();

            if (exercise is null)
                return;

            mapper.Map(editModel, exercise);
            await dbContext.SaveChangesAsync();
        }
    }
}
