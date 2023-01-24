using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace univercityApiBackend.Migrations
{
    /// <inheritdoc />
    public partial class Createuserstable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Requisitos",
                table: "cursos",
                newName: "TargetAudiences");

            migrationBuilder.RenameColumn(
                name: "Publico_objetivo",
                table: "cursos",
                newName: "Requirements");

            migrationBuilder.RenameColumn(
                name: "Objetivos",
                table: "cursos",
                newName: "Objectives");

            migrationBuilder.RenameColumn(
                name: "Nivel",
                table: "cursos",
                newName: "LongDescription");

            migrationBuilder.RenameColumn(
                name: "Descripcion_larga",
                table: "cursos",
                newName: "DeletedBy");

            migrationBuilder.RenameColumn(
                name: "Descripcion_corta",
                table: "cursos",
                newName: "ShortDescription");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "cursos",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "cursos",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "cursos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Level",
                table: "cursos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpDateAt",
                table: "cursos",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpDatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpDateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "cursos");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "cursos");

            migrationBuilder.DropColumn(
                name: "Level",
                table: "cursos");

            migrationBuilder.DropColumn(
                name: "UpDateAt",
                table: "cursos");

            migrationBuilder.RenameColumn(
                name: "TargetAudiences",
                table: "cursos",
                newName: "Requisitos");

            migrationBuilder.RenameColumn(
                name: "ShortDescription",
                table: "cursos",
                newName: "Descripcion_corta");

            migrationBuilder.RenameColumn(
                name: "Requirements",
                table: "cursos",
                newName: "Publico_objetivo");

            migrationBuilder.RenameColumn(
                name: "Objectives",
                table: "cursos",
                newName: "Objetivos");

            migrationBuilder.RenameColumn(
                name: "LongDescription",
                table: "cursos",
                newName: "Nivel");

            migrationBuilder.RenameColumn(
                name: "DeletedBy",
                table: "cursos",
                newName: "Descripcion_larga");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "cursos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);
        }
    }
}
