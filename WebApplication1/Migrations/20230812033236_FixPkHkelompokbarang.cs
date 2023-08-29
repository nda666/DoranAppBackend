using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace DoranOfficeBackend.Migrations
{
    public partial class FixPkHkelompokbarang : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
            name: "kode",
            table: "hkelompokbarang",
            type: "int(11)",
            nullable: false,
            oldClrType: typeof(int),
            oldType: "int(11)")
            .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
            name: "kode",
            table: "hkelompokbarang",
            type: "int(11)",
            nullable: false,
            oldClrType: typeof(int),
            oldType: "int(11)");
        }
    }
}
