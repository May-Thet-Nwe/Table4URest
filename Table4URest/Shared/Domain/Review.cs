using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Table4URest.Shared.Domain
{
    public class Review: BaseDomainModel
    {
      
        public int Reviews { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer? Customer { get; set; }
        public int RestaurantId { get; set; }
        public virtual Restaurant? Restaurant { get; set; }
        public virtual List<Reservation>? Reservations { get; set; }
    }
}
