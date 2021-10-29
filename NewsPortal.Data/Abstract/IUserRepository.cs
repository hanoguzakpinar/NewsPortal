using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsPortal.Entities.Concrete;
using NewsPortal.Shared.Data.Abstract;

namespace NewsPortal.Data.Abstract
{
    public interface IUserRepository : IEntityRepository<User>
    {
    }
}
