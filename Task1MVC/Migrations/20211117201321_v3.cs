using Microsoft.EntityFrameworkCore.Migrations;

namespace Task1MVC.Migrations
{
    public partial class v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_employee_department_departmentId",
                table: "employee");

            migrationBuilder.DropIndex(
                name: "IX_employee_departmentId",
                table: "employee");

            migrationBuilder.DropColumn(
                name: "departmentId",
                table: "employee");

            migrationBuilder.CreateIndex(
                name: "IX_employee_Department_id",
                table: "employee",
                column: "Department_id");

            migrationBuilder.AddForeignKey(
                name: "FK_employee_department_Department_id",
                table: "employee",
                column: "Department_id",
                principalTable: "department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_employee_department_Department_id",
                table: "employee");

            migrationBuilder.DropIndex(
                name: "IX_employee_Department_id",
                table: "employee");

            migrationBuilder.AddColumn<int>(
                name: "departmentId",
                table: "employee",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_employee_departmentId",
                table: "employee",
                column: "departmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_employee_department_departmentId",
                table: "employee",
                column: "departmentId",
                principalTable: "department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
