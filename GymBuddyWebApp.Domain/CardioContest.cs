using System;
using System.Collections.Generic;
using System.Text;

namespace GymBuddyWebApp.Domain
{
    public class CardioContest
    {
       
            public int Id { get; set; }
            public string Name { get; set; }
            public virtual ICollection<PersonCardioCompetiotion> Competitions { get; set; }
            public CardioTypes CardioTypes { get; set; }

     
    }

}

