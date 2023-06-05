using ApplicationService.DTOs;
using ApplicationService.Implementations;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarMVC.Models
{
    public class CarVM:Service
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "This field is required!")]
        public int Brand_id { get; set; }
        public IEnumerable<BrandDTO> Brand { get; set; }
        [Required(ErrorMessage = "This field is required!")]
        public int Model_id { get; set; }
        public IEnumerable<ModelDTO> Model { get; set; }
        [Required(ErrorMessage = "This field is required!")]
        [StringLength(25, MinimumLength = 3)]
        public string Color { get; set; }
        [Required(ErrorMessage = "This field is required!")]
        public int User_id { get; set; }
        public IdentityUser User { get; set; }
        [Required(ErrorMessage = "This field is required!")]
        public double Price { get; set; }
        
        public int Mileage { get; set; }
        public DateTime? Year { get; set; }
        [Required(ErrorMessage = "This field is required!")]
        public int Fuel_id { get; set; }
        public IEnumerable<FuelDTO> Fuel { get; set; }
        [Required(ErrorMessage = "This field is required!")]
        public int Class_id { get; set; }
        public IEnumerable<CarClassDTO> Class { get; set; }
        [Required(ErrorMessage = "This field is required!")]
        public int Transmission_id { get; set; }
        public IEnumerable<TransmissionDTO> Transmission { get; set; }
        [Required(ErrorMessage = "This field is required!")]
        public int Town_id { get; set; }
        public IEnumerable<TownDTO> Town { get; set; }
        [Required(ErrorMessage = "This field is required!")]
        public int CarStatus_id { get; set; }
        public IEnumerable<CarStatusDTO> Status { get; set; }
        [Required(ErrorMessage = "This field is required!")]
        [StringLength(255)]
        public string Description { get; set; }
       // [RegularExpression(@"(https?:\/\/(?:www\.|(?!www))[a-zA-Z0-9][a-zA-Z0-9-]+[a-zA-Z0-9]\.[^\s]{2,}|www\.[a-zA-Z0-9][a-zA-Z0-9-]+[a-zA-Z0-9]\.[^\s]{2,}|https?:\/\/(?:www\.|(?!www))[a-zA-Z0-9]+\.[^\s]{2,}|www\.[a-zA-Z0-9]+\.[^\s]{2,})
//")]
        [Url]
        public string ImageURL { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public int CreatedBy { get;  set; }
        public int UpdatedBy { get; set; }

       
        /*public List<ModelDTO> getBrandsFromModel(int ){        }*/
       
       
    }
}
