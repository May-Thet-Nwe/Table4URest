using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Table4URest.Shared.Domain
{
    public class Review: BaseDomainModel
    {
        public string? Reviews { get; set; }
        public int StaffID { get; set; }
        public virtual Staff? Staff { get; set; }
        public int CustomerID { get; set; }
        public virtual Customer? Customer { get; set; }
        public virtual List<Reservation>? Reservations { get; set; }
    }
}
