using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GymBuddyWebApp.Data;
using GymBuddyWebApp.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApp_Assignment2.Controllers
{
    public class CardioController : Controller
    {
        GymBuddyContext context = new GymBuddyContext();

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

    }
}