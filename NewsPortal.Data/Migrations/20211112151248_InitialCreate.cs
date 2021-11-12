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
                    { 1, "InitialCreate", new DateTime(2021, 11, 12, 18, 12, 47, 546, DateTimeKind.Local).AddTicks(3375), "Ekonomi Haberleri", true, false, "InitialCreate", new DateTime(2021, 11, 12, 18, 12, 47, 546, DateTimeKind.Local).AddTicks(3387), "Ekonomi", "Ekonomi Kategorisi" },
                    { 2, "InitialCreate", new DateTime(2021, 11, 12, 18, 12, 47, 546, DateTimeKind.Local).AddTicks(3402), "Sağlık Haberleri", true, false, "InitialCreate", new DateTime(2021, 11, 12, 18, 12, 47, 546, DateTimeKind.Local).AddTicks(3404), "Sağlık", "Sağlık Kategorisi" },
                    { 3, "InitialCreate", new DateTime(2021, 11, 12, 18, 12, 47, 546, DateTimeKind.Local).AddTicks(3408), "Dünya Haberleri", true, false, "InitialCreate", new DateTime(2021, 11, 12, 18, 12, 47, 546, DateTimeKind.Local).AddTicks(3409), "Dünya", "Dünya Kategorisi" },
                    { 4, "InitialCreate", new DateTime(2021, 11, 12, 18, 12, 47, 546, DateTimeKind.Local).AddTicks(3415), "Gündem Haberleri", true, false, "InitialCreate", new DateTime(2021, 11, 12, 18, 12, 47, 546, DateTimeKind.Local).AddTicks(3416), "Gündem", "Gündem Kategorisi" },
                    { 5, "InitialCreate", new DateTime(2021, 11, 12, 18, 12, 47, 546, DateTimeKind.Local).AddTicks(3421), "Teknoloji Haberleri", true, false, "InitialCreate", new DateTime(2021, 11, 12, 18, 12, 47, 546, DateTimeKind.Local).AddTicks(3422), "Teknoloji", "Teknoloji Kategorisi" },
                    { 6, "InitialCreate", new DateTime(2021, 11, 12, 18, 12, 47, 546, DateTimeKind.Local).AddTicks(3426), "Magazin Haberleri", true, false, "InitialCreate", new DateTime(2021, 11, 12, 18, 12, 47, 546, DateTimeKind.Local).AddTicks(3427), "Magazin", "Magazin Kategorisi" },
                    { 7, "InitialCreate", new DateTime(2021, 11, 12, 18, 12, 47, 546, DateTimeKind.Local).AddTicks(3432), "Futbol Haberleri", true, false, "InitialCreate", new DateTime(2021, 11, 12, 18, 12, 47, 546, DateTimeKind.Local).AddTicks(3433), "Futbol", "Futbol Kategorisi" },
                    { 8, "InitialCreate", new DateTime(2021, 11, 12, 18, 12, 47, 546, DateTimeKind.Local).AddTicks(3438), "Basketbol Haberleri", true, false, "InitialCreate", new DateTime(2021, 11, 12, 18, 12, 47, 546, DateTimeKind.Local).AddTicks(3440), "Basketbol", "Basketbol Kategorisi" },
                    { 9, "InitialCreate", new DateTime(2021, 11, 12, 18, 12, 47, 546, DateTimeKind.Local).AddTicks(3444), "Formula 1 Haberleri", true, false, "InitialCreate", new DateTime(2021, 11, 12, 18, 12, 47, 546, DateTimeKind.Local).AddTicks(3445), "Formula 1", "Formula 1 Kategorisi" },
                    { 10, "InitialCreate", new DateTime(2021, 11, 12, 18, 12, 47, 546, DateTimeKind.Local).AddTicks(3449), "Espor Haberleri", true, false, "InitialCreate", new DateTime(2021, 11, 12, 18, 12, 47, 546, DateTimeKind.Local).AddTicks(3450), "Espor", "Espor Kategorisi" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 15, "04cebf3a-4550-4c12-8863-65299279ab8c", "Role.Update", "ROLE.UPDATE" },
                    { 16, "db7f964f-81f1-42f3-9837-2ee3bbe77d59", "Role.Delete", "ROLE.DELETE" },
                    { 17, "a55da65c-78c7-43de-8a9d-6d3f21925bfc", "Comment.Create", "COMMENT.CREATE" },
                    { 18, "7a27495a-cba7-4dc5-a5e7-c9e348860d5a", "Comment.Read", "COMMENT.READ" },
                    { 23, "90ec2b04-12f7-4f40-8b12-640d7a32207c", "Normal", "NORMAL" },
                    { 20, "a08a2705-e584-4afc-a9b7-35c3fa89ecae", "Comment.Delete", "COMMENT.DELETE" },
                    { 21, "f9c991a9-c8fd-4958-9179-097ecba9f30d", "AdminArea.Home.Read", "ADMINAREA.HOME.READ" },
                    { 22, "c2cc7914-8bea-42be-91b8-8e2a77365747", "SuperAdmin", "SUPERADMIN" },
                    { 14, "85033c3c-375a-4ee8-8ba7-d2af3c435db6", "Role.Read", "ROLE.READ" },
                    { 19, "1f34f668-4adf-4db3-8219-95be02e79e9e", "Comment.Update", "COMMENT.UPDATE" },
                    { 13, "bff8140c-e1bf-4384-9b0a-28d09a57fffe", "Role.Create", "ROLE.CREATE" },
                    { 8, "3d4502a5-c9c1-4a36-832c-1a225ded3dd4", "Report.Delete", "REPORT.DELETE" },
                    { 11, "2330ae2e-ba81-4ac1-b0ec-c736a39a9f1b", "User.Update", "USER.UPDATE" },
                    { 10, "6f8145ee-7151-4f07-9734-79dbbf322bf4", "User.Read", "USER.READ" },
                    { 9, "3cff742d-e5c4-44d4-a0d5-4e330a5828f9", "User.Create", "USER.CREATE" },
                    { 7, "a2907867-4325-4640-aede-d5e0f704f8c0", "Report.Update", "REPORT.UPDATE" },
                    { 6, "fc08065c-29b2-4263-a841-483599528fdd", "Report.Read", "REPORT.READ" },
                    { 5, "2c82b46c-8184-4abc-99a5-712ad8416e58", "Report.Create", "REPORT.CREATE" },
                    { 4, "a23754a3-fab4-4ca8-a4e1-2e4ae9a03d67", "Category.Delete", "CATEGORY.DELETE" },
                    { 3, "8ea15a8f-abc7-474f-9911-263db3244d89", "Category.Update", "CATEGORY.UPDATE" },
                    { 2, "fdc26238-86fd-4356-acd3-22520123e26b", "Category.Read", "CATEGORY.READ" },
                    { 1, "22a253b5-62fc-4b7d-bb61-42c8a405df03", "Category.Create", "CATEGORY.CREATE" },
                    { 12, "e7ed4731-9a7b-4fc0-b8eb-5c34c5abf57c", "User.Delete", "USER.DELETE" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "About", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FacebookLink", "FirstName", "GitHubLink", "InstagramLink", "LastName", "LinkedInLink", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Picture", "SecurityStamp", "TwitterLink", "TwoFactorEnabled", "UserName", "WebsiteLink", "YoutubeLink" },
                values: new object[,]
                {
                    { 1, "Admin User of NewsPortal", 0, "59884b85-9544-45d6-b1ae-09f5f03772d1", "adminuser@gmail.com", true, "https://facebook.com/adminuser", "Admin", "https://github.com/adminuser", "https://instagram.com/adminuser", "User", "https://linkedin.com/adminuser", false, null, "ADMINUSER@GMAIL.COM", "ADMINUSER", "AQAAAAEAACcQAAAAEOgTeFS7prfFO6Gq0rkqSJeepaQcLr5R5w85PuixlRDAPlUr26p4TnzSFQc+0CxR1w==", "+905555555555", true, "/userImages/defaultUser.png", "ba2e6233-4cb2-4513-8c15-ca998b3bd3b1", "https://twitter.com/adminuser", false, "adminuser", "https://newsportal.com/", "https://youtube.com/adminuser" },
                    { 2, "Editor User of NewsPortal", 0, "44b6d591-3891-454e-b962-2f7a66034c07", "editoruser@gmail.com", true, "https://facebook.com/editoruser", "Admin", "https://github.com/editoruser", "https://instagram.com/editoruser", "User", "https://linkedin.com/editoruser", false, null, "EDITORUSER@GMAIL.COM", "EDITORUSER", "AQAAAAEAACcQAAAAEHrC2iYx/YYYwbZNix61TyYVwNkArZLRY+5orD/ypnp/Il+T6X0ngpUdF2lWftdCFg==", "+905555555555", true, "/userImages/defaultUser.png", "4e833e9d-f621-44c9-869b-15a573391b01", "https://twitter.com/editoruser", false, "editoruser", "https://newsportal.com/", "https://youtube.com/editoruser" }
                });

            migrationBuilder.InsertData(
                table: "Reports",
                columns: new[] { "Id", "CategoryId", "CommentCount", "Content", "CreatedByName", "CreatedDate", "Date", "IsActive", "IsDeleted", "ModifiedByName", "ModifiedDate", "Note", "SeoAuthor", "SeoDescription", "SeoTags", "Thumbnail", "Title", "UserId", "ViewsCount" },
                values: new object[,]
                {
                    { 1, 1, 1, "Lorem Ipsum, dizgi ve baskı endüstrisinde kullanılan mıgır metinlerdir. Lorem Ipsum, adı bilinmeyen bir matbaacının bir hurufat numune kitabı oluşturmak üzere bir yazı galerisini alarak karıştırdığı 1500'lerden beri endüstri standardı sahte metinler olarak kullanılmıştır. Beşyüz yıl boyunca varlığını sürdürmekle kalmamış, aynı zamanda pek değişmeden elektronik dizgiye de sıçramıştır. 1960'larda Lorem Ipsum pasajları da içeren Letraset yapraklarının yayınlanması ile ve yakın zamanda Aldus PageMaker gibi Lorem Ipsum sürümleri içeren masaüstü yayıncılık yazılımları ile popüler olmuştur.", "Initial Create", new DateTime(2021, 11, 12, 18, 12, 47, 542, DateTimeKind.Local).AddTicks(1385), new DateTime(2021, 11, 12, 18, 12, 47, 542, DateTimeKind.Local).AddTicks(379), true, false, "Initial Create", new DateTime(2021, 11, 12, 18, 12, 47, 542, DateTimeKind.Local).AddTicks(1912), "SHIBA INU'ya zirveden giren yüzde 45 kaybetti", "Oğuzhan Akpınar", "SHIBA INU'ya zirveden giren yüzde 45 kaybetti", "SHIBA INU", "postImages/defaultThumbnail.png", "SHIBA INU'ya zirveden giren yüzde 45 kaybetti", 1, 100 },
                    { 10, 10, 1, "Yaygın inancın tersine, Lorem Ipsum rastgele sözcüklerden oluşmaz. Kökleri M.Ö. 45 tarihinden bu yana klasik Latin edebiyatına kadar uzanan 2000 yıllık bir geçmişi vardır. Virginia'daki Hampden-Sydney College'dan Latince profesörü Richard McClintock, bir Lorem Ipsum pasajında geçen ve anlaşılması en güç sözcüklerden biri olan 'consectetur' sözcüğünün klasik edebiyattaki örneklerini incelediğinde kesin bir kaynağa ulaşmıştır. Lorm Ipsum, Çiçero tarafından M.Ö. 45 tarihinde kaleme alınan de Finibus Bonorum et Malorum (İyi ve Kötünün Uç Sınırları) eserinin 1.10.32 ve 1.10.33 sayılı bölümlerinden gelmektedir. Bu kitap, ahlak kuramı üzerine bir tezdir ve Rönesans döneminde çok popüler olmuştur. Lorem Ipsum pasajının ilk satırı olan Lorem ipsum dolor sit amet 1.10.32 sayılı bölümdeki bir satırdan gelmektedir.", "Initial Create", new DateTime(2021, 11, 12, 18, 12, 47, 542, DateTimeKind.Local).AddTicks(3295), new DateTime(2021, 11, 12, 18, 12, 47, 542, DateTimeKind.Local).AddTicks(3294), true, false, "Initial Create", new DateTime(2021, 11, 12, 18, 12, 47, 542, DateTimeKind.Local).AddTicks(3297), "Dota 2 The International 2021 Şampiyonu Team Spirit Oldu!", "Oğuzhan Akpınar", "Dota 2 The International 2021 Şampiyonu Team Spirit Oldu!", "Dota International Spirit", "postImages/defaultThumbnail.png", "Dota 2 The International 2021 Şampiyonu Team Spirit Oldu!", 1, 50 },
                    { 8, 8, 1, "Yaygın inancın tersine, Lorem Ipsum rastgele sözcüklerden oluşmaz. Kökleri M.Ö. 45 tarihinden bu yana klasik Latin edebiyatına kadar uzanan 2000 yıllık bir geçmişi vardır. Virginia'daki Hampden-Sydney College'dan Latince profesörü Richard McClintock, bir Lorem Ipsum pasajında geçen ve anlaşılması en güç sözcüklerden biri olan 'consectetur' sözcüğünün klasik edebiyattaki örneklerini incelediğinde kesin bir kaynağa ulaşmıştır. Lorm Ipsum, Çiçero tarafından M.Ö. 45 tarihinde kaleme alınan de Finibus Bonorum et Malorum (İyi ve Kötünün Uç Sınırları) eserinin 1.10.32 ve 1.10.33 sayılı bölümlerinden gelmektedir. Bu kitap, ahlak kuramı üzerine bir tezdir ve Rönesans döneminde çok popüler olmuştur. Lorem Ipsum pasajının ilk satırı olan Lorem ipsum dolor sit amet 1.10.32 sayılı bölümdeki bir satırdan gelmektedir.", "Initial Create", new DateTime(2021, 11, 12, 18, 12, 47, 542, DateTimeKind.Local).AddTicks(3282), new DateTime(2021, 11, 12, 18, 12, 47, 542, DateTimeKind.Local).AddTicks(3281), true, false, "Initial Create", new DateTime(2021, 11, 12, 18, 12, 47, 542, DateTimeKind.Local).AddTicks(3284), "Anadolu Efes: 85 - Galatasaray Nef: 92", "Oğuzhan Akpınar", "Anadolu Efes: 85 - Galatasaray Nef: 92", "GS Efes Basketbol", "postImages/defaultThumbnail.png", "Anadolu Efes: 85 - Galatasaray Nef: 92", 1, 200 },
                    { 7, 7, 2, "Yaygın inancın tersine, Lorem Ipsum rastgele sözcüklerden oluşmaz. Kökleri M.Ö. 45 tarihinden bu yana klasik Latin edebiyatına kadar uzanan 2000 yıllık bir geçmişi vardır. Virginia'daki Hampden-Sydney College'dan Latince profesörü Richard McClintock, bir Lorem Ipsum pasajında geçen ve anlaşılması en güç sözcüklerden biri olan 'consectetur' sözcüğünün klasik edebiyattaki örneklerini incelediğinde kesin bir kaynağa ulaşmıştır. Lorm Ipsum, Çiçero tarafından M.Ö. 45 tarihinde kaleme alınan de Finibus Bonorum et Malorum (İyi ve Kötünün Uç Sınırları) eserinin 1.10.32 ve 1.10.33 sayılı bölümlerinden gelmektedir. Bu kitap, ahlak kuramı üzerine bir tezdir ve Rönesans döneminde çok popüler olmuştur. Lorem Ipsum pasajının ilk satırı olan Lorem ipsum dolor sit amet 1.10.32 sayılı bölümdeki bir satırdan gelmektedir.", "Initial Create", new DateTime(2021, 11, 12, 18, 12, 47, 542, DateTimeKind.Local).AddTicks(3276), new DateTime(2021, 11, 12, 18, 12, 47, 542, DateTimeKind.Local).AddTicks(3274), true, false, "Initial Create", new DateTime(2021, 11, 12, 18, 12, 47, 542, DateTimeKind.Local).AddTicks(3277), "Galatasaray: 1 - Lokomotiv Moskova: 1", "Oğuzhan Akpınar", "Galatasaray: 1 - Lokomotiv Moskova: 1", "GS LM Uefa", "postImages/defaultThumbnail.png", "Galatasaray: 1 - Lokomotiv Moskova: 1", 1, 255 },
                    { 6, 6, 2, "Yaygın inancın tersine, Lorem Ipsum rastgele sözcüklerden oluşmaz. Kökleri M.Ö. 45 tarihinden bu yana klasik Latin edebiyatına kadar uzanan 2000 yıllık bir geçmişi vardır. Virginia'daki Hampden-Sydney College'dan Latince profesörü Richard McClintock, bir Lorem Ipsum pasajında geçen ve anlaşılması en güç sözcüklerden biri olan 'consectetur' sözcüğünün klasik edebiyattaki örneklerini incelediğinde kesin bir kaynağa ulaşmıştır. Lorm Ipsum, Çiçero tarafından M.Ö. 45 tarihinde kaleme alınan de Finibus Bonorum et Malorum (İyi ve Kötünün Uç Sınırları) eserinin 1.10.32 ve 1.10.33 sayılı bölümlerinden gelmektedir. Bu kitap, ahlak kuramı üzerine bir tezdir ve Rönesans döneminde çok popüler olmuştur. Lorem Ipsum pasajının ilk satırı olan Lorem ipsum dolor sit amet 1.10.32 sayılı bölümdeki bir satırdan gelmektedir.", "Initial Create", new DateTime(2021, 11, 12, 18, 12, 47, 542, DateTimeKind.Local).AddTicks(3269), new DateTime(2021, 11, 12, 18, 12, 47, 542, DateTimeKind.Local).AddTicks(3267), true, false, "Initial Create", new DateTime(2021, 11, 12, 18, 12, 47, 542, DateTimeKind.Local).AddTicks(3270), "Saçma Magazin Haberi", "Oğuzhan Akpınar", "Saçma Magazin Haberi", "Magazin Saçma Haber", "postImages/defaultThumbnail.png", "Saçma Magazin Haberi", 1, 15 },
                    { 9, 9, 1, "Yaygın inancın tersine, Lorem Ipsum rastgele sözcüklerden oluşmaz. Kökleri M.Ö. 45 tarihinden bu yana klasik Latin edebiyatına kadar uzanan 2000 yıllık bir geçmişi vardır. Virginia'daki Hampden-Sydney College'dan Latince profesörü Richard McClintock, bir Lorem Ipsum pasajında geçen ve anlaşılması en güç sözcüklerden biri olan 'consectetur' sözcüğünün klasik edebiyattaki örneklerini incelediğinde kesin bir kaynağa ulaşmıştır. Lorm Ipsum, Çiçero tarafından M.Ö. 45 tarihinde kaleme alınan de Finibus Bonorum et Malorum (İyi ve Kötünün Uç Sınırları) eserinin 1.10.32 ve 1.10.33 sayılı bölümlerinden gelmektedir. Bu kitap, ahlak kuramı üzerine bir tezdir ve Rönesans döneminde çok popüler olmuştur. Lorem Ipsum pasajının ilk satırı olan Lorem ipsum dolor sit amet 1.10.32 sayılı bölümdeki bir satırdan gelmektedir.", "Initial Create", new DateTime(2021, 11, 12, 18, 12, 47, 542, DateTimeKind.Local).AddTicks(3289), new DateTime(2021, 11, 12, 18, 12, 47, 542, DateTimeKind.Local).AddTicks(3288), true, false, "Initial Create", new DateTime(2021, 11, 12, 18, 12, 47, 542, DateTimeKind.Local).AddTicks(3290), "Mercedes'in Hamilton'ın motor cezası alma ihtimaliyle ilgili endişeleri azaldı", "Oğuzhan Akpınar", "Mercedes'in Hamilton'ın motor cezası alma ihtimaliyle ilgili endişeleri azaldı", "F1 Mercedes", "postImages/defaultThumbnail.png", "Mercedes'in Hamilton'ın motor cezası alma ihtimaliyle ilgili endişeleri azaldı", 1, 100 },
                    { 4, 4, 1, "Yaygın inancın tersine, Lorem Ipsum rastgele sözcüklerden oluşmaz. Kökleri M.Ö. 45 tarihinden bu yana klasik Latin edebiyatına kadar uzanan 2000 yıllık bir geçmişi vardır. Virginia'daki Hampden-Sydney College'dan Latince profesörü Richard McClintock, bir Lorem Ipsum pasajında geçen ve anlaşılması en güç sözcüklerden biri olan 'consectetur' sözcüğünün klasik edebiyattaki örneklerini incelediğinde kesin bir kaynağa ulaşmıştır. Lorm Ipsum, Çiçero tarafından M.Ö. 45 tarihinde kaleme alınan de Finibus Bonorum et Malorum (İyi ve Kötünün Uç Sınırları) eserinin 1.10.32 ve 1.10.33 sayılı bölümlerinden gelmektedir. Bu kitap, ahlak kuramı üzerine bir tezdir ve Rönesans döneminde çok popüler olmuştur. Lorem Ipsum pasajının ilk satırı olan Lorem ipsum dolor sit amet 1.10.32 sayılı bölümdeki bir satırdan gelmektedir.", "Initial Create", new DateTime(2021, 11, 12, 18, 12, 47, 542, DateTimeKind.Local).AddTicks(3255), new DateTime(2021, 11, 12, 18, 12, 47, 542, DateTimeKind.Local).AddTicks(3254), true, false, "Initial Create", new DateTime(2021, 11, 12, 18, 12, 47, 542, DateTimeKind.Local).AddTicks(3257), "50 yıl sonra görüldü! O balık İzmit Körfezi'nde!", "Oğuzhan Akpınar", "50 yıl sonra görüldü! O balık İzmit Körfezi'nde!", "Balık İzmit Körfez", "postImages/defaultThumbnail.png", "50 yıl sonra görüldü! O balık İzmit Körfezi'nde!", 1, 100 },
                    { 3, 3, 1, "Yaygın inancın tersine, Lorem Ipsum rastgele sözcüklerden oluşmaz. Kökleri M.Ö. 45 tarihinden bu yana klasik Latin edebiyatına kadar uzanan 2000 yıllık bir geçmişi vardır. Virginia'daki Hampden-Sydney College'dan Latince profesörü Richard McClintock, bir Lorem Ipsum pasajında geçen ve anlaşılması en güç sözcüklerden biri olan 'consectetur' sözcüğünün klasik edebiyattaki örneklerini incelediğinde kesin bir kaynağa ulaşmıştır. Lorm Ipsum, Çiçero tarafından M.Ö. 45 tarihinde kaleme alınan de Finibus Bonorum et Malorum (İyi ve Kötünün Uç Sınırları) eserinin 1.10.32 ve 1.10.33 sayılı bölümlerinden gelmektedir. Bu kitap, ahlak kuramı üzerine bir tezdir ve Rönesans döneminde çok popüler olmuştur. Lorem Ipsum pasajının ilk satırı olan Lorem ipsum dolor sit amet 1.10.32 sayılı bölümdeki bir satırdan gelmektedir.", "Initial Create", new DateTime(2021, 11, 12, 18, 12, 47, 542, DateTimeKind.Local).AddTicks(3249), new DateTime(2021, 11, 12, 18, 12, 47, 542, DateTimeKind.Local).AddTicks(3247), true, false, "Initial Create", new DateTime(2021, 11, 12, 18, 12, 47, 542, DateTimeKind.Local).AddTicks(3250), "İran'dan şoke eden itiraf! \"Petrolü kaçak satıyoruz!\"", "Oğuzhan Akpınar", "İran'dan şoke eden itiraf! \"Petrolü kaçak satıyoruz!\"", "İran Kaçak Petrol", "postImages/defaultThumbnail.png", "İran'dan şoke eden itiraf! \"Petrolü kaçak satıyoruz!\"", 1, 120 },
                    { 2, 2, 1, "Yinelenen bir sayfa içeriğinin okuyucunun dikkatini dağıttığı bilinen bir gerçektir. Lorem Ipsum kullanmanın amacı, sürekli 'buraya metin gelecek, buraya metin gelecek' yazmaya kıyasla daha dengeli bir harf dağılımı sağlayarak okunurluğu artırmasıdır. Şu anda birçok masaüstü yayıncılık paketi ve web sayfa düzenleyicisi, varsayılan mıgır metinler olarak Lorem Ipsum kullanmaktadır. Ayrıca arama motorlarında 'lorem ipsum' anahtar sözcükleri ile arama yapıldığında henüz tasarım aşamasında olan çok sayıda site listelenir. Yıllar içinde, bazen kazara, bazen bilinçli olarak (örneğin mizah katılarak), çeşitli sürümleri geliştirilmiştir.", "Initial Create", new DateTime(2021, 11, 12, 18, 12, 47, 542, DateTimeKind.Local).AddTicks(3239), new DateTime(2021, 11, 12, 18, 12, 47, 542, DateTimeKind.Local).AddTicks(3238), true, false, "Initial Create", new DateTime(2021, 11, 12, 18, 12, 47, 542, DateTimeKind.Local).AddTicks(3241), "Kalp krizini hangisi daha fazla tetikliyor? Hamburger mi yoksa stres mi?", "Oğuzhan Akpınar", "Kalp krizini hangisi daha fazla tetikliyor? Hamburger mi yoksa stres mi?", "Kalp Krizi Stres Hamburger", "postImages/defaultThumbnail.png", "Kalp krizini hangisi daha fazla tetikliyor? Hamburger mi yoksa stres mi?", 1, 295 },
                    { 5, 5, 2, "Yaygın inancın tersine, Lorem Ipsum rastgele sözcüklerden oluşmaz. Kökleri M.Ö. 45 tarihinden bu yana klasik Latin edebiyatına kadar uzanan 2000 yıllık bir geçmişi vardır. Virginia'daki Hampden-Sydney College'dan Latince profesörü Richard McClintock, bir Lorem Ipsum pasajında geçen ve anlaşılması en güç sözcüklerden biri olan 'consectetur' sözcüğünün klasik edebiyattaki örneklerini incelediğinde kesin bir kaynağa ulaşmıştır. Lorm Ipsum, Çiçero tarafından M.Ö. 45 tarihinde kaleme alınan de Finibus Bonorum et Malorum (İyi ve Kötünün Uç Sınırları) eserinin 1.10.32 ve 1.10.33 sayılı bölümlerinden gelmektedir. Bu kitap, ahlak kuramı üzerine bir tezdir ve Rönesans döneminde çok popüler olmuştur. Lorem Ipsum pasajının ilk satırı olan Lorem ipsum dolor sit amet 1.10.32 sayılı bölümdeki bir satırdan gelmektedir.", "Initial Create", new DateTime(2021, 11, 12, 18, 12, 47, 542, DateTimeKind.Local).AddTicks(3262), new DateTime(2021, 11, 12, 18, 12, 47, 542, DateTimeKind.Local).AddTicks(3261), true, false, "Initial Create", new DateTime(2021, 11, 12, 18, 12, 47, 542, DateTimeKind.Local).AddTicks(3263), "Cisco, AR destekli toplantı çözümü Webex Hologram'ı tanıttı", "Oğuzhan Akpınar", "Cisco, AR destekli toplantı çözümü Webex Hologram'ı tanıttı", "Cisco AR Hologram", "postImages/defaultThumbnail.png", "Cisco, AR destekli toplantı çözümü Webex Hologram'ı tanıttı", 1, 222 }
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
                    { 1, "InitialCreate", new DateTime(2021, 11, 12, 18, 12, 47, 549, DateTimeKind.Local).AddTicks(197), true, false, "InitialCreate", new DateTime(2021, 11, 12, 18, 12, 47, 549, DateTimeKind.Local).AddTicks(212), "Yorum 1", 1, "Lorem Ipsum pasajlarının birçok çeşitlemesi vardır. Ancak bunların büyük bir çoğunluğu mizah katılarak veya rastgele sözcükler eklenerek değiştirilmişlerdir. Eğer bir Lorem Ipsum pasajı kullanacaksanız, metin aralarına utandırıcı sözcükler gizlenmediğinden emin olmanız gerekir. İnternet'teki tüm Lorem Ipsum üreteçleri önceden belirlenmiş metin bloklarını yineler. Bu da, bu üreteci İnternet üzerindeki gerçek Lorem Ipsum üreteci yapar. Bu üreteç, 200'den fazla Latince sözcük ve onlara ait cümle yapılarını içeren bir sözlük kullanır. Bu nedenle, üretilen Lorem Ipsum metinleri yinelemelerden, mizahtan ve karakteristik olmayan sözcüklerden uzaktır." },
                    { 2, "InitialCreate", new DateTime(2021, 11, 12, 18, 12, 47, 549, DateTimeKind.Local).AddTicks(226), true, false, "InitialCreate", new DateTime(2021, 11, 12, 18, 12, 47, 549, DateTimeKind.Local).AddTicks(228), "Yorum 2", 2, "Lorem Ipsum jest tekstem stosowanym jako przykładowy wypełniacz w przemyśle poligraficznym. Został po raz pierwszy użyty w XV w. przez nieznanego drukarza do wypełnienia tekstem próbnej książki. Pięć wieków później zaczął być używany przemyśle elektronicznym, pozostając praktycznie niezmienionym. Spopularyzował się w latach 60. XX w. wraz z publikacją arkuszy Letrasetu, zawierających fragmenty Lorem Ipsum, a ostatnio z zawierającym różne wersje Lorem Ipsum oprogramowaniem przeznaczonym do realizacji druków na komputerach osobistych, jak Aldus PageMaker" },
                    { 3, "InitialCreate", new DateTime(2021, 11, 12, 18, 12, 47, 549, DateTimeKind.Local).AddTicks(232), true, false, "InitialCreate", new DateTime(2021, 11, 12, 18, 12, 47, 549, DateTimeKind.Local).AddTicks(233), "Yorum 3", 3, "Ang Lorem Ipsum ay ginagamit na modelo ng industriya ng pagpriprint at pagtytypeset. Ang Lorem Ipsum ang naging regular na modelo simula pa noong 1500s, noong may isang di kilalang manlilimbag and kumuha ng galley ng type at ginulo ang pagkaka-ayos nito upang makagawa ng libro ng mga type specimen. Nalagpasan nito hindi lang limang siglo, kundi nalagpasan din nito ang paglaganap ng electronic typesetting at nanatiling parehas. Sumikat ito noong 1960s kasabay ng pag labas ng Letraset sheets na mayroong mga talata ng Lorem Ipsum, at kamakailan lang sa mga desktop publishing software tulad ng Aldus Pagemaker ginamit ang mga bersyon ng Lorem Ipsum." },
                    { 4, "InitialCreate", new DateTime(2021, 11, 12, 18, 12, 47, 549, DateTimeKind.Local).AddTicks(237), true, false, "InitialCreate", new DateTime(2021, 11, 12, 18, 12, 47, 549, DateTimeKind.Local).AddTicks(239), "Yorum 4", 4, "Lorem Ipsum er rett og slett dummytekst fra og for trykkeindustrien. Lorem Ipsum har vært bransjens standard for dummytekst helt siden 1500-tallet, da en ukjent boktrykker stokket en mengde bokstaver for å lage et prøveeksemplar av en bok. Lorem Ipsum har tålt tidens tann usedvanlig godt, og har i tillegg til å bestå gjennom fem århundrer også tålt spranget over til elektronisk typografi uten vesentlige endringer. Lorem Ipsum ble gjort allment kjent i 1960-årene ved lanseringen av Letraset-ark med avsnitt fra Lorem Ipsum, og senere med sideombrekkingsprogrammet Aldus PageMaker som tok i bruk nettopp Lorem Ipsum for dummytekst." },
                    { 5, "InitialCreate", new DateTime(2021, 11, 12, 18, 12, 47, 549, DateTimeKind.Local).AddTicks(243), true, false, "InitialCreate", new DateTime(2021, 11, 12, 18, 12, 47, 549, DateTimeKind.Local).AddTicks(244), "Yorum 5", 5, "Lorem Ipsum este pur şi simplu o machetă pentru text a industriei tipografice. Lorem Ipsum a fost macheta standard a industriei încă din secolul al XVI-lea, când un tipograf anonim a luat o planşetă de litere şi le-a amestecat pentru a crea o carte demonstrativă pentru literele respective. Nu doar că a supravieţuit timp de cinci secole, dar şi a facut saltul în tipografia electronică practic neschimbată. A fost popularizată în anii '60 odată cu ieşirea colilor Letraset care conţineau pasaje Lorem Ipsum, iar mai recent, prin programele de publicare pentru calculator, ca Aldus PageMaker care includeau versiuni de Lorem Ipsum." },
                    { 6, "InitialCreate", new DateTime(2021, 11, 12, 18, 12, 47, 549, DateTimeKind.Local).AddTicks(248), true, false, "InitialCreate", new DateTime(2021, 11, 12, 18, 12, 47, 549, DateTimeKind.Local).AddTicks(249), "Yorum 6", 6, "Lorem Ipsum je jednostavno probni tekst koji se koristi u tiskarskoj i slovoslagarskoj industriji. Lorem Ipsum postoji kao industrijski standard još od 16-og stoljeća, kada je nepoznati tiskar uzeo tiskarsku galiju slova i posložio ih da bi napravio knjigu s uzorkom tiska. Taj je tekst ne samo preživio pet stoljeća, već se i vinuo u svijet elektronskog slovoslagarstva, ostajući u suštini nepromijenjen. Postao je popularan tijekom 1960-ih s pojavom Letraset listova s odlomcima Lorem Ipsum-a, a u skorije vrijeme sa software-om za stolno izdavaštvo kao što je Aldus PageMaker koji također sadrži varijante Lorem Ipsum-a." },
                    { 7, "InitialCreate", new DateTime(2021, 11, 12, 18, 12, 47, 549, DateTimeKind.Local).AddTicks(253), true, false, "InitialCreate", new DateTime(2021, 11, 12, 18, 12, 47, 549, DateTimeKind.Local).AddTicks(254), "Yorum 7", 7, "Lorem Ipsum – tas ir teksta salikums, kuru izmanto poligrāfijā un maketēšanas darbos. Lorem Ipsum ir kļuvis par vispārpieņemtu teksta aizvietotāju kopš 16. gadsimta sākuma. Tajā laikā kāds nezināms iespiedējs izveidoja teksta fragmentu, lai nodrukātu grāmatu ar burtu paraugiem. Tas ir ne tikai pārdzīvojis piecus gadsimtus, bet bez ievērojamām izmaiņām saglabājies arī mūsdienās, pārejot uz datorizētu teksta apstrādi. Tā popularizēšanai 60-tajos gados kalpoja Letraset burtu paraugu publicēšana ar Lorem Ipsum teksta fragmentiem un, nesenā pagātnē, tādas maketēšanas programmas kā Aldus PageMaker, kuras šablonu paraugos ir izmantots Lorem Ipsum teksts." },
                    { 8, "InitialCreate", new DateTime(2021, 11, 12, 18, 12, 47, 549, DateTimeKind.Local).AddTicks(258), true, false, "InitialCreate", new DateTime(2021, 11, 12, 18, 12, 47, 549, DateTimeKind.Local).AddTicks(259), "Yorum 8", 8, "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like)." },
                    { 9, "InitialCreate", new DateTime(2021, 11, 12, 18, 12, 47, 549, DateTimeKind.Local).AddTicks(263), true, false, "InitialCreate", new DateTime(2021, 11, 12, 18, 12, 47, 549, DateTimeKind.Local).AddTicks(265), "Yorum 9", 9, "هنالك العديد من الأنواع المتوفرة لنصوص لوريم إيبسوم، ولكن الغالبية تم تعديلها بشكل ما عبر إدخال بعض النوادر أو الكلمات العشوائية إلى النص. إن كنت تريد أن تستخدم نص لوريم إيبسوم ما، عليك أن تتحقق أولاً أن ليس هناك أي كلمات أو عبارات محرجة أو غير لائقة مخبأة في هذا النص. بينما تعمل جميع مولّدات نصوص لوريم إيبسوم على الإنترنت على إعادة تكرار مقاطع من نص لوريم إيبسوم نفسه عدة مرات بما تتطلبه الحاجة، يقوم مولّدنا هذا باستخدام كلمات من قاموس يحوي على أكثر من 200 كلمة لا تينية، مضاف إليها مجموعة من الجمل النموذجية، لتكوين نص لوريم إيبسوم ذو شكل منطقي قريب إلى النص الحقيقي. وبالتالي يكون النص الناتح خالي من التكرار، أو أي كلمات أو عبارات غير لائقة أو ما شابه. وهذا ما يجعله أول مولّد نص لوريم إيبسوم حقيقي على الإنترنت." },
                    { 10, "InitialCreate", new DateTime(2021, 11, 12, 18, 12, 47, 549, DateTimeKind.Local).AddTicks(269), true, false, "InitialCreate", new DateTime(2021, 11, 12, 18, 12, 47, 549, DateTimeKind.Local).AddTicks(270), "Yorum 10", 10, "Lorem Ipsum，也称乱数假文或者哑元文本， 是印刷及排版领域所常用的虚拟文字。由于曾经一台匿名的打印机刻意打乱了一盒印刷字体从而造出一本字体样品书，Lorem Ipsum从西元15世纪起就被作为此领域的标准文本使用。它不仅延续了五个世纪，还通过了电子排版的挑战，其雏形却依然保存至今。在1960年代，”Leatraset”公司发布了印刷着Lorem Ipsum段落的纸张，从而广泛普及了它的使用。最近，计算机桌面出版软件”Aldus PageMaker”也通过同样的方式使Lorem Ipsum落入大众的视野。" }
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
