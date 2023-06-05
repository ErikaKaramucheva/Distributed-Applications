using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Brand:BaseEntity
    {
        [Required]
        [StringLength(20)]
        public string Name { get; set; }
        //  public virtual ICollection<Model> Models { get; set; }

    }
}
