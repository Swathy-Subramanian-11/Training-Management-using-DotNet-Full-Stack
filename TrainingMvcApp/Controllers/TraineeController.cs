using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using TrainingMvcApp.Models;

namespace TrainingMvcApp.Controllers
{
    public class TraineeController : Controller
    {
        static HttpClient client = new HttpClient() { BaseAddress = new Uri("http://localhost:5087/api/Trainee/") };
        public async Task<ActionResult> Index()
        {
            List<Trainee> trainees = await client.GetFromJsonAsync<List<Trainee>>("");
            return View(trainees);
        }
        public async Task<ActionResult> Details(int eid, int tid )
        {
            Trainee trainee = await client.GetFromJsonAsync<Trainee>("ByIdnTid/" + eid +"/"+ tid);
            return View(trainee);
        }
        public ActionResult Create()
        {
            Trainee trainee = new Trainee();
            return View(trainee);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Trainee trainee)
        {
            try
            {
                await client.PostAsJsonAsync<Trainee>("", trainee);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        [Route("Trainee/Edit/{eid}/{tid}")]
        public async Task<ActionResult> Edit(int eid, int tid)
        {
            Trainee trainee = await client.GetFromJsonAsync<Trainee>("ByIdnTid/" + eid + "/" + tid);
            return View(trainee);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Trainee/Edit/{eid}/{tid}")]
        public async Task<ActionResult> Edit(int eid, int tid, Trainee trainee)
        {
            try
            {
                await client.PutAsJsonAsync("" + eid +"/"+ tid, trainee);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        [Route("Trainee/Delete/{eid}/{tid}")]
        public async Task<ActionResult> Delete(int eid, int tid)
        {
            Trainee trainee = await client.GetFromJsonAsync<Trainee>("ByIdnTid/" + eid + "/" + tid);
            return View(trainee);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Trainee/Delete/{eid}/{tid}")]
        public async Task<ActionResult> Delete(int eid, IFormCollection collection, int tid)
        {
            try
            {
                await client.DeleteAsync("" + eid + "/" + tid);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public async Task<ActionResult> Gettid(int tid)
        {
            List<Trainee> trainees = await client.GetFromJsonAsync<List<Trainee>>("ByTraTid/"+tid);
            return View(trainees);
        }
        public async Task<ActionResult> Geteid(int eid)
        {
            List<Trainee> trainees = await client.GetFromJsonAsync<List<Trainee>>("Byempid/" + eid);
            return View(trainees);
        }
    }
}
