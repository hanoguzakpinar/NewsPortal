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
    public class ReportMap : IEntityTypeConfiguration<Report>
    {
        public void Configure(EntityTypeBuilder<Report> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();

            builder.Property(a => a.Title).HasMaxLength(100);
            builder.Property(a => a.Title).IsRequired(true);
            builder.Property(a => a.Content).IsRequired();
            builder.Property(a => a.Content).HasColumnType("NVARCHAR(MAX)");
            builder.Property(a => a.Date).IsRequired();
            builder.Property(a => a.SeoAuthor).IsRequired();
            builder.Property(a => a.SeoAuthor).HasMaxLength(50);
            builder.Property(a => a.SeoDescription).HasMaxLength(150);
            builder.Property(a => a.SeoDescription).IsRequired();
            builder.Property(a => a.SeoTags).IsRequired();
            builder.Property(a => a.SeoTags).HasMaxLength(70);
            builder.Property(a => a.ViewsCount).IsRequired();
            builder.Property(a => a.CommentCount).IsRequired();
            builder.Property(a => a.Thumbnail).IsRequired();
            builder.Property(a => a.Thumbnail).HasMaxLength(250);

            builder.Property(a => a.CreatedByName).IsRequired();
            builder.Property(a => a.CreatedByName).HasMaxLength(50);
            builder.Property(a => a.CreatedDate).IsRequired();
            builder.Property(a => a.ModifiedByName).IsRequired();
            builder.Property(a => a.ModifiedByName).HasMaxLength(50);
            builder.Property(a => a.ModifiedDate).IsRequired();
            builder.Property(a => a.IsActive).IsRequired();
            builder.Property(a => a.IsDeleted).IsRequired();
            builder.Property(a => a.Note).HasMaxLength(500);

            builder.HasOne<Category>(a => a.Category).WithMany(c => c.Reports)
                .HasForeignKey(a => a.CategoryId);
            builder.HasOne<User>(u => u.User).WithMany(u => u.Reports)
                .HasForeignKey(a => a.UserId);

            builder.ToTable("Reports");

            //builder.HasData(
            //    new Report
            //    {
            //        Id = 1,
            //        CategoryId = 1,
            //        Title = "GS 1 - 0 Lok. Moskova",
            //        Content =
            //            "Lorem Ipsum, dizgi ve baskı endüstrisinde kullanılan mıgır metinlerdir. Lorem Ipsum, adı bilinmeyen bir matbaacının bir hurufat numune kitabı oluşturmak üzere bir yazı galerisini alarak karıştırdığı 1500'lerden beri endüstri standardı sahte metinler olarak kullanılmıştır. Beşyüz yıl boyunca varlığını sürdürmekle kalmamış, aynı zamanda pek değişmeden elektronik dizgiye de sıçramıştır. 1960'larda Lorem Ipsum pasajları da içeren Letraset yapraklarının yayınlanması ile ve yakın zamanda Aldus PageMaker gibi Lorem Ipsum sürümleri içeren masaüstü yayıncılık yazılımları ile popüler olmuştur.",
            //        Thumbnail = "Default.jpg",
            //        SeoDescription = "GS vs Moskova",
            //        SeoTags = "GS Futbol Avrupa Rusya Türkiye",
            //        SeoAuthor = "Oğuzhan Akpınar",
            //        Date = DateTime.Now,
            //        IsActive = true,
            //        IsDeleted = false,
            //        CreatedByName = "Initial Create",
            //        CreatedDate = DateTime.Now,
            //        ModifiedByName = "Initial Create",
            //        ModifiedDate = DateTime.Now,
            //        Note = "GS,Moskova futbol maçı yazısı",
            //        UserId = 1,
            //        ViewsCount = 100,
            //        CommentCount = 1
            //    },
            //    new Report
            //    {
            //        Id = 2,
            //        CategoryId = 2,
            //        Title = "Kishu coin nedir? Kishu coin ne kadar, kaç TL?",
            //        Content =
            //            "Yinelenen bir sayfa içeriğinin okuyucunun dikkatini dağıttığı bilinen bir gerçektir. Lorem Ipsum kullanmanın amacı, sürekli 'buraya metin gelecek, buraya metin gelecek' yazmaya kıyasla daha dengeli bir harf dağılımı sağlayarak okunurluğu artırmasıdır. Şu anda birçok masaüstü yayıncılık paketi ve web sayfa düzenleyicisi, varsayılan mıgır metinler olarak Lorem Ipsum kullanmaktadır. Ayrıca arama motorlarında 'lorem ipsum' anahtar sözcükleri ile arama yapıldığında henüz tasarım aşamasında olan çok sayıda site listelenir. Yıllar içinde, bazen kazara, bazen bilinçli olarak (örneğin mizah katılarak), çeşitli sürümleri geliştirilmiştir.",
            //        Thumbnail = "Default.jpg",
            //        SeoDescription = "Kishu coin nedir? Kishu coin ne kadar, kaç TL?",
            //        SeoTags = "Kishu Coin Crypto",
            //        SeoAuthor = "Oğuzhan Akpınar",
            //        Date = DateTime.Now,
            //        IsActive = true,
            //        IsDeleted = false,
            //        CreatedByName = "Initial Create",
            //        CreatedDate = DateTime.Now,
            //        ModifiedByName = "Initial Create",
            //        ModifiedDate = DateTime.Now,
            //        Note = "Kishu coin nedir?",
            //        UserId = 1,
            //        ViewsCount = 295,
            //        CommentCount = 1
            //    },
            //    new Report
            //    {
            //        Id = 3,
            //        CategoryId = 3,
            //        Title = "Arena of Valor: Yeni Çağ, Türkiye’ye geldi!",
            //        Content =
            //            "Yaygın inancın tersine, Lorem Ipsum rastgele sözcüklerden oluşmaz. Kökleri M.Ö. 45 tarihinden bu yana klasik Latin edebiyatına kadar uzanan 2000 yıllık bir geçmişi vardır. Virginia'daki Hampden-Sydney College'dan Latince profesörü Richard McClintock, bir Lorem Ipsum pasajında geçen ve anlaşılması en güç sözcüklerden biri olan 'consectetur' sözcüğünün klasik edebiyattaki örneklerini incelediğinde kesin bir kaynağa ulaşmıştır. Lorm Ipsum, Çiçero tarafından M.Ö. 45 tarihinde kaleme alınan de Finibus Bonorum et Malorum (İyi ve Kötünün Uç Sınırları) eserinin 1.10.32 ve 1.10.33 sayılı bölümlerinden gelmektedir. Bu kitap, ahlak kuramı üzerine bir tezdir ve Rönesans döneminde çok popüler olmuştur. Lorem Ipsum pasajının ilk satırı olan Lorem ipsum dolor sit amet 1.10.32 sayılı bölümdeki bir satırdan gelmektedir.",
            //        Thumbnail = "Default.jpg",
            //        SeoDescription = "Arena of Valor: Yeni Çağ, Türkiye’ye geldi!",
            //        SeoTags = "Tencent Arena of Valor",
            //        SeoAuthor = "Oğuzhan Akpınar",
            //        Date = DateTime.Now,
            //        IsActive = true,
            //        IsDeleted = false,
            //        CreatedByName = "Initial Create",
            //        CreatedDate = DateTime.Now,
            //        ModifiedByName = "Initial Create",
            //        ModifiedDate = DateTime.Now,
            //        Note = "Arena of Valor: Yeni Çağ, Türkiye’ye geldi!",
            //        UserId = 1,
            //        ViewsCount = 12,
            //        CommentCount = 1
            //    }
            //);
        }
    }
}
