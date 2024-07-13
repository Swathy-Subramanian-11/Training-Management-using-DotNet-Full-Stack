using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using EFTrainingLibrary.Models;
using EFTrainingLibrary.Repos;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using Microsoft.AspNetCore.Http.HttpResults;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TrainingsWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechnologyController : ControllerBase
    {
        IEFTechnologyRepoAsync Techrepo;
        public TechnologyController(IEFTechnologyRepoAsync repo)
        {
            Techrepo = repo;
        }

        // GET: api/<TechnologyController>
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            List<Technology> techs = await Techrepo.GetAllTechnologyAsync();
            return Ok(techs);
        }

        // GET api/<TechnologyController>/5
        [HttpGet("ById/{techId}")]
        public async Task<ActionResult> GetOne(int techId)
        {
            try
            {
                Technology Tech = await Techrepo.GetTechnologyAsync(techId);
                return Ok(Tech);

            }
            catch(Exception ex) {
                return NotFound(ex.Message);
            }
        }
        [HttpGet("ByType/{type}")]
        public async Task<ActionResult> GetType(string type)
        {
            try
            {
                List<Technology> techs = await Techrepo.GetTechnologyByType(type);
                return Ok(techs);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

            // POST api/<TechnologyController>
            [HttpPost]
            public async Task<ActionResult> Add(Technology tech)
            {
                try {
                    await Techrepo.AddTechnologyAsync(tech);
                    return Created($"api/Technology/{tech.TechnologyId}", tech);
                }
                catch (Exception ex) {
                    return BadRequest(ex.Message);
                }
            }
        
        // PUT api/<TechnologyController>/5
        [HttpPut("{techId}")]
        public async Task<ActionResult> Update(int techId, Technology tech)
        {
        try
        {
            await Techrepo.UpdateTechnologyAsync(techId, tech);
            return Ok(tech);
        }

        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

        }

        // DELETE api/<TechnologyController>/5
        [HttpDelete("{techId}")]
        public async Task<ActionResult> Delete(int techId)
        {
        try
        {
            await Techrepo.DeleteTechnologyAsync(techId);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }


        }
    }
}
