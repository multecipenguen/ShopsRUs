using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopsRUs.Persistence.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    IsAffliate = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsEmployee = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Discounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Type = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Percentage = table.Column<double>(type: "REAL", nullable: false),
                    Amount = table.Column<decimal>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Amount = table.Column<decimal>(type: "TEXT", nullable: false),
                    CustomerId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invoices_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "CreatedAt", "IsAffliate", "IsEmployee", "Name" },
                values: new object[] { new Guid("fdf83730-67e7-4961-b842-9244ffa5032a"), new DateTime(2022, 1, 9, 21, 16, 52, 50, DateTimeKind.Local).AddTicks(543), true, false, "Özgür" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "CreatedAt", "IsAffliate", "IsEmployee", "Name" },
                values: new object[] { new Guid("f82f86e5-b247-46b0-9676-c6754a95c2e2"), new DateTime(2022, 1, 9, 21, 16, 52, 50, DateTimeKind.Local).AddTicks(7051), false, true, "Burcu" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "CreatedAt", "IsAffliate", "IsEmployee", "Name" },
                values: new object[] { new Guid("fc7491b8-21d3-4122-a015-6e1d17606da1"), new DateTime(2022, 1, 9, 21, 16, 52, 50, DateTimeKind.Local).AddTicks(7075), false, false, "Mısra" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "CreatedAt", "IsAffliate", "IsEmployee", "Name" },
                values: new object[] { new Guid("3934a23b-ea17-4470-9c9d-a46dfafb09d6"), new DateTime(2017, 1, 9, 21, 16, 52, 50, DateTimeKind.Local).AddTicks(7078), false, false, "Duygu" });

            migrationBuilder.InsertData(
                table: "Discounts",
                columns: new[] { "Id", "Amount", "CreatedAt", "Name", "Percentage", "Type" },
                values: new object[] { new Guid("5bd7f808-52eb-40b4-b0c6-764efa658257"), 0m, new DateTime(2022, 1, 9, 21, 16, 52, 51, DateTimeKind.Local).AddTicks(9933), "Affliate", 10.0, "affliatediscount" });

            migrationBuilder.InsertData(
                table: "Discounts",
                columns: new[] { "Id", "Amount", "CreatedAt", "Name", "Percentage", "Type" },
                values: new object[] { new Guid("d5bf8a8e-76a9-4bfb-a82c-02a7c567db9a"), 0m, new DateTime(2022, 1, 9, 21, 16, 52, 51, DateTimeKind.Local).AddTicks(9997), "Employee", 30.0, "employeediscount" });

            migrationBuilder.InsertData(
                table: "Discounts",
                columns: new[] { "Id", "Amount", "CreatedAt", "Name", "Percentage", "Type" },
                values: new object[] { new Guid("1977943c-e033-482a-bc30-265a45702968"), 0m, new DateTime(2022, 1, 9, 21, 16, 52, 52, DateTimeKind.Local), "Old Customer", 5.0, "oldcustomerdiscount" });

            migrationBuilder.InsertData(
                table: "Discounts",
                columns: new[] { "Id", "Amount", "CreatedAt", "Name", "Percentage", "Type" },
                values: new object[] { new Guid("8dfeeed1-0d47-4e28-8084-5f4b6b24e85e"), 0m, new DateTime(2022, 1, 9, 21, 16, 52, 52, DateTimeKind.Local).AddTicks(2), "100 Dollar Discount", 5.0, "Per100Dollardiscount" });

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_CustomerId",
                table: "Invoices",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Discounts");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
