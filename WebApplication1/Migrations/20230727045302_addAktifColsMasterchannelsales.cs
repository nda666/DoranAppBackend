using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace DoranOfficeBackend.Migrations
{
    public partial class addAktifColsMasterchannelsales : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("ALTER TABLE `masterchannelsales` ADD `aktif` tinyint(1) NOT NULL DEFAULT TRUE AFTER `nama`");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
         

            migrationBuilder.DropColumn(
                name: "Aktif",
                table: "masterchannelsales");
            
        }
    }
}
