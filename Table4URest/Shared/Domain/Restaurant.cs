using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Table4URest.Shared.Domain
{
    public class Restaurant : BaseDomainModel
    {
        public string? Name { get; set; }
        public string? Address { get; set; }
        public int Contact { get; set; }    
        public string? PriceRange { get; set; }
        public virtual PriceFilter? PriceFilter { get; set; }
        public int PostalCode { get; set; }
        public virtual LocationFilter? LocationFilter { get; set; }
        public string? ServeRange { get; set; }
        public virtual ServeFilter? ServeFilter { get; set; }
        public virtual List<Reservation>? Reservations { get; set; }

    }
}
