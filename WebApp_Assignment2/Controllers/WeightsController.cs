using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GymBuddyWebApp.Domain;
using Microsoft.AspNetCore.Mvc;
using GymBuddyWebApp.Data;

namespace WebApp_Assignment2.Controllers
{
   
    public class WeightsController : Controller
    {
        GymBuddyContext context = new GymBuddyContext();
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
    }
}
