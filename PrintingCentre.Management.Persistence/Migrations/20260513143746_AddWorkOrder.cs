using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrintingCentre.Management.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddWorkOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Envelopes_FlowSequences_FlowSequenceId",
                table: "Envelopes");

            migrationBuilder.DropForeignKey(
                name: "FK_PrintTemplates_FlowSequences_FlowSequenceId",
                table: "PrintTemplates");

            migrationBuilder.DropIndex(
                name: "IX_PrintTemplates_FlowSequenceId",
                table: "PrintTemplates");

            migrationBuilder.DropIndex(
                name: "IX_Envelopes_FlowSequenceId",
                table: "Envelopes");

            migrationBuilder.DropColumn(
                name: "FlowSequenceId",
                table: "PrintTemplates");

            migrationBuilder.DropColumn(
                name: "FlowSequenceId",
                table: "Envelopes");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "FlowSequences",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "FlowSequences",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "FlowSequences",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                table: "FlowSequences",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Flows",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Flows",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "Flows",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                table: "Flows",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "EnvelopeFlowSequence",
                columns: table => new
                {
                    EnvelopesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FlowSequencesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnvelopeFlowSequence", x => new { x.EnvelopesId, x.FlowSequencesId });
                    table.ForeignKey(
                        name: "FK_EnvelopeFlowSequence_Envelopes_EnvelopesId",
                        column: x => x.EnvelopesId,
                        principalTable: "Envelopes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EnvelopeFlowSequence_FlowSequences_FlowSequencesId",
                        column: x => x.FlowSequencesId,
                        principalTable: "FlowSequences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FlowSequencePrintTemplate",
                columns: table => new
                {
                    FlowSequencesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PrintTemplatesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlowSequencePrintTemplate", x => new { x.FlowSequencesId, x.PrintTemplatesId });
                    table.ForeignKey(
                        name: "FK_FlowSequencePrintTemplate_FlowSequences_FlowSequencesId",
                        column: x => x.FlowSequencesId,
                        principalTable: "FlowSequences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FlowSequencePrintTemplate_PrintTemplates_PrintTemplatesId",
                        column: x => x.PrintTemplatesId,
                        principalTable: "PrintTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EnvelopeFlowSequence_FlowSequencesId",
                table: "EnvelopeFlowSequence",
                column: "FlowSequencesId");

            migrationBuilder.CreateIndex(
                name: "IX_FlowSequencePrintTemplate_PrintTemplatesId",
                table: "FlowSequencePrintTemplate",
                column: "PrintTemplatesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EnvelopeFlowSequence");

            migrationBuilder.DropTable(
                name: "FlowSequencePrintTemplate");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "FlowSequences");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "FlowSequences");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "FlowSequences");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                table: "FlowSequences");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Flows");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Flows");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Flows");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                table: "Flows");

            migrationBuilder.AddColumn<Guid>(
                name: "FlowSequenceId",
                table: "PrintTemplates",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "FlowSequenceId",
                table: "Envelopes",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PrintTemplates_FlowSequenceId",
                table: "PrintTemplates",
                column: "FlowSequenceId");

            migrationBuilder.CreateIndex(
                name: "IX_Envelopes_FlowSequenceId",
                table: "Envelopes",
                column: "FlowSequenceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Envelopes_FlowSequences_FlowSequenceId",
                table: "Envelopes",
                column: "FlowSequenceId",
                principalTable: "FlowSequences",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PrintTemplates_FlowSequences_FlowSequenceId",
                table: "PrintTemplates",
                column: "FlowSequenceId",
                principalTable: "FlowSequences",
                principalColumn: "Id");
        }
    }
}
