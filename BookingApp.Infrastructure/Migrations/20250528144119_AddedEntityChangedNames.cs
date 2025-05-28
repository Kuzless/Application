using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookingApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedEntityChangedNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Types_TypeId",
                table: "Rooms");

            migrationBuilder.DropForeignKey(
                name: "FK_TypeAmenties_Types_TypeId",
                table: "TypeAmenties");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Types",
                newName: "Type");

            migrationBuilder.RenameIndex(
                name: "IX_Types_Name",
                table: "Types",
                newName: "IX_Types_Type");

            migrationBuilder.RenameColumn(
                name: "TypeId",
                table: "TypeAmenties",
                newName: "RoomTypeId");

            migrationBuilder.RenameColumn(
                name: "TypeId",
                table: "Rooms",
                newName: "RoomTypeId");

            migrationBuilder.RenameColumn(
                name: "Capacity",
                table: "Rooms",
                newName: "RoomCapacityId");

            migrationBuilder.RenameIndex(
                name: "IX_Rooms_TypeId",
                table: "Rooms",
                newName: "IX_Rooms_RoomTypeId");

            migrationBuilder.CreateTable(
                name: "RoomCapacity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Capacity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomCapacity", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "RoomCapacity",
                columns: new[] { "Id", "Capacity" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 5 },
                    { 4, 10 },
                    { 5, 20 }
                });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 4,
                column: "RoomCapacityId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 5,
                column: "RoomCapacityId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 6,
                column: "RoomCapacityId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 9,
                column: "RoomCapacityId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 10,
                column: "RoomCapacityId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 13,
                column: "RoomCapacityId",
                value: 3);

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_RoomCapacityId",
                table: "Rooms",
                column: "RoomCapacityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_RoomCapacity_RoomCapacityId",
                table: "Rooms",
                column: "RoomCapacityId",
                principalTable: "RoomCapacity",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Types_RoomTypeId",
                table: "Rooms",
                column: "RoomTypeId",
                principalTable: "Types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TypeAmenties_Types_RoomTypeId",
                table: "TypeAmenties",
                column: "RoomTypeId",
                principalTable: "Types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_RoomCapacity_RoomCapacityId",
                table: "Rooms");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Types_RoomTypeId",
                table: "Rooms");

            migrationBuilder.DropForeignKey(
                name: "FK_TypeAmenties_Types_RoomTypeId",
                table: "TypeAmenties");

            migrationBuilder.DropTable(
                name: "RoomCapacity");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_RoomCapacityId",
                table: "Rooms");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Types",
                newName: "Name");

            migrationBuilder.RenameIndex(
                name: "IX_Types_Type",
                table: "Types",
                newName: "IX_Types_Name");

            migrationBuilder.RenameColumn(
                name: "RoomTypeId",
                table: "TypeAmenties",
                newName: "TypeId");

            migrationBuilder.RenameColumn(
                name: "RoomTypeId",
                table: "Rooms",
                newName: "TypeId");

            migrationBuilder.RenameColumn(
                name: "RoomCapacityId",
                table: "Rooms",
                newName: "Capacity");

            migrationBuilder.RenameIndex(
                name: "IX_Rooms_RoomTypeId",
                table: "Rooms",
                newName: "IX_Rooms_TypeId");

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 4,
                column: "Capacity",
                value: 10);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 5,
                column: "Capacity",
                value: 20);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 6,
                column: "Capacity",
                value: 20);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 9,
                column: "Capacity",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 10,
                column: "Capacity",
                value: 10);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 13,
                column: "Capacity",
                value: 5);

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Types_TypeId",
                table: "Rooms",
                column: "TypeId",
                principalTable: "Types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TypeAmenties_Types_TypeId",
                table: "TypeAmenties",
                column: "TypeId",
                principalTable: "Types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
