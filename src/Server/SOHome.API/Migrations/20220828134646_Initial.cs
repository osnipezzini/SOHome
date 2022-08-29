using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SOHome.API.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "grid_seq");

            migrationBuilder.CreateSequence(
                name: "person_code_seq");

            migrationBuilder.CreateSequence(
                name: "product_code_seq");

            migrationBuilder.CreateTable(
                name: "people",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "NEXTVAL('grid_seq')"),
                    code = table.Column<int>(type: "integer", nullable: true, defaultValueSql: "NEXTVAL('person_code_seq')"),
                    document = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    street_name = table.Column<string>(type: "text", nullable: true),
                    street_number = table.Column<string>(type: "text", nullable: true),
                    district = table.Column<string>(type: "text", nullable: true),
                    city = table.Column<string>(type: "text", nullable: true),
                    state = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_people", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "NEXTVAL('grid_seq')"),
                    code = table.Column<int>(type: "integer", nullable: true, defaultValueSql: "NEXTVAL('product_code_seq')"),
                    barcode = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    price = table.Column<decimal>(type: "numeric", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_products", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "people");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropSequence(
                name: "grid_seq");

            migrationBuilder.DropSequence(
                name: "person_code_seq");

            migrationBuilder.DropSequence(
                name: "product_code_seq");
        }
    }
}
