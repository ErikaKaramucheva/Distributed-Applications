using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Transmission:BaseEntity
    {
        [Required]
        [StringLength(12)]
        public string Name { get; set; }
    }
}
