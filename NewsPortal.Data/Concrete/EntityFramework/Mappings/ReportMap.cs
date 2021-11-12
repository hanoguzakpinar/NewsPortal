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

            builder.HasData(
                new Report
                {
                    Id = 1,
                    CategoryId = 1,
                    Title = "SHIBA INU'ya zirveden giren yüzde 45 kaybetti",
                    Content =
                        "Lorem Ipsum, dizgi ve baskı endüstrisinde kullanılan mıgır metinlerdir. Lorem Ipsum, adı bilinmeyen bir matbaacının bir hurufat numune kitabı oluşturmak üzere bir yazı galerisini alarak karıştırdığı 1500'lerden beri endüstri standardı sahte metinler olarak kullanılmıştır. Beşyüz yıl boyunca varlığını sürdürmekle kalmamış, aynı zamanda pek değişmeden elektronik dizgiye de sıçramıştır. 1960'larda Lorem Ipsum pasajları da içeren Letraset yapraklarının yayınlanması ile ve yakın zamanda Aldus PageMaker gibi Lorem Ipsum sürümleri içeren masaüstü yayıncılık yazılımları ile popüler olmuştur.",
                    Thumbnail = "postImages/defaultThumbnail.png",
                    SeoDescription = "SHIBA INU'ya zirveden giren yüzde 45 kaybetti",
                    SeoTags = "SHIBA INU",
                    SeoAuthor = "Oğuzhan Akpınar",
                    Date = DateTime.Now,
                    IsActive = true,
                    IsDeleted = false,
                    CreatedByName = "Initial Create",
                    CreatedDate = DateTime.Now,
                    ModifiedByName = "Initial Create",
                    ModifiedDate = DateTime.Now,
                    Note = "SHIBA INU'ya zirveden giren yüzde 45 kaybetti",
                    UserId = 1,
                    ViewsCount = 100,
                    CommentCount = 1
                },
                new Report
                {
                    Id = 2,
                    CategoryId = 2,
                    Title =
                        "Kalp krizini hangisi daha fazla tetikliyor? Hamburger mi yoksa stres mi?",
                    Content =
                        "Yinelenen bir sayfa içeriğinin okuyucunun dikkatini dağıttığı bilinen bir gerçektir. Lorem Ipsum kullanmanın amacı, sürekli 'buraya metin gelecek, buraya metin gelecek' yazmaya kıyasla daha dengeli bir harf dağılımı sağlayarak okunurluğu artırmasıdır. Şu anda birçok masaüstü yayıncılık paketi ve web sayfa düzenleyicisi, varsayılan mıgır metinler olarak Lorem Ipsum kullanmaktadır. Ayrıca arama motorlarında 'lorem ipsum' anahtar sözcükleri ile arama yapıldığında henüz tasarım aşamasında olan çok sayıda site listelenir. Yıllar içinde, bazen kazara, bazen bilinçli olarak (örneğin mizah katılarak), çeşitli sürümleri geliştirilmiştir.",
                    Thumbnail = "postImages/defaultThumbnail.png",
                    SeoDescription =
                        "Kalp krizini hangisi daha fazla tetikliyor? Hamburger mi yoksa stres mi?",
                    SeoTags = "Kalp Krizi Stres Hamburger",
                    SeoAuthor = "Oğuzhan Akpınar",
                    Date = DateTime.Now,
                    IsActive = true,
                    IsDeleted = false,
                    CreatedByName = "Initial Create",
                    CreatedDate = DateTime.Now,
                    ModifiedByName = "Initial Create",
                    ModifiedDate = DateTime.Now,
                    Note =
                        "Kalp krizini hangisi daha fazla tetikliyor? Hamburger mi yoksa stres mi?",
                    UserId = 1,
                    ViewsCount = 295,
                    CommentCount = 1
                },
                new Report
                {
                    Id = 3,
                    CategoryId = 3,
                    Title = "İran'dan şoke eden itiraf! \"Petrolü kaçak satıyoruz!\"",
                    Content =
                        "Yaygın inancın tersine, Lorem Ipsum rastgele sözcüklerden oluşmaz. Kökleri M.Ö. 45 tarihinden bu yana klasik Latin edebiyatına kadar uzanan 2000 yıllık bir geçmişi vardır. Virginia'daki Hampden-Sydney College'dan Latince profesörü Richard McClintock, bir Lorem Ipsum pasajında geçen ve anlaşılması en güç sözcüklerden biri olan 'consectetur' sözcüğünün klasik edebiyattaki örneklerini incelediğinde kesin bir kaynağa ulaşmıştır. Lorm Ipsum, Çiçero tarafından M.Ö. 45 tarihinde kaleme alınan de Finibus Bonorum et Malorum (İyi ve Kötünün Uç Sınırları) eserinin 1.10.32 ve 1.10.33 sayılı bölümlerinden gelmektedir. Bu kitap, ahlak kuramı üzerine bir tezdir ve Rönesans döneminde çok popüler olmuştur. Lorem Ipsum pasajının ilk satırı olan Lorem ipsum dolor sit amet 1.10.32 sayılı bölümdeki bir satırdan gelmektedir.",
                    Thumbnail = "postImages/defaultThumbnail.png",
                    SeoDescription = "İran'dan şoke eden itiraf! \"Petrolü kaçak satıyoruz!\"",
                    SeoTags = "İran Kaçak Petrol",
                    SeoAuthor = "Oğuzhan Akpınar",
                    Date = DateTime.Now,
                    IsActive = true,
                    IsDeleted = false,
                    CreatedByName = "Initial Create",
                    CreatedDate = DateTime.Now,
                    ModifiedByName = "Initial Create",
                    ModifiedDate = DateTime.Now,
                    Note = "İran'dan şoke eden itiraf! \"Petrolü kaçak satıyoruz!\"",
                    UserId = 1,
                    ViewsCount = 120,
                    CommentCount = 1
                },
                new Report
                {
                    Id = 4,
                    CategoryId = 4,
                    Title = "50 yıl sonra görüldü! O balık İzmit Körfezi'nde!",
                    Content =
                        "Yaygın inancın tersine, Lorem Ipsum rastgele sözcüklerden oluşmaz. Kökleri M.Ö. 45 tarihinden bu yana klasik Latin edebiyatına kadar uzanan 2000 yıllık bir geçmişi vardır. Virginia'daki Hampden-Sydney College'dan Latince profesörü Richard McClintock, bir Lorem Ipsum pasajında geçen ve anlaşılması en güç sözcüklerden biri olan 'consectetur' sözcüğünün klasik edebiyattaki örneklerini incelediğinde kesin bir kaynağa ulaşmıştır. Lorm Ipsum, Çiçero tarafından M.Ö. 45 tarihinde kaleme alınan de Finibus Bonorum et Malorum (İyi ve Kötünün Uç Sınırları) eserinin 1.10.32 ve 1.10.33 sayılı bölümlerinden gelmektedir. Bu kitap, ahlak kuramı üzerine bir tezdir ve Rönesans döneminde çok popüler olmuştur. Lorem Ipsum pasajının ilk satırı olan Lorem ipsum dolor sit amet 1.10.32 sayılı bölümdeki bir satırdan gelmektedir.",
                    Thumbnail = "postImages/defaultThumbnail.png",
                    SeoDescription = "50 yıl sonra görüldü! O balık İzmit Körfezi'nde!",
                    SeoTags = "Balık İzmit Körfez",
                    SeoAuthor = "Oğuzhan Akpınar",
                    Date = DateTime.Now,
                    IsActive = true,
                    IsDeleted = false,
                    CreatedByName = "Initial Create",
                    CreatedDate = DateTime.Now,
                    ModifiedByName = "Initial Create",
                    ModifiedDate = DateTime.Now,
                    Note = "50 yıl sonra görüldü! O balık İzmit Körfezi'nde!",
                    UserId = 1,
                    ViewsCount = 100,
                    CommentCount = 1
                },
                new Report
                {
                    Id = 5,
                    CategoryId = 5,
                    Title = "Cisco, AR destekli toplantı çözümü Webex Hologram'ı tanıttı",
                    Content =
                        "Yaygın inancın tersine, Lorem Ipsum rastgele sözcüklerden oluşmaz. Kökleri M.Ö. 45 tarihinden bu yana klasik Latin edebiyatına kadar uzanan 2000 yıllık bir geçmişi vardır. Virginia'daki Hampden-Sydney College'dan Latince profesörü Richard McClintock, bir Lorem Ipsum pasajında geçen ve anlaşılması en güç sözcüklerden biri olan 'consectetur' sözcüğünün klasik edebiyattaki örneklerini incelediğinde kesin bir kaynağa ulaşmıştır. Lorm Ipsum, Çiçero tarafından M.Ö. 45 tarihinde kaleme alınan de Finibus Bonorum et Malorum (İyi ve Kötünün Uç Sınırları) eserinin 1.10.32 ve 1.10.33 sayılı bölümlerinden gelmektedir. Bu kitap, ahlak kuramı üzerine bir tezdir ve Rönesans döneminde çok popüler olmuştur. Lorem Ipsum pasajının ilk satırı olan Lorem ipsum dolor sit amet 1.10.32 sayılı bölümdeki bir satırdan gelmektedir.",
                    Thumbnail = "postImages/defaultThumbnail.png",
                    SeoDescription = "Cisco, AR destekli toplantı çözümü Webex Hologram'ı tanıttı",
                    SeoTags = "Cisco AR Hologram",
                    SeoAuthor = "Oğuzhan Akpınar",
                    Date = DateTime.Now,
                    IsActive = true,
                    IsDeleted = false,
                    CreatedByName = "Initial Create",
                    CreatedDate = DateTime.Now,
                    ModifiedByName = "Initial Create",
                    ModifiedDate = DateTime.Now,
                    Note = "Cisco, AR destekli toplantı çözümü Webex Hologram'ı tanıttı",
                    UserId = 1,
                    ViewsCount = 222,
                    CommentCount = 2
                },
                new Report
                {
                    Id = 6,
                    CategoryId = 6,
                    Title = "Saçma Magazin Haberi",
                    Content =
                        "Yaygın inancın tersine, Lorem Ipsum rastgele sözcüklerden oluşmaz. Kökleri M.Ö. 45 tarihinden bu yana klasik Latin edebiyatına kadar uzanan 2000 yıllık bir geçmişi vardır. Virginia'daki Hampden-Sydney College'dan Latince profesörü Richard McClintock, bir Lorem Ipsum pasajında geçen ve anlaşılması en güç sözcüklerden biri olan 'consectetur' sözcüğünün klasik edebiyattaki örneklerini incelediğinde kesin bir kaynağa ulaşmıştır. Lorm Ipsum, Çiçero tarafından M.Ö. 45 tarihinde kaleme alınan de Finibus Bonorum et Malorum (İyi ve Kötünün Uç Sınırları) eserinin 1.10.32 ve 1.10.33 sayılı bölümlerinden gelmektedir. Bu kitap, ahlak kuramı üzerine bir tezdir ve Rönesans döneminde çok popüler olmuştur. Lorem Ipsum pasajının ilk satırı olan Lorem ipsum dolor sit amet 1.10.32 sayılı bölümdeki bir satırdan gelmektedir.",
                    Thumbnail = "postImages/defaultThumbnail.png",
                    SeoDescription = "Saçma Magazin Haberi",
                    SeoTags = "Magazin Saçma Haber",
                    SeoAuthor = "Oğuzhan Akpınar",
                    Date = DateTime.Now,
                    IsActive = true,
                    IsDeleted = false,
                    CreatedByName = "Initial Create",
                    CreatedDate = DateTime.Now,
                    ModifiedByName = "Initial Create",
                    ModifiedDate = DateTime.Now,
                    Note = "Saçma Magazin Haberi",
                    UserId = 1,
                    ViewsCount = 15,
                    CommentCount = 2
                },
                new Report
                {
                    Id = 7,
                    CategoryId = 7,
                    Title = "Galatasaray: 1 - Lokomotiv Moskova: 1",
                    Content =
                        "Yaygın inancın tersine, Lorem Ipsum rastgele sözcüklerden oluşmaz. Kökleri M.Ö. 45 tarihinden bu yana klasik Latin edebiyatına kadar uzanan 2000 yıllık bir geçmişi vardır. Virginia'daki Hampden-Sydney College'dan Latince profesörü Richard McClintock, bir Lorem Ipsum pasajında geçen ve anlaşılması en güç sözcüklerden biri olan 'consectetur' sözcüğünün klasik edebiyattaki örneklerini incelediğinde kesin bir kaynağa ulaşmıştır. Lorm Ipsum, Çiçero tarafından M.Ö. 45 tarihinde kaleme alınan de Finibus Bonorum et Malorum (İyi ve Kötünün Uç Sınırları) eserinin 1.10.32 ve 1.10.33 sayılı bölümlerinden gelmektedir. Bu kitap, ahlak kuramı üzerine bir tezdir ve Rönesans döneminde çok popüler olmuştur. Lorem Ipsum pasajının ilk satırı olan Lorem ipsum dolor sit amet 1.10.32 sayılı bölümdeki bir satırdan gelmektedir.",
                    Thumbnail = "postImages/defaultThumbnail.png",
                    SeoDescription = "Galatasaray: 1 - Lokomotiv Moskova: 1",
                    SeoTags = "GS LM Uefa",
                    SeoAuthor = "Oğuzhan Akpınar",
                    Date = DateTime.Now,
                    IsActive = true,
                    IsDeleted = false,
                    CreatedByName = "Initial Create",
                    CreatedDate = DateTime.Now,
                    ModifiedByName = "Initial Create",
                    ModifiedDate = DateTime.Now,
                    Note = "Galatasaray: 1 - Lokomotiv Moskova: 1",
                    UserId = 1,
                    ViewsCount = 255,
                    CommentCount = 2
                },
                new Report
                {
                    Id = 8,
                    CategoryId = 8,
                    Title = "Anadolu Efes: 85 - Galatasaray Nef: 92",
                    Content =
                        "Yaygın inancın tersine, Lorem Ipsum rastgele sözcüklerden oluşmaz. Kökleri M.Ö. 45 tarihinden bu yana klasik Latin edebiyatına kadar uzanan 2000 yıllık bir geçmişi vardır. Virginia'daki Hampden-Sydney College'dan Latince profesörü Richard McClintock, bir Lorem Ipsum pasajında geçen ve anlaşılması en güç sözcüklerden biri olan 'consectetur' sözcüğünün klasik edebiyattaki örneklerini incelediğinde kesin bir kaynağa ulaşmıştır. Lorm Ipsum, Çiçero tarafından M.Ö. 45 tarihinde kaleme alınan de Finibus Bonorum et Malorum (İyi ve Kötünün Uç Sınırları) eserinin 1.10.32 ve 1.10.33 sayılı bölümlerinden gelmektedir. Bu kitap, ahlak kuramı üzerine bir tezdir ve Rönesans döneminde çok popüler olmuştur. Lorem Ipsum pasajının ilk satırı olan Lorem ipsum dolor sit amet 1.10.32 sayılı bölümdeki bir satırdan gelmektedir.",
                    Thumbnail = "postImages/defaultThumbnail.png",
                    SeoDescription = "Anadolu Efes: 85 - Galatasaray Nef: 92",
                    SeoTags = "GS Efes Basketbol",
                    SeoAuthor = "Oğuzhan Akpınar",
                    Date = DateTime.Now,
                    IsActive = true,
                    IsDeleted = false,
                    CreatedByName = "Initial Create",
                    CreatedDate = DateTime.Now,
                    ModifiedByName = "Initial Create",
                    ModifiedDate = DateTime.Now,
                    Note = "Anadolu Efes: 85 - Galatasaray Nef: 92",
                    UserId = 1,
                    ViewsCount = 200,
                    CommentCount = 1
                },
                new Report
                {
                    Id = 9,
                    CategoryId = 9,
                    Title =
                        "Mercedes'in Hamilton'ın motor cezası alma ihtimaliyle ilgili endişeleri azaldı",
                    Content =
                        "Yaygın inancın tersine, Lorem Ipsum rastgele sözcüklerden oluşmaz. Kökleri M.Ö. 45 tarihinden bu yana klasik Latin edebiyatına kadar uzanan 2000 yıllık bir geçmişi vardır. Virginia'daki Hampden-Sydney College'dan Latince profesörü Richard McClintock, bir Lorem Ipsum pasajında geçen ve anlaşılması en güç sözcüklerden biri olan 'consectetur' sözcüğünün klasik edebiyattaki örneklerini incelediğinde kesin bir kaynağa ulaşmıştır. Lorm Ipsum, Çiçero tarafından M.Ö. 45 tarihinde kaleme alınan de Finibus Bonorum et Malorum (İyi ve Kötünün Uç Sınırları) eserinin 1.10.32 ve 1.10.33 sayılı bölümlerinden gelmektedir. Bu kitap, ahlak kuramı üzerine bir tezdir ve Rönesans döneminde çok popüler olmuştur. Lorem Ipsum pasajının ilk satırı olan Lorem ipsum dolor sit amet 1.10.32 sayılı bölümdeki bir satırdan gelmektedir.",
                    Thumbnail = "postImages/defaultThumbnail.png",
                    SeoDescription =
                        "Mercedes'in Hamilton'ın motor cezası alma ihtimaliyle ilgili endişeleri azaldı",
                    SeoTags = "F1 Mercedes",
                    SeoAuthor = "Oğuzhan Akpınar",
                    Date = DateTime.Now,
                    IsActive = true,
                    IsDeleted = false,
                    CreatedByName = "Initial Create",
                    CreatedDate = DateTime.Now,
                    ModifiedByName = "Initial Create",
                    ModifiedDate = DateTime.Now,
                    Note =
                        "Mercedes'in Hamilton'ın motor cezası alma ihtimaliyle ilgili endişeleri azaldı",
                    UserId = 1,
                    ViewsCount = 100,
                    CommentCount = 1
                },
                new Report
                {
                    Id = 10,
                    CategoryId = 10,
                    Title = "Dota 2 The International 2021 Şampiyonu Team Spirit Oldu!",
                    Content =
                        "Yaygın inancın tersine, Lorem Ipsum rastgele sözcüklerden oluşmaz. Kökleri M.Ö. 45 tarihinden bu yana klasik Latin edebiyatına kadar uzanan 2000 yıllık bir geçmişi vardır. Virginia'daki Hampden-Sydney College'dan Latince profesörü Richard McClintock, bir Lorem Ipsum pasajında geçen ve anlaşılması en güç sözcüklerden biri olan 'consectetur' sözcüğünün klasik edebiyattaki örneklerini incelediğinde kesin bir kaynağa ulaşmıştır. Lorm Ipsum, Çiçero tarafından M.Ö. 45 tarihinde kaleme alınan de Finibus Bonorum et Malorum (İyi ve Kötünün Uç Sınırları) eserinin 1.10.32 ve 1.10.33 sayılı bölümlerinden gelmektedir. Bu kitap, ahlak kuramı üzerine bir tezdir ve Rönesans döneminde çok popüler olmuştur. Lorem Ipsum pasajının ilk satırı olan Lorem ipsum dolor sit amet 1.10.32 sayılı bölümdeki bir satırdan gelmektedir.",
                    Thumbnail = "postImages/defaultThumbnail.png",
                    SeoDescription = "Dota 2 The International 2021 Şampiyonu Team Spirit Oldu!",
                    SeoTags = "Dota International Spirit",
                    SeoAuthor = "Oğuzhan Akpınar",
                    Date = DateTime.Now,
                    IsActive = true,
                    IsDeleted = false,
                    CreatedByName = "Initial Create",
                    CreatedDate = DateTime.Now,
                    ModifiedByName = "Initial Create",
                    ModifiedDate = DateTime.Now,
                    Note = "Dota 2 The International 2021 Şampiyonu Team Spirit Oldu!",
                    UserId = 1,
                    ViewsCount = 50,
                    CommentCount = 1
                }
            );
        }
    }
}