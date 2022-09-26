using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SOHome.API.Migrations
{
    public partial class CreateExerciseTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "exercise_code_seq");

            migrationBuilder.CreateTable(
                name: "exercises",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false, defaultValueSql: "NEXTVAL('grid_seq')"),
                    code = table.Column<int>(type: "integer", nullable: false, defaultValueSql: "NEXTVAL('product_code_seq')"),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    exercise_type = table.Column<int>(type: "integer", nullable: false),
                    images = table.Column<List<string>>(type: "text[]", nullable: false),
                    user_id = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_exercises", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "exercises");

            migrationBuilder.DropSequence(
                name: "exercise_code_seq");
        }
    }
}
