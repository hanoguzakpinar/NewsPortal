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
                    { 1, "InitialCreate", new DateTime(2021, 11, 12, 20, 59, 58, 21, DateTimeKind.Local).AddTicks(556), "Ekonomi Haberleri", true, false, "InitialCreate", new DateTime(2021, 11, 12, 20, 59, 58, 21, DateTimeKind.Local).AddTicks(579), "Ekonomi", "Ekonomi Kategorisi" },
                    { 2, "InitialCreate", new DateTime(2021, 11, 12, 20, 59, 58, 21, DateTimeKind.Local).AddTicks(592), "Sağlık Haberleri", true, false, "InitialCreate", new DateTime(2021, 11, 12, 20, 59, 58, 21, DateTimeKind.Local).AddTicks(594), "Sağlık", "Sağlık Kategorisi" },
                    { 3, "InitialCreate", new DateTime(2021, 11, 12, 20, 59, 58, 21, DateTimeKind.Local).AddTicks(599), "Dünya Haberleri", true, false, "InitialCreate", new DateTime(2021, 11, 12, 20, 59, 58, 21, DateTimeKind.Local).AddTicks(600), "Dünya", "Dünya Kategorisi" },
                    { 4, "InitialCreate", new DateTime(2021, 11, 12, 20, 59, 58, 21, DateTimeKind.Local).AddTicks(605), "Gündem Haberleri", true, false, "InitialCreate", new DateTime(2021, 11, 12, 20, 59, 58, 21, DateTimeKind.Local).AddTicks(606), "Gündem", "Gündem Kategorisi" },
                    { 5, "InitialCreate", new DateTime(2021, 11, 12, 20, 59, 58, 21, DateTimeKind.Local).AddTicks(610), "Teknoloji Haberleri", true, false, "InitialCreate", new DateTime(2021, 11, 12, 20, 59, 58, 21, DateTimeKind.Local).AddTicks(612), "Teknoloji", "Teknoloji Kategorisi" },
                    { 6, "InitialCreate", new DateTime(2021, 11, 12, 20, 59, 58, 21, DateTimeKind.Local).AddTicks(616), "Magazin Haberleri", true, false, "InitialCreate", new DateTime(2021, 11, 12, 20, 59, 58, 21, DateTimeKind.Local).AddTicks(617), "Magazin", "Magazin Kategorisi" },
                    { 7, "InitialCreate", new DateTime(2021, 11, 12, 20, 59, 58, 21, DateTimeKind.Local).AddTicks(622), "Futbol Haberleri", true, false, "InitialCreate", new DateTime(2021, 11, 12, 20, 59, 58, 21, DateTimeKind.Local).AddTicks(623), "Futbol", "Futbol Kategorisi" },
                    { 8, "InitialCreate", new DateTime(2021, 11, 12, 20, 59, 58, 21, DateTimeKind.Local).AddTicks(628), "Basketbol Haberleri", true, false, "InitialCreate", new DateTime(2021, 11, 12, 20, 59, 58, 21, DateTimeKind.Local).AddTicks(629), "Basketbol", "Basketbol Kategorisi" },
                    { 9, "InitialCreate", new DateTime(2021, 11, 12, 20, 59, 58, 21, DateTimeKind.Local).AddTicks(633), "Formula 1 Haberleri", true, false, "InitialCreate", new DateTime(2021, 11, 12, 20, 59, 58, 21, DateTimeKind.Local).AddTicks(635), "Formula 1", "Formula 1 Kategorisi" },
                    { 10, "InitialCreate", new DateTime(2021, 11, 12, 20, 59, 58, 21, DateTimeKind.Local).AddTicks(639), "Espor Haberleri", true, false, "InitialCreate", new DateTime(2021, 11, 12, 20, 59, 58, 21, DateTimeKind.Local).AddTicks(641), "Espor", "Espor Kategorisi" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 15, "7b79f9aa-f734-4875-b67a-7f3006c35efe", "Role.Update", "ROLE.UPDATE" },
                    { 16, "0e00200b-0abd-462e-87b1-5068056dfca7", "Role.Delete", "ROLE.DELETE" },
                    { 17, "594ebeea-a91a-4a92-8022-dcf62e5d065e", "Comment.Create", "COMMENT.CREATE" },
                    { 18, "e9719c20-c8f3-4304-a224-fdef96685bb8", "Comment.Read", "COMMENT.READ" },
                    { 23, "56adab4c-0bfd-42b3-bbda-5e1db9757f86", "Normal", "NORMAL" },
                    { 20, "84f4fa31-cb88-4453-9512-ced7265bd5de", "Comment.Delete", "COMMENT.DELETE" },
                    { 21, "557057ae-6805-4d40-a129-92a0b1ef72a0", "AdminArea.Home.Read", "ADMINAREA.HOME.READ" },
                    { 22, "0acf5fd3-f18b-4a90-98ac-1d4787965b0c", "SuperAdmin", "SUPERADMIN" },
                    { 14, "296e9b30-1358-415d-b7d6-4b16eca727b4", "Role.Read", "ROLE.READ" },
                    { 19, "65e213a4-2f70-4a49-9a72-b4be480c62ab", "Comment.Update", "COMMENT.UPDATE" },
                    { 13, "40adde60-268f-42d7-805c-f3be77f4aa8b", "Role.Create", "ROLE.CREATE" },
                    { 8, "ea4824ee-2d18-4722-a6cb-a8503953e4ea", "Report.Delete", "REPORT.DELETE" },
                    { 11, "5ec7c482-73e6-4746-af8c-2445991de9a9", "User.Update", "USER.UPDATE" },
                    { 10, "b7c8550a-dde3-4cb7-aa67-35b2dec3d1bb", "User.Read", "USER.READ" },
                    { 9, "6d1f575e-df15-40e9-bb74-a0da9bbe522d", "User.Create", "USER.CREATE" },
                    { 7, "1bb68220-316b-4223-af2b-ab0e71a5af9a", "Report.Update", "REPORT.UPDATE" },
                    { 6, "dae0b3c2-bd78-41dd-bee9-22584735ef07", "Report.Read", "REPORT.READ" },
                    { 5, "02a46c14-7e08-49be-b308-a5eaafc39003", "Report.Create", "REPORT.CREATE" },
                    { 4, "626ad867-77c0-41b0-a4a4-79ec01a99a2b", "Category.Delete", "CATEGORY.DELETE" },
                    { 3, "9e17255d-7e39-4108-8a24-80a94ddc7900", "Category.Update", "CATEGORY.UPDATE" },
                    { 2, "e67f82ac-caf6-44a7-9d9f-a57663f73452", "Category.Read", "CATEGORY.READ" },
                    { 1, "996f7712-f61c-43c0-b4f0-98a2b3a4d36c", "Category.Create", "CATEGORY.CREATE" },
                    { 12, "d1822b0f-46de-47c0-90a1-accd183dd507", "User.Delete", "USER.DELETE" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "About", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FacebookLink", "FirstName", "GitHubLink", "InstagramLink", "LastName", "LinkedInLink", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Picture", "SecurityStamp", "TwitterLink", "TwoFactorEnabled", "UserName", "WebsiteLink", "YoutubeLink" },
                values: new object[,]
                {
                    { 1, "Admin User of NewsPortal", 0, "80855296-c7c4-47fb-b0ff-df9e969bdde4", "adminuser@gmail.com", true, "https://facebook.com/adminuser", "Admin", "https://github.com/adminuser", "https://instagram.com/adminuser", "User", "https://linkedin.com/adminuser", false, null, "ADMINUSER@GMAIL.COM", "ADMINUSER", "AQAAAAEAACcQAAAAELAIMVzBVImd6nyV5ex0/fSmrrRD2jaNTOsophW5odaVSSYavrvWIRC+lJpfbEs41A==", "+905555555555", true, "/userImages/defaultUser.jpg", "2089e8d0-7630-4404-9c73-6cce2a75d43f", "https://twitter.com/adminuser", false, "adminuser", "https://newsportal.com/", "https://youtube.com/adminuser" },
                    { 2, "Editor User of NewsPortal", 0, "42b3ebde-cb02-4948-b452-d1aac92f564c", "editoruser@gmail.com", true, "https://facebook.com/editoruser", "Admin", "https://github.com/editoruser", "https://instagram.com/editoruser", "User", "https://linkedin.com/editoruser", false, null, "EDITORUSER@GMAIL.COM", "EDITORUSER", "AQAAAAEAACcQAAAAEKUalNXffNnxx73d3YZiMMOQIZ+3enEpgc1MB59s51+Xr/d+Rg9qsXlQIhd12/JEBQ==", "+905555555555", true, "/userImages/defaultUser.jpg", "333af147-3938-48b4-9a03-670ffa7699aa", "https://twitter.com/editoruser", false, "editoruser", "https://newsportal.com/", "https://youtube.com/editoruser" }
                });

            migrationBuilder.InsertData(
                table: "Reports",
                columns: new[] { "Id", "CategoryId", "CommentCount", "Content", "CreatedByName", "CreatedDate", "Date", "IsActive", "IsDeleted", "ModifiedByName", "ModifiedDate", "Note", "SeoAuthor", "SeoDescription", "SeoTags", "Thumbnail", "Title", "UserId", "ViewsCount" },
                values: new object[,]
                {
                    { 1, 1, 1, "Lorem Ipsum, dizgi ve baskı endüstrisinde kullanılan mıgır metinlerdir. Lorem Ipsum, adı bilinmeyen bir matbaacının bir hurufat numune kitabı oluşturmak üzere bir yazı galerisini alarak karıştırdığı 1500'lerden beri endüstri standardı sahte metinler olarak kullanılmıştır. Beşyüz yıl boyunca varlığını sürdürmekle kalmamış, aynı zamanda pek değişmeden elektronik dizgiye de sıçramıştır. 1960'larda Lorem Ipsum pasajları da içeren Letraset yapraklarının yayınlanması ile ve yakın zamanda Aldus PageMaker gibi Lorem Ipsum sürümleri içeren masaüstü yayıncılık yazılımları ile popüler olmuştur.", "Initial Create", new DateTime(2021, 11, 12, 20, 59, 58, 16, DateTimeKind.Local).AddTicks(3575), new DateTime(2021, 11, 12, 20, 59, 58, 16, DateTimeKind.Local).AddTicks(2464), true, false, "Initial Create", new DateTime(2021, 11, 12, 20, 59, 58, 16, DateTimeKind.Local).AddTicks(4149), "SHIBA INU'ya zirveden giren yüzde 45 kaybetti", "Oğuzhan Akpınar", "SHIBA INU'ya zirveden giren yüzde 45 kaybetti", "SHIBA INU", "postImages/defaultThumbnail.png", "SHIBA INU'ya zirveden giren yüzde 45 kaybetti", 1, 100 },
                    { 10, 10, 1, "Yaygın inancın tersine, Lorem Ipsum rastgele sözcüklerden oluşmaz. Kökleri M.Ö. 45 tarihinden bu yana klasik Latin edebiyatına kadar uzanan 2000 yıllık bir geçmişi vardır. Virginia'daki Hampden-Sydney College'dan Latince profesörü Richard McClintock, bir Lorem Ipsum pasajında geçen ve anlaşılması en güç sözcüklerden biri olan 'consectetur' sözcüğünün klasik edebiyattaki örneklerini incelediğinde kesin bir kaynağa ulaşmıştır. Lorm Ipsum, Çiçero tarafından M.Ö. 45 tarihinde kaleme alınan de Finibus Bonorum et Malorum (İyi ve Kötünün Uç Sınırları) eserinin 1.10.32 ve 1.10.33 sayılı bölümlerinden gelmektedir. Bu kitap, ahlak kuramı üzerine bir tezdir ve Rönesans döneminde çok popüler olmuştur. Lorem Ipsum pasajının ilk satırı olan Lorem ipsum dolor sit amet 1.10.32 sayılı bölümdeki bir satırdan gelmektedir.", "Initial Create", new DateTime(2021, 11, 12, 20, 59, 58, 16, DateTimeKind.Local).AddTicks(5594), new DateTime(2021, 11, 12, 20, 59, 58, 16, DateTimeKind.Local).AddTicks(5592), true, false, "Initial Create", new DateTime(2021, 11, 12, 20, 59, 58, 16, DateTimeKind.Local).AddTicks(5595), "Dota 2 The International 2021 Şampiyonu Team Spirit Oldu!", "Oğuzhan Akpınar", "Dota 2 The International 2021 Şampiyonu Team Spirit Oldu!", "Dota International Spirit", "postImages/defaultThumbnail.png", "Dota 2 The International 2021 Şampiyonu Team Spirit Oldu!", 1, 50 },
                    { 8, 8, 1, "Yaygın inancın tersine, Lorem Ipsum rastgele sözcüklerden oluşmaz. Kökleri M.Ö. 45 tarihinden bu yana klasik Latin edebiyatına kadar uzanan 2000 yıllık bir geçmişi vardır. Virginia'daki Hampden-Sydney College'dan Latince profesörü Richard McClintock, bir Lorem Ipsum pasajında geçen ve anlaşılması en güç sözcüklerden biri olan 'consectetur' sözcüğünün klasik edebiyattaki örneklerini incelediğinde kesin bir kaynağa ulaşmıştır. Lorm Ipsum, Çiçero tarafından M.Ö. 45 tarihinde kaleme alınan de Finibus Bonorum et Malorum (İyi ve Kötünün Uç Sınırları) eserinin 1.10.32 ve 1.10.33 sayılı bölümlerinden gelmektedir. Bu kitap, ahlak kuramı üzerine bir tezdir ve Rönesans döneminde çok popüler olmuştur. Lorem Ipsum pasajının ilk satırı olan Lorem ipsum dolor sit amet 1.10.32 sayılı bölümdeki bir satırdan gelmektedir.", "Initial Create", new DateTime(2021, 11, 12, 20, 59, 58, 16, DateTimeKind.Local).AddTicks(5579), new DateTime(2021, 11, 12, 20, 59, 58, 16, DateTimeKind.Local).AddTicks(5577), true, false, "Initial Create", new DateTime(2021, 11, 12, 20, 59, 58, 16, DateTimeKind.Local).AddTicks(5580), "Anadolu Efes: 85 - Galatasaray Nef: 92", "Oğuzhan Akpınar", "Anadolu Efes: 85 - Galatasaray Nef: 92", "GS Efes Basketbol", "postImages/defaultThumbnail.png", "Anadolu Efes: 85 - Galatasaray Nef: 92", 1, 200 },
                    { 7, 7, 2, "Yaygın inancın tersine, Lorem Ipsum rastgele sözcüklerden oluşmaz. Kökleri M.Ö. 45 tarihinden bu yana klasik Latin edebiyatına kadar uzanan 2000 yıllık bir geçmişi vardır. Virginia'daki Hampden-Sydney College'dan Latince profesörü Richard McClintock, bir Lorem Ipsum pasajında geçen ve anlaşılması en güç sözcüklerden biri olan 'consectetur' sözcüğünün klasik edebiyattaki örneklerini incelediğinde kesin bir kaynağa ulaşmıştır. Lorm Ipsum, Çiçero tarafından M.Ö. 45 tarihinde kaleme alınan de Finibus Bonorum et Malorum (İyi ve Kötünün Uç Sınırları) eserinin 1.10.32 ve 1.10.33 sayılı bölümlerinden gelmektedir. Bu kitap, ahlak kuramı üzerine bir tezdir ve Rönesans döneminde çok popüler olmuştur. Lorem Ipsum pasajının ilk satırı olan Lorem ipsum dolor sit amet 1.10.32 sayılı bölümdeki bir satırdan gelmektedir.", "Initial Create", new DateTime(2021, 11, 12, 20, 59, 58, 16, DateTimeKind.Local).AddTicks(5571), new DateTime(2021, 11, 12, 20, 59, 58, 16, DateTimeKind.Local).AddTicks(5570), true, false, "Initial Create", new DateTime(2021, 11, 12, 20, 59, 58, 16, DateTimeKind.Local).AddTicks(5573), "Galatasaray: 1 - Lokomotiv Moskova: 1", "Oğuzhan Akpınar", "Galatasaray: 1 - Lokomotiv Moskova: 1", "GS LM Uefa", "postImages/defaultThumbnail.png", "Galatasaray: 1 - Lokomotiv Moskova: 1", 1, 255 },
                    { 6, 6, 2, "Yaygın inancın tersine, Lorem Ipsum rastgele sözcüklerden oluşmaz. Kökleri M.Ö. 45 tarihinden bu yana klasik Latin edebiyatına kadar uzanan 2000 yıllık bir geçmişi vardır. Virginia'daki Hampden-Sydney College'dan Latince profesörü Richard McClintock, bir Lorem Ipsum pasajında geçen ve anlaşılması en güç sözcüklerden biri olan 'consectetur' sözcüğünün klasik edebiyattaki örneklerini incelediğinde kesin bir kaynağa ulaşmıştır. Lorm Ipsum, Çiçero tarafından M.Ö. 45 tarihinde kaleme alınan de Finibus Bonorum et Malorum (İyi ve Kötünün Uç Sınırları) eserinin 1.10.32 ve 1.10.33 sayılı bölümlerinden gelmektedir. Bu kitap, ahlak kuramı üzerine bir tezdir ve Rönesans döneminde çok popüler olmuştur. Lorem Ipsum pasajının ilk satırı olan Lorem ipsum dolor sit amet 1.10.32 sayılı bölümdeki bir satırdan gelmektedir.", "Initial Create", new DateTime(2021, 11, 12, 20, 59, 58, 16, DateTimeKind.Local).AddTicks(5564), new DateTime(2021, 11, 12, 20, 59, 58, 16, DateTimeKind.Local).AddTicks(5562), true, false, "Initial Create", new DateTime(2021, 11, 12, 20, 59, 58, 16, DateTimeKind.Local).AddTicks(5565), "Saçma Magazin Haberi", "Oğuzhan Akpınar", "Saçma Magazin Haberi", "Magazin Saçma Haber", "postImages/defaultThumbnail.png", "Saçma Magazin Haberi", 1, 15 },
                    { 9, 9, 1, "Yaygın inancın tersine, Lorem Ipsum rastgele sözcüklerden oluşmaz. Kökleri M.Ö. 45 tarihinden bu yana klasik Latin edebiyatına kadar uzanan 2000 yıllık bir geçmişi vardır. Virginia'daki Hampden-Sydney College'dan Latince profesörü Richard McClintock, bir Lorem Ipsum pasajında geçen ve anlaşılması en güç sözcüklerden biri olan 'consectetur' sözcüğünün klasik edebiyattaki örneklerini incelediğinde kesin bir kaynağa ulaşmıştır. Lorm Ipsum, Çiçero tarafından M.Ö. 45 tarihinde kaleme alınan de Finibus Bonorum et Malorum (İyi ve Kötünün Uç Sınırları) eserinin 1.10.32 ve 1.10.33 sayılı bölümlerinden gelmektedir. Bu kitap, ahlak kuramı üzerine bir tezdir ve Rönesans döneminde çok popüler olmuştur. Lorem Ipsum pasajının ilk satırı olan Lorem ipsum dolor sit amet 1.10.32 sayılı bölümdeki bir satırdan gelmektedir.", "Initial Create", new DateTime(2021, 11, 12, 20, 59, 58, 16, DateTimeKind.Local).AddTicks(5587), new DateTime(2021, 11, 12, 20, 59, 58, 16, DateTimeKind.Local).AddTicks(5585), true, false, "Initial Create", new DateTime(2021, 11, 12, 20, 59, 58, 16, DateTimeKind.Local).AddTicks(5588), "Mercedes'in Hamilton'ın motor cezası alma ihtimaliyle ilgili endişeleri azaldı", "Oğuzhan Akpınar", "Mercedes'in Hamilton'ın motor cezası alma ihtimaliyle ilgili endişeleri azaldı", "F1 Mercedes", "postImages/defaultThumbnail.png", "Mercedes'in Hamilton'ın motor cezası alma ihtimaliyle ilgili endişeleri azaldı", 1, 100 },
                    { 4, 4, 1, "Yaygın inancın tersine, Lorem Ipsum rastgele sözcüklerden oluşmaz. Kökleri M.Ö. 45 tarihinden bu yana klasik Latin edebiyatına kadar uzanan 2000 yıllık bir geçmişi vardır. Virginia'daki Hampden-Sydney College'dan Latince profesörü Richard McClintock, bir Lorem Ipsum pasajında geçen ve anlaşılması en güç sözcüklerden biri olan 'consectetur' sözcüğünün klasik edebiyattaki örneklerini incelediğinde kesin bir kaynağa ulaşmıştır. Lorm Ipsum, Çiçero tarafından M.Ö. 45 tarihinde kaleme alınan de Finibus Bonorum et Malorum (İyi ve Kötünün Uç Sınırları) eserinin 1.10.32 ve 1.10.33 sayılı bölümlerinden gelmektedir. Bu kitap, ahlak kuramı üzerine bir tezdir ve Rönesans döneminde çok popüler olmuştur. Lorem Ipsum pasajının ilk satırı olan Lorem ipsum dolor sit amet 1.10.32 sayılı bölümdeki bir satırdan gelmektedir.", "Initial Create", new DateTime(2021, 11, 12, 20, 59, 58, 16, DateTimeKind.Local).AddTicks(5550), new DateTime(2021, 11, 12, 20, 59, 58, 16, DateTimeKind.Local).AddTicks(5548), true, false, "Initial Create", new DateTime(2021, 11, 12, 20, 59, 58, 16, DateTimeKind.Local).AddTicks(5551), "50 yıl sonra görüldü! O balık İzmit Körfezi'nde!", "Oğuzhan Akpınar", "50 yıl sonra görüldü! O balık İzmit Körfezi'nde!", "Balık İzmit Körfez", "postImages/defaultThumbnail.png", "50 yıl sonra görüldü! O balık İzmit Körfezi'nde!", 1, 100 },
                    { 3, 3, 1, "Yaygın inancın tersine, Lorem Ipsum rastgele sözcüklerden oluşmaz. Kökleri M.Ö. 45 tarihinden bu yana klasik Latin edebiyatına kadar uzanan 2000 yıllık bir geçmişi vardır. Virginia'daki Hampden-Sydney College'dan Latince profesörü Richard McClintock, bir Lorem Ipsum pasajında geçen ve anlaşılması en güç sözcüklerden biri olan 'consectetur' sözcüğünün klasik edebiyattaki örneklerini incelediğinde kesin bir kaynağa ulaşmıştır. Lorm Ipsum, Çiçero tarafından M.Ö. 45 tarihinde kaleme alınan de Finibus Bonorum et Malorum (İyi ve Kötünün Uç Sınırları) eserinin 1.10.32 ve 1.10.33 sayılı bölümlerinden gelmektedir. Bu kitap, ahlak kuramı üzerine bir tezdir ve Rönesans döneminde çok popüler olmuştur. Lorem Ipsum pasajının ilk satırı olan Lorem ipsum dolor sit amet 1.10.32 sayılı bölümdeki bir satırdan gelmektedir.", "Initial Create", new DateTime(2021, 11, 12, 20, 59, 58, 16, DateTimeKind.Local).AddTicks(5542), new DateTime(2021, 11, 12, 20, 59, 58, 16, DateTimeKind.Local).AddTicks(5540), true, false, "Initial Create", new DateTime(2021, 11, 12, 20, 59, 58, 16, DateTimeKind.Local).AddTicks(5543), "İran'dan şoke eden itiraf! \"Petrolü kaçak satıyoruz!\"", "Oğuzhan Akpınar", "İran'dan şoke eden itiraf! \"Petrolü kaçak satıyoruz!\"", "İran Kaçak Petrol", "postImages/defaultThumbnail.png", "İran'dan şoke eden itiraf! \"Petrolü kaçak satıyoruz!\"", 1, 120 },
                    { 2, 2, 1, "Yinelenen bir sayfa içeriğinin okuyucunun dikkatini dağıttığı bilinen bir gerçektir. Lorem Ipsum kullanmanın amacı, sürekli 'buraya metin gelecek, buraya metin gelecek' yazmaya kıyasla daha dengeli bir harf dağılımı sağlayarak okunurluğu artırmasıdır. Şu anda birçok masaüstü yayıncılık paketi ve web sayfa düzenleyicisi, varsayılan mıgır metinler olarak Lorem Ipsum kullanmaktadır. Ayrıca arama motorlarında 'lorem ipsum' anahtar sözcükleri ile arama yapıldığında henüz tasarım aşamasında olan çok sayıda site listelenir. Yıllar içinde, bazen kazara, bazen bilinçli olarak (örneğin mizah katılarak), çeşitli sürümleri geliştirilmiştir.", "Initial Create", new DateTime(2021, 11, 12, 20, 59, 58, 16, DateTimeKind.Local).AddTicks(5533), new DateTime(2021, 11, 12, 20, 59, 58, 16, DateTimeKind.Local).AddTicks(5531), true, false, "Initial Create", new DateTime(2021, 11, 12, 20, 59, 58, 16, DateTimeKind.Local).AddTicks(5534), "Kalp krizini hangisi daha fazla tetikliyor? Hamburger mi yoksa stres mi?", "Oğuzhan Akpınar", "Kalp krizini hangisi daha fazla tetikliyor? Hamburger mi yoksa stres mi?", "Kalp Krizi Stres Hamburger", "postImages/defaultThumbnail.png", "Kalp krizini hangisi daha fazla tetikliyor? Hamburger mi yoksa stres mi?", 1, 295 },
                    { 5, 5, 2, "Yaygın inancın tersine, Lorem Ipsum rastgele sözcüklerden oluşmaz. Kökleri M.Ö. 45 tarihinden bu yana klasik Latin edebiyatına kadar uzanan 2000 yıllık bir geçmişi vardır. Virginia'daki Hampden-Sydney College'dan Latince profesörü Richard McClintock, bir Lorem Ipsum pasajında geçen ve anlaşılması en güç sözcüklerden biri olan 'consectetur' sözcüğünün klasik edebiyattaki örneklerini incelediğinde kesin bir kaynağa ulaşmıştır. Lorm Ipsum, Çiçero tarafından M.Ö. 45 tarihinde kaleme alınan de Finibus Bonorum et Malorum (İyi ve Kötünün Uç Sınırları) eserinin 1.10.32 ve 1.10.33 sayılı bölümlerinden gelmektedir. Bu kitap, ahlak kuramı üzerine bir tezdir ve Rönesans döneminde çok popüler olmuştur. Lorem Ipsum pasajının ilk satırı olan Lorem ipsum dolor sit amet 1.10.32 sayılı bölümdeki bir satırdan gelmektedir.", "Initial Create", new DateTime(2021, 11, 12, 20, 59, 58, 16, DateTimeKind.Local).AddTicks(5557), new DateTime(2021, 11, 12, 20, 59, 58, 16, DateTimeKind.Local).AddTicks(5555), true, false, "Initial Create", new DateTime(2021, 11, 12, 20, 59, 58, 16, DateTimeKind.Local).AddTicks(5558), "Cisco, AR destekli toplantı çözümü Webex Hologram'ı tanıttı", "Oğuzhan Akpınar", "Cisco, AR destekli toplantı çözümü Webex Hologram'ı tanıttı", "Cisco AR Hologram", "postImages/defaultThumbnail.png", "Cisco, AR destekli toplantı çözümü Webex Hologram'ı tanıttı", 1, 222 }
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
                    { 1, "InitialCreate", new DateTime(2021, 11, 12, 20, 59, 58, 24, DateTimeKind.Local).AddTicks(3368), true, false, "InitialCreate", new DateTime(2021, 11, 12, 20, 59, 58, 24, DateTimeKind.Local).AddTicks(3384), "Yorum 1", 1, "Lorem Ipsum pasajlarının birçok çeşitlemesi vardır. Ancak bunların büyük bir çoğunluğu mizah katılarak veya rastgele sözcükler eklenerek değiştirilmişlerdir. Eğer bir Lorem Ipsum pasajı kullanacaksanız, metin aralarına utandırıcı sözcükler gizlenmediğinden emin olmanız gerekir. İnternet'teki tüm Lorem Ipsum üreteçleri önceden belirlenmiş metin bloklarını yineler. Bu da, bu üreteci İnternet üzerindeki gerçek Lorem Ipsum üreteci yapar. Bu üreteç, 200'den fazla Latince sözcük ve onlara ait cümle yapılarını içeren bir sözlük kullanır. Bu nedenle, üretilen Lorem Ipsum metinleri yinelemelerden, mizahtan ve karakteristik olmayan sözcüklerden uzaktır." },
                    { 2, "InitialCreate", new DateTime(2021, 11, 12, 20, 59, 58, 24, DateTimeKind.Local).AddTicks(3398), true, false, "InitialCreate", new DateTime(2021, 11, 12, 20, 59, 58, 24, DateTimeKind.Local).AddTicks(3400), "Yorum 2", 2, "Lorem Ipsum jest tekstem stosowanym jako przykładowy wypełniacz w przemyśle poligraficznym. Został po raz pierwszy użyty w XV w. przez nieznanego drukarza do wypełnienia tekstem próbnej książki. Pięć wieków później zaczął być używany przemyśle elektronicznym, pozostając praktycznie niezmienionym. Spopularyzował się w latach 60. XX w. wraz z publikacją arkuszy Letrasetu, zawierających fragmenty Lorem Ipsum, a ostatnio z zawierającym różne wersje Lorem Ipsum oprogramowaniem przeznaczonym do realizacji druków na komputerach osobistych, jak Aldus PageMaker" },
                    { 3, "InitialCreate", new DateTime(2021, 11, 12, 20, 59, 58, 24, DateTimeKind.Local).AddTicks(3405), true, false, "InitialCreate", new DateTime(2021, 11, 12, 20, 59, 58, 24, DateTimeKind.Local).AddTicks(3406), "Yorum 3", 3, "Ang Lorem Ipsum ay ginagamit na modelo ng industriya ng pagpriprint at pagtytypeset. Ang Lorem Ipsum ang naging regular na modelo simula pa noong 1500s, noong may isang di kilalang manlilimbag and kumuha ng galley ng type at ginulo ang pagkaka-ayos nito upang makagawa ng libro ng mga type specimen. Nalagpasan nito hindi lang limang siglo, kundi nalagpasan din nito ang paglaganap ng electronic typesetting at nanatiling parehas. Sumikat ito noong 1960s kasabay ng pag labas ng Letraset sheets na mayroong mga talata ng Lorem Ipsum, at kamakailan lang sa mga desktop publishing software tulad ng Aldus Pagemaker ginamit ang mga bersyon ng Lorem Ipsum." },
                    { 4, "InitialCreate", new DateTime(2021, 11, 12, 20, 59, 58, 24, DateTimeKind.Local).AddTicks(3410), true, false, "InitialCreate", new DateTime(2021, 11, 12, 20, 59, 58, 24, DateTimeKind.Local).AddTicks(3412), "Yorum 4", 4, "Lorem Ipsum er rett og slett dummytekst fra og for trykkeindustrien. Lorem Ipsum har vært bransjens standard for dummytekst helt siden 1500-tallet, da en ukjent boktrykker stokket en mengde bokstaver for å lage et prøveeksemplar av en bok. Lorem Ipsum har tålt tidens tann usedvanlig godt, og har i tillegg til å bestå gjennom fem århundrer også tålt spranget over til elektronisk typografi uten vesentlige endringer. Lorem Ipsum ble gjort allment kjent i 1960-årene ved lanseringen av Letraset-ark med avsnitt fra Lorem Ipsum, og senere med sideombrekkingsprogrammet Aldus PageMaker som tok i bruk nettopp Lorem Ipsum for dummytekst." },
                    { 5, "InitialCreate", new DateTime(2021, 11, 12, 20, 59, 58, 24, DateTimeKind.Local).AddTicks(3416), true, false, "InitialCreate", new DateTime(2021, 11, 12, 20, 59, 58, 24, DateTimeKind.Local).AddTicks(3417), "Yorum 5", 5, "Lorem Ipsum este pur şi simplu o machetă pentru text a industriei tipografice. Lorem Ipsum a fost macheta standard a industriei încă din secolul al XVI-lea, când un tipograf anonim a luat o planşetă de litere şi le-a amestecat pentru a crea o carte demonstrativă pentru literele respective. Nu doar că a supravieţuit timp de cinci secole, dar şi a facut saltul în tipografia electronică practic neschimbată. A fost popularizată în anii '60 odată cu ieşirea colilor Letraset care conţineau pasaje Lorem Ipsum, iar mai recent, prin programele de publicare pentru calculator, ca Aldus PageMaker care includeau versiuni de Lorem Ipsum." },
                    { 6, "InitialCreate", new DateTime(2021, 11, 12, 20, 59, 58, 24, DateTimeKind.Local).AddTicks(3422), true, false, "InitialCreate", new DateTime(2021, 11, 12, 20, 59, 58, 24, DateTimeKind.Local).AddTicks(3423), "Yorum 6", 6, "Lorem Ipsum je jednostavno probni tekst koji se koristi u tiskarskoj i slovoslagarskoj industriji. Lorem Ipsum postoji kao industrijski standard još od 16-og stoljeća, kada je nepoznati tiskar uzeo tiskarsku galiju slova i posložio ih da bi napravio knjigu s uzorkom tiska. Taj je tekst ne samo preživio pet stoljeća, već se i vinuo u svijet elektronskog slovoslagarstva, ostajući u suštini nepromijenjen. Postao je popularan tijekom 1960-ih s pojavom Letraset listova s odlomcima Lorem Ipsum-a, a u skorije vrijeme sa software-om za stolno izdavaštvo kao što je Aldus PageMaker koji također sadrži varijante Lorem Ipsum-a." },
                    { 7, "InitialCreate", new DateTime(2021, 11, 12, 20, 59, 58, 24, DateTimeKind.Local).AddTicks(3427), true, false, "InitialCreate", new DateTime(2021, 11, 12, 20, 59, 58, 24, DateTimeKind.Local).AddTicks(3429), "Yorum 7", 7, "Lorem Ipsum – tas ir teksta salikums, kuru izmanto poligrāfijā un maketēšanas darbos. Lorem Ipsum ir kļuvis par vispārpieņemtu teksta aizvietotāju kopš 16. gadsimta sākuma. Tajā laikā kāds nezināms iespiedējs izveidoja teksta fragmentu, lai nodrukātu grāmatu ar burtu paraugiem. Tas ir ne tikai pārdzīvojis piecus gadsimtus, bet bez ievērojamām izmaiņām saglabājies arī mūsdienās, pārejot uz datorizētu teksta apstrādi. Tā popularizēšanai 60-tajos gados kalpoja Letraset burtu paraugu publicēšana ar Lorem Ipsum teksta fragmentiem un, nesenā pagātnē, tādas maketēšanas programmas kā Aldus PageMaker, kuras šablonu paraugos ir izmantots Lorem Ipsum teksts." },
                    { 8, "InitialCreate", new DateTime(2021, 11, 12, 20, 59, 58, 24, DateTimeKind.Local).AddTicks(3433), true, false, "InitialCreate", new DateTime(2021, 11, 12, 20, 59, 58, 24, DateTimeKind.Local).AddTicks(3434), "Yorum 8", 8, "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like)." },
                    { 9, "InitialCreate", new DateTime(2021, 11, 12, 20, 59, 58, 24, DateTimeKind.Local).AddTicks(3439), true, false, "InitialCreate", new DateTime(2021, 11, 12, 20, 59, 58, 24, DateTimeKind.Local).AddTicks(3440), "Yorum 9", 9, "هنالك العديد من الأنواع المتوفرة لنصوص لوريم إيبسوم، ولكن الغالبية تم تعديلها بشكل ما عبر إدخال بعض النوادر أو الكلمات العشوائية إلى النص. إن كنت تريد أن تستخدم نص لوريم إيبسوم ما، عليك أن تتحقق أولاً أن ليس هناك أي كلمات أو عبارات محرجة أو غير لائقة مخبأة في هذا النص. بينما تعمل جميع مولّدات نصوص لوريم إيبسوم على الإنترنت على إعادة تكرار مقاطع من نص لوريم إيبسوم نفسه عدة مرات بما تتطلبه الحاجة، يقوم مولّدنا هذا باستخدام كلمات من قاموس يحوي على أكثر من 200 كلمة لا تينية، مضاف إليها مجموعة من الجمل النموذجية، لتكوين نص لوريم إيبسوم ذو شكل منطقي قريب إلى النص الحقيقي. وبالتالي يكون النص الناتح خالي من التكرار، أو أي كلمات أو عبارات غير لائقة أو ما شابه. وهذا ما يجعله أول مولّد نص لوريم إيبسوم حقيقي على الإنترنت." },
                    { 10, "InitialCreate", new DateTime(2021, 11, 12, 20, 59, 58, 24, DateTimeKind.Local).AddTicks(3444), true, false, "InitialCreate", new DateTime(2021, 11, 12, 20, 59, 58, 24, DateTimeKind.Local).AddTicks(3446), "Yorum 10", 10, "Lorem Ipsum，也称乱数假文或者哑元文本， 是印刷及排版领域所常用的虚拟文字。由于曾经一台匿名的打印机刻意打乱了一盒印刷字体从而造出一本字体样品书，Lorem Ipsum从西元15世纪起就被作为此领域的标准文本使用。它不仅延续了五个世纪，还通过了电子排版的挑战，其雏形却依然保存至今。在1960年代，”Leatraset”公司发布了印刷着Lorem Ipsum段落的纸张，从而广泛普及了它的使用。最近，计算机桌面出版软件”Aldus PageMaker”也通过同样的方式使Lorem Ipsum落入大众的视野。" }
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
