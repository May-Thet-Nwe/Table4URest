using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Table4URest.Shared.Domain
{
    public class Staff: BaseDomainModel
    {
        public string? Name { get; set; }
        public string? Position { get; set; }
        public int RestaurantID { get; set; }
        public virtual Restaurant? Restaurant { get; set; }
    }
}
