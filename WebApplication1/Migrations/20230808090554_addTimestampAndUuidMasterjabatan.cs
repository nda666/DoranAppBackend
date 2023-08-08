using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace DoranOfficeBackend.Migrations
{
    public partial class addTimestampAndUuidMasterjabatan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
             name: "kode",
             table: "masterjabatan",
             type: "int(11)",
             nullable: false,
             oldClrType: typeof(int),
             oldType: "int(11)")
             .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<Guid>(
                name: "id",
                table: "masterjabatan",
                type: "char(36)",
                nullable: false,
                defaultValueSql: "UUID()");

            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                table: "masterjabatan",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_at",
                table: "masterjabatan",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "deleted_at",
                table: "masterjabatan",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_masterpegawai_kodejabatan",
                table: "masterpegawai",
                column: "kodejabatan");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
            name: "kode",
            table: "masterjabatan",
            type: "int(11)",
            nullable: false,
            oldClrType: typeof(int),
            oldType: "int(11)");

            migrationBuilder.DropIndex(
                name: "IX_masterpegawai_kodejabatan",
                table: "masterpegawai");

            migrationBuilder.DropColumn(
                name: "created_at",
                table: "masterjabatan");

            migrationBuilder.DropColumn(
                name: "deleted_at",
                table: "masterjabatan");

            migrationBuilder.DropColumn(
                name: "id",
                table: "masterjabatan");

            migrationBuilder.DropColumn(
                name: "updated_at",
                table: "masterjabatan");
        }
    }
}
