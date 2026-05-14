using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrintingCentre.Management.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddWorkOrderSequence : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.RenameColumn(
                name: "WorkOrderId",
                table: "WorkOrderSequenceTemplates",
                newName: "WorkOrderSequenceId");

            migrationBuilder.RenameIndex(
                name: "IX_WorkOrderSequenceTemplates_WorkOrderId",
                table: "WorkOrderSequenceTemplates",
                newName: "IX_WorkOrderSequenceTemplates_WorkOrderSequenceId");

            migrationBuilder.RenameColumn(
                name: "WorkOrderId",
                table: "WorkOrderSequenceEnvelopes",
                newName: "WorkOrderSequenceId");

            migrationBuilder.RenameIndex(
                name: "IX_WorkOrderSequenceEnvelopes_WorkOrderId",
                table: "WorkOrderSequenceEnvelopes",
                newName: "IX_WorkOrderSequenceEnvelopes_WorkOrderSequenceId");

            migrationBuilder.CreateTable(
                name: "WorkOrderSequences",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WorkOrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FlowSequenceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkOrderSequences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkOrderSequences_FlowSequences_FlowSequenceId",
                        column: x => x.FlowSequenceId,
                        principalTable: "FlowSequences",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WorkOrderSequences_WorkOrders_WorkOrderId",
                        column: x => x.WorkOrderId,
                        principalTable: "WorkOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrderSequences_FlowSequenceId",
                table: "WorkOrderSequences",
                column: "FlowSequenceId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrderSequences_WorkOrderId",
                table: "WorkOrderSequences",
                column: "WorkOrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkOrderSequenceEnvelopes_WorkOrderSequences_WorkOrderSequenceId",
                table: "WorkOrderSequenceEnvelopes",
                column: "WorkOrderSequenceId",
                principalTable: "WorkOrderSequences",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkOrderSequenceTemplates_WorkOrderSequences_WorkOrderSequenceId",
                table: "WorkOrderSequenceTemplates",
                column: "WorkOrderSequenceId",
                principalTable: "WorkOrderSequences",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkOrderSequenceEnvelopes_WorkOrderSequences_WorkOrderSequenceId",
                table: "WorkOrderSequenceEnvelopes");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkOrderSequenceTemplates_WorkOrderSequences_WorkOrderSequenceId",
                table: "WorkOrderSequenceTemplates");

            migrationBuilder.DropTable(
                name: "WorkOrderSequences");

            migrationBuilder.RenameColumn(
                name: "WorkOrderSequenceId",
                table: "WorkOrderSequenceTemplates",
                newName: "WorkOrderId");

            migrationBuilder.RenameIndex(
                name: "IX_WorkOrderSequenceTemplates_WorkOrderSequenceId",
                table: "WorkOrderSequenceTemplates",
                newName: "IX_WorkOrderSequenceTemplates_WorkOrderId");

            migrationBuilder.RenameColumn(
                name: "WorkOrderSequenceId",
                table: "WorkOrderSequenceEnvelopes",
                newName: "WorkOrderId");

            migrationBuilder.RenameIndex(
                name: "IX_WorkOrderSequenceEnvelopes_WorkOrderSequenceId",
                table: "WorkOrderSequenceEnvelopes",
                newName: "IX_WorkOrderSequenceEnvelopes_WorkOrderId");

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
                name: "FK_WorkOrderSequenceTemplates_WorkOrders_WorkOrderId",
                table: "WorkOrderSequenceTemplates",
                column: "WorkOrderId",
                principalTable: "WorkOrders",
                principalColumn: "Id");
        }
    }
}
