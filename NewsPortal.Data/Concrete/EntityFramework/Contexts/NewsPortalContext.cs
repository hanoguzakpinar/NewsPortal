using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NewsPortal.Entities.Concrete;

namespace NewsPortal.Data.Concrete.EntityFramework.Contexts
{
    public class NewsPortalContext : DbContext
    {
        public DbSet<Report> Reports { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                connectionString: @"Server=LAZRAEL\SQLEXPRESS;Database=NewsPortal;Trusted_Connection=True;Connect Timeout=30;MultipleActiveResultSets=True;");
        }
    }
}
