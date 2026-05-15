using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrintingCentre.Management.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class IntroduceFlowSequenceJunctionEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EnvelopeFlowSequence");

            migrationBuilder.DropTable(
                name: "FlowSequencePrintTemplate");

            migrationBuilder.CreateTable(
                name: "FlowSequenceEnvelopes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FlowSequenceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EnvelopeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlowSequenceEnvelopes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FlowSequenceEnvelopes_Envelopes_EnvelopeId",
                        column: x => x.EnvelopeId,
                        principalTable: "Envelopes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FlowSequenceEnvelopes_FlowSequences_FlowSequenceId",
                        column: x => x.FlowSequenceId,
                        principalTable: "FlowSequences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FlowSequencePrintTemplates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FlowSequenceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PrintTemplateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlowSequencePrintTemplates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FlowSequencePrintTemplates_FlowSequences_FlowSequenceId",
                        column: x => x.FlowSequenceId,
                        principalTable: "FlowSequences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FlowSequencePrintTemplates_PrintTemplates_PrintTemplateId",
                        column: x => x.PrintTemplateId,
                        principalTable: "PrintTemplates",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_FlowSequenceEnvelopes_EnvelopeId",
                table: "FlowSequenceEnvelopes",
                column: "EnvelopeId");

            migrationBuilder.CreateIndex(
                name: "IX_FlowSequenceEnvelopes_FlowSequenceId",
                table: "FlowSequenceEnvelopes",
                column: "FlowSequenceId");

            migrationBuilder.CreateIndex(
                name: "IX_FlowSequencePrintTemplates_FlowSequenceId",
                table: "FlowSequencePrintTemplates",
                column: "FlowSequenceId");

            migrationBuilder.CreateIndex(
                name: "IX_FlowSequencePrintTemplates_PrintTemplateId",
                table: "FlowSequencePrintTemplates",
                column: "PrintTemplateId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FlowSequenceEnvelopes");

            migrationBuilder.DropTable(
                name: "FlowSequencePrintTemplates");

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
    }
}
