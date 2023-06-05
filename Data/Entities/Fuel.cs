using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Fuel:BaseEntity
    {
        [Required]
        [StringLength(15)]
        public string Name { get; set; }
    }
}
