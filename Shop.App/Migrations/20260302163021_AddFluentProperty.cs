using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop.App.Migrations
{
    /// <inheritdoc />
    public partial class AddFluentProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PrimaryKey_UserId",
                table: "Users",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.AddCheckConstraint(
                name: "MinNameLength",
                table: "Users",
                sql: "LEN(Name) >= 1");

            migrationBuilder.AddCheckConstraint(
                name: "MinSurNameLength",
                table: "Users",
                sql: "LEN(SurName) >= 1");

            migrationBuilder.AddCheckConstraint(
                name: "RoleCheck",
                table: "Users",
                sql: "[Role] BETWEEN 0 AND 3");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PrimaryKey_UserId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_Email",
                table: "Users");

            migrationBuilder.DropCheckConstraint(
                name: "MinNameLength",
                table: "Users");

            migrationBuilder.DropCheckConstraint(
                name: "MinSurNameLength",
                table: "Users");

            migrationBuilder.DropCheckConstraint(
                name: "RoleCheck",
                table: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");
        }
    }
}
