using System;
using System.Collections.Generic;
using System.Text;

namespace GymBuddyWebApp.Domain
{
   public class Cardio
    {
        public int Id { get; set; }
        public int Time { get; set; }
        public double Distance { get; set; }
       public CardioTypes CardioType { get; set; }
        public DateTime Date { get; set; }
        public virtual Person Person { get; set; }
        public int PersonId { get; set; }
    }
}
