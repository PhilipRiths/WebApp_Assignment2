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
    public class CardioController : Controller
    {
        GymBuddyContext context = new GymBuddyContext();

        public IActionResult Index()

        {
            return View();
        }
        // GET: Cardio
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult SaveCardio(Cardio cardio)
        {
            if (!ModelState.IsValid)
            {
                return View("Create");
            }
            context.Cardio.Add(cardio);
            context.SaveChanges();
            return View("CardioAdded", cardio);

        }
        public IActionResult Update(int id, Cardio cardio)
        {
            if (cardio == null || cardio.Id != id)
            {
                return BadRequest();
            }

            var findCardioSession = context.Cardio.Find(id);
            if (findCardioSession == null)
            {
                return NotFound();
            }
            findCardioSession.Id = cardio.Id;
            findCardioSession.CardioType = cardio.CardioType;
            findCardioSession.Date = cardio.Date;
            findCardioSession.Distance = cardio.Distance;
            findCardioSession.Time = cardio.Time;
            findCardioSession.Person = cardio.Person;
            findCardioSession.PersonId = cardio.PersonId;


            context.Cardio.Update(findCardioSession);
            context.SaveChanges();
            return View("Index");
        }
        public async Task<IActionResult> Edit(int id)
        {
            var cardio = await context.Cardio
           .SingleAsync(c => c.Id == id);

            if (cardio == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    context.Update(cardio);
                    await context.SaveChangesAsync();
                    return View("Edit", cardio);
                }
                catch (DbUpdateException /* ex */)
                {
                    ModelState.AddModelError("", "Unable to save changes. " +
                                                 "Try again, and if the problem persists, " +
                                                 "see your system administrator.");
                }
            }
            return View(cardio);
        }
        public IActionResult Delete(int id)
        {
            var cardio = context.Cardio.Find(id);
            if (cardio == null)
            {
                return NotFound();
            }

            context.Cardio.Remove(cardio);
            context.SaveChanges();
            return View("CardioDeleted", cardio);
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cardio = await context.Cardio
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.Id == id);

            if (cardio == null)
            {
                return NotFound();
            }

            return View("Details", cardio);
        }
    }
}