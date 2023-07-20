using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DoranOfficeBackend.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "char(36)", nullable: false),
                    name = table.Column<string>(type: "varchar(255)", nullable: false),
                    active = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValueSql: "'1'"),
                    created_at = table.Column<DateTime>(type: "timestamp", nullable: true, defaultValueSql: "NULL"),
                    updated_at = table.Column<DateTime>(type: "timestamp", nullable: true, defaultValueSql: "NULL"),
                    deleted_at = table.Column<DateTime>(type: "timestamp", nullable: true, defaultValueSql: "NULL")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "saleschannels",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "char(36)", nullable: false),
                    name = table.Column<string>(type: "varchar(100)", nullable: false),
                    active = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_saleschannels", x => x.id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "salesteams",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "char(36)", nullable: false),
                    name = table.Column<string>(type: "varchar(100)", nullable: false),
                    sales_channel_id = table.Column<Guid>(type: "char(36)", nullable: false),
                    jete_target = table.Column<ulong>(type: "bigint unsigned", nullable: false),
                    omzet_target = table.Column<ulong>(type: "bigint unsigned", nullable: false),
                    show_last_year = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    commission_terms = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    active = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_salesteams", x => x.id);
                    table.ForeignKey(
                        name: "sales_sales_channel_id_foreign",
                        column: x => x.sales_channel_id,
                        principalTable: "saleschannels",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "sales",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "char(36)", nullable: false),
                    name = table.Column<string>(type: "varchar(100)", nullable: false),
                    sales_team_id = table.Column<Guid>(type: "char(36)", nullable: false),
                    is_manager = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    manager_id = table.Column<Guid>(type: "char(36)", nullable: true),
                    get_omzet_email = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    active = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp", nullable: true),
                    updated_at = table.Column<DateTime>(type: "timestamp", nullable: true),
                    deleted_at = table.Column<DateTime>(type: "timestamp", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sales", x => x.id);
                    table.ForeignKey(
                        name: "FK_sales_sales_manager_id",
                        column: x => x.manager_id,
                        principalTable: "sales",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "sales_sales_team_id_foreign",
                        column: x => x.sales_team_id,
                        principalTable: "salesteams",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "char(36)", nullable: false),
                    username = table.Column<string>(type: "varchar(255)", nullable: false),
                    password = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    passwordText = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    api_token = table.Column<string>(type: "varchar(255)", nullable: true, defaultValueSql: "NULL"),
                    role_id = table.Column<Guid>(type: "char(36)", nullable: false),
                    sales_id = table.Column<Guid>(type: "char(36)", nullable: true),
                    remember_token = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true, defaultValueSql: "NULL"),
                    active = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValueSql: "'1'"),
                    created_at = table.Column<DateTime>(type: "timestamp", nullable: true, defaultValueSql: "NULL"),
                    updated_at = table.Column<DateTime>(type: "timestamp", nullable: true, defaultValueSql: "NULL"),
                    deleted_at = table.Column<DateTime>(type: "timestamp", nullable: true, defaultValueSql: "NULL")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.id);
                    table.ForeignKey(
                        name: "users_role_id_foreign",
                        column: x => x.role_id,
                        principalTable: "roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "users_sales_id_foreign",
                        column: x => x.sales_id,
                        principalTable: "sales",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "id", "active", "name" },
                values: new object[] { new Guid("60e5c903-93ab-4142-a202-73873dfc71b9"), false, "superadmin" });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "active", "password", "passwordText", "role_id", "sales_id", "username" },
                values: new object[] { new Guid("dd271bd1-e883-4d96-a82c-c11d6fbc9862"), false, "$2a$11$.aWnw4S5hS8YElM0ZSE1r.QxsLfeekSHLYspJWr9sGqRH0Paeseui", "superadmin", new Guid("60e5c903-93ab-4142-a202-73873dfc71b9"), null, "superadmin" });

            migrationBuilder.CreateIndex(
                name: "roles_name_unique",
                table: "roles",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_sales_manager_id",
                table: "sales",
                column: "manager_id");

            migrationBuilder.CreateIndex(
                name: "IX_sales_sales_team_id",
                table: "sales",
                column: "sales_team_id");

            migrationBuilder.CreateIndex(
                name: "IX_salesteams_sales_channel_id",
                table: "salesteams",
                column: "sales_channel_id");

            migrationBuilder.CreateIndex(
                name: "IX_users_sales_id",
                table: "users",
                column: "sales_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "users_api_token_unique",
                table: "users",
                column: "api_token",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "users_role_id_foreign",
                table: "users",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "users_username_unique",
                table: "users",
                column: "username",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "roles");

            migrationBuilder.DropTable(
                name: "sales");

            migrationBuilder.DropTable(
                name: "salesteams");

            migrationBuilder.DropTable(
                name: "saleschannels");
        }
    }
}
