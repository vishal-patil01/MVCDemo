using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStore.DomainModels.Migrations
{
    public partial class Added_User_Roles_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User_Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserIdID = table.Column<int>(type: "int", nullable: true),
                    RoleIdId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Roles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Roles_Roles_RoleIdId",
                        column: x => x.RoleIdId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_Roles_User_UserIdID",
                        column: x => x.UserIdID,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_Roles_RoleIdId",
                table: "User_Roles",
                column: "RoleIdId");

            migrationBuilder.CreateIndex(
                name: "IX_User_Roles_UserIdID",
                table: "User_Roles",
                column: "UserIdID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User_Roles");
        }
    }
}
