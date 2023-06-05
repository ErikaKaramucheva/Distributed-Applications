using ApplicationService.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Interfaces
{
    public interface IFuelService
    {
        List<FuelDTO> Get();
        FuelDTO GetById(int id);
        bool Save(FuelDTO fuelDTO);

        bool Update(FuelDTO fuelDTO);
        bool Delete(int id);
    }
}
