using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DotnetBackend.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LGAs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StateId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LGAs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LGAs_States_StateId",
                        column: x => x.StateId,
                        principalTable: "States",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LGAId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_LGAs_LGAId",
                        column: x => x.LGAId,
                        principalTable: "LGAs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OTPs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OTPs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OTPs_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Name" },
                values: new object[,]
                {
                    { 1L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 27, 20, 2, 10, 442, DateTimeKind.Unspecified).AddTicks(7905), new TimeSpan(0, 1, 0, 0, 0)), "Abia State" },
                    { 2L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 27, 20, 2, 10, 442, DateTimeKind.Unspecified).AddTicks(7927), new TimeSpan(0, 1, 0, 0, 0)), "Lagos State" },
                    { 3L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 27, 20, 2, 10, 442, DateTimeKind.Unspecified).AddTicks(7929), new TimeSpan(0, 1, 0, 0, 0)), "Kaduna State" },
                    { 4L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 27, 20, 2, 10, 442, DateTimeKind.Unspecified).AddTicks(7930), new TimeSpan(0, 1, 0, 0, 0)), "Sokoto State" },
                    { 5L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 27, 20, 2, 10, 442, DateTimeKind.Unspecified).AddTicks(7931), new TimeSpan(0, 1, 0, 0, 0)), "Ogun State" },
                    { 6L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 27, 20, 2, 10, 442, DateTimeKind.Unspecified).AddTicks(7933), new TimeSpan(0, 1, 0, 0, 0)), "Taraba State" },
                    { 7L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 27, 20, 2, 10, 442, DateTimeKind.Unspecified).AddTicks(7935), new TimeSpan(0, 1, 0, 0, 0)), "Imo State" },
                    { 8L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 27, 20, 2, 10, 442, DateTimeKind.Unspecified).AddTicks(7936), new TimeSpan(0, 1, 0, 0, 0)), "Edo State" }
                });

            migrationBuilder.InsertData(
                table: "LGAs",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Name", "StateId" },
                values: new object[,]
                {
                    { 1L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 27, 20, 2, 10, 442, DateTimeKind.Unspecified).AddTicks(8151), new TimeSpan(0, 1, 0, 0, 0)), "LGA 1 + 1", 1L },
                    { 2L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 27, 20, 2, 10, 442, DateTimeKind.Unspecified).AddTicks(8194), new TimeSpan(0, 1, 0, 0, 0)), "LGA 1 + 2", 1L },
                    { 3L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 27, 20, 2, 10, 442, DateTimeKind.Unspecified).AddTicks(8197), new TimeSpan(0, 1, 0, 0, 0)), "LGA 1 + 3", 1L },
                    { 4L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 27, 20, 2, 10, 442, DateTimeKind.Unspecified).AddTicks(8199), new TimeSpan(0, 1, 0, 0, 0)), "LGA 1 + 4", 1L },
                    { 5L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 27, 20, 2, 10, 442, DateTimeKind.Unspecified).AddTicks(8201), new TimeSpan(0, 1, 0, 0, 0)), "LGA 1 + 5", 1L },
                    { 6L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 27, 20, 2, 10, 442, DateTimeKind.Unspecified).AddTicks(8205), new TimeSpan(0, 1, 0, 0, 0)), "LGA 1 + 6", 1L },
                    { 7L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 27, 20, 2, 10, 442, DateTimeKind.Unspecified).AddTicks(8207), new TimeSpan(0, 1, 0, 0, 0)), "LGA 1 + 7", 1L },
                    { 8L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 27, 20, 2, 10, 442, DateTimeKind.Unspecified).AddTicks(8210), new TimeSpan(0, 1, 0, 0, 0)), "LGA 1 + 8", 1L },
                    { 9L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 27, 20, 2, 10, 442, DateTimeKind.Unspecified).AddTicks(8212), new TimeSpan(0, 1, 0, 0, 0)), "LGA 1 + 9", 1L },
                    { 10L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 27, 20, 2, 10, 442, DateTimeKind.Unspecified).AddTicks(8215), new TimeSpan(0, 1, 0, 0, 0)), "LGA 1 + 10", 1L },
                    { 11L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 27, 20, 2, 10, 442, DateTimeKind.Unspecified).AddTicks(8218), new TimeSpan(0, 1, 0, 0, 0)), "LGA 1 + 11", 1L },
                    { 12L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 27, 20, 2, 10, 442, DateTimeKind.Unspecified).AddTicks(8220), new TimeSpan(0, 1, 0, 0, 0)), "LGA 1 + 12", 1L },
                    { 13L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 27, 20, 2, 10, 442, DateTimeKind.Unspecified).AddTicks(8223), new TimeSpan(0, 1, 0, 0, 0)), "LGA 1 + 13", 1L },
                    { 14L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 27, 20, 2, 10, 442, DateTimeKind.Unspecified).AddTicks(8225), new TimeSpan(0, 1, 0, 0, 0)), "LGA 1 + 14", 1L },
                    { 15L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 27, 20, 2, 10, 442, DateTimeKind.Unspecified).AddTicks(8227), new TimeSpan(0, 1, 0, 0, 0)), "LGA 1 + 15", 1L },
                    { 16L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 27, 20, 2, 10, 442, DateTimeKind.Unspecified).AddTicks(8230), new TimeSpan(0, 1, 0, 0, 0)), "LGA 2 + 1", 2L },
                    { 17L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 27, 20, 2, 10, 442, DateTimeKind.Unspecified).AddTicks(8232), new TimeSpan(0, 1, 0, 0, 0)), "LGA 2 + 2", 2L },
                    { 18L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 27, 20, 2, 10, 442, DateTimeKind.Unspecified).AddTicks(8235), new TimeSpan(0, 1, 0, 0, 0)), "LGA 2 + 3", 2L },
                    { 19L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 27, 20, 2, 10, 442, DateTimeKind.Unspecified).AddTicks(8238), new TimeSpan(0, 1, 0, 0, 0)), "LGA 2 + 4", 2L },
                    { 20L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 27, 20, 2, 10, 442, DateTimeKind.Unspecified).AddTicks(8240), new TimeSpan(0, 1, 0, 0, 0)), "LGA 2 + 5", 2L },
                    { 21L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 27, 20, 2, 10, 442, DateTimeKind.Unspecified).AddTicks(8242), new TimeSpan(0, 1, 0, 0, 0)), "LGA 2 + 6", 2L },
                    { 22L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 27, 20, 2, 10, 442, DateTimeKind.Unspecified).AddTicks(8244), new TimeSpan(0, 1, 0, 0, 0)), "LGA 2 + 7", 2L },
                    { 23L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 27, 20, 2, 10, 442, DateTimeKind.Unspecified).AddTicks(8246), new TimeSpan(0, 1, 0, 0, 0)), "LGA 2 + 8", 2L },
                    { 24L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 27, 20, 2, 10, 442, DateTimeKind.Unspecified).AddTicks(8249), new TimeSpan(0, 1, 0, 0, 0)), "LGA 2 + 9", 2L },
                    { 25L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 27, 20, 2, 10, 442, DateTimeKind.Unspecified).AddTicks(8251), new TimeSpan(0, 1, 0, 0, 0)), "LGA 2 + 10", 2L },
                    { 26L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 27, 20, 2, 10, 442, DateTimeKind.Unspecified).AddTicks(8322), new TimeSpan(0, 1, 0, 0, 0)), "LGA 2 + 11", 2L },
                    { 27L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 27, 20, 2, 10, 442, DateTimeKind.Unspecified).AddTicks(8325), new TimeSpan(0, 1, 0, 0, 0)), "LGA 2 + 12", 2L },
                    { 28L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 27, 20, 2, 10, 442, DateTimeKind.Unspecified).AddTicks(8327), new TimeSpan(0, 1, 0, 0, 0)), "LGA 2 + 13", 2L },
                    { 29L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 27, 20, 2, 10, 442, DateTimeKind.Unspecified).AddTicks(8330), new TimeSpan(0, 1, 0, 0, 0)), "LGA 2 + 14", 2L },
                    { 30L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 27, 20, 2, 10, 442, DateTimeKind.Unspecified).AddTicks(8332), new TimeSpan(0, 1, 0, 0, 0)), "LGA 2 + 15", 2L },
                    { 31L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 27, 20, 2, 10, 442, DateTimeKind.Unspecified).AddTicks(8334), new TimeSpan(0, 1, 0, 0, 0)), "LGA 3 + 1", 3L },
                    { 32L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 27, 20, 2, 10, 442, DateTimeKind.Unspecified).AddTicks(8336), new TimeSpan(0, 1, 0, 0, 0)), "LGA 3 + 2", 3L },
                    { 33L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 27, 20, 2, 10, 442, DateTimeKind.Unspecified).AddTicks(8339), new TimeSpan(0, 1, 0, 0, 0)), "LGA 3 + 3", 3L },
                    { 34L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 27, 20, 2, 10, 442, DateTimeKind.Unspecified).AddTicks(8342), new TimeSpan(0, 1, 0, 0, 0)), "LGA 3 + 4", 3L },
                    { 35L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 27, 20, 2, 10, 442, DateTimeKind.Unspecified).AddTicks(8344), new TimeSpan(0, 1, 0, 0, 0)), "LGA 3 + 5", 3L },
                    { 36L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 27, 20, 2, 10, 442, DateTimeKind.Unspecified).AddTicks(8346), new TimeSpan(0, 1, 0, 0, 0)), "LGA 3 + 6", 3L },
                    { 37L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 27, 20, 2, 10, 442, DateTimeKind.Unspecified).AddTicks(8349), new TimeSpan(0, 1, 0, 0, 0)), "LGA 3 + 7", 3L },
                    { 38L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 27, 20, 2, 10, 442, DateTimeKind.Unspecified).AddTicks(8351), new TimeSpan(0, 1, 0, 0, 0)), "LGA 3 + 8", 3L },
                    { 39L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 27, 20, 2, 10, 442, DateTimeKind.Unspecified).AddTicks(8353), new TimeSpan(0, 1, 0, 0, 0)), "LGA 3 + 9", 3L },
                    { 40L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 27, 20, 2, 10, 442, DateTimeKind.Unspecified).AddTicks(8356), new TimeSpan(0, 1, 0, 0, 0)), "LGA 3 + 10", 3L },
                    { 41L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 27, 20, 2, 10, 442, DateTimeKind.Unspecified).AddTicks(8358), new TimeSpan(0, 1, 0, 0, 0)), "LGA 3 + 11", 3L },
                    { 42L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 27, 20, 2, 10, 442, DateTimeKind.Unspecified).AddTicks(8360), new TimeSpan(0, 1, 0, 0, 0)), "LGA 3 + 12", 3L }
                });

            migrationBuilder.InsertData(
                table: "LGAs",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Name", "StateId" },
                values: new object[,]
                {
                    { 43L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 27, 20, 2, 10, 442, DateTimeKind.Unspecified).AddTicks(8363), new TimeSpan(0, 1, 0, 0, 0)), "LGA 3 + 13", 3L },
                    { 44L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 27, 20, 2, 10, 442, DateTimeKind.Unspecified).AddTicks(8365), new TimeSpan(0, 1, 0, 0, 0)), "LGA 3 + 14", 3L },
                    { 45L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 27, 20, 2, 10, 442, DateTimeKind.Unspecified).AddTicks(8367), new TimeSpan(0, 1, 0, 0, 0)), "LGA 3 + 15", 3L },
                    { 46L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 27, 20, 2, 10, 442, DateTimeKind.Unspecified).AddTicks(8369), new TimeSpan(0, 1, 0, 0, 0)), "LGA 4 + 1", 4L },
                    { 47L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 27, 20, 2, 10, 442, DateTimeKind.Unspecified).AddTicks(8372), new TimeSpan(0, 1, 0, 0, 0)), "LGA 4 + 2", 4L },
                    { 48L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 27, 20, 2, 10, 442, DateTimeKind.Unspecified).AddTicks(8374), new TimeSpan(0, 1, 0, 0, 0)), "LGA 4 + 3", 4L },
                    { 49L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 27, 20, 2, 10, 442, DateTimeKind.Unspecified).AddTicks(8376), new TimeSpan(0, 1, 0, 0, 0)), "LGA 4 + 4", 4L },
                    { 50L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 27, 20, 2, 10, 442, DateTimeKind.Unspecified).AddTicks(8379), new TimeSpan(0, 1, 0, 0, 0)), "LGA 4 + 5", 4L },
                    { 51L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 27, 20, 2, 10, 442, DateTimeKind.Unspecified).AddTicks(8381), new TimeSpan(0, 1, 0, 0, 0)), "LGA 4 + 6", 4L },
                    { 52L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 27, 20, 2, 10, 442, DateTimeKind.Unspecified).AddTicks(8383), new TimeSpan(0, 1, 0, 0, 0)), "LGA 4 + 7", 4L },
                    { 53L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 27, 20, 2, 10, 442, DateTimeKind.Unspecified).AddTicks(8385), new TimeSpan(0, 1, 0, 0, 0)), "LGA 4 + 8", 4L },
                    { 54L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 27, 20, 2, 10, 442, DateTimeKind.Unspecified).AddTicks(8387), new TimeSpan(0, 1, 0, 0, 0)), "LGA 4 + 9", 4L },
                    { 55L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 27, 20, 2, 10, 442, DateTimeKind.Unspecified).AddTicks(8390), new TimeSpan(0, 1, 0, 0, 0)), "LGA 4 + 10", 4L },
                    { 56L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 27, 20, 2, 10, 442, DateTimeKind.Unspecified).AddTicks(8392), new TimeSpan(0, 1, 0, 0, 0)), "LGA 4 + 11", 4L },
                    { 57L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 27, 20, 2, 10, 442, DateTimeKind.Unspecified).AddTicks(8394), new TimeSpan(0, 1, 0, 0, 0)), "LGA 4 + 12", 4L },
                    { 58L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 27, 20, 2, 10, 442, DateTimeKind.Unspecified).AddTicks(8397), new TimeSpan(0, 1, 0, 0, 0)), "LGA 4 + 13", 4L },
                    { 59L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 27, 20, 2, 10, 442, DateTimeKind.Unspecified).AddTicks(8399), new TimeSpan(0, 1, 0, 0, 0)), "LGA 4 + 14", 4L },
                    { 60L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 27, 20, 2, 10, 442, DateTimeKind.Unspecified).AddTicks(8401), new TimeSpan(0, 1, 0, 0, 0)), "LGA 4 + 15", 4L },
                    { 61L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 27, 20, 2, 10, 442, DateTimeKind.Unspecified).AddTicks(8404), new TimeSpan(0, 1, 0, 0, 0)), "LGA 5 + 1", 5L },
                    { 62L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 27, 20, 2, 10, 442, DateTimeKind.Unspecified).AddTicks(8406), new TimeSpan(0, 1, 0, 0, 0)), "LGA 5 + 2", 5L },
                    { 63L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 27, 20, 2, 10, 442, DateTimeKind.Unspecified).AddTicks(8408), new TimeSpan(0, 1, 0, 0, 0)), "LGA 5 + 3", 5L },
                    { 64L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 27, 20, 2, 10, 442, DateTimeKind.Unspecified).AddTicks(8410), new TimeSpan(0, 1, 0, 0, 0)), "LGA 5 + 4", 5L },
                    { 65L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 27, 20, 2, 10, 442, DateTimeKind.Unspecified).AddTicks(8412), new TimeSpan(0, 1, 0, 0, 0)), "LGA 5 + 5", 5L },
                    { 66L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 27, 20, 2, 10, 442, DateTimeKind.Unspecified).AddTicks(8416), new TimeSpan(0, 1, 0, 0, 0)), "LGA 5 + 6", 5L },
                    { 67L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 27, 20, 2, 10, 442, DateTimeKind.Unspecified).AddTicks(8418), new TimeSpan(0, 1, 0, 0, 0)), "LGA 5 + 7", 5L },
                    { 68L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 27, 20, 2, 10, 442, DateTimeKind.Unspecified).AddTicks(8420), new TimeSpan(0, 1, 0, 0, 0)), "LGA 5 + 8", 5L },
                    { 69L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 27, 20, 2, 10, 442, DateTimeKind.Unspecified).AddTicks(8423), new TimeSpan(0, 1, 0, 0, 0)), "LGA 5 + 9", 5L },
                    { 70L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 27, 20, 2, 10, 442, DateTimeKind.Unspecified).AddTicks(8425), new TimeSpan(0, 1, 0, 0, 0)), "LGA 5 + 10", 5L },
                    { 71L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 27, 20, 2, 10, 442, DateTimeKind.Unspecified).AddTicks(8427), new TimeSpan(0, 1, 0, 0, 0)), "LGA 5 + 11", 5L },
                    { 72L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 27, 20, 2, 10, 442, DateTimeKind.Unspecified).AddTicks(8429), new TimeSpan(0, 1, 0, 0, 0)), "LGA 5 + 12", 5L },
                    { 73L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 27, 20, 2, 10, 442, DateTimeKind.Unspecified).AddTicks(8432), new TimeSpan(0, 1, 0, 0, 0)), "LGA 5 + 13", 5L },
                    { 74L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 27, 20, 2, 10, 442, DateTimeKind.Unspecified).AddTicks(8434), new TimeSpan(0, 1, 0, 0, 0)), "LGA 5 + 14", 5L },
                    { 75L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 27, 20, 2, 10, 442, DateTimeKind.Unspecified).AddTicks(8436), new TimeSpan(0, 1, 0, 0, 0)), "LGA 5 + 15", 5L },
                    { 76L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 27, 20, 2, 10, 442, DateTimeKind.Unspecified).AddTicks(8438), new TimeSpan(0, 1, 0, 0, 0)), "LGA 6 + 1", 6L },
                    { 77L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 27, 20, 2, 10, 442, DateTimeKind.Unspecified).AddTicks(8441), new TimeSpan(0, 1, 0, 0, 0)), "LGA 6 + 2", 6L },
                    { 78L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 27, 20, 2, 10, 442, DateTimeKind.Unspecified).AddTicks(8443), new TimeSpan(0, 1, 0, 0, 0)), "LGA 6 + 3", 6L },
                    { 79L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 27, 20, 2, 10, 442, DateTimeKind.Unspecified).AddTicks(8445), new TimeSpan(0, 1, 0, 0, 0)), "LGA 6 + 4", 6L },
                    { 80L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 27, 20, 2, 10, 442, DateTimeKind.Unspecified).AddTicks(8447), new TimeSpan(0, 1, 0, 0, 0)), "LGA 6 + 5", 6L },
                    { 81L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 27, 20, 2, 10, 442, DateTimeKind.Unspecified).AddTicks(8449), new TimeSpan(0, 1, 0, 0, 0)), "LGA 6 + 6", 6L },
                    { 82L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 27, 20, 2, 10, 442, DateTimeKind.Unspecified).AddTicks(8452), new TimeSpan(0, 1, 0, 0, 0)), "LGA 6 + 7", 6L },
                    { 83L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 27, 20, 2, 10, 442, DateTimeKind.Unspecified).AddTicks(8506), new TimeSpan(0, 1, 0, 0, 0)), "LGA 6 + 8", 6L },
                    { 84L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 27, 20, 2, 10, 442, DateTimeKind.Unspecified).AddTicks(8509), new TimeSpan(0, 1, 0, 0, 0)), "LGA 6 + 9", 6L }
                });

            migrationBuilder.InsertData(
                table: "LGAs",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Name", "StateId" },
                values: new object[,]
                {
                    { 85L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 27, 20, 2, 10, 442, DateTimeKind.Unspecified).AddTicks(8511), new TimeSpan(0, 1, 0, 0, 0)), "LGA 6 + 10", 6L },
                    { 86L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 27, 20, 2, 10, 442, DateTimeKind.Unspecified).AddTicks(8513), new TimeSpan(0, 1, 0, 0, 0)), "LGA 6 + 11", 6L },
                    { 87L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 27, 20, 2, 10, 442, DateTimeKind.Unspecified).AddTicks(8515), new TimeSpan(0, 1, 0, 0, 0)), "LGA 6 + 12", 6L },
                    { 88L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 27, 20, 2, 10, 442, DateTimeKind.Unspecified).AddTicks(8518), new TimeSpan(0, 1, 0, 0, 0)), "LGA 6 + 13", 6L },
                    { 89L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 27, 20, 2, 10, 442, DateTimeKind.Unspecified).AddTicks(8520), new TimeSpan(0, 1, 0, 0, 0)), "LGA 6 + 14", 6L },
                    { 90L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 27, 20, 2, 10, 442, DateTimeKind.Unspecified).AddTicks(8522), new TimeSpan(0, 1, 0, 0, 0)), "LGA 6 + 15", 6L },
                    { 91L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 27, 20, 2, 10, 442, DateTimeKind.Unspecified).AddTicks(8524), new TimeSpan(0, 1, 0, 0, 0)), "LGA 7 + 1", 7L },
                    { 92L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 27, 20, 2, 10, 442, DateTimeKind.Unspecified).AddTicks(8526), new TimeSpan(0, 1, 0, 0, 0)), "LGA 7 + 2", 7L },
                    { 93L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 27, 20, 2, 10, 442, DateTimeKind.Unspecified).AddTicks(8529), new TimeSpan(0, 1, 0, 0, 0)), "LGA 7 + 3", 7L },
                    { 94L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 27, 20, 2, 10, 442, DateTimeKind.Unspecified).AddTicks(8531), new TimeSpan(0, 1, 0, 0, 0)), "LGA 7 + 4", 7L },
                    { 95L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 27, 20, 2, 10, 442, DateTimeKind.Unspecified).AddTicks(8533), new TimeSpan(0, 1, 0, 0, 0)), "LGA 7 + 5", 7L },
                    { 96L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 27, 20, 2, 10, 442, DateTimeKind.Unspecified).AddTicks(8535), new TimeSpan(0, 1, 0, 0, 0)), "LGA 7 + 6", 7L },
                    { 97L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 27, 20, 2, 10, 442, DateTimeKind.Unspecified).AddTicks(8537), new TimeSpan(0, 1, 0, 0, 0)), "LGA 7 + 7", 7L },
                    { 98L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 27, 20, 2, 10, 442, DateTimeKind.Unspecified).AddTicks(8540), new TimeSpan(0, 1, 0, 0, 0)), "LGA 7 + 8", 7L },
                    { 99L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 27, 20, 2, 10, 442, DateTimeKind.Unspecified).AddTicks(8542), new TimeSpan(0, 1, 0, 0, 0)), "LGA 7 + 9", 7L },
                    { 100L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 27, 20, 2, 10, 442, DateTimeKind.Unspecified).AddTicks(8544), new TimeSpan(0, 1, 0, 0, 0)), "LGA 7 + 10", 7L },
                    { 101L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 27, 20, 2, 10, 442, DateTimeKind.Unspecified).AddTicks(8546), new TimeSpan(0, 1, 0, 0, 0)), "LGA 7 + 11", 7L },
                    { 102L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 27, 20, 2, 10, 442, DateTimeKind.Unspecified).AddTicks(8549), new TimeSpan(0, 1, 0, 0, 0)), "LGA 7 + 12", 7L },
                    { 103L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 27, 20, 2, 10, 442, DateTimeKind.Unspecified).AddTicks(8551), new TimeSpan(0, 1, 0, 0, 0)), "LGA 7 + 13", 7L },
                    { 104L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 27, 20, 2, 10, 442, DateTimeKind.Unspecified).AddTicks(8553), new TimeSpan(0, 1, 0, 0, 0)), "LGA 7 + 14", 7L },
                    { 105L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 27, 20, 2, 10, 442, DateTimeKind.Unspecified).AddTicks(8555), new TimeSpan(0, 1, 0, 0, 0)), "LGA 7 + 15", 7L },
                    { 106L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 27, 20, 2, 10, 442, DateTimeKind.Unspecified).AddTicks(8558), new TimeSpan(0, 1, 0, 0, 0)), "LGA 8 + 1", 8L },
                    { 107L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 27, 20, 2, 10, 442, DateTimeKind.Unspecified).AddTicks(8560), new TimeSpan(0, 1, 0, 0, 0)), "LGA 8 + 2", 8L },
                    { 108L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 27, 20, 2, 10, 442, DateTimeKind.Unspecified).AddTicks(8562), new TimeSpan(0, 1, 0, 0, 0)), "LGA 8 + 3", 8L },
                    { 109L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 27, 20, 2, 10, 442, DateTimeKind.Unspecified).AddTicks(8564), new TimeSpan(0, 1, 0, 0, 0)), "LGA 8 + 4", 8L },
                    { 110L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 27, 20, 2, 10, 442, DateTimeKind.Unspecified).AddTicks(8567), new TimeSpan(0, 1, 0, 0, 0)), "LGA 8 + 5", 8L },
                    { 111L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 27, 20, 2, 10, 442, DateTimeKind.Unspecified).AddTicks(8569), new TimeSpan(0, 1, 0, 0, 0)), "LGA 8 + 6", 8L },
                    { 112L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 27, 20, 2, 10, 442, DateTimeKind.Unspecified).AddTicks(8571), new TimeSpan(0, 1, 0, 0, 0)), "LGA 8 + 7", 8L },
                    { 113L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 27, 20, 2, 10, 442, DateTimeKind.Unspecified).AddTicks(8573), new TimeSpan(0, 1, 0, 0, 0)), "LGA 8 + 8", 8L },
                    { 114L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 27, 20, 2, 10, 442, DateTimeKind.Unspecified).AddTicks(8575), new TimeSpan(0, 1, 0, 0, 0)), "LGA 8 + 9", 8L },
                    { 115L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 27, 20, 2, 10, 442, DateTimeKind.Unspecified).AddTicks(8578), new TimeSpan(0, 1, 0, 0, 0)), "LGA 8 + 10", 8L },
                    { 116L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 27, 20, 2, 10, 442, DateTimeKind.Unspecified).AddTicks(8580), new TimeSpan(0, 1, 0, 0, 0)), "LGA 8 + 11", 8L },
                    { 117L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 27, 20, 2, 10, 442, DateTimeKind.Unspecified).AddTicks(8582), new TimeSpan(0, 1, 0, 0, 0)), "LGA 8 + 12", 8L },
                    { 118L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 27, 20, 2, 10, 442, DateTimeKind.Unspecified).AddTicks(8584), new TimeSpan(0, 1, 0, 0, 0)), "LGA 8 + 13", 8L },
                    { 119L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 27, 20, 2, 10, 442, DateTimeKind.Unspecified).AddTicks(8587), new TimeSpan(0, 1, 0, 0, 0)), "LGA 8 + 14", 8L },
                    { 120L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 27, 20, 2, 10, 442, DateTimeKind.Unspecified).AddTicks(8589), new TimeSpan(0, 1, 0, 0, 0)), "LGA 8 + 15", 8L }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_LGAId",
                table: "Customers",
                column: "LGAId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_PhoneNumber",
                table: "Customers",
                column: "PhoneNumber");

            migrationBuilder.CreateIndex(
                name: "IX_LGAs_StateId",
                table: "LGAs",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_OTPs_Code",
                table: "OTPs",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_OTPs_CustomerId",
                table: "OTPs",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OTPs");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "LGAs");

            migrationBuilder.DropTable(
                name: "States");
        }
    }
}
