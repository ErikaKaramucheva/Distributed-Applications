using ApplicationService.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Interfaces
{
    public interface IBrandService
    {
        List<BrandDTO> Get();
        BrandDTO GetById(int id);
        bool Save(BrandDTO brandDTO);

        bool Update(BrandDTO brandDTO);
        bool Delete(int id);
    }
}
