using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Table4URest.Shared.Domain
{
    public class Customer : BaseDomainModel
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public int Contact { get; set; }
        public virtual List<Reservation>? Reservations { get; set; }

    }
}
