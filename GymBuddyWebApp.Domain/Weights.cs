using System;
using System.Collections.Generic;
using System.Text;

namespace GymBuddyWebApp.Domain
{
   public class Weights
    {
        public int Id { get; set; }
        public int Reps { get; set; }
        public int Sets { get; set; }
        public double Weight { get; set; }
        public ExerciseTypes ExerciseType { get; set; }
        public DateTime Date { get; set; }
        public virtual Person Person { get; set; }
        public int PersonId { get; set; }

    }
}
