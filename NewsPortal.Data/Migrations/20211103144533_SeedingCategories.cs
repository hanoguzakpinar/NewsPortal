using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NewsPortal.Data.Migrations
{
    public partial class SeedingCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                "INSERT INTO [NewsPortal].dbo.Categories (Name,Description,Note,CreatedDate,CreatedByName,ModifiedDate,ModifiedByName,IsActive,IsDeleted) VALUES ('Futbol','Futbol ile İlgili En Güncel Bilgiler','Futbol Kategorisi',GETDATE(),'Migration',GETDATE(),'Migration',1,0)");
            migrationBuilder.Sql(
                "INSERT INTO [NewsPortal].dbo.Categories (Name,Description,Note,CreatedDate,CreatedByName,ModifiedDate,ModifiedByName,IsActive,IsDeleted) VALUES ('Basketbol','Basketbol ile İlgili En Güncel Bilgiler','Basketbol Kategorisi',GETDATE(),'Migration',GETDATE(),'Migration',1,0)");
            migrationBuilder.Sql(
                "INSERT INTO [NewsPortal].dbo.Categories (Name,Description,Note,CreatedDate,CreatedByName,ModifiedDate,ModifiedByName,IsActive,IsDeleted) VALUES ('Voleybol','Voleybol ile İlgili En Güncel Bilgiler','Voleybol Kategorisi',GETDATE(),'Migration',GETDATE(),'Migration',1,0)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
