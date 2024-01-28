using System;
using System.Collections.Generic;

namespace Labb3SQL.Models
{
    public partial class Betyg
    {
        public int BetygId { get; set; }
        public DateTime Datum { get; set; }
        public int? ElevId { get; set; }
        public int? KursId { get; set; }
        public int? PersonalId { get; set; }
        public int? Betyg1 { get; set; }
        public string? BetygText { get; set; }

        public virtual Student? Elev { get; set; }
        public virtual Kur? Kurs { get; set; }
        public virtual Personal? Personal { get; set; }
    }
}
