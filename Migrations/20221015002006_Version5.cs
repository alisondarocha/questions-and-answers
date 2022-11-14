using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Q.A.__social_network.Migrations
{
    public partial class Version5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserIdUser",
                table: "Questions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserModelIdUser",
                table: "Questions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Questions_UserIdUser",
                table: "Questions",
                column: "UserIdUser");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Users_UserIdUser",
                table: "Questions",
                column: "UserIdUser",
                principalTable: "Users",
                principalColumn: "IdUser");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Users_UserIdUser",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Questions_UserIdUser",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "UserIdUser",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "UserModelIdUser",
                table: "Questions");
        }
    }
}
