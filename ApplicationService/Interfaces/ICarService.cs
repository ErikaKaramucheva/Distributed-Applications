using ApplicationService.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Interfaces
{
    public interface ICarService
    {
        List<CarDTO> Get();
        CarDTO GetById(int id);
        bool Save(CarDTO carDTO);

        bool Update(CarDTO carDTO);
        bool Delete(int id);
    }
}
