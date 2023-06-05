using ApplicationService.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Interfaces
{
    public interface ICarStatus
    {
        List<CarStatusDTO> Get();
        CarStatusDTO GetById(int id);
        bool Save(CarStatusDTO statusDTO);

        bool Update(CarStatusDTO statusDTO);
        bool Delete(int id);
    }
}
