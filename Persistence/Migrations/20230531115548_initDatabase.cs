using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SamianSoft.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class initDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ObjectTemplates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateUserId = table.Column<int>(type: "int", nullable: false),
                    RequestUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SessionId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientIP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequestId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HttpMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Host = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Agent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    XClientVersion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    XClientName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApiVersion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObjectTemplates", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ObjectTemplates");
        }
    }
}
