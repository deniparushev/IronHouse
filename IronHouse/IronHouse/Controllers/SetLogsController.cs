using IronHouse.Data;
using IronHouse.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IronHouse.Controllers
{
    public class SetLogsController : Controller
    {
       private readonly ApplicationDbContext _context;

        public SetLogsController(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public IActionResult Create(int workoutLogId)
        {
            ViewBag.WorkoutLogId = workoutLogId;
            ViewBag.Exercises = new SelectList(_context.Exercises, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WeightKg,Reps,WorkoutLogId,ExerciseId")] SetLog setLog)
        {
            if (ModelState.IsValid)
            {
                _context.Add(setLog);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "WorkoutLogs", new { id = setLog.WorkoutLogId });
            }

            ViewBag.WorkoutLogId = setLog.WorkoutLogId;
            ViewBag.Exercises = new SelectList(_context.Exercises, "Id", "Name", setLog.ExerciseId);
            return View(setLog);
        }
    }
}
