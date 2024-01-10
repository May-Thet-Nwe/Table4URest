using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Table4URest.Shared.Domain
{
    public class PriceFilter: BaseDomainModel
    {
        public string? PriceRange { get; set; }
    }
}
