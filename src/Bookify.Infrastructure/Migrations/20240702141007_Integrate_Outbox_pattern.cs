using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Bookify.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Integrate_Outbox_pattern : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("19545c2e-473b-445b-8177-1c196ed34868"));

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("394add29-add6-4dfc-b8bd-efa4a6da512e"));

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("3a462683-d48b-4d2d-9d20-5a0183c39306"));

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("4421064a-9dbe-4583-ab8e-199d9693acb3"));

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("48cc917a-7e50-4fe3-adf8-7e0601a1b12f"));

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("53966fa1-358f-4b8c-ba24-c8982a84ed41"));

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("5a144b1a-ac54-464d-b9a5-f9aea5082b99"));

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("5fb293bb-eae6-4221-b69f-de01ca0b4327"));

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("a3e1f014-3ae4-40ba-84b0-8991fc6f7aec"));

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("ff747da5-6a82-4c40-b70e-732754b42c0d"));

            migrationBuilder.CreateTable(
                name: "outbox_message",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    OccurredOnUtc = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Type = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Content = table.Column<string>(type: "json", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProcessedOnUtc = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Error = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_outbox_message", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "outbox_message");

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "Email", "FirstName", "IdentityId", "LastName" },
                values: new object[,]
                {
                    { new Guid("19545c2e-473b-445b-8177-1c196ed34868"), "Maci_Schuppe63@gmail.com", "Dedric", "b6e2d2c1-8abd-4382-be15-ebd4baac336f", "Dickinson" },
                    { new Guid("394add29-add6-4dfc-b8bd-efa4a6da512e"), "Bryce18@gmail.com", "Kayley", "ba1fb0c8-3fcd-4090-6493-4537ac53a9d3", "Kuhlman" },
                    { new Guid("3a462683-d48b-4d2d-9d20-5a0183c39306"), "Hazel.Lubowitz@hotmail.com", "Jesse", "360c8a4b-1d35-976d-b2f9-4d34d614dfac", "Krajcik" },
                    { new Guid("4421064a-9dbe-4583-ab8e-199d9693acb3"), "Norval15@hotmail.com", "Blanca", "c1fc7922-08af-6609-6585-b4eaf24dd0a4", "Hilpert" },
                    { new Guid("48cc917a-7e50-4fe3-adf8-7e0601a1b12f"), "Jermain_Sawayn@gmail.com", "Sherman", "7a1739fa-c1ef-5b63-0939-d052cc91af2c", "Flatley" },
                    { new Guid("53966fa1-358f-4b8c-ba24-c8982a84ed41"), "Harley.Carter45@hotmail.com", "Tressa", "06c4eb73-d434-e9f9-57c1-b639a2ef4608", "Hamill" },
                    { new Guid("5a144b1a-ac54-464d-b9a5-f9aea5082b99"), "Hildegard_Lehner41@gmail.com", "Americo", "fc898973-cf86-6fa1-cc8d-d3960c4ed481", "Hickle" },
                    { new Guid("5fb293bb-eae6-4221-b69f-de01ca0b4327"), "Judy76@yahoo.com", "Kelly", "7259e892-ab51-b013-e0ed-29f4a7c5b7ed", "Hartmann" },
                    { new Guid("a3e1f014-3ae4-40ba-84b0-8991fc6f7aec"), "Jonathan37@gmail.com", "Myrtis", "4f11324c-01d7-6b9e-84a2-58528d4f82d9", "Fay" },
                    { new Guid("ff747da5-6a82-4c40-b70e-732754b42c0d"), "Garry_Cummings@hotmail.com", "Kamryn", "0b18a91e-cc77-6412-25f1-9cec70d454c5", "Fadel" }
                });
        }
    }
}
