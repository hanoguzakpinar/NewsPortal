using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsPortal.Data.Abstract;
using NewsPortal.Data.Concrete.EntityFramework.Contexts;
using NewsPortal.Data.Concrete.EntityFramework.Repositories;

namespace NewsPortal.Data.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly NewsPortalContext _context;
        private EfReportRepository _reportRepository;
        private EfCategoryRepository _categoryRepository;
        private EfCommentRepository _commentRepository;
        public UnitOfWork(NewsPortalContext context)
        {
            _context = context;
        }
        // ?? null kontrolü -- Null Coalescing
        public IReportRepository Reports => _reportRepository ?? new EfReportRepository(_context);
        public ICategoryRepository Categories => _categoryRepository ?? new EfCategoryRepository(_context);
        public ICommentRepository Comments => _commentRepository ?? new EfCommentRepository(_context);
        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }
    }
}