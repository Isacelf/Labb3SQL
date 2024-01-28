using System;
using System.Collections.Generic;

namespace Labb3SQL.Models
{
    public partial class Student
    {
        public Student()
        {
            Betygs = new HashSet<Betyg>();
        }

        public int ElevId { get; set; }
        public string Klassnamn { get; set; } = null!;
        public string Personnummer { get; set; } = null!;
        public string? Förnamn { get; set; }
        public string? Efternamn { get; set; }

        public virtual ICollection<Betyg> Betygs { get; set; }
    }
}
