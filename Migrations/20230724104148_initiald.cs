using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FirstTut.Migrations
{
    /// <inheritdoc />
    public partial class initiald : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Weapons_WeaponId",
                table: "Characters");

            migrationBuilder.DropIndex(
                name: "IX_Characters_WeaponId",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "WeaponId",
                table: "Characters");

            migrationBuilder.AddColumn<int>(
                name: "CharacterId",
                table: "Weapons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Weapons_CharacterId",
                table: "Weapons",
                column: "CharacterId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Weapons_Characters_CharacterId",
                table: "Weapons",
                column: "CharacterId",
                principalTable: "Characters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Weapons_Characters_CharacterId",
                table: "Weapons");

            migrationBuilder.DropIndex(
                name: "IX_Weapons_CharacterId",
                table: "Weapons");

            migrationBuilder.DropColumn(
                name: "CharacterId",
                table: "Weapons");

            migrationBuilder.AddColumn<int>(
                name: "WeaponId",
                table: "Characters",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Characters_WeaponId",
                table: "Characters",
                column: "WeaponId",
                unique: true,
                filter: "[WeaponId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Weapons_WeaponId",
                table: "Characters",
                column: "WeaponId",
                principalTable: "Weapons",
                principalColumn: "Id");
        }
    }
}
