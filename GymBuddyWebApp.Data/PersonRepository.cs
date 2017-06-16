using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using GymBuddyWebApp.Domain;

namespace GymBuddyWebApp.Data
{
    public class PersonRepository
    {
        private GymBuddyContext _context = new GymBuddyContext();

        public IEnumerable<Person> Persons => _context.Persons;
    }
}
