using Microsoft.AspNetCore.Mvc;
using WebApplication5.Data.Repository;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    public class ActorController : Controller
    {
        private readonly IActorRepository _repository;
        public ActorController(IActorRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var data =await _repository.GetAllAsync();
           
            return View(data);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName,ProfilePictureURL,Bio")] Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }
            await _repository.AddAsync(actor);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var actorDetails = await _repository.GetByIdAsync(id);
            if (actorDetails == null) return View("Empty");
            {
                return View(actorDetails);
            }
        }
        public async Task<IActionResult> Edit(int id)
        {
            var actorDetails = await _repository.GetByIdAsync(id);
            if (actorDetails == null) return View("NotFound");
            return View(actorDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,ProfilePictureURL,Bio")] Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }
            await _repository.UpdateAsync(id, actor);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var actorDetails = await _repository.GetByIdAsync(id);
            if (actorDetails == null) return View("NotFound");
            return View(actorDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var actorDetails = await _repository.GetByIdAsync(id);
            if (actorDetails == null) return View("NotFound");

            await _repository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
