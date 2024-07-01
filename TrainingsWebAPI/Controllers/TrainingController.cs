using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EFTrainingLibrary.Repos;
using EFTrainingLibrary.Models;

namespace TrainingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingController : ControllerBase
    {
        readonly IEFTrainingRepoAsync trainingRepo;
        public TrainingController(IEFTrainingRepoAsync trainingRepoAsync)
        {
            trainingRepo = trainingRepoAsync;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllTrainings()
        {
            List<Training> training = await trainingRepo.GetAllTrainingsAsync();
            return Ok(training);
        }
        [HttpGet("ById/{trainingId}")]
        public async Task<ActionResult> GetOne(int trainingId)
        {
            try
            {
                Training training = await trainingRepo.GetTrainingByIdAsync(trainingId);
                return Ok(training);
            }
            catch (TrainingsException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("ByTrainer/{trainerId}")]
        public async Task<ActionResult> GetByTrainer(int trainerId)
        {
            try
            {
                List<Training> trnByTrainer = await trainingRepo.GetTrainingByTrainerIdAsync(trainerId);
                return Ok(trnByTrainer);
            }
            catch (TrainingsException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("ByTechnology/{techId}")]
        public async Task<ActionResult> GetByTechnology(int techId)
        {
            try
            {
                List<Training> trnByTech = await trainingRepo.GetTrainingByTrainerIdAsync(techId);
                return Ok(trnByTech);
            }
            catch (TrainingsException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Add(Training training)
        {
            try
            {
                await trainingRepo.InsertTrainingAsync(training);
                return Created($"api/Training/{training.TrainingId}", training);
            }
            catch (TrainingsException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{trainingId}")]
        public async Task<ActionResult> Update(int trainingId, Training training)
        {
            try
            {
                await trainingRepo.UpdateTrainingAsync(trainingId, training);
                return Ok(training);
            }
            catch (TrainingsException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{trainingId}")]
        public async Task<ActionResult> Delete(int trainingId)
        {
            try
            {
                await trainingRepo.DeleteTrainingAsync(trainingId);
                return Ok();
            }
            catch (TrainingsException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}