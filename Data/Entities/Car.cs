using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    
    public class Car:BaseEntity
    {
        [Required]
        public int Brand_id { get; set; }
        [Required]
        public int Model_id { get; set; }
        [Required]
        [StringLength(25)]
        public string Color { get; set; }
        [Required]
        public int User_id { get; set; }
        [Required]
        public double Price { get; set; }
        public int Mileage { get; set; }
        public DateTime? Year { get; set; }
        [Required]
        public int Fuel_id { get; set; }
        [Required]
        public int Class_id { get; set; }
        [Required]
        public int Transmission_id { get; set; }

        public int Town_id { get; set; }
        [Required]
        public int CarStatus_id { get; set; }
        [StringLength(255)]
        public string Description { get; set; }

       // [RegularExpression(@"(https?:\/\/(?:www\.|(?!www))[a-zA-Z0-9][a-zA-Z0-9-]+[a-zA-Z0-9]\.[^\s]{2,}|www\.[a-zA-Z0-9][a-zA-Z0-9-]+[a-zA-Z0-9]\.[^\s]{2,}|https?:\/\/(?:www\.|(?!www))[a-zA-Z0-9]+\.[^\s]{2,}|www\.[a-zA-Z0-9]+\.[^\s]{2,})
//")]
[Url]
        public string ImageURL { get; set; }

    }
}
