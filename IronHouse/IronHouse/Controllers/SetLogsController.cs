using IronHouse.Data;
using IronHouse.Models;
using IronHouse.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IronHouse.Controllers
{
    public class SetLogsController : Controller
    {
        private readonly ISetLogService _setLogService;
        private readonly IExerciseService _exerciseService;

        public SetLogsController(ISetLogService setLogService, IExerciseService exerciseService)
        {
            _setLogService = setLogService;
            _exerciseService = exerciseService;
        }

        public async Task<IActionResult> Create(int? workoutLogId)
        {
            if (workoutLogId == null || !await _setLogService.WorkoutExistsAsync(workoutLogId.Value))
            {
                return NotFound();
            }

            ViewBag.WorkoutLogId = workoutLogId.Value;
            ViewBag.Exercises = new SelectList(await _exerciseService.GetAllAsync(), "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SetLog setLog)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.WorkoutLogId = setLog.WorkoutLogId;
                ViewBag.Exercises = new SelectList(await _exerciseService.GetAllAsync(), "Id", "Name", setLog.ExerciseId);
                return View(setLog);
            }

            await _setLogService.CreateAsync(setLog);
            return RedirectToAction("Details", "WorkoutLogs", new { id = setLog.WorkoutLogId });
        }
    }
}
