using System;
using System.Collections.Generic;
using System.Text;
using Codenation.Challenge.Exceptions;
using System.Linq;

namespace Codenation.Challenge
{
    public class Team
    {
      // PROPERTIES

      public long Id { get; set; }
      public string Name { get; set; }
      public DateTime CreateDate { get; set; }
      public string MainShirtColor { get; set; }
      public string SecondaryShirtColor { get; set; }
      public int Captain { get; set; } // player id
      public long VisitorTeamId { get; set; }

    }
}
