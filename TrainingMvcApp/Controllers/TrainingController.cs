using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrainingMvcApp.Models;

namespace TrainingMvcApp.Controllers
{
    public class TrainingController : Controller
    {
        static HttpClient client = new HttpClient() { BaseAddress = new Uri("http://localhost:5087/api/Training/") };
        public async Task<ActionResult> Index()
        {
            List<Training> trainings = await client.GetFromJsonAsync<List<Training>>("");
            return View(trainings);
        }

        // GET: TrainingController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            Training training = await client.GetFromJsonAsync<Training>("ById/" + id);
            return View(training);
        }

        // GET: TrainingController/Create
        public ActionResult Create()
        {
            Training training = new Training();
            return View(training);
        }

        // POST: TrainingController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Training training)
        {
            try
            {
                await client.PostAsJsonAsync<Training>("", training);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TrainingController/Edit/5
        [Route("Training/Edit/{id}")]

        public async Task<ActionResult> Edit(int id)
        {
            Training training = await client.GetFromJsonAsync<Training>("ById/" + id);
            return View(training);
        }

        // POST: TrainingController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Training/Edit/{id}")]

        public async Task<ActionResult> Edit(int id, Training training)
        {
            try
            {
                await client.PutAsJsonAsync("" + id,training);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TrainingController/Delete/5
        [Route("Training/Delete/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            Training training = await client.GetFromJsonAsync<Training>("ById/" + id);
            return View(training);
        }

        // POST: TrainingController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Training/Delete/{id}")]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                await client.DeleteAsync("" + id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult>ByTechnology(int techId)
        {
            List<Training> training = await client.GetFromJsonAsync<List<Training>>("ByTechnology/" + techId);
            return View(training);
        }

        public async Task<ActionResult> ByTrainer(int trainerId)
        {
            List<Training> training = await client.GetFromJsonAsync<List<Training>>("ByTrainer/" + trainerId);
            return View(training);
        }
    }
}
