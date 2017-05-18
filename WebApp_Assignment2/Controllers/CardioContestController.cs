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
    public class CardioContestController : Controller
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

    
    public IActionResult SaveCompetition(CardioContest competition)
    {
        if (!ModelState.IsValid)
        {
            return View("Create");
        }
        context.CardioContests.Add(competition);
        context.SaveChanges();
        return View("CompetitionAdded", competition);
    }
    public IActionResult Update(int id, CardioContest competition)
    {
        if (competition == null || competition.Id != id)
        {
            return BadRequest();
        }

        var findCompetition = context.CardioContests.Find(id);
        if (findCompetition == null)
        {
            return NotFound();
        }
        findCompetition.Id = competition.Id;
        findCompetition.Competitions = competition.Competitions;
        findCompetition.CardioTypes = competition.CardioTypes;
        findCompetition.Name = competition.Name;
   



        context.CardioContests.Update(findCompetition);
        context.SaveChanges();
        return View("Index");
    }
    public async Task<IActionResult> Edit(int id)
    {
        var competition = await context.CardioContests
            .SingleAsync(w => w.Id == id);

        if (competition == null)
        {
            return NotFound();
        }
        if (ModelState.IsValid)
        {
            try
            {
                context.Update(competition);
                await context.SaveChangesAsync();
                return View("Edit", competition);
            }
            catch (DbUpdateException /* ex */)
            {
                ModelState.AddModelError("", "Unable to save changes. " +
                                             "Try again, and if the problem persists, " +
                                             "see your system administrator.");
            }
        }
        return View(competition);
    }
    public IActionResult Delete(int id)
    {
        var competition = context.CardioContests.Find(id);
        if (competition == null)
        {
            return NotFound();
        }

        context.CardioContests.Remove(competition);
        context.SaveChanges();
        return View("CompetitionDeleted", competition);
    }
}
}
