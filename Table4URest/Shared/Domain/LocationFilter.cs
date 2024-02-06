using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Table4URest.Shared.Domain
{
    public class LocationFilter: BaseDomainModel
    {
        [Required]
        [RegularExpression(@"^\d{6}$", ErrorMessage = "Postal code must be 6 digits.")]    /* need 6 digits*/
        public int PostalCode { get; set; }
    }
}
