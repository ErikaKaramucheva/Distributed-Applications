using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Town:BaseEntity
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
    }
}
