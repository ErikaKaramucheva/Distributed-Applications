using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public interface IUserName
    {
        string Username { get; set; }
        string Password { get; set; }
    }
}
