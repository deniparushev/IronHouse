
using IronHouse.Models;
using IronHouse.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IronHouse.Controllers
{
    public class WorkoutLogsController : Controller
    {  
        private readonly IWorkoutService _workoutService;
        public WorkoutLogsController(IWorkoutService workoutService)
        {      
            _workoutService = workoutService;
        }

        public async Task<IActionResult> Index()
        {
            var workoutLogs = await _workoutService.GetAllAsync();
            return View(workoutLogs);
        }

       public async Task<IActionResult> Details(int? id)
        {
             if (id == null)
               {
                return NotFound();
               }

            var workoutLog = await _workoutService.GetByIdWithSetsAsync(id.Value);

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
            if (!ModelState.IsValid)
            {
                return View(workoutLog);             
            }

            await _workoutService.CreateAsync(workoutLog);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workoutLog = await _workoutService.GetByIdAsync(id.Value);

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
                    await _workoutService.UpdateAsync(workoutLog);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _workoutService.ExistAsync(workoutLog.Id))
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

            var workoutLog = await _workoutService.GetByIdAsync(id.Value);

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
            await _workoutService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
