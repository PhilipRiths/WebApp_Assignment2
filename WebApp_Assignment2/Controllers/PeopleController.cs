using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GymBuddyWebApp.Data;
using GymBuddyWebApp.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp_Assignment2.Models;

namespace WebApp_Assignment2.Controllers
{
    public class PeopleController : Controller
    {
        GymBuddyContext context = new GymBuddyContext();
        public List<Person> Persons = new List<Person>();

        // GET: People
        public ActionResult Index()
        {
            if (Persons.Count < 1)
            {
                AddPersonToList();
            }
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        public void AddPersonToList()
        {
           
                foreach (var person in context.Persons)
                {
                    Persons.Add(person);
                }
            
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

        public IActionResult DeleteMe()
        {
            return View();
        }
        public ViewResult ListAllPeople()
        {
            IEnumerable<Person> persons;
                persons = context.Persons.OrderBy(p => p.Id);
return View(new PersonViewModel
            {
              Persons = persons
            });
        }

        public void LoadPeople()
        {
            var person = new Person
            {
                Age = 25,
                FirstName = "Philip",
                LastName = "Ryström",
                Height = 175,
                Weight = 80
            };
            context.Add(person);
            var person1 = new Person
            {
                Age = 25,
                FirstName = "Kalle",
                LastName = "Anka",
                Height = 160,
                Weight = 40
            };
            context.Add(person1);
            var person2 = new Person
            {
                Age = 25,
                FirstName = "Knatte",
                LastName = "Anka",
                Height = 120,
                Weight = 30
            };
            context.Add(person2);
            var person3 = new Person
            {
                Age = 25,
                FirstName = "Fnatte",
                LastName = "Anka",
                Height = 120,
                Weight = 30
            };
            context.Add(person3);
            var person4 = new Person
            {
                Age = 25,
                FirstName = "Tjatte",
                LastName = "Anka",
                Height = 120,
                Weight = 30
            };
            context.Add(person4);
            context.SaveChanges();
        }

        public IActionResult LoadPeoples()
        {
            LoadPeople();
            return Ok();
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
        
        
        public IActionResult Update(int id, Person person)
        {
            if (person == null || person.Id != id)
            {
                return BadRequest();
            }

            var findPerson = context.Persons.Find(id);
            if (findPerson == null)
            {
                return NotFound();
            }
            findPerson.Id = person.Id;
            findPerson.Age = person.Age;
            findPerson.FirstName = person.FirstName;
            findPerson.LastName = person.LastName;
            findPerson.Height = person.Height;
            findPerson.Weight = person.Height;


            context.Persons.Update(findPerson);
            context.SaveChanges();
            return View("Index");
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
                    ModelState.AddModelError("", "Unable to save changes. " +
                                                 "Try again, and if the problem persists, " +
                                                 "see your system administrator.");
                }
            }
            return View(person);
        }
        public IActionResult Delete(int id)
        {
            var person = context.Persons.Find(id);
            if (person == null)
            {
                return NotFound();
            }

            context.Persons.Remove(person);
            context.SaveChanges();
            return View("PersonDeleted", person);
        }
    }
}
