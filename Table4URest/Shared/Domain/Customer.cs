using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Table4URest.Shared.Domain
{
    public class Customer : BaseDomainModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "Name is too long.")]
        public string? Name { get; set; }

        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage ="Email address is not valid")]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"(6|8|9)\d{7}", ErrorMessage ="Contact number is not valid")]
        public int Contact { get; set; }
        public virtual List<Reservation>? Reservations { get; set; }

    }
}
