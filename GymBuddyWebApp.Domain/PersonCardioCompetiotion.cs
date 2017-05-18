using System;
using System.Collections.Generic;
using System.Text;

namespace GymBuddyWebApp.Domain
{
   public class PersonCardioCompetiotion
    {
        public int Id { get; set; }
        public virtual CardioContest CardioContest{ get; set; }
        public virtual Person Person { get; set; }
        public int CardioContestId { get; set; }
        public int PersonId { get; set; }
    }
}
