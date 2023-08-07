using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace DoranOfficeBackend.Migrations
{
    public partial class AddPkToMasterDivisi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
              name: "kode",
              table: "masterdivisi",
              type: "int(11)",
              nullable: false,
              oldClrType: typeof(int),
              oldType: "int(11)")
              .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<Guid>(
               name: "id",
               table: "masterdivisi",
               type: "char(36)",
               nullable: false,
               defaultValueSql: "UUID()");

            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                table: "masterdivisi",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_at",
                table: "masterdivisi",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "deleted_at",
                table: "masterdivisi",
                type: "datetime(6)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
            name: "kode",
            table: "masterdivisi",
            type: "int(11)",
            nullable: false,
            oldClrType: typeof(int),
            oldType: "int(11)", defaultValue: "0");

            migrationBuilder.DropColumn(
                name: "created_at",
                table: "masterdivisi");

            migrationBuilder.DropColumn(
                name: "deleted_at",
                table: "masterdivisi");

            migrationBuilder.DropColumn(
                name: "id",
                table: "masterdivisi");

            migrationBuilder.DropColumn(
                name: "updated_at",
                table: "masterdivisi");
        }
    }
}
