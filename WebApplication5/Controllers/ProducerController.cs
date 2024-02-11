using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication5.Data;

namespace WebApplication5.Controllers
{
    public class ProducerController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ProducerController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var AllProducers = await _context.Producers.ToListAsync();
            return View(AllProducers);
        }
    }
}
