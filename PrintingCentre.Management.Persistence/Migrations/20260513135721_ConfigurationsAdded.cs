using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrintingCentre.Management.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ConfigurationsAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Drop the orphaned Envelopes table created by CreateEnvelopeTable migration
            // (superseded by the Envelope table created in AddFlowEntities which has FK to FlowSequences)
            migrationBuilder.DropTable(
                name: "Envelopes");

            migrationBuilder.DropForeignKey(
                name: "FK_Envelope_FlowSequences_FlowSequenceId",
                table: "Envelope");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Envelope",
                table: "Envelope");

            migrationBuilder.RenameTable(
                name: "Envelope",
                newName: "Envelopes");

            migrationBuilder.RenameIndex(
                name: "IX_Envelope_FlowSequenceId",
                table: "Envelopes",
                newName: "IX_Envelopes_FlowSequenceId");

            migrationBuilder.AlterColumn<string>(
                name: "ShipmentType",
                table: "FlowSequences",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "PrintSide",
                table: "FlowSequences",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "FlowSequences",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ColorMode",
                table: "FlowSequences",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Flows",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Envelopes",
                type: "nvarchar(12)",
                maxLength: 12,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Envelopes",
                table: "Envelopes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Envelopes_FlowSequences_FlowSequenceId",
                table: "Envelopes",
                column: "FlowSequenceId",
                principalTable: "FlowSequences",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Envelopes_FlowSequences_FlowSequenceId",
                table: "Envelopes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Envelopes",
                table: "Envelopes");

            migrationBuilder.RenameTable(
                name: "Envelopes",
                newName: "Envelope");

            migrationBuilder.RenameIndex(
                name: "IX_Envelopes_FlowSequenceId",
                table: "Envelope",
                newName: "IX_Envelope_FlowSequenceId");

            migrationBuilder.AlterColumn<int>(
                name: "ShipmentType",
                table: "FlowSequences",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "PrintSide",
                table: "FlowSequences",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "FlowSequences",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<int>(
                name: "ColorMode",
                table: "FlowSequences",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Flows",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Envelope",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(12)",
                oldMaxLength: 12);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Envelope",
                table: "Envelope",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Envelope_FlowSequences_FlowSequenceId",
                table: "Envelope",
                column: "FlowSequenceId",
                principalTable: "FlowSequences",
                principalColumn: "Id");

            // Recreate the orphaned Envelopes table that existed before this migration
            migrationBuilder.CreateTable(
                name: "Envelopes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    EnvelopeUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuantityInStock = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Envelopes", x => x.Id);
                });
        }
    }
}
