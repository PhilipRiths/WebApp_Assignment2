using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GymBuddyWebApp.Data;
using GymBuddyWebApp.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApp_Assignment2.Controllers
{
    public class PeopleController : Controller
    {
        GymBuddyContext context = new GymBuddyContext();

        // GET: People
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        public IActionResult ValidatePerson(Person person)
        {
            if (!ModelState.IsValid)
            {
                return View("Create");
            }
            context.Add(person);
            context.SaveChanges();
            return View("PersonAdded", person);

        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await context.Persons
                .Include(p => p.CardioExercises)
                .ThenInclude(x => x.Person)
                .ThenInclude(z => z.WeightExercises)
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.Id == id);

            if (person == null)
            {
                return NotFound();
            }

            return View("Details", person);
        }

        public async Task<IActionResult> Edit(int id)
        {


            var person = await context.Persons.SingleAsync(p => p.Id == id);

            if (person == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    context.Update(person);
                    await context.SaveChangesAsync();
                    return View("Edit", person);
                }
                catch (DbUpdateException /* ex */)
                {
                    //Log the error (uncomment ex variable name and write a log.)
                    ModelState.AddModelError("", "Unable to save changes. " +
                                                 "Try again, and if the problem persists, " +
                                                 "see your system administrator.");
                }
            }
            return View(person);


        }
    }
}
