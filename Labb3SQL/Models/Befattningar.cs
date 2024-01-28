using System;
using System.Collections.Generic;

namespace Labb3SQL.Models
{
    public partial class Befattningar
    {
        public Befattningar()
        {
            Personals = new HashSet<Personal>();
        }

        public int BefattningsId { get; set; }
        public string? Befattningstyp { get; set; }

        public virtual ICollection<Personal> Personals { get; set; }
    }
}
