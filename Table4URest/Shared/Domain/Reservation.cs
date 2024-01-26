using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Table4URest.Shared.Domain
{
    public class Reservation: BaseDomainModel
    {
        public int AdultNum { get; set; }
        public int ChildNum { get; set; }
        public DateTime DateTime { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer? Customer { get; set; }
        public int RestaurantId { get; set; }
        public virtual Restaurant? Restaurant { get; set; }
        
    }
}
