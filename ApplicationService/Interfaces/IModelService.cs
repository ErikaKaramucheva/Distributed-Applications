using ApplicationService.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Interfaces
{
    public interface IModelService
    {
        List<ModelDTO> Get();
        ModelDTO GetById(int id);
        bool Save(ModelDTO modelDTO);

        bool Update(ModelDTO modelDTO);
        bool Delete(int id);
    }
}
