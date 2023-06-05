using Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Context
{
    public class ProjectDbContext:DbContext
    {
        
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<CarClass> CarClass { get; set; }
        public DbSet<CarStatus> CarStatus { get; set; }
        public DbSet<Fuel> Fuel { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Town> Towns { get; set; }
        public DbSet<Transmission> Transmissions { get; set; }
        public DbSet<User> Users { get; set; }

        
    
    }
}
