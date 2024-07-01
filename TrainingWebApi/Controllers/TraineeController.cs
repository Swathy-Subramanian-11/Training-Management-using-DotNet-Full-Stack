using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EFTrainingLibrary.Models;
using EFTrainingLibrary.Repos;

namespace TrainingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TraineeController : ControllerBase
    {
        
        IETraineeRepoAsync traineerepo;
        public TraineeController(IETraineeRepoAsync repo)
        {
            traineerepo = repo;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            List<Trainee> tras = await traineerepo.GetAllTraineesAsync();
            return Ok(tras);
        }
        [HttpGet("ByIdnTid/{empid}/{tid}")]
        public async Task<ActionResult> GetTrainee(int empid,int tid)
        {
            try
            {
                Trainee tra = await traineerepo.GetTraineeAsync(empid,tid);
                return Ok(tra);
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }
        [HttpGet("Byempid/{empid}")]
        public async Task<ActionResult> GetbyEmpId(int empid )
        {
            try
            {
                List<Trainee> tras = await traineerepo.GetTraineeByEmpIdAsync(empid);
                return Ok(tras);
            }
            catch (Exception ex)

            {
                return NotFound();
            }
        }
        [HttpPost]
        public async Task<ActionResult> Create(Trainee tra)
        {
            try
            {
                await traineerepo.InsertTraineeAsync(tra);
                return Created($"api/Trainee/{tra.EmpId}/{tra.TrainingId}", tra);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{empid}/{tid}")]
        public async Task<ActionResult> Update(int empid, Trainee tra,int tid)
        {
            try
            {
                await traineerepo.UpdateTraineeAsync(empid, tra,tid);
                return Ok(tra);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{empid}/{tid}")]
        public async Task<ActionResult> Delete(int empid, int tid)
        {
            try
            {
                await traineerepo.DeleteTraineeAsync(empid,tid);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("ByTraTid/{tid}")]
        public async Task<ActionResult> GetbyTid(int tid)
        {
            try
            {
                List<Trainee> tras = await traineerepo.GetTraineeByTrainingIdAsync(tid);
                return Ok(tras);
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }
    }
}
