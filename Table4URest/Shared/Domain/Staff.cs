using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Table4URest.Shared.Domain
{
    public class Staff: BaseDomainModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "Name is too long.")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Please provide a position")]
        public string? Position { get; set; }
        
    }
}
