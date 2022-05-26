using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Base.Api.Persistence.Migrations
{
    public partial class mig3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_articles_AspNetUsers_ApplicationUserId",
                table: "articles");

            migrationBuilder.DropForeignKey(
                name: "FK_categories_AspNetUsers_ApplicationUserId",
                table: "categories");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "76243f2f-7e73-4179-963a-aed9599cf699");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "9ef002c6-4a8e-4286-87cb-443fda4f978d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "396c1add-0c55-42ea-945a-59a05d0bd5e4", "AQAAAAEAACcQAAAAEIum2RLvOMXSGVTJNmufSZWe1XTBxkJt4JoZhTZDBpip5/QPRyzEHia1Eg6+u130Hw==", "34f5d0b1-9810-4471-acce-d82ef13c7542" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b752b668-950f-4440-a808-30c7d9886eb9", "AQAAAAEAACcQAAAAEHUk+m5oaizOdsSmom3/Hu1k5nWeK5Byos0dXbWMFtyH0yeIaK8ZN8bzPZ/KjGC6yw==", "40c71c31-2456-4acd-b01c-ca36af9022ae" });

            migrationBuilder.UpdateData(
                table: "articles",
                keyColumn: "id",
                keyValue: 1,
                column: "created_date",
                value: new DateTime(2022, 5, 19, 14, 2, 8, 302, DateTimeKind.Utc).AddTicks(7155));

            migrationBuilder.UpdateData(
                table: "articles",
                keyColumn: "id",
                keyValue: 2,
                column: "created_date",
                value: new DateTime(2022, 5, 19, 14, 2, 8, 302, DateTimeKind.Utc).AddTicks(7157));

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "id",
                keyValue: 1,
                column: "created_date",
                value: new DateTime(2022, 5, 19, 14, 2, 8, 302, DateTimeKind.Utc).AddTicks(7122));

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "id",
                keyValue: 2,
                column: "created_date",
                value: new DateTime(2022, 5, 19, 14, 2, 8, 302, DateTimeKind.Utc).AddTicks(7125));

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "id",
                keyValue: 3,
                column: "created_date",
                value: new DateTime(2022, 5, 19, 14, 2, 8, 302, DateTimeKind.Utc).AddTicks(7126));

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "id",
                keyValue: 4,
                column: "created_date",
                value: new DateTime(2022, 5, 19, 14, 2, 8, 302, DateTimeKind.Utc).AddTicks(7127));

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "id",
                keyValue: 5,
                column: "created_date",
                value: new DateTime(2022, 5, 19, 14, 2, 8, 302, DateTimeKind.Utc).AddTicks(7128));

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "id",
                keyValue: 6,
                column: "created_date",
                value: new DateTime(2022, 5, 19, 14, 2, 8, 302, DateTimeKind.Utc).AddTicks(7128));

            migrationBuilder.AddForeignKey(
                name: "FK_articles_AspNetUsers_ApplicationUserId",
                table: "articles",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_categories_AspNetUsers_ApplicationUserId",
                table: "categories",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_articles_AspNetUsers_ApplicationUserId",
                table: "articles");

            migrationBuilder.DropForeignKey(
                name: "FK_categories_AspNetUsers_ApplicationUserId",
                table: "categories");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "db8bb588-ccc1-47db-b55b-7e7bb7673dd4");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "8347dcaf-31b8-42ff-96dd-7977038483b6");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "14bd7ae6-8909-4ef0-a31e-31b9b40c9d54", "AQAAAAEAACcQAAAAEHHINl8KFCeVA4a3P2KTwBVgvhUyQKiGNBllC6VM4SyRfNvwPNoE9OnHnbMcbFVORA==", "9a24036a-457b-47f3-b9b5-27824d449d6c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2518da47-181e-4517-99af-61cbd9e9ecd5", "AQAAAAEAACcQAAAAELno/r9VFm10L9FwsIApftNz28eaWMHjQcXZQpi4BhAp7cp7jwa0LKXq3v59NCCpAg==", "a47516dc-0453-42f3-ae44-4d281cb71300" });

            migrationBuilder.UpdateData(
                table: "articles",
                keyColumn: "id",
                keyValue: 1,
                column: "created_date",
                value: new DateTime(2022, 5, 15, 12, 50, 3, 491, DateTimeKind.Utc).AddTicks(8568));

            migrationBuilder.UpdateData(
                table: "articles",
                keyColumn: "id",
                keyValue: 2,
                column: "created_date",
                value: new DateTime(2022, 5, 15, 12, 50, 3, 491, DateTimeKind.Utc).AddTicks(8569));

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "id",
                keyValue: 1,
                column: "created_date",
                value: new DateTime(2022, 5, 15, 12, 50, 3, 491, DateTimeKind.Utc).AddTicks(8530));

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "id",
                keyValue: 2,
                column: "created_date",
                value: new DateTime(2022, 5, 15, 12, 50, 3, 491, DateTimeKind.Utc).AddTicks(8532));

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "id",
                keyValue: 3,
                column: "created_date",
                value: new DateTime(2022, 5, 15, 12, 50, 3, 491, DateTimeKind.Utc).AddTicks(8533));

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "id",
                keyValue: 4,
                column: "created_date",
                value: new DateTime(2022, 5, 15, 12, 50, 3, 491, DateTimeKind.Utc).AddTicks(8534));

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "id",
                keyValue: 5,
                column: "created_date",
                value: new DateTime(2022, 5, 15, 12, 50, 3, 491, DateTimeKind.Utc).AddTicks(8534));

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "id",
                keyValue: 6,
                column: "created_date",
                value: new DateTime(2022, 5, 15, 12, 50, 3, 491, DateTimeKind.Utc).AddTicks(8535));

            migrationBuilder.AddForeignKey(
                name: "FK_articles_AspNetUsers_ApplicationUserId",
                table: "articles",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_categories_AspNetUsers_ApplicationUserId",
                table: "categories",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
