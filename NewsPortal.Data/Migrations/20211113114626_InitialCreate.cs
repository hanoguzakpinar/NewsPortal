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
                name: "Logs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MachineName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Logged = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Level = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Message = table.Column<string>(type: "NVARCHAR(MAX)", nullable: false),
                    Logger = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Callsite = table.Column<string>(type: "NVARCHAR(MAX)", nullable: true),
                    Exception = table.Column<string>(type: "NVARCHAR(MAX)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.Id);
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
                    { 1, "InitialCreate", new DateTime(2021, 11, 13, 14, 46, 26, 216, DateTimeKind.Local).AddTicks(1061), "Ekonomi Haberleri", true, false, "InitialCreate", new DateTime(2021, 11, 13, 14, 46, 26, 216, DateTimeKind.Local).AddTicks(1073), "Ekonomi", "Ekonomi Kategorisi" },
                    { 2, "InitialCreate", new DateTime(2021, 11, 13, 14, 46, 26, 216, DateTimeKind.Local).AddTicks(1090), "Sağlık Haberleri", true, false, "InitialCreate", new DateTime(2021, 11, 13, 14, 46, 26, 216, DateTimeKind.Local).AddTicks(1091), "Sağlık", "Sağlık Kategorisi" },
                    { 3, "InitialCreate", new DateTime(2021, 11, 13, 14, 46, 26, 216, DateTimeKind.Local).AddTicks(1096), "Dünya Haberleri", true, false, "InitialCreate", new DateTime(2021, 11, 13, 14, 46, 26, 216, DateTimeKind.Local).AddTicks(1098), "Dünya", "Dünya Kategorisi" },
                    { 4, "InitialCreate", new DateTime(2021, 11, 13, 14, 46, 26, 216, DateTimeKind.Local).AddTicks(1102), "Gündem Haberleri", true, false, "InitialCreate", new DateTime(2021, 11, 13, 14, 46, 26, 216, DateTimeKind.Local).AddTicks(1103), "Gündem", "Gündem Kategorisi" },
                    { 5, "InitialCreate", new DateTime(2021, 11, 13, 14, 46, 26, 216, DateTimeKind.Local).AddTicks(1107), "Teknoloji Haberleri", true, false, "InitialCreate", new DateTime(2021, 11, 13, 14, 46, 26, 216, DateTimeKind.Local).AddTicks(1109), "Teknoloji", "Teknoloji Kategorisi" },
                    { 6, "InitialCreate", new DateTime(2021, 11, 13, 14, 46, 26, 216, DateTimeKind.Local).AddTicks(1113), "Magazin Haberleri", true, false, "InitialCreate", new DateTime(2021, 11, 13, 14, 46, 26, 216, DateTimeKind.Local).AddTicks(1114), "Magazin", "Magazin Kategorisi" },
                    { 7, "InitialCreate", new DateTime(2021, 11, 13, 14, 46, 26, 216, DateTimeKind.Local).AddTicks(1118), "Futbol Haberleri", true, false, "InitialCreate", new DateTime(2021, 11, 13, 14, 46, 26, 216, DateTimeKind.Local).AddTicks(1119), "Futbol", "Futbol Kategorisi" },
                    { 8, "InitialCreate", new DateTime(2021, 11, 13, 14, 46, 26, 216, DateTimeKind.Local).AddTicks(1123), "Basketbol Haberleri", true, false, "InitialCreate", new DateTime(2021, 11, 13, 14, 46, 26, 216, DateTimeKind.Local).AddTicks(1124), "Basketbol", "Basketbol Kategorisi" },
                    { 9, "InitialCreate", new DateTime(2021, 11, 13, 14, 46, 26, 216, DateTimeKind.Local).AddTicks(1129), "Formula 1 Haberleri", true, false, "InitialCreate", new DateTime(2021, 11, 13, 14, 46, 26, 216, DateTimeKind.Local).AddTicks(1130), "Formula 1", "Formula 1 Kategorisi" },
                    { 10, "InitialCreate", new DateTime(2021, 11, 13, 14, 46, 26, 216, DateTimeKind.Local).AddTicks(1134), "Espor Haberleri", true, false, "InitialCreate", new DateTime(2021, 11, 13, 14, 46, 26, 216, DateTimeKind.Local).AddTicks(1135), "Espor", "Espor Kategorisi" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 15, "376f91d3-4f7a-492f-bc85-bd4f031e89f9", "Role.Update", "ROLE.UPDATE" },
                    { 16, "30bbbb3b-8df5-4547-bf7c-2e446f1de1c2", "Role.Delete", "ROLE.DELETE" },
                    { 17, "6b1759e3-222c-47f6-b2bc-2e2c02730a2d", "Comment.Create", "COMMENT.CREATE" },
                    { 18, "aba3b5cc-eb0f-4003-a0a5-223dfa9b499b", "Comment.Read", "COMMENT.READ" },
                    { 23, "f9e6d77a-a5e1-4589-aa18-5b644ac56927", "Normal", "NORMAL" },
                    { 20, "9be2c2fe-4dda-4585-8553-655f0e5fe07d", "Comment.Delete", "COMMENT.DELETE" },
                    { 21, "3ea50d6a-06ab-4f81-b2ad-e41d03c1be1d", "AdminArea.Home.Read", "ADMINAREA.HOME.READ" },
                    { 22, "6fefb725-caf6-4ad5-9789-d3b7ad98a0ab", "SuperAdmin", "SUPERADMIN" },
                    { 14, "c0ca055d-220f-480e-b8d5-faead7041dad", "Role.Read", "ROLE.READ" },
                    { 19, "eace3b59-85de-477e-8907-fd7139bd6478", "Comment.Update", "COMMENT.UPDATE" },
                    { 13, "ab0e6037-8a7e-4336-bd6c-17c94fca8e6f", "Role.Create", "ROLE.CREATE" },
                    { 8, "f6872c94-10e0-4cf5-9840-49e4b393695c", "Report.Delete", "REPORT.DELETE" },
                    { 11, "1f955333-6daf-4481-baf8-0813a55b367e", "User.Update", "USER.UPDATE" },
                    { 10, "6842cee0-6b2a-4656-8784-59881897b101", "User.Read", "USER.READ" },
                    { 9, "30080bd3-995a-49ad-9773-ac1c29499012", "User.Create", "USER.CREATE" },
                    { 7, "d730ada3-2040-4ba9-a32d-501d55569984", "Report.Update", "REPORT.UPDATE" },
                    { 6, "fbfd2e97-cb0c-4d6e-a26f-f63059c15b6f", "Report.Read", "REPORT.READ" },
                    { 5, "d33009cf-2276-4ef5-82c6-2c77307ba550", "Report.Create", "REPORT.CREATE" },
                    { 4, "96055308-7b58-4c75-901a-8c7344627205", "Category.Delete", "CATEGORY.DELETE" },
                    { 3, "9078eb02-5f40-4a4a-b3e5-c3fe7c82c27b", "Category.Update", "CATEGORY.UPDATE" },
                    { 2, "c24c203d-ccdc-4405-bd4b-53cf3afa91db", "Category.Read", "CATEGORY.READ" },
                    { 1, "f04db07c-1277-4468-ae32-3e33c8730988", "Category.Create", "CATEGORY.CREATE" },
                    { 12, "6355a93b-d606-4767-a714-c003b98bb33f", "User.Delete", "USER.DELETE" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "About", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FacebookLink", "FirstName", "GitHubLink", "InstagramLink", "LastName", "LinkedInLink", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Picture", "SecurityStamp", "TwitterLink", "TwoFactorEnabled", "UserName", "WebsiteLink", "YoutubeLink" },
                values: new object[,]
                {
                    { 1, "Admin User of NewsPortal", 0, "88c873f4-8137-40a9-8804-10f7a5208c10", "adminuser@gmail.com", true, "https://facebook.com/adminuser", "Admin", "https://github.com/adminuser", "https://instagram.com/adminuser", "User", "https://linkedin.com/adminuser", false, null, "ADMINUSER@GMAIL.COM", "ADMINUSER", "AQAAAAEAACcQAAAAEAlIicoopWReCvKzp1rr/7Jo5cAS08zf1MxSZuMt2L2tO6nWtEP3hMuOSe0yUarSAA==", "+905555555555", true, "/userImages/defaultUser.jpg", "4f34c474-cb28-4691-a4df-a72593aba8ae", "https://twitter.com/adminuser", false, "adminuser", "https://newsportal.com/", "https://youtube.com/adminuser" },
                    { 2, "Editor User of NewsPortal", 0, "f8e5f1e4-0a6d-4302-9d2c-e118ce394b15", "editoruser@gmail.com", true, "https://facebook.com/editoruser", "Admin", "https://github.com/editoruser", "https://instagram.com/editoruser", "User", "https://linkedin.com/editoruser", false, null, "EDITORUSER@GMAIL.COM", "EDITORUSER", "AQAAAAEAACcQAAAAEO/KYWxJ8iwKL+bL2vV6ZM/JGgWZorCsBk60pdKmSV0FRnOprcI0ES5jCGMsDnFF2A==", "+905555555555", true, "/userImages/defaultUser.jpg", "a1bbc761-0b65-40da-b578-972a3eb44577", "https://twitter.com/editoruser", false, "editoruser", "https://newsportal.com/", "https://youtube.com/editoruser" }
                });

            migrationBuilder.InsertData(
                table: "Reports",
                columns: new[] { "Id", "CategoryId", "CommentCount", "Content", "CreatedByName", "CreatedDate", "Date", "IsActive", "IsDeleted", "ModifiedByName", "ModifiedDate", "Note", "SeoAuthor", "SeoDescription", "SeoTags", "Thumbnail", "Title", "UserId", "ViewsCount" },
                values: new object[,]
                {
                    { 1, 1, 1, "Lorem Ipsum, dizgi ve baskı endüstrisinde kullanılan mıgır metinlerdir. Lorem Ipsum, adı bilinmeyen bir matbaacının bir hurufat numune kitabı oluşturmak üzere bir yazı galerisini alarak karıştırdığı 1500'lerden beri endüstri standardı sahte metinler olarak kullanılmıştır. Beşyüz yıl boyunca varlığını sürdürmekle kalmamış, aynı zamanda pek değişmeden elektronik dizgiye de sıçramıştır. 1960'larda Lorem Ipsum pasajları da içeren Letraset yapraklarının yayınlanması ile ve yakın zamanda Aldus PageMaker gibi Lorem Ipsum sürümleri içeren masaüstü yayıncılık yazılımları ile popüler olmuştur.", "Initial Create", new DateTime(2021, 11, 13, 14, 46, 26, 212, DateTimeKind.Local).AddTicks(5167), new DateTime(2021, 11, 13, 14, 46, 26, 212, DateTimeKind.Local).AddTicks(4177), true, false, "Initial Create", new DateTime(2021, 11, 13, 14, 46, 26, 212, DateTimeKind.Local).AddTicks(5681), "SHIBA INU'ya zirveden giren yüzde 45 kaybetti", "Oğuzhan Akpınar", "SHIBA INU'ya zirveden giren yüzde 45 kaybetti", "SHIBA INU", "postImages/defaultThumbnail.png", "SHIBA INU'ya zirveden giren yüzde 45 kaybetti", 1, 100 },
                    { 10, 10, 1, "Yaygın inancın tersine, Lorem Ipsum rastgele sözcüklerden oluşmaz. Kökleri M.Ö. 45 tarihinden bu yana klasik Latin edebiyatına kadar uzanan 2000 yıllık bir geçmişi vardır. Virginia'daki Hampden-Sydney College'dan Latince profesörü Richard McClintock, bir Lorem Ipsum pasajında geçen ve anlaşılması en güç sözcüklerden biri olan 'consectetur' sözcüğünün klasik edebiyattaki örneklerini incelediğinde kesin bir kaynağa ulaşmıştır. Lorm Ipsum, Çiçero tarafından M.Ö. 45 tarihinde kaleme alınan de Finibus Bonorum et Malorum (İyi ve Kötünün Uç Sınırları) eserinin 1.10.32 ve 1.10.33 sayılı bölümlerinden gelmektedir. Bu kitap, ahlak kuramı üzerine bir tezdir ve Rönesans döneminde çok popüler olmuştur. Lorem Ipsum pasajının ilk satırı olan Lorem ipsum dolor sit amet 1.10.32 sayılı bölümdeki bir satırdan gelmektedir.", "Initial Create", new DateTime(2021, 11, 13, 14, 46, 26, 212, DateTimeKind.Local).AddTicks(7360), new DateTime(2021, 11, 13, 14, 46, 26, 212, DateTimeKind.Local).AddTicks(7358), true, false, "Initial Create", new DateTime(2021, 11, 13, 14, 46, 26, 212, DateTimeKind.Local).AddTicks(7361), "Dota 2 The International 2021 Şampiyonu Team Spirit Oldu!", "Oğuzhan Akpınar", "Dota 2 The International 2021 Şampiyonu Team Spirit Oldu!", "Dota International Spirit", "postImages/defaultThumbnail.png", "Dota 2 The International 2021 Şampiyonu Team Spirit Oldu!", 1, 50 },
                    { 8, 8, 1, "Yaygın inancın tersine, Lorem Ipsum rastgele sözcüklerden oluşmaz. Kökleri M.Ö. 45 tarihinden bu yana klasik Latin edebiyatına kadar uzanan 2000 yıllık bir geçmişi vardır. Virginia'daki Hampden-Sydney College'dan Latince profesörü Richard McClintock, bir Lorem Ipsum pasajında geçen ve anlaşılması en güç sözcüklerden biri olan 'consectetur' sözcüğünün klasik edebiyattaki örneklerini incelediğinde kesin bir kaynağa ulaşmıştır. Lorm Ipsum, Çiçero tarafından M.Ö. 45 tarihinde kaleme alınan de Finibus Bonorum et Malorum (İyi ve Kötünün Uç Sınırları) eserinin 1.10.32 ve 1.10.33 sayılı bölümlerinden gelmektedir. Bu kitap, ahlak kuramı üzerine bir tezdir ve Rönesans döneminde çok popüler olmuştur. Lorem Ipsum pasajının ilk satırı olan Lorem ipsum dolor sit amet 1.10.32 sayılı bölümdeki bir satırdan gelmektedir.", "Initial Create", new DateTime(2021, 11, 13, 14, 46, 26, 212, DateTimeKind.Local).AddTicks(7346), new DateTime(2021, 11, 13, 14, 46, 26, 212, DateTimeKind.Local).AddTicks(7343), true, false, "Initial Create", new DateTime(2021, 11, 13, 14, 46, 26, 212, DateTimeKind.Local).AddTicks(7347), "Anadolu Efes: 85 - Galatasaray Nef: 92", "Oğuzhan Akpınar", "Anadolu Efes: 85 - Galatasaray Nef: 92", "GS Efes Basketbol", "postImages/defaultThumbnail.png", "Anadolu Efes: 85 - Galatasaray Nef: 92", 1, 200 },
                    { 7, 7, 2, "Yaygın inancın tersine, Lorem Ipsum rastgele sözcüklerden oluşmaz. Kökleri M.Ö. 45 tarihinden bu yana klasik Latin edebiyatına kadar uzanan 2000 yıllık bir geçmişi vardır. Virginia'daki Hampden-Sydney College'dan Latince profesörü Richard McClintock, bir Lorem Ipsum pasajında geçen ve anlaşılması en güç sözcüklerden biri olan 'consectetur' sözcüğünün klasik edebiyattaki örneklerini incelediğinde kesin bir kaynağa ulaşmıştır. Lorm Ipsum, Çiçero tarafından M.Ö. 45 tarihinde kaleme alınan de Finibus Bonorum et Malorum (İyi ve Kötünün Uç Sınırları) eserinin 1.10.32 ve 1.10.33 sayılı bölümlerinden gelmektedir. Bu kitap, ahlak kuramı üzerine bir tezdir ve Rönesans döneminde çok popüler olmuştur. Lorem Ipsum pasajının ilk satırı olan Lorem ipsum dolor sit amet 1.10.32 sayılı bölümdeki bir satırdan gelmektedir.", "Initial Create", new DateTime(2021, 11, 13, 14, 46, 26, 212, DateTimeKind.Local).AddTicks(7338), new DateTime(2021, 11, 13, 14, 46, 26, 212, DateTimeKind.Local).AddTicks(7336), true, false, "Initial Create", new DateTime(2021, 11, 13, 14, 46, 26, 212, DateTimeKind.Local).AddTicks(7339), "Galatasaray: 1 - Lokomotiv Moskova: 1", "Oğuzhan Akpınar", "Galatasaray: 1 - Lokomotiv Moskova: 1", "GS LM Uefa", "postImages/defaultThumbnail.png", "Galatasaray: 1 - Lokomotiv Moskova: 1", 1, 255 },
                    { 6, 6, 2, "Yaygın inancın tersine, Lorem Ipsum rastgele sözcüklerden oluşmaz. Kökleri M.Ö. 45 tarihinden bu yana klasik Latin edebiyatına kadar uzanan 2000 yıllık bir geçmişi vardır. Virginia'daki Hampden-Sydney College'dan Latince profesörü Richard McClintock, bir Lorem Ipsum pasajında geçen ve anlaşılması en güç sözcüklerden biri olan 'consectetur' sözcüğünün klasik edebiyattaki örneklerini incelediğinde kesin bir kaynağa ulaşmıştır. Lorm Ipsum, Çiçero tarafından M.Ö. 45 tarihinde kaleme alınan de Finibus Bonorum et Malorum (İyi ve Kötünün Uç Sınırları) eserinin 1.10.32 ve 1.10.33 sayılı bölümlerinden gelmektedir. Bu kitap, ahlak kuramı üzerine bir tezdir ve Rönesans döneminde çok popüler olmuştur. Lorem Ipsum pasajının ilk satırı olan Lorem ipsum dolor sit amet 1.10.32 sayılı bölümdeki bir satırdan gelmektedir.", "Initial Create", new DateTime(2021, 11, 13, 14, 46, 26, 212, DateTimeKind.Local).AddTicks(7331), new DateTime(2021, 11, 13, 14, 46, 26, 212, DateTimeKind.Local).AddTicks(7328), true, false, "Initial Create", new DateTime(2021, 11, 13, 14, 46, 26, 212, DateTimeKind.Local).AddTicks(7332), "Saçma Magazin Haberi", "Oğuzhan Akpınar", "Saçma Magazin Haberi", "Magazin Saçma Haber", "postImages/defaultThumbnail.png", "Saçma Magazin Haberi", 1, 15 },
                    { 9, 9, 1, "Yaygın inancın tersine, Lorem Ipsum rastgele sözcüklerden oluşmaz. Kökleri M.Ö. 45 tarihinden bu yana klasik Latin edebiyatına kadar uzanan 2000 yıllık bir geçmişi vardır. Virginia'daki Hampden-Sydney College'dan Latince profesörü Richard McClintock, bir Lorem Ipsum pasajında geçen ve anlaşılması en güç sözcüklerden biri olan 'consectetur' sözcüğünün klasik edebiyattaki örneklerini incelediğinde kesin bir kaynağa ulaşmıştır. Lorm Ipsum, Çiçero tarafından M.Ö. 45 tarihinde kaleme alınan de Finibus Bonorum et Malorum (İyi ve Kötünün Uç Sınırları) eserinin 1.10.32 ve 1.10.33 sayılı bölümlerinden gelmektedir. Bu kitap, ahlak kuramı üzerine bir tezdir ve Rönesans döneminde çok popüler olmuştur. Lorem Ipsum pasajının ilk satırı olan Lorem ipsum dolor sit amet 1.10.32 sayılı bölümdeki bir satırdan gelmektedir.", "Initial Create", new DateTime(2021, 11, 13, 14, 46, 26, 212, DateTimeKind.Local).AddTicks(7353), new DateTime(2021, 11, 13, 14, 46, 26, 212, DateTimeKind.Local).AddTicks(7351), true, false, "Initial Create", new DateTime(2021, 11, 13, 14, 46, 26, 212, DateTimeKind.Local).AddTicks(7354), "Mercedes'in Hamilton'ın motor cezası alma ihtimaliyle ilgili endişeleri azaldı", "Oğuzhan Akpınar", "Mercedes'in Hamilton'ın motor cezası alma ihtimaliyle ilgili endişeleri azaldı", "F1 Mercedes", "postImages/defaultThumbnail.png", "Mercedes'in Hamilton'ın motor cezası alma ihtimaliyle ilgili endişeleri azaldı", 1, 100 },
                    { 4, 4, 1, "Yaygın inancın tersine, Lorem Ipsum rastgele sözcüklerden oluşmaz. Kökleri M.Ö. 45 tarihinden bu yana klasik Latin edebiyatına kadar uzanan 2000 yıllık bir geçmişi vardır. Virginia'daki Hampden-Sydney College'dan Latince profesörü Richard McClintock, bir Lorem Ipsum pasajında geçen ve anlaşılması en güç sözcüklerden biri olan 'consectetur' sözcüğünün klasik edebiyattaki örneklerini incelediğinde kesin bir kaynağa ulaşmıştır. Lorm Ipsum, Çiçero tarafından M.Ö. 45 tarihinde kaleme alınan de Finibus Bonorum et Malorum (İyi ve Kötünün Uç Sınırları) eserinin 1.10.32 ve 1.10.33 sayılı bölümlerinden gelmektedir. Bu kitap, ahlak kuramı üzerine bir tezdir ve Rönesans döneminde çok popüler olmuştur. Lorem Ipsum pasajının ilk satırı olan Lorem ipsum dolor sit amet 1.10.32 sayılı bölümdeki bir satırdan gelmektedir.", "Initial Create", new DateTime(2021, 11, 13, 14, 46, 26, 212, DateTimeKind.Local).AddTicks(7315), new DateTime(2021, 11, 13, 14, 46, 26, 212, DateTimeKind.Local).AddTicks(7313), true, false, "Initial Create", new DateTime(2021, 11, 13, 14, 46, 26, 212, DateTimeKind.Local).AddTicks(7316), "50 yıl sonra görüldü! O balık İzmit Körfezi'nde!", "Oğuzhan Akpınar", "50 yıl sonra görüldü! O balık İzmit Körfezi'nde!", "Balık İzmit Körfez", "postImages/defaultThumbnail.png", "50 yıl sonra görüldü! O balık İzmit Körfezi'nde!", 1, 100 },
                    { 3, 3, 1, "Yaygın inancın tersine, Lorem Ipsum rastgele sözcüklerden oluşmaz. Kökleri M.Ö. 45 tarihinden bu yana klasik Latin edebiyatına kadar uzanan 2000 yıllık bir geçmişi vardır. Virginia'daki Hampden-Sydney College'dan Latince profesörü Richard McClintock, bir Lorem Ipsum pasajında geçen ve anlaşılması en güç sözcüklerden biri olan 'consectetur' sözcüğünün klasik edebiyattaki örneklerini incelediğinde kesin bir kaynağa ulaşmıştır. Lorm Ipsum, Çiçero tarafından M.Ö. 45 tarihinde kaleme alınan de Finibus Bonorum et Malorum (İyi ve Kötünün Uç Sınırları) eserinin 1.10.32 ve 1.10.33 sayılı bölümlerinden gelmektedir. Bu kitap, ahlak kuramı üzerine bir tezdir ve Rönesans döneminde çok popüler olmuştur. Lorem Ipsum pasajının ilk satırı olan Lorem ipsum dolor sit amet 1.10.32 sayılı bölümdeki bir satırdan gelmektedir.", "Initial Create", new DateTime(2021, 11, 13, 14, 46, 26, 212, DateTimeKind.Local).AddTicks(7307), new DateTime(2021, 11, 13, 14, 46, 26, 212, DateTimeKind.Local).AddTicks(7305), true, false, "Initial Create", new DateTime(2021, 11, 13, 14, 46, 26, 212, DateTimeKind.Local).AddTicks(7308), "İran'dan şoke eden itiraf! \"Petrolü kaçak satıyoruz!\"", "Oğuzhan Akpınar", "İran'dan şoke eden itiraf! \"Petrolü kaçak satıyoruz!\"", "İran Kaçak Petrol", "postImages/defaultThumbnail.png", "İran'dan şoke eden itiraf! \"Petrolü kaçak satıyoruz!\"", 1, 120 },
                    { 2, 2, 1, "Yinelenen bir sayfa içeriğinin okuyucunun dikkatini dağıttığı bilinen bir gerçektir. Lorem Ipsum kullanmanın amacı, sürekli 'buraya metin gelecek, buraya metin gelecek' yazmaya kıyasla daha dengeli bir harf dağılımı sağlayarak okunurluğu artırmasıdır. Şu anda birçok masaüstü yayıncılık paketi ve web sayfa düzenleyicisi, varsayılan mıgır metinler olarak Lorem Ipsum kullanmaktadır. Ayrıca arama motorlarında 'lorem ipsum' anahtar sözcükleri ile arama yapıldığında henüz tasarım aşamasında olan çok sayıda site listelenir. Yıllar içinde, bazen kazara, bazen bilinçli olarak (örneğin mizah katılarak), çeşitli sürümleri geliştirilmiştir.", "Initial Create", new DateTime(2021, 11, 13, 14, 46, 26, 212, DateTimeKind.Local).AddTicks(7297), new DateTime(2021, 11, 13, 14, 46, 26, 212, DateTimeKind.Local).AddTicks(7295), true, false, "Initial Create", new DateTime(2021, 11, 13, 14, 46, 26, 212, DateTimeKind.Local).AddTicks(7299), "Kalp krizini hangisi daha fazla tetikliyor? Hamburger mi yoksa stres mi?", "Oğuzhan Akpınar", "Kalp krizini hangisi daha fazla tetikliyor? Hamburger mi yoksa stres mi?", "Kalp Krizi Stres Hamburger", "postImages/defaultThumbnail.png", "Kalp krizini hangisi daha fazla tetikliyor? Hamburger mi yoksa stres mi?", 1, 295 },
                    { 5, 5, 2, "Yaygın inancın tersine, Lorem Ipsum rastgele sözcüklerden oluşmaz. Kökleri M.Ö. 45 tarihinden bu yana klasik Latin edebiyatına kadar uzanan 2000 yıllık bir geçmişi vardır. Virginia'daki Hampden-Sydney College'dan Latince profesörü Richard McClintock, bir Lorem Ipsum pasajında geçen ve anlaşılması en güç sözcüklerden biri olan 'consectetur' sözcüğünün klasik edebiyattaki örneklerini incelediğinde kesin bir kaynağa ulaşmıştır. Lorm Ipsum, Çiçero tarafından M.Ö. 45 tarihinde kaleme alınan de Finibus Bonorum et Malorum (İyi ve Kötünün Uç Sınırları) eserinin 1.10.32 ve 1.10.33 sayılı bölümlerinden gelmektedir. Bu kitap, ahlak kuramı üzerine bir tezdir ve Rönesans döneminde çok popüler olmuştur. Lorem Ipsum pasajının ilk satırı olan Lorem ipsum dolor sit amet 1.10.32 sayılı bölümdeki bir satırdan gelmektedir.", "Initial Create", new DateTime(2021, 11, 13, 14, 46, 26, 212, DateTimeKind.Local).AddTicks(7323), new DateTime(2021, 11, 13, 14, 46, 26, 212, DateTimeKind.Local).AddTicks(7321), true, false, "Initial Create", new DateTime(2021, 11, 13, 14, 46, 26, 212, DateTimeKind.Local).AddTicks(7324), "Cisco, AR destekli toplantı çözümü Webex Hologram'ı tanıttı", "Oğuzhan Akpınar", "Cisco, AR destekli toplantı çözümü Webex Hologram'ı tanıttı", "Cisco AR Hologram", "postImages/defaultThumbnail.png", "Cisco, AR destekli toplantı çözümü Webex Hologram'ı tanıttı", 1, 222 }
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
                    { 1, "InitialCreate", new DateTime(2021, 11, 13, 14, 46, 26, 218, DateTimeKind.Local).AddTicks(7553), true, false, "InitialCreate", new DateTime(2021, 11, 13, 14, 46, 26, 218, DateTimeKind.Local).AddTicks(7564), "Yorum 1", 1, "Lorem Ipsum pasajlarının birçok çeşitlemesi vardır. Ancak bunların büyük bir çoğunluğu mizah katılarak veya rastgele sözcükler eklenerek değiştirilmişlerdir. Eğer bir Lorem Ipsum pasajı kullanacaksanız, metin aralarına utandırıcı sözcükler gizlenmediğinden emin olmanız gerekir. İnternet'teki tüm Lorem Ipsum üreteçleri önceden belirlenmiş metin bloklarını yineler. Bu da, bu üreteci İnternet üzerindeki gerçek Lorem Ipsum üreteci yapar. Bu üreteç, 200'den fazla Latince sözcük ve onlara ait cümle yapılarını içeren bir sözlük kullanır. Bu nedenle, üretilen Lorem Ipsum metinleri yinelemelerden, mizahtan ve karakteristik olmayan sözcüklerden uzaktır." },
                    { 2, "InitialCreate", new DateTime(2021, 11, 13, 14, 46, 26, 218, DateTimeKind.Local).AddTicks(7577), true, false, "InitialCreate", new DateTime(2021, 11, 13, 14, 46, 26, 218, DateTimeKind.Local).AddTicks(7578), "Yorum 2", 2, "Lorem Ipsum jest tekstem stosowanym jako przykładowy wypełniacz w przemyśle poligraficznym. Został po raz pierwszy użyty w XV w. przez nieznanego drukarza do wypełnienia tekstem próbnej książki. Pięć wieków później zaczął być używany przemyśle elektronicznym, pozostając praktycznie niezmienionym. Spopularyzował się w latach 60. XX w. wraz z publikacją arkuszy Letrasetu, zawierających fragmenty Lorem Ipsum, a ostatnio z zawierającym różne wersje Lorem Ipsum oprogramowaniem przeznaczonym do realizacji druków na komputerach osobistych, jak Aldus PageMaker" },
                    { 3, "InitialCreate", new DateTime(2021, 11, 13, 14, 46, 26, 218, DateTimeKind.Local).AddTicks(7583), true, false, "InitialCreate", new DateTime(2021, 11, 13, 14, 46, 26, 218, DateTimeKind.Local).AddTicks(7584), "Yorum 3", 3, "Ang Lorem Ipsum ay ginagamit na modelo ng industriya ng pagpriprint at pagtytypeset. Ang Lorem Ipsum ang naging regular na modelo simula pa noong 1500s, noong may isang di kilalang manlilimbag and kumuha ng galley ng type at ginulo ang pagkaka-ayos nito upang makagawa ng libro ng mga type specimen. Nalagpasan nito hindi lang limang siglo, kundi nalagpasan din nito ang paglaganap ng electronic typesetting at nanatiling parehas. Sumikat ito noong 1960s kasabay ng pag labas ng Letraset sheets na mayroong mga talata ng Lorem Ipsum, at kamakailan lang sa mga desktop publishing software tulad ng Aldus Pagemaker ginamit ang mga bersyon ng Lorem Ipsum." },
                    { 4, "InitialCreate", new DateTime(2021, 11, 13, 14, 46, 26, 218, DateTimeKind.Local).AddTicks(7588), true, false, "InitialCreate", new DateTime(2021, 11, 13, 14, 46, 26, 218, DateTimeKind.Local).AddTicks(7590), "Yorum 4", 4, "Lorem Ipsum er rett og slett dummytekst fra og for trykkeindustrien. Lorem Ipsum har vært bransjens standard for dummytekst helt siden 1500-tallet, da en ukjent boktrykker stokket en mengde bokstaver for å lage et prøveeksemplar av en bok. Lorem Ipsum har tålt tidens tann usedvanlig godt, og har i tillegg til å bestå gjennom fem århundrer også tålt spranget over til elektronisk typografi uten vesentlige endringer. Lorem Ipsum ble gjort allment kjent i 1960-årene ved lanseringen av Letraset-ark med avsnitt fra Lorem Ipsum, og senere med sideombrekkingsprogrammet Aldus PageMaker som tok i bruk nettopp Lorem Ipsum for dummytekst." },
                    { 5, "InitialCreate", new DateTime(2021, 11, 13, 14, 46, 26, 218, DateTimeKind.Local).AddTicks(7594), true, false, "InitialCreate", new DateTime(2021, 11, 13, 14, 46, 26, 218, DateTimeKind.Local).AddTicks(7595), "Yorum 5", 5, "Lorem Ipsum este pur şi simplu o machetă pentru text a industriei tipografice. Lorem Ipsum a fost macheta standard a industriei încă din secolul al XVI-lea, când un tipograf anonim a luat o planşetă de litere şi le-a amestecat pentru a crea o carte demonstrativă pentru literele respective. Nu doar că a supravieţuit timp de cinci secole, dar şi a facut saltul în tipografia electronică practic neschimbată. A fost popularizată în anii '60 odată cu ieşirea colilor Letraset care conţineau pasaje Lorem Ipsum, iar mai recent, prin programele de publicare pentru calculator, ca Aldus PageMaker care includeau versiuni de Lorem Ipsum." },
                    { 6, "InitialCreate", new DateTime(2021, 11, 13, 14, 46, 26, 218, DateTimeKind.Local).AddTicks(7645), true, false, "InitialCreate", new DateTime(2021, 11, 13, 14, 46, 26, 218, DateTimeKind.Local).AddTicks(7646), "Yorum 6", 6, "Lorem Ipsum je jednostavno probni tekst koji se koristi u tiskarskoj i slovoslagarskoj industriji. Lorem Ipsum postoji kao industrijski standard još od 16-og stoljeća, kada je nepoznati tiskar uzeo tiskarsku galiju slova i posložio ih da bi napravio knjigu s uzorkom tiska. Taj je tekst ne samo preživio pet stoljeća, već se i vinuo u svijet elektronskog slovoslagarstva, ostajući u suštini nepromijenjen. Postao je popularan tijekom 1960-ih s pojavom Letraset listova s odlomcima Lorem Ipsum-a, a u skorije vrijeme sa software-om za stolno izdavaštvo kao što je Aldus PageMaker koji također sadrži varijante Lorem Ipsum-a." },
                    { 7, "InitialCreate", new DateTime(2021, 11, 13, 14, 46, 26, 218, DateTimeKind.Local).AddTicks(7650), true, false, "InitialCreate", new DateTime(2021, 11, 13, 14, 46, 26, 218, DateTimeKind.Local).AddTicks(7652), "Yorum 7", 7, "Lorem Ipsum – tas ir teksta salikums, kuru izmanto poligrāfijā un maketēšanas darbos. Lorem Ipsum ir kļuvis par vispārpieņemtu teksta aizvietotāju kopš 16. gadsimta sākuma. Tajā laikā kāds nezināms iespiedējs izveidoja teksta fragmentu, lai nodrukātu grāmatu ar burtu paraugiem. Tas ir ne tikai pārdzīvojis piecus gadsimtus, bet bez ievērojamām izmaiņām saglabājies arī mūsdienās, pārejot uz datorizētu teksta apstrādi. Tā popularizēšanai 60-tajos gados kalpoja Letraset burtu paraugu publicēšana ar Lorem Ipsum teksta fragmentiem un, nesenā pagātnē, tādas maketēšanas programmas kā Aldus PageMaker, kuras šablonu paraugos ir izmantots Lorem Ipsum teksts." },
                    { 8, "InitialCreate", new DateTime(2021, 11, 13, 14, 46, 26, 218, DateTimeKind.Local).AddTicks(7656), true, false, "InitialCreate", new DateTime(2021, 11, 13, 14, 46, 26, 218, DateTimeKind.Local).AddTicks(7657), "Yorum 8", 8, "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like)." },
                    { 9, "InitialCreate", new DateTime(2021, 11, 13, 14, 46, 26, 218, DateTimeKind.Local).AddTicks(7661), true, false, "InitialCreate", new DateTime(2021, 11, 13, 14, 46, 26, 218, DateTimeKind.Local).AddTicks(7663), "Yorum 9", 9, "هنالك العديد من الأنواع المتوفرة لنصوص لوريم إيبسوم، ولكن الغالبية تم تعديلها بشكل ما عبر إدخال بعض النوادر أو الكلمات العشوائية إلى النص. إن كنت تريد أن تستخدم نص لوريم إيبسوم ما، عليك أن تتحقق أولاً أن ليس هناك أي كلمات أو عبارات محرجة أو غير لائقة مخبأة في هذا النص. بينما تعمل جميع مولّدات نصوص لوريم إيبسوم على الإنترنت على إعادة تكرار مقاطع من نص لوريم إيبسوم نفسه عدة مرات بما تتطلبه الحاجة، يقوم مولّدنا هذا باستخدام كلمات من قاموس يحوي على أكثر من 200 كلمة لا تينية، مضاف إليها مجموعة من الجمل النموذجية، لتكوين نص لوريم إيبسوم ذو شكل منطقي قريب إلى النص الحقيقي. وبالتالي يكون النص الناتح خالي من التكرار، أو أي كلمات أو عبارات غير لائقة أو ما شابه. وهذا ما يجعله أول مولّد نص لوريم إيبسوم حقيقي على الإنترنت." },
                    { 10, "InitialCreate", new DateTime(2021, 11, 13, 14, 46, 26, 218, DateTimeKind.Local).AddTicks(7668), true, false, "InitialCreate", new DateTime(2021, 11, 13, 14, 46, 26, 218, DateTimeKind.Local).AddTicks(7669), "Yorum 10", 10, "Lorem Ipsum，也称乱数假文或者哑元文本， 是印刷及排版领域所常用的虚拟文字。由于曾经一台匿名的打印机刻意打乱了一盒印刷字体从而造出一本字体样品书，Lorem Ipsum从西元15世纪起就被作为此领域的标准文本使用。它不仅延续了五个世纪，还通过了电子排版的挑战，其雏形却依然保存至今。在1960年代，”Leatraset”公司发布了印刷着Lorem Ipsum段落的纸张，从而广泛普及了它的使用。最近，计算机桌面出版软件”Aldus PageMaker”也通过同样的方式使Lorem Ipsum落入大众的视野。" }
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
                name: "Logs");

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
