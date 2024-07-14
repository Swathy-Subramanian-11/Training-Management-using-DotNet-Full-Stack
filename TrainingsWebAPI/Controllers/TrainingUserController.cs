using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrainingUserLibrary.Models;
using TrainingUserLibrary.Repos;

namespace TrainingsWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingUserController : ControllerBase
    {
        ITrainingUserRepo trainingUserRepo;
        public TrainingUserController(ITrainingUserRepo repo)
        {
            trainingUserRepo = repo;
        }
        [HttpPost("Register")]
        public async Task<ActionResult> Register(TrainingUser user)
        {
            try
            {
                await trainingUserRepo.RegisterAsync(user);
                return Created("", user);
            }
            catch (TrainingUserException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("Login/{userId}")]
        public async Task<ActionResult> Login(string userId, [FromBody] string password)
        {
            try
            {
                await trainingUserRepo.LoginAsync(userId, password);
                return Ok();
            }
            catch (TrainingUserException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult> GetUser(string userId)
        {
            try
            {
                TrainingUser user = await trainingUserRepo.GetUserDetails(userId);
                return Ok(user);
            }
            catch (TrainingUserException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
