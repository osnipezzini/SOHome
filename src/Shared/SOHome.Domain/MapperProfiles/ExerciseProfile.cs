using AutoMapper;

using SOHome.Common.DataModels;
using SOHome.Common.DataModels.Requests;
using SOHome.Common.DataModels.Responses;
using SOHome.Domain.Models;

namespace SOHome.Domain.MapperProfiles
{
    public class ExerciseProfile : Profile
    {
        public ExerciseProfile()
        {
            CreateMap<ExerciseCreateModel, Exercise>();
            CreateMap<Exercise, ExerciseResponse>();
            CreateMap<Exercise, ExerciseDto>();
        }
    }
}
