using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Security.Principal;
using TrainingMvcApp.Models;

namespace TrainingMvcApp.Controllers
{
    public class TrainerController : Controller
    {
        static HttpClient client = new HttpClient() { BaseAddress = new Uri("http://localhost:5066/api/Trainer/") };

   
        public async Task<ActionResult> Index()
        {
            List<Trainer> trainers = await client.GetFromJsonAsync<List<Trainer>>("");

            return View(trainers);
        }

        // GET: TrainerController
       

        // GET: TrainerController/Details/5
        public async Task<ActionResult> Details(int trainerId)
        {
            Trainer trainer = await client.GetFromJsonAsync<Trainer>("ByTrainerId/"+ trainerId);
            return View(trainer);
        }

        // GET: TrainerController/Create
        public async Task<ActionResult> Create()
        {
            Trainer trainer = new Trainer();
            return View(trainer);
        }

        // POST: TrainerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Trainer trainer)
        {
            try
            {
                await client.PostAsJsonAsync<Trainer>("", trainer);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TrainerController/Edit/5
        // GET: Trainer/Edit/5
        [Route("Trainer/Edit/{trainerId}")]
        public async Task<ActionResult> Edit(int trainerId)
        {
            Trainer trainer = await client.GetFromJsonAsync<Trainer>($"ByTrainerId/{trainerId}");
            return View(trainer);
        }

        // POST: Trainer/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Trainer/Edit/{trainerId}")]
        public async Task<ActionResult> Edit(int trainerId, Trainer trainer)
        {
            try
            {
                await client.PutAsJsonAsync<Trainer>($"ByTrainerId/{trainerId}", trainer);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(trainer);
            }
        }
        [Route("Trainer/Delete/{trainerId}")]        
        // GET: TrainerController/Delete/5
        public async Task<ActionResult> Delete(int trainerId)
        {
            //Trainer trainer = await client.GetFromJsonAsync<Trainer>(""+trainerId);
            Trainer trainer = await client.GetFromJsonAsync<Trainer>("ByTrainerId/" + trainerId);

            return View(trainer);
        }

        // POST: TrainerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Trainer/Delete/{trainerId}")]
        public async Task<ActionResult> Delete(int trainerId, IFormCollection collection)
        {
            try
            {
                await client.DeleteAsync("ByTrainerId/" + trainerId);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }





        [Route(("ByType/{trainerType}"))]
        public async Task<ActionResult> GetByType(string trainerType)
        {
            try
            {
                List<Trainer> trainers = await client.GetFromJsonAsync<List<Trainer>>("ByType/" + trainerType);
                return View(trainers);
            }
            catch
            {
                return View();
            }
        }

    }
}
