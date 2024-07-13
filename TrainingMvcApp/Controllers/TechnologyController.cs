using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrainingMvcApp.Models;

namespace TrainingMvcApp.Controllers
{
    public class TechnologyController : Controller
    {
        static HttpClient Client = new HttpClient() { BaseAddress = new Uri("http://localhost:5087/api/Technology/") };
        // GET: TechnologyController
        public async Task <ActionResult> Index()
        {
            List<Technology> technologies = await Client.GetFromJsonAsync<List<Technology>>("");
            return View(technologies);
        }

        // GET: TechnologyController/Details/5
        public async Task  <ActionResult> Details(int techId)
        {
            Technology tech = await Client.GetFromJsonAsync<Technology>("ById/" + techId);
            return View(tech);
        }

        // GET: TechnologyController/Create
        public  ActionResult Create()
        {
            return View();
        }

        // POST: TechnologyController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Technology tech)
        {
            try
            {
                await Client.PostAsJsonAsync<Technology>("", tech);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TechnologyController/Edit/5
        [Route("Technology/Edit/{techId}")]
        public async Task<ActionResult> Edit(int techId)
        {
            Technology tech = await Client.GetFromJsonAsync<Technology>("ById/" + techId);
            return View(tech);
        }


        // POST: TechnologyController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Technology/Edit/{techId}")]
        public async Task<ActionResult> Edit(int techId, Technology tech)
        {
            try
            {
                await Client.PutAsJsonAsync<Technology>("" + techId, tech );
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [Route("Technology/Delete/{techId}")]
        // GET: TechnologyController/Delete/5
        public async Task<ActionResult> Delete(int techId)
        {
            Technology tech = await Client.GetFromJsonAsync<Technology>("ById/" + techId);
            return View(tech);
        }

        // POST: TechnologyController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Technology/Delete/{techId}")]
        public async Task<ActionResult> Delete(int techId, IFormCollection collection)
        {
            try
            {
                await Client.DeleteAsync("" + techId);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public async Task<ActionResult> GetByType(string Type)
        {
            List<Technology> technologies = await Client.GetFromJsonAsync<List<Technology>>("ByType/" + Type);
            return View(technologies);
        }
    }
}
