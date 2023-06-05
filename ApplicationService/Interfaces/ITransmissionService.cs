using ApplicationService.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Interfaces
{
    public interface ITransmissionService
    {
        List<TransmissionDTO> Get();
        TransmissionDTO GetById(int id);
        bool Save(TransmissionDTO transmissionDTO);

        bool Update(TransmissionDTO transmissionDTO);
        bool Delete(int id);
    }
}
