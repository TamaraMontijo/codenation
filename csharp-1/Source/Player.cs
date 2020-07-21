using System;
using System.Collections.Generic;
using System.Text;
using Codenation.Challenge.Exceptions;
using System.Linq;

namespace Codenation.Challenge
{
    public class Player
    {
      //PROPERTIES

      public long Id { get; set; }
      public long TeamId { get; set; }
      public string Name { get; set; }
      public DateTime BirthDate { get; set; }
      public int SkillLevel { get; set; } // from 0 to 100
      public decimal Salary { get; set; }
      public bool Captain { get; set; } // true or false
    }
}
