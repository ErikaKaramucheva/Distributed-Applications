using ApplicationService.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Interfaces
{
    public interface IUserService
    {
        List<UserDTO> Get();
        UserDTO GetById(int id);
        bool Save(UserDTO userDTO);

        bool Update(UserDTO userDTO);
        bool Delete(int id);
    }
}
