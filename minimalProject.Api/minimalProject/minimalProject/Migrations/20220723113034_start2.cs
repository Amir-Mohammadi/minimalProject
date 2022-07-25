using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace minimalProject.Migrations
{
    public partial class start2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ipDetects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ip = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    continent_code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    continent_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    country_code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    country_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    region_code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    region_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    city = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    zip = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    latitude = table.Column<double>(type: "float", nullable: false),
                    longitude = table.Column<double>(type: "float", nullable: false),
                    country_flag = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    country_flag_emoji = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    country_flag_emoji_unicode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    calling_code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    is_eu = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ipDetects", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ipDetects");
        }
    }
}
