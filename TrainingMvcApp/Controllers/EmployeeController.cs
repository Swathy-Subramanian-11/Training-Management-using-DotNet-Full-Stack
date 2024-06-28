using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrainingMvcApp.Models;
namespace TrainingMvcApp.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: EmployeeController
        static HttpClient client = new HttpClient() { BaseAddress= new Uri ("http://localhost:5066/api/Employee/") };
        public async Task <ActionResult> Index()
        {
            List<Employee> emps = await client.GetFromJsonAsync<List<Employee>>("");
            return View(emps);
        }

        // GET: EmployeeController/Details/5
        public async Task<ActionResult> Details(int empid)
        {
            Employee emp = await client.GetFromJsonAsync<Employee>("ById/" + empid);
            return View(emp);
        }

        // GET: EmployeeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <ActionResult> Create(Employee emp)
        {
            try
            {
                await client.PostAsJsonAsync<Employee>("",emp);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeController/Edit/5
        [Route("Employee/Edit/{empid}")]
        public async Task <ActionResult> Edit(int empid)
        {
            Employee emp = await client.GetFromJsonAsync<Employee>("ById/" + empid);

            return View(emp);
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Employee/Edit/{empid}")]
        public async Task<ActionResult> Edit(int empid,Employee emp)
        {
            try
            {
                await client.PutAsJsonAsync<Employee>("" + empid, emp);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeController/Delete/5
        [Route("Employee/Delete/{empid}")]
        public async Task <ActionResult> Delete(int empid)
        {
            Employee emp = await client.GetFromJsonAsync<Employee>("ById/" + empid);
            return View(emp);
        }

        // POST: EmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Employee/Delete/{empid}")]
        public async Task<ActionResult> Delete(int empid, IFormCollection collection)
        {
            try
            {
                await client.DeleteAsync("" + empid);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public async Task<ActionResult> GetEmployeeByDes(string desg)
        {
            List<Employee> emps = await client.GetFromJsonAsync<List<Employee>>("ByDesg/"+desg);
            return View(emps);
        }
    }
}
