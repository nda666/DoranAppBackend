using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace DoranOfficeBackend.Migrations
{
    public partial class AddPkAndTsHkelompokbarang : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.AddColumn<Guid>(
               name: "id",
               table: "hkelompokbarang",
               type: "char(36)",
               nullable: false,
               defaultValueSql: "UUID()");

            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                table: "hkelompokbarang",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_at",
                table: "hkelompokbarang",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "deleted_at",
                table: "hkelompokbarang",
                type: "datetime(6)",
                nullable: true);

            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropColumn(
               name: "created_at",
               table: "hkelompokbarang");

            migrationBuilder.DropColumn(
                name: "deleted_at",
                table: "hkelompokbarang");

            migrationBuilder.DropColumn(
                name: "id",
                table: "hkelompokbarang");

            migrationBuilder.DropColumn(
                name: "updated_at",
                table: "hkelompokbarang");
        }
    }
}
