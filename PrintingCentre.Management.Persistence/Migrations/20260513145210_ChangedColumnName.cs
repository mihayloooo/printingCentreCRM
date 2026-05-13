using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrintingCentre.Management.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ChangedColumnName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PrintPages",
                table: "WorkOrderSequenceTemplates",
                newName: "PrintedPages");

            migrationBuilder.RenameColumn(
                name: "PrintPages",
                table: "WorkOrderSequenceEnvelopes",
                newName: "EnvelopedItems");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PrintedPages",
                table: "WorkOrderSequenceTemplates",
                newName: "PrintPages");

            migrationBuilder.RenameColumn(
                name: "EnvelopedItems",
                table: "WorkOrderSequenceEnvelopes",
                newName: "PrintPages");
        }
    }
}
