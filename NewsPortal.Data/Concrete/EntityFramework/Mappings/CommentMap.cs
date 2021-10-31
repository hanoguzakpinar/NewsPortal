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
    public class CommentMap : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();

            builder.Property(c => c.Text).IsRequired();
            builder.Property(c => c.Text).HasMaxLength(1000);

            builder.HasOne<Report>(a => a.Report).WithMany(a => a.Comments)
                .HasForeignKey(c => c.ReportId);

            builder.Property(c => c.CreatedByName).IsRequired();
            builder.Property(c => c.CreatedByName).HasMaxLength(50);
            builder.Property(c => c.CreatedDate).IsRequired();
            builder.Property(c => c.ModifiedByName).IsRequired();
            builder.Property(c => c.ModifiedByName).HasMaxLength(50);
            builder.Property(c => c.ModifiedDate).HasMaxLength(50);
            builder.Property(c => c.IsActive).IsRequired();
            builder.Property(c => c.IsDeleted).IsRequired();
            builder.Property(c => c.Note).HasMaxLength(500);

            builder.ToTable("Comments");

           // builder.HasData(
           //    new Comment
           //    {
           //        Id = 1,
           //        ReportId = 1,
           //        Text =
           //            "Lorem Ipsum pasajlarının birçok çeşitlemesi vardır. Ancak bunların büyük bir çoğunluğu mizah katılarak veya rastgele sözcükler eklenerek değiştirilmişlerdir. Eğer bir Lorem Ipsum pasajı kullanacaksanız",
           //        IsActive = true,
           //        IsDeleted = false,
           //        CreatedByName = "Initial Create",
           //        CreatedDate = DateTime.Now,
           //        ModifiedByName = "Initial Create",
           //        ModifiedDate = DateTime.Now,
           //        Note = "Spor Yorumu",
           //    },
           //    new Comment
           //    {
           //        Id = 2,
           //        ReportId = 2,
           //        Text =
           //            "Lorem Ipsum pasajlarının birçok çeşitlemesi vardır. Ancak bunların büyük bir çoğunluğu mizah katılarak veya rastgele sözcükler eklenerek değiştirilmişlerdir. Eğer bir Lorem Ipsum pasajı kullanacaksanız",
           //        IsActive = true,
           //        IsDeleted = false,
           //        CreatedByName = "Initial Create",
           //        CreatedDate = DateTime.Now,
           //        ModifiedByName = "Initial Create",
           //        ModifiedDate = DateTime.Now,
           //        Note = "Ekonomi Yorumu",
           //    },
           //    new Comment
           //    {
           //        Id = 3,
           //        ReportId = 3,
           //        Text =
           //            "Lorem Ipsum pasajlarının birçok çeşitlemesi vardır. Ancak bunların büyük bir çoğunluğu mizah katılarak veya rastgele sözcükler eklenerek değiştirilmişlerdir. Eğer bir Lorem Ipsum pasajı kullanacaksanız",
           //        IsActive = true,
           //        IsDeleted = false,
           //        CreatedByName = "Initial Create",
           //        CreatedDate = DateTime.Now,
           //        ModifiedByName = "Initial Create",
           //        ModifiedDate = DateTime.Now,
           //        Note = "Teknoloji Yorumu",
           //    }
           //);
        }
    }
}
