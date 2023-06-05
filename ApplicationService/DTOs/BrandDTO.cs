using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.DTOs
{
   public class BrandDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "This field is required!")]
        [StringLength(20,MinimumLength =2)]
        public string Name { get; set; }
        public DateTime? CreatedOn { get;  set; }
        public int CreatedBy { get;  set; }
        public DateTime? UpdatedOn { get;  set; }
        public int UpdatedBy { get;  set; }

        public bool Validate()
        {
            return !String.IsNullOrEmpty(Name);
        }
    }
}
