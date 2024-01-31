using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Table4URest.Shared.Domain
{
    public class Restaurant : BaseDomainModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "Name is too long.")]
        public string? Name { get; set; }
        public string? Address { get; set; }
        public byte[] menuPic { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"(6|8|9)\d{7}", ErrorMessage = "Contact number is not valid")]
        public int Contact { get; set; }    
        public int PriceFilterId { get; set; }
        public virtual PriceFilter? PriceFilter { get; set; }
        public int LocationFilterId { get; set; }
        public virtual LocationFilter? LocationFilter { get; set; }
        public int ServeFilterId { get; set; }
        public virtual ServeFilter? ServeFilter { get; set; }
        public virtual ICollection<Reservation>? Reservations { get; set; }

    }
}
