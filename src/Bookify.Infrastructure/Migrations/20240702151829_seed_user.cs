using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Bookify.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class seed_user : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "Email", "FirstName", "IdentityId", "LastName" },
                values: new object[,]
                {
                    { new Guid("0bcb1385-6a4b-478f-b347-582ded0fe416"), "Maximillia.Von51@yahoo.com", "Albin", "6bda7e63-3175-55b8-01a6-ea2b687c49af", "Emmerich" },
                    { new Guid("4842c24d-8f9b-4cc1-85ab-e58f20d9aac4"), "Flavie51@gmail.com", "Dorian", "db85018d-e13b-34af-636c-a1cc8a239615", "Tremblay" },
                    { new Guid("4ec463fd-4685-4f78-b2f8-62fedb99453c"), "Rocky.Runte69@hotmail.com", "Graciela", "2c6fc0ea-55c0-e4f5-7e67-7204630ebd2a", "Wiegand" },
                    { new Guid("5205b138-da4f-4f54-b14a-99932123daf3"), "Rosendo_Hessel10@hotmail.com", "Dorcas", "757810d3-ecc0-c5bf-44a8-b8c639932b31", "Beahan" },
                    { new Guid("9ec700a2-9f35-4ad6-a907-4b6f92ef73a2"), "Clark.Christiansen@hotmail.com", "Sarai", "1722853f-7cfa-5c31-3da1-1571398c090b", "Robel" },
                    { new Guid("c274c795-7d95-4fab-b2bd-3a2a6732191a"), "Arlo_Simonis50@yahoo.com", "Emerald", "11dbb132-b6fd-1e55-a3f0-c723a1c71e55", "Schimmel" },
                    { new Guid("d12230d6-64ee-453c-8a86-23791b109118"), "Louvenia_Quigley45@hotmail.com", "Eden", "4c72d46c-66ad-a306-707f-ae0bbb9732a4", "Leannon" },
                    { new Guid("dc7a84a7-1086-4381-b015-cede3761786f"), "Alexis.Legros@hotmail.com", "Bailee", "2640549c-0a4e-d964-b26b-862b3161a65a", "Olson" },
                    { new Guid("f6881969-f4f5-48c8-82a4-2644051a7f45"), "Ethan_McLaughlin@yahoo.com", "Audrey", "d36a041c-44a3-c1e4-3b93-9ca119a2255e", "Rohan" },
                    { new Guid("f8a32326-ef6b-4064-ab07-3a5ad8d984dd"), "Marley_Quigley15@yahoo.com", "Imogene", "65f2d860-d177-9a0c-da84-d31dbcaa8135", "Wehner" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("0bcb1385-6a4b-478f-b347-582ded0fe416"));

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("4842c24d-8f9b-4cc1-85ab-e58f20d9aac4"));

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("4ec463fd-4685-4f78-b2f8-62fedb99453c"));

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("5205b138-da4f-4f54-b14a-99932123daf3"));

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("9ec700a2-9f35-4ad6-a907-4b6f92ef73a2"));

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("c274c795-7d95-4fab-b2bd-3a2a6732191a"));

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("d12230d6-64ee-453c-8a86-23791b109118"));

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("dc7a84a7-1086-4381-b015-cede3761786f"));

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("f6881969-f4f5-48c8-82a4-2644051a7f45"));

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("f8a32326-ef6b-4064-ab07-3a5ad8d984dd"));
        }
    }
}
