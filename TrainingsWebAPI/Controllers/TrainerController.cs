using EFTrainingLibrary.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EFTrainingLibrary.Repos;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace TrainingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainerController : ControllerBase
    {
        readonly IEFTrainerRepoAsync trainerrepo;
        public TrainerController(IEFTrainerRepoAsync trainerrepoasync)
        {
            trainerrepo = trainerrepoasync;
        }
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            List<Trainer> trainers = await trainerrepo.GetAllTrainersAsync();
            return Ok(trainers);
        }
        [HttpGet("ByTrainerId/{trainerId}")]
        public async Task<ActionResult> GetById(int trainerId)
        {
            try
            {
                Trainer trainer = await trainerrepo.GetTrainerByIdAsync(trainerId);
                return Ok(trainer);
            }
            catch (TrainingsException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("ByType/{trainerType}")]
        public async Task<ActionResult> GetByType(string trainerType)
        {
            List<Trainer> trainers = await trainerrepo.GetTrainersByTypeAsync(trainerType);
            if (trainers.Count > 0)
            {
                return Ok(trainers);
            }
            else
            {
                throw new Exception("No Trainers for this type");
            }

        }


        [HttpPost]
        public async Task<ActionResult> InsertTrainer(Trainer trainer)
        {
            try
            {
                await trainerrepo.InsertTrainerAsync(trainer);
                return Created($"api/Trainer/ByTrainerId/{trainer.TrainerId}", trainer);

            }
            catch (TrainingsException ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("ByTrainerId/{trainerId}")]
        public async Task<ActionResult> DeleteTrainer(int trainerId)
        {
            try
            {
                await trainerrepo.DeleteTrainerAsync(trainerId);
                return Ok();
            }
            catch (TrainingsException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("ByTrainerId/{trainerId}")]
        public async Task<ActionResult> UpdateTrainer(int trainerId, Trainer trainer)
        {
            try
            {
                await trainerrepo.UpdateTrainerAsync(trainer, trainerId);
                return Ok(trainer);
            }
            catch (TrainingsException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}