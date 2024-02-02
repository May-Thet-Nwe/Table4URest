using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Table4URest.Shared.Domain
{
    public class Reservation : BaseDomainModel
    {
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Adult number should not be negative.")]
        public int AdultNum { get; set; }
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Children number must not be negative.")]
        public int ChildNum { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateTime { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer? Customer { get; set; }
        public int RestaurantId { get; set; }
        public virtual Restaurant? Restaurant { get; set; }
    }
}