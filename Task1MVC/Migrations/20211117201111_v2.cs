using Microsoft.EntityFrameworkCore.Migrations;

namespace Task1MVC.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_employee_country_Country_id",
                table: "employee");

            migrationBuilder.DropForeignKey(
                name: "FK_employee_department_Department_id",
                table: "employee");

            migrationBuilder.DropIndex(
                name: "IX_employee_Country_id",
                table: "employee");

            migrationBuilder.DropIndex(
                name: "IX_employee_Department_id",
                table: "employee");

            migrationBuilder.DropColumn(
                name: "Country_id",
                table: "employee");

            migrationBuilder.AddColumn<int>(
                name: "departmentId",
                table: "employee",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Country_id",
                table: "city",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_employee_departmentId",
                table: "employee",
                column: "departmentId");

            migrationBuilder.CreateIndex(
                name: "IX_city_Country_id",
                table: "city",
                column: "Country_id");

            migrationBuilder.AddForeignKey(
                name: "FK_city_country_Country_id",
                table: "city",
                column: "Country_id",
                principalTable: "country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_employee_department_departmentId",
                table: "employee",
                column: "departmentId",
                principalTable: "department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_city_country_Country_id",
                table: "city");

            migrationBuilder.DropForeignKey(
                name: "FK_employee_department_departmentId",
                table: "employee");

            migrationBuilder.DropIndex(
                name: "IX_employee_departmentId",
                table: "employee");

            migrationBuilder.DropIndex(
                name: "IX_city_Country_id",
                table: "city");

            migrationBuilder.DropColumn(
                name: "departmentId",
                table: "employee");

            migrationBuilder.DropColumn(
                name: "Country_id",
                table: "city");

            migrationBuilder.AddColumn<int>(
                name: "Country_id",
                table: "employee",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_employee_Country_id",
                table: "employee",
                column: "Country_id");

            migrationBuilder.CreateIndex(
                name: "IX_employee_Department_id",
                table: "employee",
                column: "Department_id");

            migrationBuilder.AddForeignKey(
                name: "FK_employee_country_Country_id",
                table: "employee",
                column: "Country_id",
                principalTable: "country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_employee_department_Department_id",
                table: "employee",
                column: "Department_id",
                principalTable: "department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
