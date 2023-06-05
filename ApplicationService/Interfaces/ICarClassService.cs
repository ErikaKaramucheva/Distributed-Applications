using ApplicationService.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Interfaces
{
   public interface ICarClassService
    {
        List<CarClassDTO> Get();
        CarClassDTO GetById(int id);
        bool Save(CarClassDTO carClassDTO);

        bool Update(CarClassDTO carClassDTO);
        bool Delete(int id);
    }
}
