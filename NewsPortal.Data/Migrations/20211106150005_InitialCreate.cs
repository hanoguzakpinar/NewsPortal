using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NewsPortal.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", maxLength: 50, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Picture = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    About = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    YoutubeLink = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    TwitterLink = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    InstagramLink = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    FacebookLink = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    LinkedInLink = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    GitHubLink = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    WebsiteLink = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Content = table.Column<string>(type: "NVARCHAR(MAX)", nullable: false),
                    Thumbnail = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ViewsCount = table.Column<int>(type: "int", nullable: false),
                    CommentCount = table.Column<int>(type: "int", nullable: false),
                    SeoAuthor = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SeoDescription = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    SeoTags = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reports_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reports_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    ReportId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", maxLength: 50, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedByName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Reports_ReportId",
                        column: x => x.ReportId,
                        principalTable: "Reports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedByName", "CreatedDate", "Description", "IsActive", "IsDeleted", "ModifiedByName", "ModifiedDate", "Name", "Note" },
                values: new object[,]
                {
                    { 1, "InitialCreate", new DateTime(2021, 11, 6, 18, 0, 5, 63, DateTimeKind.Local).AddTicks(9255), "Ekonomi Haberleri", true, false, "InitialCreate", new DateTime(2021, 11, 6, 18, 0, 5, 63, DateTimeKind.Local).AddTicks(9269), "Ekonomi", "Ekonomi Kategorisi" },
                    { 2, "InitialCreate", new DateTime(2021, 11, 6, 18, 0, 5, 63, DateTimeKind.Local).AddTicks(9283), "Sağlık Haberleri", true, false, "InitialCreate", new DateTime(2021, 11, 6, 18, 0, 5, 63, DateTimeKind.Local).AddTicks(9285), "Sağlık", "Sağlık Kategorisi" },
                    { 3, "InitialCreate", new DateTime(2021, 11, 6, 18, 0, 5, 63, DateTimeKind.Local).AddTicks(9289), "Dünya Haberleri", true, false, "InitialCreate", new DateTime(2021, 11, 6, 18, 0, 5, 63, DateTimeKind.Local).AddTicks(9290), "Dünya", "Dünya Kategorisi" },
                    { 4, "InitialCreate", new DateTime(2021, 11, 6, 18, 0, 5, 63, DateTimeKind.Local).AddTicks(9294), "Gündem Haberleri", true, false, "InitialCreate", new DateTime(2021, 11, 6, 18, 0, 5, 63, DateTimeKind.Local).AddTicks(9295), "Gündem", "Gündem Kategorisi" },
                    { 5, "InitialCreate", new DateTime(2021, 11, 6, 18, 0, 5, 63, DateTimeKind.Local).AddTicks(9299), "Teknoloji Haberleri", true, false, "InitialCreate", new DateTime(2021, 11, 6, 18, 0, 5, 63, DateTimeKind.Local).AddTicks(9300), "Teknoloji", "Teknoloji Kategorisi" },
                    { 6, "InitialCreate", new DateTime(2021, 11, 6, 18, 0, 5, 63, DateTimeKind.Local).AddTicks(9304), "Magazin Haberleri", true, false, "InitialCreate", new DateTime(2021, 11, 6, 18, 0, 5, 63, DateTimeKind.Local).AddTicks(9306), "Magazin", "Magazin Kategorisi" },
                    { 7, "InitialCreate", new DateTime(2021, 11, 6, 18, 0, 5, 63, DateTimeKind.Local).AddTicks(9309), "Futbol Haberleri", true, false, "InitialCreate", new DateTime(2021, 11, 6, 18, 0, 5, 63, DateTimeKind.Local).AddTicks(9311), "Futbol", "Futbol Kategorisi" },
                    { 8, "InitialCreate", new DateTime(2021, 11, 6, 18, 0, 5, 63, DateTimeKind.Local).AddTicks(9315), "Basketbol Haberleri", true, false, "InitialCreate", new DateTime(2021, 11, 6, 18, 0, 5, 63, DateTimeKind.Local).AddTicks(9316), "Basketbol", "Basketbol Kategorisi" },
                    { 9, "InitialCreate", new DateTime(2021, 11, 6, 18, 0, 5, 63, DateTimeKind.Local).AddTicks(9320), "Formula 1 Haberleri", true, false, "InitialCreate", new DateTime(2021, 11, 6, 18, 0, 5, 63, DateTimeKind.Local).AddTicks(9321), "Formula 1", "Formula 1 Kategorisi" },
                    { 10, "InitialCreate", new DateTime(2021, 11, 6, 18, 0, 5, 63, DateTimeKind.Local).AddTicks(9325), "Espor Haberleri", true, false, "InitialCreate", new DateTime(2021, 11, 6, 18, 0, 5, 63, DateTimeKind.Local).AddTicks(9326), "Espor", "Espor Kategorisi" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 14, "c2da3d64-c1df-4244-bde7-87877631ac72", "Role.Read", "ROLE.READ" },
                    { 15, "d6b9032d-3232-4217-88a8-576faec4758b", "Role.Update", "ROLE.UPDATE" },
                    { 16, "de4c6846-d351-49ac-b273-bcdaba210a33", "Role.Delete", "ROLE.DELETE" },
                    { 17, "b96bf4fc-5540-4242-a46c-496f1ef62885", "Comment.Create", "COMMENT.CREATE" },
                    { 22, "e22ecde2-157f-4691-9de8-ba87eaa27434", "SuperAdmin", "SUPERADMIN" },
                    { 19, "e9c85d0a-b582-4087-8c9b-30e527d2100a", "Comment.Update", "COMMENT.UPDATE" },
                    { 20, "454f36b8-8813-436b-8a29-96f6c2184726", "Comment.Delete", "COMMENT.DELETE" },
                    { 21, "88dadb4b-f068-4efe-a0d0-659d8b2499ee", "AdminArea.Home.Read", "ADMINAREA.HOME.READ" },
                    { 13, "beab186e-991a-4fa5-925d-62d257f32f9f", "Role.Create", "ROLE.CREATE" },
                    { 18, "fa92b5b3-2cd1-4a89-8975-b5dcd292d40b", "Comment.Read", "COMMENT.READ" },
                    { 12, "952e4806-45db-4df4-bbcc-9b6e2994bb80", "User.Delete", "USER.DELETE" },
                    { 7, "49b3ea4c-8269-459c-b449-da775afec4ad", "Report.Update", "REPORT.UPDATE" },
                    { 10, "7ef3150d-5ee5-401d-b487-97f1e1cfc587", "User.Read", "USER.READ" },
                    { 9, "eaf5ba21-0099-4f7a-be32-566f736ab826", "User.Create", "USER.CREATE" },
                    { 8, "3612d6c2-fc75-41b5-bc61-6bfbb8b2f00d", "Report.Delete", "REPORT.DELETE" },
                    { 6, "a5bc7e9a-d73c-414b-a21b-0d365130f1cb", "Report.Read", "REPORT.READ" },
                    { 5, "2cd17927-cb44-4caf-86cc-177694fd881f", "Report.Create", "REPORT.CREATE" },
                    { 4, "85a6c7f1-821c-44f9-ba01-f07f9c378ce9", "Category.Delete", "CATEGORY.DELETE" },
                    { 3, "5d8e8a02-2859-4927-ae8c-92760bf262cf", "Category.Update", "CATEGORY.UPDATE" },
                    { 2, "74f445b6-e919-4d77-bfa8-971ad578f44f", "Category.Read", "CATEGORY.READ" },
                    { 1, "bf878e8c-3b9b-4af2-9bad-5fe0260ddc0a", "Category.Create", "CATEGORY.CREATE" },
                    { 11, "3aee7b43-9fc3-42d3-9574-22af25fb96ba", "User.Update", "USER.UPDATE" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "About", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FacebookLink", "FirstName", "GitHubLink", "InstagramLink", "LastName", "LinkedInLink", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Picture", "SecurityStamp", "TwitterLink", "TwoFactorEnabled", "UserName", "WebsiteLink", "YoutubeLink" },
                values: new object[,]
                {
                    { 1, "Admin User of NewsPortal", 0, "dad65c03-94ac-4657-af8d-58b22efa315e", "adminuser@gmail.com", true, "https://facebook.com/adminuser", "Admin", "https://github.com/adminuser", "https://instagram.com/adminuser", "User", "https://linkedin.com/adminuser", false, null, "ADMINUSER@GMAIL.COM", "ADMINUSER", "AQAAAAEAACcQAAAAEAAZqCYB4IkR/sPRqKcaCEl1ZKc4CWZTC/WWdjGu/YqpagZkywM/+Li4HKY6bSIG1g==", "+905555555555", true, "/userImages/defaultUser.png", "a5cf75c0-ba86-48b3-b3c1-7f990f44c50e", "https://twitter.com/adminuser", false, "adminuser", "https://newsportal.com/", "https://youtube.com/adminuser" },
                    { 2, "Editor User of NewsPortal", 0, "20d61cd2-0e40-4637-91f6-556128a555e0", "editoruser@gmail.com", true, "https://facebook.com/editoruser", "Admin", "https://github.com/editoruser", "https://instagram.com/editoruser", "User", "https://linkedin.com/editoruser", false, null, "EDITORUSER@GMAIL.COM", "EDITORUSER", "AQAAAAEAACcQAAAAED4CG338gUMggDzk7sxdwYZnsvh/cMfzR2fi2nZfPOo2TVBrey5WRTiBvHfHH3LTWQ==", "+905555555555", true, "/userImages/defaultUser.png", "338f5d3e-0193-4afe-8a67-d65cfc0f24c4", "https://twitter.com/editoruser", false, "editoruser", "https://newsportal.com/", "https://youtube.com/editoruser" }
                });

            migrationBuilder.InsertData(
                table: "Reports",
                columns: new[] { "Id", "CategoryId", "CommentCount", "Content", "CreatedByName", "CreatedDate", "Date", "IsActive", "IsDeleted", "ModifiedByName", "ModifiedDate", "Note", "SeoAuthor", "SeoDescription", "SeoTags", "Thumbnail", "Title", "UserId", "ViewsCount" },
                values: new object[,]
                {
                    { 1, 1, 1, "Lorem Ipsum, dizgi ve baskı endüstrisinde kullanılan mıgır metinlerdir. Lorem Ipsum, adı bilinmeyen bir matbaacının bir hurufat numune kitabı oluşturmak üzere bir yazı galerisini alarak karıştırdığı 1500'lerden beri endüstri standardı sahte metinler olarak kullanılmıştır. Beşyüz yıl boyunca varlığını sürdürmekle kalmamış, aynı zamanda pek değişmeden elektronik dizgiye de sıçramıştır. 1960'larda Lorem Ipsum pasajları da içeren Letraset yapraklarının yayınlanması ile ve yakın zamanda Aldus PageMaker gibi Lorem Ipsum sürümleri içeren masaüstü yayıncılık yazılımları ile popüler olmuştur.", "Initial Create", new DateTime(2021, 11, 6, 18, 0, 5, 60, DateTimeKind.Local).AddTicks(2945), new DateTime(2021, 11, 6, 18, 0, 5, 60, DateTimeKind.Local).AddTicks(1466), true, false, "Initial Create", new DateTime(2021, 11, 6, 18, 0, 5, 60, DateTimeKind.Local).AddTicks(3500), "SHIBA INU'ya zirveden giren yüzde 45 kaybetti", "Oğuzhan Akpınar", "SHIBA INU'ya zirveden giren yüzde 45 kaybetti", "SHIBA INU", "postImages/defaultThumbnail.jpg", "SHIBA INU'ya zirveden giren yüzde 45 kaybetti", 1, 100 },
                    { 10, 10, 1, "Yaygın inancın tersine, Lorem Ipsum rastgele sözcüklerden oluşmaz. Kökleri M.Ö. 45 tarihinden bu yana klasik Latin edebiyatına kadar uzanan 2000 yıllık bir geçmişi vardır. Virginia'daki Hampden-Sydney College'dan Latince profesörü Richard McClintock, bir Lorem Ipsum pasajında geçen ve anlaşılması en güç sözcüklerden biri olan 'consectetur' sözcüğünün klasik edebiyattaki örneklerini incelediğinde kesin bir kaynağa ulaşmıştır. Lorm Ipsum, Çiçero tarafından M.Ö. 45 tarihinde kaleme alınan de Finibus Bonorum et Malorum (İyi ve Kötünün Uç Sınırları) eserinin 1.10.32 ve 1.10.33 sayılı bölümlerinden gelmektedir. Bu kitap, ahlak kuramı üzerine bir tezdir ve Rönesans döneminde çok popüler olmuştur. Lorem Ipsum pasajının ilk satırı olan Lorem ipsum dolor sit amet 1.10.32 sayılı bölümdeki bir satırdan gelmektedir.", "Initial Create", new DateTime(2021, 11, 6, 18, 0, 5, 60, DateTimeKind.Local).AddTicks(4883), new DateTime(2021, 11, 6, 18, 0, 5, 60, DateTimeKind.Local).AddTicks(4881), true, false, "Initial Create", new DateTime(2021, 11, 6, 18, 0, 5, 60, DateTimeKind.Local).AddTicks(4884), "Dota 2 The International 2021 Şampiyonu Team Spirit Oldu!", "Oğuzhan Akpınar", "Dota 2 The International 2021 Şampiyonu Team Spirit Oldu!", "Dota International Spirit", "postImages/defaultThumbnail.jpg", "Dota 2 The International 2021 Şampiyonu Team Spirit Oldu!", 1, 50 },
                    { 8, 8, 1, "Yaygın inancın tersine, Lorem Ipsum rastgele sözcüklerden oluşmaz. Kökleri M.Ö. 45 tarihinden bu yana klasik Latin edebiyatına kadar uzanan 2000 yıllık bir geçmişi vardır. Virginia'daki Hampden-Sydney College'dan Latince profesörü Richard McClintock, bir Lorem Ipsum pasajında geçen ve anlaşılması en güç sözcüklerden biri olan 'consectetur' sözcüğünün klasik edebiyattaki örneklerini incelediğinde kesin bir kaynağa ulaşmıştır. Lorm Ipsum, Çiçero tarafından M.Ö. 45 tarihinde kaleme alınan de Finibus Bonorum et Malorum (İyi ve Kötünün Uç Sınırları) eserinin 1.10.32 ve 1.10.33 sayılı bölümlerinden gelmektedir. Bu kitap, ahlak kuramı üzerine bir tezdir ve Rönesans döneminde çok popüler olmuştur. Lorem Ipsum pasajının ilk satırı olan Lorem ipsum dolor sit amet 1.10.32 sayılı bölümdeki bir satırdan gelmektedir.", "Initial Create", new DateTime(2021, 11, 6, 18, 0, 5, 60, DateTimeKind.Local).AddTicks(4787), new DateTime(2021, 11, 6, 18, 0, 5, 60, DateTimeKind.Local).AddTicks(4786), true, false, "Initial Create", new DateTime(2021, 11, 6, 18, 0, 5, 60, DateTimeKind.Local).AddTicks(4788), "Anadolu Efes: 85 - Galatasaray Nef: 92", "Oğuzhan Akpınar", "Anadolu Efes: 85 - Galatasaray Nef: 92", "GS Efes Basketbol", "postImages/defaultThumbnail.jpg", "Anadolu Efes: 85 - Galatasaray Nef: 92", 1, 200 },
                    { 7, 7, 2, "Yaygın inancın tersine, Lorem Ipsum rastgele sözcüklerden oluşmaz. Kökleri M.Ö. 45 tarihinden bu yana klasik Latin edebiyatına kadar uzanan 2000 yıllık bir geçmişi vardır. Virginia'daki Hampden-Sydney College'dan Latince profesörü Richard McClintock, bir Lorem Ipsum pasajında geçen ve anlaşılması en güç sözcüklerden biri olan 'consectetur' sözcüğünün klasik edebiyattaki örneklerini incelediğinde kesin bir kaynağa ulaşmıştır. Lorm Ipsum, Çiçero tarafından M.Ö. 45 tarihinde kaleme alınan de Finibus Bonorum et Malorum (İyi ve Kötünün Uç Sınırları) eserinin 1.10.32 ve 1.10.33 sayılı bölümlerinden gelmektedir. Bu kitap, ahlak kuramı üzerine bir tezdir ve Rönesans döneminde çok popüler olmuştur. Lorem Ipsum pasajının ilk satırı olan Lorem ipsum dolor sit amet 1.10.32 sayılı bölümdeki bir satırdan gelmektedir.", "Initial Create", new DateTime(2021, 11, 6, 18, 0, 5, 60, DateTimeKind.Local).AddTicks(4780), new DateTime(2021, 11, 6, 18, 0, 5, 60, DateTimeKind.Local).AddTicks(4778), true, false, "Initial Create", new DateTime(2021, 11, 6, 18, 0, 5, 60, DateTimeKind.Local).AddTicks(4781), "Galatasaray: 1 - Lokomotiv Moskova: 1", "Oğuzhan Akpınar", "Galatasaray: 1 - Lokomotiv Moskova: 1", "GS LM Uefa", "postImages/defaultThumbnail.jpg", "Galatasaray: 1 - Lokomotiv Moskova: 1", 1, 255 },
                    { 6, 6, 2, "Yaygın inancın tersine, Lorem Ipsum rastgele sözcüklerden oluşmaz. Kökleri M.Ö. 45 tarihinden bu yana klasik Latin edebiyatına kadar uzanan 2000 yıllık bir geçmişi vardır. Virginia'daki Hampden-Sydney College'dan Latince profesörü Richard McClintock, bir Lorem Ipsum pasajında geçen ve anlaşılması en güç sözcüklerden biri olan 'consectetur' sözcüğünün klasik edebiyattaki örneklerini incelediğinde kesin bir kaynağa ulaşmıştır. Lorm Ipsum, Çiçero tarafından M.Ö. 45 tarihinde kaleme alınan de Finibus Bonorum et Malorum (İyi ve Kötünün Uç Sınırları) eserinin 1.10.32 ve 1.10.33 sayılı bölümlerinden gelmektedir. Bu kitap, ahlak kuramı üzerine bir tezdir ve Rönesans döneminde çok popüler olmuştur. Lorem Ipsum pasajının ilk satırı olan Lorem ipsum dolor sit amet 1.10.32 sayılı bölümdeki bir satırdan gelmektedir.", "Initial Create", new DateTime(2021, 11, 6, 18, 0, 5, 60, DateTimeKind.Local).AddTicks(4773), new DateTime(2021, 11, 6, 18, 0, 5, 60, DateTimeKind.Local).AddTicks(4771), true, false, "Initial Create", new DateTime(2021, 11, 6, 18, 0, 5, 60, DateTimeKind.Local).AddTicks(4774), "Saçma Magazin Haberi", "Oğuzhan Akpınar", "Saçma Magazin Haberi", "Magazin Saçma Haber", "postImages/defaultThumbnail.jpg", "Saçma Magazin Haberi", 1, 15 },
                    { 9, 9, 1, "Yaygın inancın tersine, Lorem Ipsum rastgele sözcüklerden oluşmaz. Kökleri M.Ö. 45 tarihinden bu yana klasik Latin edebiyatına kadar uzanan 2000 yıllık bir geçmişi vardır. Virginia'daki Hampden-Sydney College'dan Latince profesörü Richard McClintock, bir Lorem Ipsum pasajında geçen ve anlaşılması en güç sözcüklerden biri olan 'consectetur' sözcüğünün klasik edebiyattaki örneklerini incelediğinde kesin bir kaynağa ulaşmıştır. Lorm Ipsum, Çiçero tarafından M.Ö. 45 tarihinde kaleme alınan de Finibus Bonorum et Malorum (İyi ve Kötünün Uç Sınırları) eserinin 1.10.32 ve 1.10.33 sayılı bölümlerinden gelmektedir. Bu kitap, ahlak kuramı üzerine bir tezdir ve Rönesans döneminde çok popüler olmuştur. Lorem Ipsum pasajının ilk satırı olan Lorem ipsum dolor sit amet 1.10.32 sayılı bölümdeki bir satırdan gelmektedir.", "Initial Create", new DateTime(2021, 11, 6, 18, 0, 5, 60, DateTimeKind.Local).AddTicks(4876), new DateTime(2021, 11, 6, 18, 0, 5, 60, DateTimeKind.Local).AddTicks(4874), true, false, "Initial Create", new DateTime(2021, 11, 6, 18, 0, 5, 60, DateTimeKind.Local).AddTicks(4877), "Mercedes'in Hamilton'ın motor cezası alma ihtimaliyle ilgili endişeleri azaldı", "Oğuzhan Akpınar", "Mercedes'in Hamilton'ın motor cezası alma ihtimaliyle ilgili endişeleri azaldı", "F1 Mercedes", "postImages/defaultThumbnail.jpg", "Mercedes'in Hamilton'ın motor cezası alma ihtimaliyle ilgili endişeleri azaldı", 1, 100 },
                    { 4, 4, 1, "Yaygın inancın tersine, Lorem Ipsum rastgele sözcüklerden oluşmaz. Kökleri M.Ö. 45 tarihinden bu yana klasik Latin edebiyatına kadar uzanan 2000 yıllık bir geçmişi vardır. Virginia'daki Hampden-Sydney College'dan Latince profesörü Richard McClintock, bir Lorem Ipsum pasajında geçen ve anlaşılması en güç sözcüklerden biri olan 'consectetur' sözcüğünün klasik edebiyattaki örneklerini incelediğinde kesin bir kaynağa ulaşmıştır. Lorm Ipsum, Çiçero tarafından M.Ö. 45 tarihinde kaleme alınan de Finibus Bonorum et Malorum (İyi ve Kötünün Uç Sınırları) eserinin 1.10.32 ve 1.10.33 sayılı bölümlerinden gelmektedir. Bu kitap, ahlak kuramı üzerine bir tezdir ve Rönesans döneminde çok popüler olmuştur. Lorem Ipsum pasajının ilk satırı olan Lorem ipsum dolor sit amet 1.10.32 sayılı bölümdeki bir satırdan gelmektedir.", "Initial Create", new DateTime(2021, 11, 6, 18, 0, 5, 60, DateTimeKind.Local).AddTicks(4759), new DateTime(2021, 11, 6, 18, 0, 5, 60, DateTimeKind.Local).AddTicks(4758), true, false, "Initial Create", new DateTime(2021, 11, 6, 18, 0, 5, 60, DateTimeKind.Local).AddTicks(4760), "50 yıl sonra görüldü! O balık İzmit Körfezi'nde!", "Oğuzhan Akpınar", "50 yıl sonra görüldü! O balık İzmit Körfezi'nde!", "Balık İzmit Körfez", "postImages/defaultThumbnail.jpg", "50 yıl sonra görüldü! O balık İzmit Körfezi'nde!", 1, 100 },
                    { 3, 3, 1, "Yaygın inancın tersine, Lorem Ipsum rastgele sözcüklerden oluşmaz. Kökleri M.Ö. 45 tarihinden bu yana klasik Latin edebiyatına kadar uzanan 2000 yıllık bir geçmişi vardır. Virginia'daki Hampden-Sydney College'dan Latince profesörü Richard McClintock, bir Lorem Ipsum pasajında geçen ve anlaşılması en güç sözcüklerden biri olan 'consectetur' sözcüğünün klasik edebiyattaki örneklerini incelediğinde kesin bir kaynağa ulaşmıştır. Lorm Ipsum, Çiçero tarafından M.Ö. 45 tarihinde kaleme alınan de Finibus Bonorum et Malorum (İyi ve Kötünün Uç Sınırları) eserinin 1.10.32 ve 1.10.33 sayılı bölümlerinden gelmektedir. Bu kitap, ahlak kuramı üzerine bir tezdir ve Rönesans döneminde çok popüler olmuştur. Lorem Ipsum pasajının ilk satırı olan Lorem ipsum dolor sit amet 1.10.32 sayılı bölümdeki bir satırdan gelmektedir.", "Initial Create", new DateTime(2021, 11, 6, 18, 0, 5, 60, DateTimeKind.Local).AddTicks(4753), new DateTime(2021, 11, 6, 18, 0, 5, 60, DateTimeKind.Local).AddTicks(4751), true, false, "Initial Create", new DateTime(2021, 11, 6, 18, 0, 5, 60, DateTimeKind.Local).AddTicks(4754), "İran'dan şoke eden itiraf! \"Petrolü kaçak satıyoruz!\"", "Oğuzhan Akpınar", "İran'dan şoke eden itiraf! \"Petrolü kaçak satıyoruz!\"", "İran Kaçak Petrol", "postImages/defaultThumbnail.jpg", "İran'dan şoke eden itiraf! \"Petrolü kaçak satıyoruz!\"", 1, 120 },
                    { 2, 2, 1, "Yinelenen bir sayfa içeriğinin okuyucunun dikkatini dağıttığı bilinen bir gerçektir. Lorem Ipsum kullanmanın amacı, sürekli 'buraya metin gelecek, buraya metin gelecek' yazmaya kıyasla daha dengeli bir harf dağılımı sağlayarak okunurluğu artırmasıdır. Şu anda birçok masaüstü yayıncılık paketi ve web sayfa düzenleyicisi, varsayılan mıgır metinler olarak Lorem Ipsum kullanmaktadır. Ayrıca arama motorlarında 'lorem ipsum' anahtar sözcükleri ile arama yapıldığında henüz tasarım aşamasında olan çok sayıda site listelenir. Yıllar içinde, bazen kazara, bazen bilinçli olarak (örneğin mizah katılarak), çeşitli sürümleri geliştirilmiştir.", "Initial Create", new DateTime(2021, 11, 6, 18, 0, 5, 60, DateTimeKind.Local).AddTicks(4745), new DateTime(2021, 11, 6, 18, 0, 5, 60, DateTimeKind.Local).AddTicks(4743), true, false, "Initial Create", new DateTime(2021, 11, 6, 18, 0, 5, 60, DateTimeKind.Local).AddTicks(4746), "Kalp krizini hangisi daha fazla tetikliyor? Hamburger mi yoksa stres mi?", "Oğuzhan Akpınar", "Kalp krizini hangisi daha fazla tetikliyor? Hamburger mi yoksa stres mi?", "Kalp Krizi Stres Hamburger", "postImages/defaultThumbnail.jpg", "Kalp krizini hangisi daha fazla tetikliyor? Hamburger mi yoksa stres mi?", 1, 295 },
                    { 5, 5, 2, "Yaygın inancın tersine, Lorem Ipsum rastgele sözcüklerden oluşmaz. Kökleri M.Ö. 45 tarihinden bu yana klasik Latin edebiyatına kadar uzanan 2000 yıllık bir geçmişi vardır. Virginia'daki Hampden-Sydney College'dan Latince profesörü Richard McClintock, bir Lorem Ipsum pasajında geçen ve anlaşılması en güç sözcüklerden biri olan 'consectetur' sözcüğünün klasik edebiyattaki örneklerini incelediğinde kesin bir kaynağa ulaşmıştır. Lorm Ipsum, Çiçero tarafından M.Ö. 45 tarihinde kaleme alınan de Finibus Bonorum et Malorum (İyi ve Kötünün Uç Sınırları) eserinin 1.10.32 ve 1.10.33 sayılı bölümlerinden gelmektedir. Bu kitap, ahlak kuramı üzerine bir tezdir ve Rönesans döneminde çok popüler olmuştur. Lorem Ipsum pasajının ilk satırı olan Lorem ipsum dolor sit amet 1.10.32 sayılı bölümdeki bir satırdan gelmektedir.", "Initial Create", new DateTime(2021, 11, 6, 18, 0, 5, 60, DateTimeKind.Local).AddTicks(4766), new DateTime(2021, 11, 6, 18, 0, 5, 60, DateTimeKind.Local).AddTicks(4765), true, false, "Initial Create", new DateTime(2021, 11, 6, 18, 0, 5, 60, DateTimeKind.Local).AddTicks(4767), "Cisco, AR destekli toplantı çözümü Webex Hologram'ı tanıttı", "Oğuzhan Akpınar", "Cisco, AR destekli toplantı çözümü Webex Hologram'ı tanıttı", "Cisco AR Hologram", "postImages/defaultThumbnail.jpg", "Cisco, AR destekli toplantı çözümü Webex Hologram'ı tanıttı", 1, 222 }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { 3, 2 },
                    { 20, 1 },
                    { 21, 1 },
                    { 22, 1 },
                    { 1, 2 },
                    { 2, 2 },
                    { 4, 2 },
                    { 17, 2 },
                    { 6, 2 },
                    { 7, 2 },
                    { 8, 2 },
                    { 19, 1 },
                    { 18, 2 },
                    { 19, 2 },
                    { 5, 2 },
                    { 18, 1 },
                    { 13, 1 },
                    { 16, 1 },
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 1 },
                    { 4, 1 },
                    { 5, 1 },
                    { 6, 1 },
                    { 7, 1 },
                    { 8, 1 },
                    { 9, 1 },
                    { 10, 1 },
                    { 11, 1 },
                    { 12, 1 },
                    { 20, 2 },
                    { 14, 1 }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { 15, 1 });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { 17, 1 });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { 21, 2 });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CreatedByName", "CreatedDate", "IsActive", "IsDeleted", "ModifiedByName", "ModifiedDate", "Note", "ReportId", "Text" },
                values: new object[,]
                {
                    { 1, "InitialCreate", new DateTime(2021, 11, 6, 18, 0, 5, 66, DateTimeKind.Local).AddTicks(6074), true, false, "InitialCreate", new DateTime(2021, 11, 6, 18, 0, 5, 66, DateTimeKind.Local).AddTicks(6086), "Yorum 1", 1, "Lorem Ipsum pasajlarının birçok çeşitlemesi vardır. Ancak bunların büyük bir çoğunluğu mizah katılarak veya rastgele sözcükler eklenerek değiştirilmişlerdir. Eğer bir Lorem Ipsum pasajı kullanacaksanız, metin aralarına utandırıcı sözcükler gizlenmediğinden emin olmanız gerekir. İnternet'teki tüm Lorem Ipsum üreteçleri önceden belirlenmiş metin bloklarını yineler. Bu da, bu üreteci İnternet üzerindeki gerçek Lorem Ipsum üreteci yapar. Bu üreteç, 200'den fazla Latince sözcük ve onlara ait cümle yapılarını içeren bir sözlük kullanır. Bu nedenle, üretilen Lorem Ipsum metinleri yinelemelerden, mizahtan ve karakteristik olmayan sözcüklerden uzaktır." },
                    { 2, "InitialCreate", new DateTime(2021, 11, 6, 18, 0, 5, 66, DateTimeKind.Local).AddTicks(6100), true, false, "InitialCreate", new DateTime(2021, 11, 6, 18, 0, 5, 66, DateTimeKind.Local).AddTicks(6101), "Yorum 2", 2, "Lorem Ipsum jest tekstem stosowanym jako przykładowy wypełniacz w przemyśle poligraficznym. Został po raz pierwszy użyty w XV w. przez nieznanego drukarza do wypełnienia tekstem próbnej książki. Pięć wieków później zaczął być używany przemyśle elektronicznym, pozostając praktycznie niezmienionym. Spopularyzował się w latach 60. XX w. wraz z publikacją arkuszy Letrasetu, zawierających fragmenty Lorem Ipsum, a ostatnio z zawierającym różne wersje Lorem Ipsum oprogramowaniem przeznaczonym do realizacji druków na komputerach osobistych, jak Aldus PageMaker" },
                    { 3, "InitialCreate", new DateTime(2021, 11, 6, 18, 0, 5, 66, DateTimeKind.Local).AddTicks(6105), true, false, "InitialCreate", new DateTime(2021, 11, 6, 18, 0, 5, 66, DateTimeKind.Local).AddTicks(6107), "Yorum 3", 3, "Ang Lorem Ipsum ay ginagamit na modelo ng industriya ng pagpriprint at pagtytypeset. Ang Lorem Ipsum ang naging regular na modelo simula pa noong 1500s, noong may isang di kilalang manlilimbag and kumuha ng galley ng type at ginulo ang pagkaka-ayos nito upang makagawa ng libro ng mga type specimen. Nalagpasan nito hindi lang limang siglo, kundi nalagpasan din nito ang paglaganap ng electronic typesetting at nanatiling parehas. Sumikat ito noong 1960s kasabay ng pag labas ng Letraset sheets na mayroong mga talata ng Lorem Ipsum, at kamakailan lang sa mga desktop publishing software tulad ng Aldus Pagemaker ginamit ang mga bersyon ng Lorem Ipsum." },
                    { 4, "InitialCreate", new DateTime(2021, 11, 6, 18, 0, 5, 66, DateTimeKind.Local).AddTicks(6111), true, false, "InitialCreate", new DateTime(2021, 11, 6, 18, 0, 5, 66, DateTimeKind.Local).AddTicks(6112), "Yorum 4", 4, "Lorem Ipsum er rett og slett dummytekst fra og for trykkeindustrien. Lorem Ipsum har vært bransjens standard for dummytekst helt siden 1500-tallet, da en ukjent boktrykker stokket en mengde bokstaver for å lage et prøveeksemplar av en bok. Lorem Ipsum har tålt tidens tann usedvanlig godt, og har i tillegg til å bestå gjennom fem århundrer også tålt spranget over til elektronisk typografi uten vesentlige endringer. Lorem Ipsum ble gjort allment kjent i 1960-årene ved lanseringen av Letraset-ark med avsnitt fra Lorem Ipsum, og senere med sideombrekkingsprogrammet Aldus PageMaker som tok i bruk nettopp Lorem Ipsum for dummytekst." },
                    { 5, "InitialCreate", new DateTime(2021, 11, 6, 18, 0, 5, 66, DateTimeKind.Local).AddTicks(6116), true, false, "InitialCreate", new DateTime(2021, 11, 6, 18, 0, 5, 66, DateTimeKind.Local).AddTicks(6117), "Yorum 5", 5, "Lorem Ipsum este pur şi simplu o machetă pentru text a industriei tipografice. Lorem Ipsum a fost macheta standard a industriei încă din secolul al XVI-lea, când un tipograf anonim a luat o planşetă de litere şi le-a amestecat pentru a crea o carte demonstrativă pentru literele respective. Nu doar că a supravieţuit timp de cinci secole, dar şi a facut saltul în tipografia electronică practic neschimbată. A fost popularizată în anii '60 odată cu ieşirea colilor Letraset care conţineau pasaje Lorem Ipsum, iar mai recent, prin programele de publicare pentru calculator, ca Aldus PageMaker care includeau versiuni de Lorem Ipsum." },
                    { 6, "InitialCreate", new DateTime(2021, 11, 6, 18, 0, 5, 66, DateTimeKind.Local).AddTicks(6121), true, false, "InitialCreate", new DateTime(2021, 11, 6, 18, 0, 5, 66, DateTimeKind.Local).AddTicks(6122), "Yorum 6", 6, "Lorem Ipsum je jednostavno probni tekst koji se koristi u tiskarskoj i slovoslagarskoj industriji. Lorem Ipsum postoji kao industrijski standard još od 16-og stoljeća, kada je nepoznati tiskar uzeo tiskarsku galiju slova i posložio ih da bi napravio knjigu s uzorkom tiska. Taj je tekst ne samo preživio pet stoljeća, već se i vinuo u svijet elektronskog slovoslagarstva, ostajući u suštini nepromijenjen. Postao je popularan tijekom 1960-ih s pojavom Letraset listova s odlomcima Lorem Ipsum-a, a u skorije vrijeme sa software-om za stolno izdavaštvo kao što je Aldus PageMaker koji također sadrži varijante Lorem Ipsum-a." },
                    { 7, "InitialCreate", new DateTime(2021, 11, 6, 18, 0, 5, 66, DateTimeKind.Local).AddTicks(6126), true, false, "InitialCreate", new DateTime(2021, 11, 6, 18, 0, 5, 66, DateTimeKind.Local).AddTicks(6127), "Yorum 7", 7, "Lorem Ipsum – tas ir teksta salikums, kuru izmanto poligrāfijā un maketēšanas darbos. Lorem Ipsum ir kļuvis par vispārpieņemtu teksta aizvietotāju kopš 16. gadsimta sākuma. Tajā laikā kāds nezināms iespiedējs izveidoja teksta fragmentu, lai nodrukātu grāmatu ar burtu paraugiem. Tas ir ne tikai pārdzīvojis piecus gadsimtus, bet bez ievērojamām izmaiņām saglabājies arī mūsdienās, pārejot uz datorizētu teksta apstrādi. Tā popularizēšanai 60-tajos gados kalpoja Letraset burtu paraugu publicēšana ar Lorem Ipsum teksta fragmentiem un, nesenā pagātnē, tādas maketēšanas programmas kā Aldus PageMaker, kuras šablonu paraugos ir izmantots Lorem Ipsum teksts." },
                    { 8, "InitialCreate", new DateTime(2021, 11, 6, 18, 0, 5, 66, DateTimeKind.Local).AddTicks(6131), true, false, "InitialCreate", new DateTime(2021, 11, 6, 18, 0, 5, 66, DateTimeKind.Local).AddTicks(6132), "Yorum 8", 8, "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like)." },
                    { 9, "InitialCreate", new DateTime(2021, 11, 6, 18, 0, 5, 66, DateTimeKind.Local).AddTicks(6136), true, false, "InitialCreate", new DateTime(2021, 11, 6, 18, 0, 5, 66, DateTimeKind.Local).AddTicks(6138), "Yorum 9", 9, "هنالك العديد من الأنواع المتوفرة لنصوص لوريم إيبسوم، ولكن الغالبية تم تعديلها بشكل ما عبر إدخال بعض النوادر أو الكلمات العشوائية إلى النص. إن كنت تريد أن تستخدم نص لوريم إيبسوم ما، عليك أن تتحقق أولاً أن ليس هناك أي كلمات أو عبارات محرجة أو غير لائقة مخبأة في هذا النص. بينما تعمل جميع مولّدات نصوص لوريم إيبسوم على الإنترنت على إعادة تكرار مقاطع من نص لوريم إيبسوم نفسه عدة مرات بما تتطلبه الحاجة، يقوم مولّدنا هذا باستخدام كلمات من قاموس يحوي على أكثر من 200 كلمة لا تينية، مضاف إليها مجموعة من الجمل النموذجية، لتكوين نص لوريم إيبسوم ذو شكل منطقي قريب إلى النص الحقيقي. وبالتالي يكون النص الناتح خالي من التكرار، أو أي كلمات أو عبارات غير لائقة أو ما شابه. وهذا ما يجعله أول مولّد نص لوريم إيبسوم حقيقي على الإنترنت." },
                    { 10, "InitialCreate", new DateTime(2021, 11, 6, 18, 0, 5, 66, DateTimeKind.Local).AddTicks(6142), true, false, "InitialCreate", new DateTime(2021, 11, 6, 18, 0, 5, 66, DateTimeKind.Local).AddTicks(6143), "Yorum 10", 10, "Lorem Ipsum，也称乱数假文或者哑元文本， 是印刷及排版领域所常用的虚拟文字。由于曾经一台匿名的打印机刻意打乱了一盒印刷字体从而造出一本字体样品书，Lorem Ipsum从西元15世纪起就被作为此领域的标准文本使用。它不仅延续了五个世纪，还通过了电子排版的挑战，其雏形却依然保存至今。在1960年代，”Leatraset”公司发布了印刷着Lorem Ipsum段落的纸张，从而广泛普及了它的使用。最近，计算机桌面出版软件”Aldus PageMaker”也通过同样的方式使Lorem Ipsum落入大众的视野。" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ReportId",
                table: "Comments",
                column: "ReportId");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_CategoryId",
                table: "Reports",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_UserId",
                table: "Reports",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId",
                table: "RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Roles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                table: "UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Users",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
