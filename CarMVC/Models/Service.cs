using ApplicationService.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarMVC.Models
{
    public abstract class Service
    {
        public string UserName(int id)
        {
           UserService us = new UserService();
            var user = us.GetById(id);
            return user.FirstName+" "+user.LastName;

        }
        public string BrandName(int id)
        {
            BrandService bs = new BrandService();
            var brand = bs.GetById(id);
            return brand.Name;

        }
        public string ModelName(int id)
        {
            ModelService ms = new ModelService();
            var model = ms.GetById(id);
            return model.Name;

        }
        public string FuelName(int id)
        {
            FuelService fs = new FuelService();
            var fuel = fs.GetById(id);
            return fuel.Name;

        }
        public string ClassName(int id)
        {
            CarClassService cs = new CarClassService();
            var carClass = cs.GetById(id);
            return carClass.Name;

        }
        public string TransmissionName(int id)
        {
            TransmissionService ts = new TransmissionService();
            var tran = ts.GetById(id);
            return tran.Name;

        }
        public string StatusName(int id)
        {
            CarStatusService s = new CarStatusService();
            var status = s.GetById(id);
            return status.Name;

        }
        public string TownName(int id)
        {
            TownService ts = new TownService();
            var town = ts.GetById(id);
            return town.Name;

        }
        public string GetUserPhone(int id)
        {
            UserService us = new UserService();
            var phone = us.GetById(id);
            return phone.Phone;

        }
        public string GetUserEmail(int id)
        {
            UserService us = new UserService();
            var user = us.GetById(id);
            return user.Email;

        }
    }
}
