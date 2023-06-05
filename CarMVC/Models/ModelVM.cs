using ApplicationService.DTOs;
using ApplicationService.Implementations;
using Repository.Implementations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarMVC.Models
{
    public class ModelVM:Service
    {

        public int Id { get; set; }
        [Required(ErrorMessage = "This field is required!")]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; }
        [Required(ErrorMessage = "This field is required!")]
        public int Brand_id { get; set; }
        public IEnumerable<BrandDTO> Brand { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public int UpdatedBy { get; set; }
      
       
    }
}
