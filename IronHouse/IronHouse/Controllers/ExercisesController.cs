using IronHouse.Models;
using IronHouse.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IronHouse.Controllers
{
    public class ExercisesController : Controller
    {
        private readonly IExerciseService _exerciseService;

        public ExercisesController(IExerciseService exerciseService)
        {
            _exerciseService = exerciseService;
        }

    
        public async Task<IActionResult> Index()
        {
            var exercises = await _exerciseService.GetAllAsync();
            return View(exercises);
        }

     
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exercise = await _exerciseService.GetByIdAsync(id.Value);
            if (exercise == null)
            {
                return NotFound();
            }

            return View(exercise);
        }

      
        public IActionResult Create()
        {
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,MuscleGroup,Description")] Exercise exercise)
        {
            if (!ModelState.IsValid)
            {
                return View(exercise);
            }

            await _exerciseService.CreateAsync(exercise);
            return RedirectToAction(nameof(Index));
        }

        
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exercise = await _exerciseService.GetByIdAsync(id.Value);
            if (exercise == null)
            {
                return NotFound();
            }

            return View(exercise);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,MuscleGroup,Description")] Exercise exercise)
        {
            if (id != exercise.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(exercise);
            }

            try
            {
                await _exerciseService.UpdateAsync(exercise);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _exerciseService.ExistsAsync(exercise.Id))
                {
                    return NotFound();
                }

                throw;
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exercise = await _exerciseService.GetByIdAsync(id.Value);
            if (exercise == null)
            {
                return NotFound();
            }

            return View(exercise);
        }

       
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _exerciseService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}