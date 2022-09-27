using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using SOHome.Common.DataModels;
using SOHome.Common.DataModels.Requests;
using SOHome.Common.Services;

namespace SOHome.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
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
    public async Task<ExerciseDto?> Get(string id)
    {
        logger.LogDebug("Buscando exercício com a ID: {0}", id);
        return await exerciseService.GetExercise(id);
    }

    [HttpPost]
    [Authorize]
    public async Task Post([FromBody] ExerciseCreateModel createModel)
    {
        logger.LogInformation("Cadastrando exercício...");
        await exerciseService.CreateExercise(createModel);
    }

    // PUT api/<ExercisesController>/5
    [HttpPut("{code}")]
    public async Task Put(int code, [FromBody] ExerciseEditModel editModel)
    {
        logger.LogInformation("Atualizando exercício...");
        await exerciseService.UpdateService(code, editModel);
    }

    // DELETE api/<ExercisesController>/5
    [HttpDelete("{code}")]
    public async Task Delete(int code)
    {
        logger.LogInformation("Removendo exercício...");
        await exerciseService.Remove(code);
    }
}
