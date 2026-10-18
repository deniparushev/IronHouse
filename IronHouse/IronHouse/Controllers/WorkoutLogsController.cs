using IronHouse.Data;
using IronHouse.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IronHouse.Controllers
{
    public class WorkoutLogsController : Controller
    {
        private readonly ApplicationDbContext _context;
        public WorkoutLogsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var wourkoutLogs = await _context.WorkoutLogs
                .Include(wl => wl.SetLogs)
                .ThenInclude(sl => sl.Exercise)
                .OrderByDescending(wl => wl.Date)
                .ToListAsync();

            return View(wourkoutLogs);
        }

       public async Task<IActionResult> Details(int? id)
        {
             if (id == null)
               {
                return NotFound();
               }

            var workoutLog = await _context.WorkoutLogs
                .Include(wl => wl.SetLogs)
                .ThenInclude(sl => sl.Exercise)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (workoutLog == null)
            {
                return NotFound();
            }

            return View(workoutLog);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Date,WorkoutType,Duration,Notes,CaloriesBurned")] WorkoutLog workoutLog)
        {
            if (ModelState.IsValid)
            {
                _context.Add(workoutLog);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(workoutLog);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workoutLog = await _context.WorkoutLogs.FindAsync(id);

            if (workoutLog == null)
            {
                return NotFound();
            }
            return View(workoutLog);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Date,WorkoutType,Duration,Notes,CaloriesBurned")] WorkoutLog workoutLog)
        {
            if (id != workoutLog.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(workoutLog);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkoutLogExists(workoutLog.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(workoutLog);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workoutLog = await _context.WorkoutLogs
                .FirstOrDefaultAsync(m => m.Id == id);

            if (workoutLog == null)
            {
                return NotFound();
            }
            return View(workoutLog);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var workoutLog = await _context.WorkoutLogs.FindAsync(id);
            if (workoutLog != null)
            {
                _context.WorkoutLogs.Remove(workoutLog);
                await _context.SaveChangesAsync();
            }

            
            return RedirectToAction(nameof(Index));
        }

        private bool WorkoutLogExists(int id)
        {
            return _context.WorkoutLogs.Any(e => e.Id == id);
        }
    }
}
