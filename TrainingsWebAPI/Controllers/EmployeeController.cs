using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EFTrainingLibrary.Models;
using EFTrainingLibrary.Repos;
namespace TrainingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        IEFEmployeeRepoAsync emprepo;
        public EmployeeController(IEFEmployeeRepoAsync repo)
        {
            emprepo= repo;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            List<Employee> emps = await emprepo.GetEmployeesAsync();
            return Ok(emps);
        }
        [HttpGet("ById/{empid}")]
        public async Task<ActionResult> GetOne(int empid)
        {
            try
            {
                Employee emp = await emprepo.GetEmployeeByIdAsync(empid);
                return Ok(emp);
            }
            catch (TrainingsException ex)
            {
                return NotFound();
            }
        }
        [HttpGet("ByDesg/{desg}")]
        public async Task<ActionResult> GetbyDesg(string desg)
        {
            try
            {
                List<Employee> emps = await emprepo.GetEmployeeByDesignationAsync(desg);
                return Ok(emps);
            }
            catch (TrainingsException ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPost]
        public async Task<ActionResult> Create(Employee emp)
        {
            try
            {
                await emprepo.InsertEmployeeAsync(emp);
                return Created($"api/Employee/{emp.EmpId}", emp);
            }
            catch (TrainingsException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{empid}")]
        public async Task<ActionResult> Update(int empid, Employee emp)
        {
            try
            {
                await emprepo.UpdateEmployeeAsync(empid, emp);
                return Ok(emp);
            }
            catch (TrainingsException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{empid}")]
        public async Task<ActionResult> Delete(int empid)
        {
            try
            {
                await emprepo.DeleteEmployeeAsync(empid);
                return Ok();
            }
            catch (TrainingsException ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
