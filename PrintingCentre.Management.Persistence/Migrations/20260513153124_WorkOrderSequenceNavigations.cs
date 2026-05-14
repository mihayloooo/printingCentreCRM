using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrintingCentre.Management.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class WorkOrderSequenceNavigations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkOrderSequenceEnvelopes_Envelopes_EnvelopeId",
                table: "WorkOrderSequenceEnvelopes");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkOrderSequenceEnvelopes_WorkOrders_WorkOrderId",
                table: "WorkOrderSequenceEnvelopes");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkOrderSequenceTemplates_PrintTemplates_PrintTemplateId",
                table: "WorkOrderSequenceTemplates");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkOrderSequenceTemplates_WorkOrders_WorkOrderId",
                table: "WorkOrderSequenceTemplates");

            migrationBuilder.AddColumn<Guid>(
                name: "FlowSequenceId",
                table: "WorkOrderSequenceTemplates",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "FlowSequenceId",
                table: "WorkOrderSequenceEnvelopes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrderSequenceTemplates_FlowSequenceId",
                table: "WorkOrderSequenceTemplates",
                column: "FlowSequenceId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrderSequenceEnvelopes_FlowSequenceId",
                table: "WorkOrderSequenceEnvelopes",
                column: "FlowSequenceId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkOrderSequenceEnvelopes_Envelopes_EnvelopeId",
                table: "WorkOrderSequenceEnvelopes",
                column: "EnvelopeId",
                principalTable: "Envelopes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkOrderSequenceEnvelopes_FlowSequences_FlowSequenceId",
                table: "WorkOrderSequenceEnvelopes",
                column: "FlowSequenceId",
                principalTable: "FlowSequences",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkOrderSequenceEnvelopes_WorkOrders_WorkOrderId",
                table: "WorkOrderSequenceEnvelopes",
                column: "WorkOrderId",
                principalTable: "WorkOrders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkOrderSequenceTemplates_FlowSequences_FlowSequenceId",
                table: "WorkOrderSequenceTemplates",
                column: "FlowSequenceId",
                principalTable: "FlowSequences",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkOrderSequenceTemplates_PrintTemplates_PrintTemplateId",
                table: "WorkOrderSequenceTemplates",
                column: "PrintTemplateId",
                principalTable: "PrintTemplates",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkOrderSequenceTemplates_WorkOrders_WorkOrderId",
                table: "WorkOrderSequenceTemplates",
                column: "WorkOrderId",
                principalTable: "WorkOrders",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkOrderSequenceEnvelopes_Envelopes_EnvelopeId",
                table: "WorkOrderSequenceEnvelopes");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkOrderSequenceEnvelopes_FlowSequences_FlowSequenceId",
                table: "WorkOrderSequenceEnvelopes");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkOrderSequenceEnvelopes_WorkOrders_WorkOrderId",
                table: "WorkOrderSequenceEnvelopes");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkOrderSequenceTemplates_FlowSequences_FlowSequenceId",
                table: "WorkOrderSequenceTemplates");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkOrderSequenceTemplates_PrintTemplates_PrintTemplateId",
                table: "WorkOrderSequenceTemplates");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkOrderSequenceTemplates_WorkOrders_WorkOrderId",
                table: "WorkOrderSequenceTemplates");

            migrationBuilder.DropIndex(
                name: "IX_WorkOrderSequenceTemplates_FlowSequenceId",
                table: "WorkOrderSequenceTemplates");

            migrationBuilder.DropIndex(
                name: "IX_WorkOrderSequenceEnvelopes_FlowSequenceId",
                table: "WorkOrderSequenceEnvelopes");

            migrationBuilder.DropColumn(
                name: "FlowSequenceId",
                table: "WorkOrderSequenceTemplates");

            migrationBuilder.DropColumn(
                name: "FlowSequenceId",
                table: "WorkOrderSequenceEnvelopes");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkOrderSequenceEnvelopes_Envelopes_EnvelopeId",
                table: "WorkOrderSequenceEnvelopes",
                column: "EnvelopeId",
                principalTable: "Envelopes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkOrderSequenceEnvelopes_WorkOrders_WorkOrderId",
                table: "WorkOrderSequenceEnvelopes",
                column: "WorkOrderId",
                principalTable: "WorkOrders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkOrderSequenceTemplates_PrintTemplates_PrintTemplateId",
                table: "WorkOrderSequenceTemplates",
                column: "PrintTemplateId",
                principalTable: "PrintTemplates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkOrderSequenceTemplates_WorkOrders_WorkOrderId",
                table: "WorkOrderSequenceTemplates",
                column: "WorkOrderId",
                principalTable: "WorkOrders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
