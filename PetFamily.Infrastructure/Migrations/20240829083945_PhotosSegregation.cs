using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetFamily.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class PhotosSegregation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_photos_pets_pet_id",
                table: "photos");

            migrationBuilder.DropForeignKey(
                name: "fk_photos_volunteers_volunteer_id",
                table: "photos");

            migrationBuilder.DropPrimaryKey(
                name: "pk_photos",
                table: "photos");

            migrationBuilder.DropIndex(
                name: "ix_photos_pet_id",
                table: "photos");

            migrationBuilder.DropColumn(
                name: "pet_id",
                table: "photos");

            migrationBuilder.RenameTable(
                name: "photos",
                newName: "volunteer_photos");

            migrationBuilder.RenameIndex(
                name: "ix_photos_volunteer_id",
                table: "volunteer_photos",
                newName: "ix_volunteer_photos_volunteer_id");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "created_date",
                table: "pets",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2024, 8, 29, 8, 39, 44, 990, DateTimeKind.Unspecified).AddTicks(5083), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2024, 8, 26, 13, 54, 7, 250, DateTimeKind.Unspecified).AddTicks(7680), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<Guid>(
                name: "volunteer_id",
                table: "volunteer_photos",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "pk_volunteer_photos",
                table: "volunteer_photos",
                column: "id");

            migrationBuilder.CreateTable(
                name: "pet_photos",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    path = table.Column<string>(type: "text", nullable: false),
                    is_main = table.Column<bool>(type: "boolean", nullable: false),
                    pet_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_pet_photos", x => x.id);
                    table.ForeignKey(
                        name: "fk_pet_photos_pets_pet_id",
                        column: x => x.pet_id,
                        principalTable: "pets",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_pet_photos_pet_id",
                table: "pet_photos",
                column: "pet_id");

            migrationBuilder.AddForeignKey(
                name: "fk_volunteer_photos_volunteers_volunteer_id",
                table: "volunteer_photos",
                column: "volunteer_id",
                principalTable: "volunteers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_volunteer_photos_volunteers_volunteer_id",
                table: "volunteer_photos");

            migrationBuilder.DropTable(
                name: "pet_photos");

            migrationBuilder.DropPrimaryKey(
                name: "pk_volunteer_photos",
                table: "volunteer_photos");

            migrationBuilder.RenameTable(
                name: "volunteer_photos",
                newName: "photos");

            migrationBuilder.RenameIndex(
                name: "ix_volunteer_photos_volunteer_id",
                table: "photos",
                newName: "ix_photos_volunteer_id");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "created_date",
                table: "pets",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(2024, 8, 26, 13, 54, 7, 250, DateTimeKind.Unspecified).AddTicks(7680), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "timestamp with time zone",
                oldDefaultValue: new DateTimeOffset(new DateTime(2024, 8, 29, 8, 39, 44, 990, DateTimeKind.Unspecified).AddTicks(5083), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AlterColumn<Guid>(
                name: "volunteer_id",
                table: "photos",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<Guid>(
                name: "pet_id",
                table: "photos",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "pk_photos",
                table: "photos",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "ix_photos_pet_id",
                table: "photos",
                column: "pet_id");

            migrationBuilder.AddForeignKey(
                name: "fk_photos_pets_pet_id",
                table: "photos",
                column: "pet_id",
                principalTable: "pets",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_photos_volunteers_volunteer_id",
                table: "photos",
                column: "volunteer_id",
                principalTable: "volunteers",
                principalColumn: "id");
        }
    }
}
