using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.DTOs
{
    public class ModelDTO
    {
        public int Id { get; set; }
        [Required (ErrorMessage = "This field is required!")]
        [StringLength(50,MinimumLength =2)]
        public string Name { get; set; }
        [Required (ErrorMessage = "This field is required!")]
        public int Brand_id { get; set; }
        public virtual BrandDTO Brand { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int CreatedBy { get;  set; }
        public DateTime? UpdatedOn { get;  set; }
        public int UpdatedBy { get;  set; }

        public bool Validate()
        {
            if ((!String.IsNullOrEmpty(Name)) && Brand_id >= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
