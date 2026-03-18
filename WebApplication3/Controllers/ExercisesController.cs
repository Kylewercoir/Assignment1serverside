using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Data;
using WebApplication3.Models;

namespace WebApplication3.Controllers
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
            var exercises = _context.Exercises.Include(e => e.Workout);
            return View(await exercises.ToListAsync());
        }

        public IActionResult Create()
        {
            ViewData["WorkoutId"] = new SelectList(_context.Workouts, "WorkoutId", "WorkoutType");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Exercise exercise)
        {
            if (ModelState.IsValid)
            {
                _context.Add(exercise);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["WorkoutId"] = new SelectList(_context.Workouts, "WorkoutId", "WorkoutType", exercise.WorkoutId);
            return View(exercise);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var exercise = await _context.Exercises.FindAsync(id);
            if (exercise == null) return NotFound();

            ViewData["WorkoutId"] = new SelectList(_context.Workouts, "WorkoutId", "WorkoutType", exercise.WorkoutId);
            return View(exercise);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Exercise exercise)
        {
            if (id != exercise.ExerciseId) return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(exercise);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(exercise);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var exercise = await _context.Exercises
                .Include(e => e.Workout)
                .FirstOrDefaultAsync(m => m.ExerciseId == id);

            return View(exercise);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var exercise = await _context.Exercises.FindAsync(id);
            _context.Exercises.Remove(exercise);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}