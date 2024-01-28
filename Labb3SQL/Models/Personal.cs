using System;
using System.Collections.Generic;

namespace Labb3SQL.Models
{
    public partial class Personal
    {
        public Personal()
        {
            Betygs = new HashSet<Betyg>();
        }

        public int PersonalId { get; set; }
        public string Namn { get; set; } = null!;
        public int? BefattningsId { get; set; }
        public string Personnummer { get; set; } = null!;

        public virtual Befattningar? Befattnings { get; set; }
        public virtual ICollection<Betyg> Betygs { get; set; }
    }
}
