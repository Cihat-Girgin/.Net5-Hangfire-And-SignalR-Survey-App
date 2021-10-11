using Microsoft.EntityFrameworkCore.Migrations;

namespace RealTimeApp.Api.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BackendFrameworks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BackendFrameworks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SurveyItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BackendFrameworkId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyItems", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "BackendFrameworks",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, ".Net Core" },
                    { 2, "Spring Boot" },
                    { 3, "Ruby" },
                    { 4, "Laravel" },
                    { 5, "ExpressJs" },
                    { 6, "Django" },
                    { 7, "Koa" },
                    { 8, "Flask" },
                    { 9, "Symfony" },
                    { 10, "Phoenix" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BackendFrameworks");

            migrationBuilder.DropTable(
                name: "SurveyItems");
        }
    }
}
