using System;
using System.Collections.Generic;

namespace Labb3SQL.Models
{
    public partial class Kur
    {
        public Kur()
        {
            Betygs = new HashSet<Betyg>();
        }

        public int KursId { get; set; }
        public string Kursnamn { get; set; } = null!;

        public virtual ICollection<Betyg> Betygs { get; set; }
    }
}
