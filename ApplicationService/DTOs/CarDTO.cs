using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.ComponentModel.DataAnnotations;

namespace ApplicationService.DTOs
{
    public class CarDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="This field is required!")]
        public int Brand_id { get; set; }
        public virtual BrandDTO Brand { get; set; }
        [Required(ErrorMessage = "This field is required!")]
        public int Model_id { get; set; }
        public virtual ModelDTO Model { get; set; }
        [Required(ErrorMessage = "This field is required!") ]
        [StringLength(25,MinimumLength =3)]
        public string Color { get; set; }
        [Required(ErrorMessage = "This field is required!") ]
        public int User_id { get; set; }
        public IdentityUser User { get; set; }
        [Required(ErrorMessage = "This field is required!") ]
        public double Price { get; set; }
        
        public int Mileage { get; set; }
        public DateTime? Year { get; set; }
        [Required(ErrorMessage = "This field is required!") ]
        public int Fuel_id { get; set; }
        public virtual FuelDTO Fuel { get; set; }
        [Required(ErrorMessage = "This field is required!") ]
        public int Class_id { get; set; }
        public virtual CarClassDTO Class { get; set; }
        [Required(ErrorMessage = "This field is required!") ]
        public int Transmission_id { get; set; }
        public virtual TransmissionDTO Transmission { get; set; }
        [Required(ErrorMessage = "This field is required!")]
        public int CarStatus_id { get; set; }
        public virtual CarStatusDTO CarStatus { get; set; }
        [Required(ErrorMessage = "This field is required!")]
        public int Town_id { get; set; }
        public virtual TownDTO Town { get; set; }
        [StringLength(255)]
        public string Description { get; set; }
      //  [RegularExpression(@"(https?:\/\/(?:www\.|(?!www))[a-zA-Z0-9][a-zA-Z0-9-]+[a-zA-Z0-9]\.[^\s]{2,}|www\.[a-zA-Z0-9][a-zA-Z0-9-]+[a-zA-Z0-9]\.[^\s]{2,}|https?:\/\/(?:www\.|(?!www))[a-zA-Z0-9]+\.[^\s]{2,}|www\.[a-zA-Z0-9]+\.[^\s]{2,})
//")]
[Url]
        public string ImageURL { get; set; }
        public DateTime? CreatedOn { get;  set; }
        public DateTime? UpdatedOn { get;  set; }
        public int CreatedBy { get;  set; }
        public int UpdatedBy { get;  set; }

        public bool Validate()
        {
            if(Brand_id>=0 &&Model_id>=0&&(!String.IsNullOrEmpty(Color))&& User_id>=0 &&
               Price>0 &&Fuel_id>=0 
                &&Class_id>=0&& Transmission_id>=0)
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
