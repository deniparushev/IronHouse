using System.Threading.Tasks;
using IronHouse.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;    
using IronHouse.Models;

namespace IronHouse.Controllers
{
    public class ExercisesController : Controller
    {
       private readonly ApplicationDbContext _context;
        public ExercisesController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var exercises = await _context.Exercises.ToListAsync();
            return View(exercises);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,MuscleGroup,Description")] Exercise exercise)
        {
            if (ModelState.IsValid)
            {
                _context.Add(exercise);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(exercise);
        }
    }
}
