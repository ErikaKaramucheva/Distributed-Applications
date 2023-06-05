using Data.Context;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Implementations
{
    public class UnitOfWork:IDisposable
    {
        private ProjectDbContext context = new ProjectDbContext();
        private GenericRepository<Brand> brandRepository;
        private GenericRepository<Data.Entities.Car> carRepository;
        private GenericRepository<CarClass> carClassRepository;
        private GenericRepository<CarStatus> carStatusRepository;
        private GenericRepository<Fuel> fuelRepository;
        private GenericRepository<Model> modelRepository;
        private GenericRepository<Town> townRepository;
        private GenericRepository<Transmission> transmissionRepository;
        private GenericRepository<User> userRepository;

        public GenericRepository<Brand> BrandRepository
        {
            get
            {

                if (this.brandRepository == null)
                {
                    this.brandRepository = new GenericRepository<Brand>(context);
                }
                return brandRepository;
            }
        }

        public GenericRepository<Data.Entities.Car> CarRepository
        {
            get
            {

                if (this.carRepository == null)
                {
                    this.carRepository = new GenericRepository<Data.Entities.Car>(context);
                }
                return carRepository;
            }
        }
        public GenericRepository<CarClass> CarClassRepository
        {
            get
            {

                if (this.carClassRepository == null)
                {
                    this.carClassRepository = new GenericRepository<CarClass>(context);
                }
                return carClassRepository;
            }
        }

        public GenericRepository<CarStatus> CarStatusRepository
        {
            get
            {

                if (this.carStatusRepository == null)
                {
                    this.carStatusRepository = new GenericRepository<CarStatus>(context);
                }
                return carStatusRepository;
            }
        }
        public GenericRepository<Fuel> FuelRepository
        {
            get
            {

                if (this.fuelRepository == null)
                {
                    this.fuelRepository = new GenericRepository<Fuel>(context);
                }
                return fuelRepository;
            }
        }
 
        public GenericRepository<Model> ModelRepository
        {
            get
            {

                if (this.modelRepository == null)
                {
                    this.modelRepository = new GenericRepository<Model>(context);
                }
                return modelRepository;
            }
        }
        public GenericRepository<Town> TownRepository
        {
            get
            {

                if (this.townRepository == null)
                {
                    this.townRepository = new GenericRepository<Town>(context);
                }
                return townRepository;
            }
        }
       
        public GenericRepository<Transmission> TransmissionRepository
        {
            get
            {

                if (this.transmissionRepository == null)
                {
                    this.transmissionRepository = new GenericRepository<Transmission>(context);
                }
                return transmissionRepository;
            }
        }
        public UserRepository<User> UserRepository
        {
            get
            {

                if (this.userRepository == null)
                {
                    this.userRepository = new UserRepository<User>(context);
                }
                return (UserRepository<User>)userRepository;
            }
        }
        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
