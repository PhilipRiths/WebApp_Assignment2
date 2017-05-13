using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace GymBuddyWebApp.Domain
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public virtual ICollection<Weights> WeightExercises { get; set; }
        public virtual ICollection<Cardio> CardioExercises { get; set; }


    }
}
