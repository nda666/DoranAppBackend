using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace DoranOfficeBackend.Migrations
{
    public partial class addTimestampHkategoribarang : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "kodeh",
                table: "hkategoribarang",
                type: "int(11)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int(11)")
                .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn);


            migrationBuilder.AddColumn<Guid>(
                name: "id",
                table: "hkategoribarang",
                type: "char(36)",
                nullable: false,
                defaultValueSql: "UUID()");

            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                table: "hkategoribarang",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_at",
                table: "hkategoribarang",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "deleted_at",
                table: "hkategoribarang",
                type: "datetime(6)",
                nullable: true);


           
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.DropColumn(
                name: "created_at",
                table: "hkategoribarang");

            migrationBuilder.DropColumn(
                name: "deleted_at",
                table: "hkategoribarang");

            migrationBuilder.DropColumn(
                name: "id",
                table: "hkategoribarang");

            migrationBuilder.DropColumn(
                name: "updated_at",
                table: "hkategoribarang");

         

            migrationBuilder.AlterColumn<int>(
                name: "kodeh",
                table: "hkategoribarang",
                type: "int(11)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int(11)")
                .OldAnnotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn);

          
        }
    }
}
