using Microsoft.AspNetCore.Mvc;

using SOHome.Common.DataModels;
using SOHome.Common.Services;

namespace SOHome.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExercisesController : ControllerBase
    {
        private readonly IExerciseService exerciseService;
        private readonly ILogger<ExercisesController> logger;

        public ExercisesController(IExerciseService exerciseService, ILogger<ExercisesController> logger)
        {
            this.exerciseService = exerciseService;
            this.logger = logger;
        }
        [HttpGet]
        public async Task<IEnumerable<ExerciseDto>> Get()
        {
            logger.LogInformation("Buscando exercícios cadastrados...");
            return await exerciseService.GetExercises();
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ExercisesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ExercisesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ExercisesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
