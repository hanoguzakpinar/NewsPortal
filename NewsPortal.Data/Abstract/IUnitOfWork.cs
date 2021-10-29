using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsPortal.Data.Abstract
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IReportRepository Reports { get; } //unitofworks.Reports
        ICategoryRepository Categories { get; }
        ICommentRepository Comments { get; }
        IRoleRepository Roles { get; }
        IUserRepository Users { get; } //_unitOfWork.Users.AddAsync();
        Task<int> SaveAsync();
    }
}