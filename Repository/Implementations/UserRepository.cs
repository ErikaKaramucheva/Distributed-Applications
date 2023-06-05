using Data.Context;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Implementations
{
    public class UserRepository<TEntity> : GenericRepository<TEntity> where TEntity : class, IUserName
    {
        public UserRepository(ProjectDbContext context) : base(context)
        {
        }

        public virtual TEntity GetByUserName(string userName,string password)
        {
            return (from e in base.context.Set<TEntity>()
                    where e.Username == userName && e.Password==password
                    select e).SingleOrDefault();
        }
    }
}
