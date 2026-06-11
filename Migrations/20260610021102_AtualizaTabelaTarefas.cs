using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Make_Me.Migrations
{
    /// <inheritdoc />
    public partial class AtualizaTabelaTarefas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DataInicio",
                table: "Tarefas",
                newName: "DataConclusao");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DataConclusao",
                table: "Tarefas",
                newName: "DataInicio");
        }
    }
}
