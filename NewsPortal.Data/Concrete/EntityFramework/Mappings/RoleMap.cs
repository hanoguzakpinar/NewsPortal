using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewsPortal.Entities.Concrete;

namespace NewsPortal.Data.Concrete.EntityFramework.Mappings
{
    public class RoleMap : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(r => r.Id);
            builder.Property(r => r.Id).ValueGeneratedOnAdd();

            builder.Property(r => r.Name).IsRequired();
            builder.Property(r => r.Name).HasMaxLength(30);
            builder.Property(r => r.Description).IsRequired();
            builder.Property(r => r.Description).HasMaxLength(250);

            builder.Property(r => r.CreatedByName).IsRequired();
            builder.Property(r => r.CreatedByName).HasMaxLength(50);
            builder.Property(r => r.CreatedDate).IsRequired();
            builder.Property(r => r.ModifiedByName).IsRequired();
            builder.Property(r => r.ModifiedByName).HasMaxLength(50);
            builder.Property(r => r.ModifiedDate).HasMaxLength(50);
            builder.Property(r => r.IsActive).IsRequired();
            builder.Property(r => r.IsDeleted).IsRequired();
            builder.Property(r => r.Note).HasMaxLength(500);

            builder.ToTable("Roles");

            builder.HasData(new Role
            {
                Id = 1,
                Name = "Admin",
                Description = "Admin Rolü. Tüm Haklara Sahiptir.",
                IsActive = true,
                IsDeleted = false,
                CreatedByName = "Initial Create",
                CreatedDate = DateTime.Now,
                ModifiedByName = "Initial Create",
                ModifiedDate = DateTime.Now,
                Note = "Admin Rolüdür."
            });
            // Fluent Api ile veri eklerken bütün değerler girilmek zorundadır. Null olabilenler dahil.
        }
    }
}
