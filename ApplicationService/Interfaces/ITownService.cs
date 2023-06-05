using ApplicationService.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Interfaces
{
   public interface ITownService
    {
        List<TownDTO> Get();
        TownDTO GetById(int id);
        bool Save(TownDTO townDTO);

        bool Update(TownDTO townDTO);
        bool Delete(int id);
    }
}
