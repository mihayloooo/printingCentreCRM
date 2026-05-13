using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrintingCentre.Management.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ConnectWorkOrederWithTemplateAndEnvelope : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_WorkOrderSequenceTemplates_PrintTemplateId",
                table: "WorkOrderSequenceTemplates",
                column: "PrintTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrderSequenceEnvelopes_EnvelopeId",
                table: "WorkOrderSequenceEnvelopes",
                column: "EnvelopeId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkOrderSequenceEnvelopes_Envelopes_EnvelopeId",
                table: "WorkOrderSequenceEnvelopes",
                column: "EnvelopeId",
                principalTable: "Envelopes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkOrderSequenceTemplates_PrintTemplates_PrintTemplateId",
                table: "WorkOrderSequenceTemplates",
                column: "PrintTemplateId",
                principalTable: "PrintTemplates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkOrderSequenceEnvelopes_Envelopes_EnvelopeId",
                table: "WorkOrderSequenceEnvelopes");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkOrderSequenceTemplates_PrintTemplates_PrintTemplateId",
                table: "WorkOrderSequenceTemplates");

            migrationBuilder.DropIndex(
                name: "IX_WorkOrderSequenceTemplates_PrintTemplateId",
                table: "WorkOrderSequenceTemplates");

            migrationBuilder.DropIndex(
                name: "IX_WorkOrderSequenceEnvelopes_EnvelopeId",
                table: "WorkOrderSequenceEnvelopes");
        }
    }
}
