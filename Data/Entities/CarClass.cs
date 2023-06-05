using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class CarClass:BaseEntity
    {

        [Required(ErrorMessage = "This field is required!")]
        [StringLength(35)]
        public string Name { get; set; }
    }
}
