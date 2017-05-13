using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GymBuddyWebApp.Domain;
using Microsoft.AspNetCore.Mvc;
using GymBuddyWebApp.Data;
using Microsoft.EntityFrameworkCore;

namespace WebApp_Assignment2.Controllers
{
   
    public class WeightsController : Controller
    {
        GymBuddyContext context = new GymBuddyContext();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult SaveWeights(Weights weights)
        {
            if (!ModelState.IsValid)
            {
                return View("Create");
            }
            context.Weights.Add(weights);
            context.SaveChanges();
            return View("WorkoutAdded", weights);
        }
        public IActionResult Update(int id, Weights weights)
        {
            if (weights == null || weights.Id != id)
            {
                return BadRequest();
            }

            var findWeightsSession = context.Weights.Find(id);
            if (findWeightsSession == null)
            {
                return NotFound();
            }
            findWeightsSession.Id = weights.Id;
            findWeightsSession.ExerciseType = weights.ExerciseType;
            findWeightsSession.Date = weights.Date;
            findWeightsSession.Reps = weights.Reps;
            findWeightsSession.Sets = weights.Sets;
            findWeightsSession.Weight = weights.Weight;
            findWeightsSession.Person = weights.Person;
            findWeightsSession.PersonId = weights.PersonId;


            context.Weights.Update(findWeightsSession);
            context.SaveChanges();
            return View("Index");
        }
        public async Task<IActionResult> Edit(int id)
        {
            var weights = await context.Weights
                .SingleAsync(w => w.Id == id);

            if (weights == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    context.Update(weights);
                    await context.SaveChangesAsync();
                    return View("Edit", weights);
                }
                catch (DbUpdateException /* ex */)
                {
                    ModelState.AddModelError("", "Unable to save changes. " +
                                                 "Try again, and if the problem persists, " +
                                                 "see your system administrator.");
                }
            }
            return View(weights);
        }
        public IActionResult Delete(int id)
        {
            var weights = context.Weights.Find(id);
            if (weights == null)
            {
                return NotFound();
            }

            context.Weights.Remove(weights);
            context.SaveChanges();
            return View("Index");
        }
    }
}
