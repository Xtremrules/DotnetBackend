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
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    HashOTPCode = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    { 1L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 28, 14, 18, 0, 673, DateTimeKind.Unspecified).AddTicks(8543), new TimeSpan(0, 1, 0, 0, 0)), "Abia State" },
                    { 2L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 28, 14, 18, 0, 673, DateTimeKind.Unspecified).AddTicks(8565), new TimeSpan(0, 1, 0, 0, 0)), "Lagos State" },
                    { 3L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 28, 14, 18, 0, 673, DateTimeKind.Unspecified).AddTicks(8567), new TimeSpan(0, 1, 0, 0, 0)), "Kaduna State" },
                    { 4L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 28, 14, 18, 0, 673, DateTimeKind.Unspecified).AddTicks(8568), new TimeSpan(0, 1, 0, 0, 0)), "Sokoto State" },
                    { 5L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 28, 14, 18, 0, 673, DateTimeKind.Unspecified).AddTicks(8569), new TimeSpan(0, 1, 0, 0, 0)), "Ogun State" },
                    { 6L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 28, 14, 18, 0, 673, DateTimeKind.Unspecified).AddTicks(8571), new TimeSpan(0, 1, 0, 0, 0)), "Taraba State" },
                    { 7L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 28, 14, 18, 0, 673, DateTimeKind.Unspecified).AddTicks(8572), new TimeSpan(0, 1, 0, 0, 0)), "Imo State" },
                    { 8L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 28, 14, 18, 0, 673, DateTimeKind.Unspecified).AddTicks(8573), new TimeSpan(0, 1, 0, 0, 0)), "Edo State" }
                });

            migrationBuilder.InsertData(
                table: "LGAs",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Name", "StateId" },
                values: new object[,]
                {
                    { 1L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 28, 14, 18, 0, 673, DateTimeKind.Unspecified).AddTicks(8822), new TimeSpan(0, 1, 0, 0, 0)), "LGA 1 + 1", 1L },
                    { 2L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 28, 14, 18, 0, 673, DateTimeKind.Unspecified).AddTicks(8856), new TimeSpan(0, 1, 0, 0, 0)), "LGA 1 + 2", 1L },
                    { 3L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 28, 14, 18, 0, 673, DateTimeKind.Unspecified).AddTicks(8859), new TimeSpan(0, 1, 0, 0, 0)), "LGA 1 + 3", 1L },
                    { 4L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 28, 14, 18, 0, 673, DateTimeKind.Unspecified).AddTicks(8862), new TimeSpan(0, 1, 0, 0, 0)), "LGA 1 + 4", 1L },
                    { 5L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 28, 14, 18, 0, 673, DateTimeKind.Unspecified).AddTicks(8864), new TimeSpan(0, 1, 0, 0, 0)), "LGA 1 + 5", 1L },
                    { 6L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 28, 14, 18, 0, 673, DateTimeKind.Unspecified).AddTicks(8868), new TimeSpan(0, 1, 0, 0, 0)), "LGA 1 + 6", 1L },
                    { 7L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 28, 14, 18, 0, 673, DateTimeKind.Unspecified).AddTicks(8870), new TimeSpan(0, 1, 0, 0, 0)), "LGA 1 + 7", 1L },
                    { 8L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 28, 14, 18, 0, 673, DateTimeKind.Unspecified).AddTicks(8872), new TimeSpan(0, 1, 0, 0, 0)), "LGA 1 + 8", 1L },
                    { 9L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 28, 14, 18, 0, 673, DateTimeKind.Unspecified).AddTicks(8874), new TimeSpan(0, 1, 0, 0, 0)), "LGA 1 + 9", 1L },
                    { 10L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 28, 14, 18, 0, 673, DateTimeKind.Unspecified).AddTicks(8878), new TimeSpan(0, 1, 0, 0, 0)), "LGA 1 + 10", 1L },
                    { 11L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 28, 14, 18, 0, 673, DateTimeKind.Unspecified).AddTicks(8880), new TimeSpan(0, 1, 0, 0, 0)), "LGA 1 + 11", 1L },
                    { 12L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 28, 14, 18, 0, 673, DateTimeKind.Unspecified).AddTicks(8882), new TimeSpan(0, 1, 0, 0, 0)), "LGA 1 + 12", 1L },
                    { 13L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 28, 14, 18, 0, 673, DateTimeKind.Unspecified).AddTicks(8885), new TimeSpan(0, 1, 0, 0, 0)), "LGA 1 + 13", 1L },
                    { 14L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 28, 14, 18, 0, 673, DateTimeKind.Unspecified).AddTicks(8887), new TimeSpan(0, 1, 0, 0, 0)), "LGA 1 + 14", 1L },
                    { 15L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 28, 14, 18, 0, 673, DateTimeKind.Unspecified).AddTicks(8889), new TimeSpan(0, 1, 0, 0, 0)), "LGA 1 + 15", 1L },
                    { 16L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 28, 14, 18, 0, 673, DateTimeKind.Unspecified).AddTicks(8892), new TimeSpan(0, 1, 0, 0, 0)), "LGA 2 + 1", 2L },
                    { 17L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 28, 14, 18, 0, 673, DateTimeKind.Unspecified).AddTicks(8895), new TimeSpan(0, 1, 0, 0, 0)), "LGA 2 + 2", 2L },
                    { 18L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 28, 14, 18, 0, 673, DateTimeKind.Unspecified).AddTicks(8898), new TimeSpan(0, 1, 0, 0, 0)), "LGA 2 + 3", 2L },
                    { 19L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 28, 14, 18, 0, 673, DateTimeKind.Unspecified).AddTicks(8900), new TimeSpan(0, 1, 0, 0, 0)), "LGA 2 + 4", 2L },
                    { 20L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 28, 14, 18, 0, 673, DateTimeKind.Unspecified).AddTicks(8902), new TimeSpan(0, 1, 0, 0, 0)), "LGA 2 + 5", 2L },
                    { 21L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 28, 14, 18, 0, 673, DateTimeKind.Unspecified).AddTicks(8905), new TimeSpan(0, 1, 0, 0, 0)), "LGA 2 + 6", 2L },
                    { 22L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 28, 14, 18, 0, 673, DateTimeKind.Unspecified).AddTicks(8907), new TimeSpan(0, 1, 0, 0, 0)), "LGA 2 + 7", 2L },
                    { 23L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 28, 14, 18, 0, 673, DateTimeKind.Unspecified).AddTicks(8909), new TimeSpan(0, 1, 0, 0, 0)), "LGA 2 + 8", 2L },
                    { 24L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 28, 14, 18, 0, 673, DateTimeKind.Unspecified).AddTicks(8911), new TimeSpan(0, 1, 0, 0, 0)), "LGA 2 + 9", 2L },
                    { 25L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 28, 14, 18, 0, 673, DateTimeKind.Unspecified).AddTicks(8913), new TimeSpan(0, 1, 0, 0, 0)), "LGA 2 + 10", 2L },
                    { 26L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 28, 14, 18, 0, 673, DateTimeKind.Unspecified).AddTicks(8915), new TimeSpan(0, 1, 0, 0, 0)), "LGA 2 + 11", 2L },
                    { 27L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 28, 14, 18, 0, 673, DateTimeKind.Unspecified).AddTicks(8983), new TimeSpan(0, 1, 0, 0, 0)), "LGA 2 + 12", 2L },
                    { 28L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 28, 14, 18, 0, 673, DateTimeKind.Unspecified).AddTicks(8987), new TimeSpan(0, 1, 0, 0, 0)), "LGA 2 + 13", 2L },
                    { 29L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 28, 14, 18, 0, 673, DateTimeKind.Unspecified).AddTicks(8989), new TimeSpan(0, 1, 0, 0, 0)), "LGA 2 + 14", 2L },
                    { 30L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 28, 14, 18, 0, 673, DateTimeKind.Unspecified).AddTicks(8992), new TimeSpan(0, 1, 0, 0, 0)), "LGA 2 + 15", 2L },
                    { 31L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 28, 14, 18, 0, 673, DateTimeKind.Unspecified).AddTicks(8994), new TimeSpan(0, 1, 0, 0, 0)), "LGA 3 + 1", 3L },
                    { 32L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 28, 14, 18, 0, 673, DateTimeKind.Unspecified).AddTicks(8996), new TimeSpan(0, 1, 0, 0, 0)), "LGA 3 + 2", 3L },
                    { 33L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 28, 14, 18, 0, 673, DateTimeKind.Unspecified).AddTicks(8998), new TimeSpan(0, 1, 0, 0, 0)), "LGA 3 + 3", 3L },
                    { 34L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 28, 14, 18, 0, 673, DateTimeKind.Unspecified).AddTicks(9002), new TimeSpan(0, 1, 0, 0, 0)), "LGA 3 + 4", 3L },
                    { 35L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 28, 14, 18, 0, 673, DateTimeKind.Unspecified).AddTicks(9004), new TimeSpan(0, 1, 0, 0, 0)), "LGA 3 + 5", 3L },
                    { 36L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 28, 14, 18, 0, 673, DateTimeKind.Unspecified).AddTicks(9007), new TimeSpan(0, 1, 0, 0, 0)), "LGA 3 + 6", 3L },
                    { 37L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 28, 14, 18, 0, 673, DateTimeKind.Unspecified).AddTicks(9009), new TimeSpan(0, 1, 0, 0, 0)), "LGA 3 + 7", 3L },
                    { 38L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 28, 14, 18, 0, 673, DateTimeKind.Unspecified).AddTicks(9011), new TimeSpan(0, 1, 0, 0, 0)), "LGA 3 + 8", 3L },
                    { 39L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 28, 14, 18, 0, 673, DateTimeKind.Unspecified).AddTicks(9013), new TimeSpan(0, 1, 0, 0, 0)), "LGA 3 + 9", 3L },
                    { 40L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 28, 14, 18, 0, 673, DateTimeKind.Unspecified).AddTicks(9015), new TimeSpan(0, 1, 0, 0, 0)), "LGA 3 + 10", 3L },
                    { 41L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 28, 14, 18, 0, 673, DateTimeKind.Unspecified).AddTicks(9017), new TimeSpan(0, 1, 0, 0, 0)), "LGA 3 + 11", 3L },
                    { 42L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 28, 14, 18, 0, 673, DateTimeKind.Unspecified).AddTicks(9020), new TimeSpan(0, 1, 0, 0, 0)), "LGA 3 + 12", 3L }
                });

            migrationBuilder.InsertData(
                table: "LGAs",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Name", "StateId" },
                values: new object[,]
                {
                    { 43L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 28, 14, 18, 0, 673, DateTimeKind.Unspecified).AddTicks(9022), new TimeSpan(0, 1, 0, 0, 0)), "LGA 3 + 13", 3L },
                    { 44L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 28, 14, 18, 0, 673, DateTimeKind.Unspecified).AddTicks(9024), new TimeSpan(0, 1, 0, 0, 0)), "LGA 3 + 14", 3L },
                    { 45L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 28, 14, 18, 0, 673, DateTimeKind.Unspecified).AddTicks(9026), new TimeSpan(0, 1, 0, 0, 0)), "LGA 3 + 15", 3L },
                    { 46L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 28, 14, 18, 0, 673, DateTimeKind.Unspecified).AddTicks(9029), new TimeSpan(0, 1, 0, 0, 0)), "LGA 4 + 1", 4L },
                    { 47L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 28, 14, 18, 0, 673, DateTimeKind.Unspecified).AddTicks(9031), new TimeSpan(0, 1, 0, 0, 0)), "LGA 4 + 2", 4L },
                    { 48L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 28, 14, 18, 0, 673, DateTimeKind.Unspecified).AddTicks(9033), new TimeSpan(0, 1, 0, 0, 0)), "LGA 4 + 3", 4L },
                    { 49L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 28, 14, 18, 0, 673, DateTimeKind.Unspecified).AddTicks(9035), new TimeSpan(0, 1, 0, 0, 0)), "LGA 4 + 4", 4L },
                    { 50L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 28, 14, 18, 0, 673, DateTimeKind.Unspecified).AddTicks(9037), new TimeSpan(0, 1, 0, 0, 0)), "LGA 4 + 5", 4L },
                    { 51L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 28, 14, 18, 0, 673, DateTimeKind.Unspecified).AddTicks(9039), new TimeSpan(0, 1, 0, 0, 0)), "LGA 4 + 6", 4L },
                    { 52L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 28, 14, 18, 0, 673, DateTimeKind.Unspecified).AddTicks(9042), new TimeSpan(0, 1, 0, 0, 0)), "LGA 4 + 7", 4L },
                    { 53L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 28, 14, 18, 0, 673, DateTimeKind.Unspecified).AddTicks(9044), new TimeSpan(0, 1, 0, 0, 0)), "LGA 4 + 8", 4L },
                    { 54L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 28, 14, 18, 0, 673, DateTimeKind.Unspecified).AddTicks(9046), new TimeSpan(0, 1, 0, 0, 0)), "LGA 4 + 9", 4L },
                    { 55L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 28, 14, 18, 0, 673, DateTimeKind.Unspecified).AddTicks(9048), new TimeSpan(0, 1, 0, 0, 0)), "LGA 4 + 10", 4L },
                    { 56L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 28, 14, 18, 0, 673, DateTimeKind.Unspecified).AddTicks(9050), new TimeSpan(0, 1, 0, 0, 0)), "LGA 4 + 11", 4L },
                    { 57L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 28, 14, 18, 0, 673, DateTimeKind.Unspecified).AddTicks(9052), new TimeSpan(0, 1, 0, 0, 0)), "LGA 4 + 12", 4L },
                    { 58L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 28, 14, 18, 0, 673, DateTimeKind.Unspecified).AddTicks(9054), new TimeSpan(0, 1, 0, 0, 0)), "LGA 4 + 13", 4L },
                    { 59L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 28, 14, 18, 0, 673, DateTimeKind.Unspecified).AddTicks(9056), new TimeSpan(0, 1, 0, 0, 0)), "LGA 4 + 14", 4L },
                    { 60L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 28, 14, 18, 0, 673, DateTimeKind.Unspecified).AddTicks(9059), new TimeSpan(0, 1, 0, 0, 0)), "LGA 4 + 15", 4L },
                    { 61L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 28, 14, 18, 0, 673, DateTimeKind.Unspecified).AddTicks(9061), new TimeSpan(0, 1, 0, 0, 0)), "LGA 5 + 1", 5L },
                    { 62L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 28, 14, 18, 0, 673, DateTimeKind.Unspecified).AddTicks(9063), new TimeSpan(0, 1, 0, 0, 0)), "LGA 5 + 2", 5L },
                    { 63L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 28, 14, 18, 0, 673, DateTimeKind.Unspecified).AddTicks(9066), new TimeSpan(0, 1, 0, 0, 0)), "LGA 5 + 3", 5L },
                    { 64L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 28, 14, 18, 0, 673, DateTimeKind.Unspecified).AddTicks(9068), new TimeSpan(0, 1, 0, 0, 0)), "LGA 5 + 4", 5L },
                    { 65L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 28, 14, 18, 0, 673, DateTimeKind.Unspecified).AddTicks(9070), new TimeSpan(0, 1, 0, 0, 0)), "LGA 5 + 5", 5L },
                    { 66L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 28, 14, 18, 0, 673, DateTimeKind.Unspecified).AddTicks(9074), new TimeSpan(0, 1, 0, 0, 0)), "LGA 5 + 6", 5L },
                    { 67L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 28, 14, 18, 0, 673, DateTimeKind.Unspecified).AddTicks(9076), new TimeSpan(0, 1, 0, 0, 0)), "LGA 5 + 7", 5L },
                    { 68L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 28, 14, 18, 0, 673, DateTimeKind.Unspecified).AddTicks(9078), new TimeSpan(0, 1, 0, 0, 0)), "LGA 5 + 8", 5L },
                    { 69L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 28, 14, 18, 0, 673, DateTimeKind.Unspecified).AddTicks(9081), new TimeSpan(0, 1, 0, 0, 0)), "LGA 5 + 9", 5L },
                    { 70L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 28, 14, 18, 0, 673, DateTimeKind.Unspecified).AddTicks(9083), new TimeSpan(0, 1, 0, 0, 0)), "LGA 5 + 10", 5L },
                    { 71L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 28, 14, 18, 0, 673, DateTimeKind.Unspecified).AddTicks(9085), new TimeSpan(0, 1, 0, 0, 0)), "LGA 5 + 11", 5L },
                    { 72L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 28, 14, 18, 0, 673, DateTimeKind.Unspecified).AddTicks(9087), new TimeSpan(0, 1, 0, 0, 0)), "LGA 5 + 12", 5L },
                    { 73L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 28, 14, 18, 0, 673, DateTimeKind.Unspecified).AddTicks(9089), new TimeSpan(0, 1, 0, 0, 0)), "LGA 5 + 13", 5L },
                    { 74L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 28, 14, 18, 0, 673, DateTimeKind.Unspecified).AddTicks(9092), new TimeSpan(0, 1, 0, 0, 0)), "LGA 5 + 14", 5L },
                    { 75L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 28, 14, 18, 0, 673, DateTimeKind.Unspecified).AddTicks(9094), new TimeSpan(0, 1, 0, 0, 0)), "LGA 5 + 15", 5L },
                    { 76L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 28, 14, 18, 0, 673, DateTimeKind.Unspecified).AddTicks(9096), new TimeSpan(0, 1, 0, 0, 0)), "LGA 6 + 1", 6L },
                    { 77L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 28, 14, 18, 0, 673, DateTimeKind.Unspecified).AddTicks(9098), new TimeSpan(0, 1, 0, 0, 0)), "LGA 6 + 2", 6L },
                    { 78L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 28, 14, 18, 0, 673, DateTimeKind.Unspecified).AddTicks(9100), new TimeSpan(0, 1, 0, 0, 0)), "LGA 6 + 3", 6L },
                    { 79L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 28, 14, 18, 0, 673, DateTimeKind.Unspecified).AddTicks(9103), new TimeSpan(0, 1, 0, 0, 0)), "LGA 6 + 4", 6L },
                    { 80L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 28, 14, 18, 0, 673, DateTimeKind.Unspecified).AddTicks(9105), new TimeSpan(0, 1, 0, 0, 0)), "LGA 6 + 5", 6L },
                    { 81L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 28, 14, 18, 0, 673, DateTimeKind.Unspecified).AddTicks(9107), new TimeSpan(0, 1, 0, 0, 0)), "LGA 6 + 6", 6L },
                    { 82L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 28, 14, 18, 0, 673, DateTimeKind.Unspecified).AddTicks(9109), new TimeSpan(0, 1, 0, 0, 0)), "LGA 6 + 7", 6L },
                    { 83L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 28, 14, 18, 0, 673, DateTimeKind.Unspecified).AddTicks(9112), new TimeSpan(0, 1, 0, 0, 0)), "LGA 6 + 8", 6L },
                    { 84L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 28, 14, 18, 0, 673, DateTimeKind.Unspecified).AddTicks(9114), new TimeSpan(0, 1, 0, 0, 0)), "LGA 6 + 9", 6L }
                });

            migrationBuilder.InsertData(
                table: "LGAs",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Name", "StateId" },
                values: new object[,]
                {
                    { 85L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 28, 14, 18, 0, 673, DateTimeKind.Unspecified).AddTicks(9168), new TimeSpan(0, 1, 0, 0, 0)), "LGA 6 + 10", 6L },
                    { 86L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 28, 14, 18, 0, 673, DateTimeKind.Unspecified).AddTicks(9171), new TimeSpan(0, 1, 0, 0, 0)), "LGA 6 + 11", 6L },
                    { 87L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 28, 14, 18, 0, 673, DateTimeKind.Unspecified).AddTicks(9174), new TimeSpan(0, 1, 0, 0, 0)), "LGA 6 + 12", 6L },
                    { 88L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 28, 14, 18, 0, 673, DateTimeKind.Unspecified).AddTicks(9176), new TimeSpan(0, 1, 0, 0, 0)), "LGA 6 + 13", 6L },
                    { 89L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 28, 14, 18, 0, 673, DateTimeKind.Unspecified).AddTicks(9178), new TimeSpan(0, 1, 0, 0, 0)), "LGA 6 + 14", 6L },
                    { 90L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 28, 14, 18, 0, 673, DateTimeKind.Unspecified).AddTicks(9180), new TimeSpan(0, 1, 0, 0, 0)), "LGA 6 + 15", 6L },
                    { 91L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 28, 14, 18, 0, 673, DateTimeKind.Unspecified).AddTicks(9183), new TimeSpan(0, 1, 0, 0, 0)), "LGA 7 + 1", 7L },
                    { 92L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 28, 14, 18, 0, 673, DateTimeKind.Unspecified).AddTicks(9185), new TimeSpan(0, 1, 0, 0, 0)), "LGA 7 + 2", 7L },
                    { 93L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 28, 14, 18, 0, 673, DateTimeKind.Unspecified).AddTicks(9187), new TimeSpan(0, 1, 0, 0, 0)), "LGA 7 + 3", 7L },
                    { 94L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 28, 14, 18, 0, 673, DateTimeKind.Unspecified).AddTicks(9189), new TimeSpan(0, 1, 0, 0, 0)), "LGA 7 + 4", 7L },
                    { 95L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 28, 14, 18, 0, 673, DateTimeKind.Unspecified).AddTicks(9192), new TimeSpan(0, 1, 0, 0, 0)), "LGA 7 + 5", 7L },
                    { 96L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 28, 14, 18, 0, 673, DateTimeKind.Unspecified).AddTicks(9194), new TimeSpan(0, 1, 0, 0, 0)), "LGA 7 + 6", 7L },
                    { 97L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 28, 14, 18, 0, 673, DateTimeKind.Unspecified).AddTicks(9196), new TimeSpan(0, 1, 0, 0, 0)), "LGA 7 + 7", 7L },
                    { 98L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 28, 14, 18, 0, 673, DateTimeKind.Unspecified).AddTicks(9198), new TimeSpan(0, 1, 0, 0, 0)), "LGA 7 + 8", 7L },
                    { 99L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 28, 14, 18, 0, 673, DateTimeKind.Unspecified).AddTicks(9200), new TimeSpan(0, 1, 0, 0, 0)), "LGA 7 + 9", 7L },
                    { 100L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 28, 14, 18, 0, 673, DateTimeKind.Unspecified).AddTicks(9202), new TimeSpan(0, 1, 0, 0, 0)), "LGA 7 + 10", 7L },
                    { 101L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 28, 14, 18, 0, 673, DateTimeKind.Unspecified).AddTicks(9204), new TimeSpan(0, 1, 0, 0, 0)), "LGA 7 + 11", 7L },
                    { 102L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 28, 14, 18, 0, 673, DateTimeKind.Unspecified).AddTicks(9206), new TimeSpan(0, 1, 0, 0, 0)), "LGA 7 + 12", 7L },
                    { 103L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 28, 14, 18, 0, 673, DateTimeKind.Unspecified).AddTicks(9209), new TimeSpan(0, 1, 0, 0, 0)), "LGA 7 + 13", 7L },
                    { 104L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 28, 14, 18, 0, 673, DateTimeKind.Unspecified).AddTicks(9211), new TimeSpan(0, 1, 0, 0, 0)), "LGA 7 + 14", 7L },
                    { 105L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 28, 14, 18, 0, 673, DateTimeKind.Unspecified).AddTicks(9213), new TimeSpan(0, 1, 0, 0, 0)), "LGA 7 + 15", 7L },
                    { 106L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 28, 14, 18, 0, 673, DateTimeKind.Unspecified).AddTicks(9215), new TimeSpan(0, 1, 0, 0, 0)), "LGA 8 + 1", 8L },
                    { 107L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 28, 14, 18, 0, 673, DateTimeKind.Unspecified).AddTicks(9218), new TimeSpan(0, 1, 0, 0, 0)), "LGA 8 + 2", 8L },
                    { 108L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 28, 14, 18, 0, 673, DateTimeKind.Unspecified).AddTicks(9220), new TimeSpan(0, 1, 0, 0, 0)), "LGA 8 + 3", 8L },
                    { 109L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 28, 14, 18, 0, 673, DateTimeKind.Unspecified).AddTicks(9222), new TimeSpan(0, 1, 0, 0, 0)), "LGA 8 + 4", 8L },
                    { 110L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 28, 14, 18, 0, 673, DateTimeKind.Unspecified).AddTicks(9224), new TimeSpan(0, 1, 0, 0, 0)), "LGA 8 + 5", 8L },
                    { 111L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 28, 14, 18, 0, 673, DateTimeKind.Unspecified).AddTicks(9226), new TimeSpan(0, 1, 0, 0, 0)), "LGA 8 + 6", 8L },
                    { 112L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 28, 14, 18, 0, 673, DateTimeKind.Unspecified).AddTicks(9228), new TimeSpan(0, 1, 0, 0, 0)), "LGA 8 + 7", 8L },
                    { 113L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 28, 14, 18, 0, 673, DateTimeKind.Unspecified).AddTicks(9231), new TimeSpan(0, 1, 0, 0, 0)), "LGA 8 + 8", 8L },
                    { 114L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 28, 14, 18, 0, 673, DateTimeKind.Unspecified).AddTicks(9233), new TimeSpan(0, 1, 0, 0, 0)), "LGA 8 + 9", 8L },
                    { 115L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 28, 14, 18, 0, 673, DateTimeKind.Unspecified).AddTicks(9235), new TimeSpan(0, 1, 0, 0, 0)), "LGA 8 + 10", 8L },
                    { 116L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 28, 14, 18, 0, 673, DateTimeKind.Unspecified).AddTicks(9237), new TimeSpan(0, 1, 0, 0, 0)), "LGA 8 + 11", 8L },
                    { 117L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 28, 14, 18, 0, 673, DateTimeKind.Unspecified).AddTicks(9239), new TimeSpan(0, 1, 0, 0, 0)), "LGA 8 + 12", 8L },
                    { 118L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 28, 14, 18, 0, 673, DateTimeKind.Unspecified).AddTicks(9242), new TimeSpan(0, 1, 0, 0, 0)), "LGA 8 + 13", 8L },
                    { 119L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 28, 14, 18, 0, 673, DateTimeKind.Unspecified).AddTicks(9244), new TimeSpan(0, 1, 0, 0, 0)), "LGA 8 + 14", 8L },
                    { 120L, "SYSTEM", new DateTimeOffset(new DateTime(2022, 3, 28, 14, 18, 0, 673, DateTimeKind.Unspecified).AddTicks(9246), new TimeSpan(0, 1, 0, 0, 0)), "LGA 8 + 15", 8L }
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
                name: "IX_OTPs_CustomerId",
                table: "OTPs",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_OTPs_HashOTPCode",
                table: "OTPs",
                column: "HashOTPCode");
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
