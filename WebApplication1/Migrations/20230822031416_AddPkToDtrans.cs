using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace DoranOfficeBackend.Migrations
{
    public partial class AddPkToDtrans : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("ALTER TABLE dtrans ADD COLUMN id INT NOT NULL AUTO_INCREMENT, ADD CONSTRAINT PK_dtrans PRIMARY KEY(id);", true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_dtrans",
                table: "dtrans");

            migrationBuilder.DropColumn(
                name: "id",
                table: "dtrans");
        }
    }
}
