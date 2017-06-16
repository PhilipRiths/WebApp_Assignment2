using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GymBuddyWebApp.Domain;

namespace WebApp_Assignment2.Models
{
    public class PersonViewModel
    {
        public IEnumerable<Person> Persons { get; set; }
    }
}
