using Microsoft.EntityFrameworkCore.Migrations;

namespace Homework_07112021.Migrations
{
    public partial class Modify_ParticipantsSportsMedals_ParticipantId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParticipantsSportsMedals_Participants_ParticipantId",
                table: "ParticipantsSportsMedals");

            migrationBuilder.DropColumn(
                name: "PartId",
                table: "ParticipantsSportsMedals");

            migrationBuilder.AlterColumn<int>(
                name: "ParticipantId",
                table: "ParticipantsSportsMedals",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ParticipantsSportsMedals_Participants_ParticipantId",
                table: "ParticipantsSportsMedals",
                column: "ParticipantId",
                principalTable: "Participants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParticipantsSportsMedals_Participants_ParticipantId",
                table: "ParticipantsSportsMedals");

            migrationBuilder.AlterColumn<int>(
                name: "ParticipantId",
                table: "ParticipantsSportsMedals",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "PartId",
                table: "ParticipantsSportsMedals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_ParticipantsSportsMedals_Participants_ParticipantId",
                table: "ParticipantsSportsMedals",
                column: "ParticipantId",
                principalTable: "Participants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
