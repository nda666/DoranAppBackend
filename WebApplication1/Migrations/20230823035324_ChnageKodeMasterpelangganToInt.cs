using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace DoranOfficeBackend.Migrations
{
    public partial class ChnageKodeMasterpelangganToInt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
           name: "kode",
           table: "masterpelanggan",
           type: "int(11)",
           nullable: false,
           oldClrType: typeof(short),
           oldType: "short(6)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<short>(
           name: "kode",
           table: "masterpelanggan",
           type: "smallint(6)",
           nullable: false,
           oldClrType: typeof(int),
           oldType: "int(11)");
        }
    }
}
