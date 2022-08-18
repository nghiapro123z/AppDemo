using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AppDemo.Data.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Author",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Author", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    Image = table.Column<string>(nullable: false),
                    AuthorId = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Book_Author_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Author",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Book_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookId = table.Column<int>(nullable: false),
                    UserEmail = table.Column<string>(nullable: true),
                    OrderQuantity = table.Column<int>(nullable: false),
                    OrderPrice = table.Column<double>(nullable: false),
                    OrderDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_Book_BookId",
                        column: x => x.BookId,
                        principalTable: "Book",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Author",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Robert Gaudi" },
                    { 2, "Jeff Kinney" },
                    { 3, "Masashi Kishimoto" }
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "History" },
                    { 2, "Entertainment" },
                    { 3, "Comics" }
                });

            migrationBuilder.InsertData(
                table: "Book",
                columns: new[] { "Id", "AuthorId", "CategoryId", "Image", "Name", "Price", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, 1, "https://img.thriftbooks.com/api/images/i/l/A8355E53B30072A52D98408A600E40C47BF77518.jpg", "The War of Jenkins' Ear", 42.590000000000003, 50 },
                    { 2, 1, 1, "https://img.thriftbooks.com/api/images/m/1b3c2d90b93acea06d9807e06ad6ff03a47a1076.jpg", "African Kaiser: General Paul Von Lettow-Vorbeck and the Great War in Africa, 1914-1918", 28.690000000000001, 30 },
                    { 3, 2, 2, "https://img.thriftbooks.com/api/images/m/81690cdfa2eaab727c29d81b308efba1dec70a55.jpg", "Diary of a Wimpy Kid", 13.99, 20 },
                    { 4, 2, 2, "https://img.thriftbooks.com/api/images/m/a38190325523b980a79a9388e76fd5da6e397f34.jpg", "The Last Straw", 22.989999999999998, 50 },
                    { 5, 2, 2, "https://img.thriftbooks.com/api/images/i/m/A41687F6F3D81F875262446FEFE9383C61A2A6C8.jpg", "Diary of a wimpy kid. rodrick rules", 13.99, 40 },
                    { 6, 3, 3, "https://img.thriftbooks.com/api/images/m/456fbecc05164ed1e327ff5ee9922475d1e38df0.jpg", "Naruto, Vol. 3", 9.9900000000000002, 20 },
                    { 7, 3, 3, "https://img.thriftbooks.com/api/images/m/1414da15882c6e496e490103cbfb8b5948be77f7.jpg", "Naruto, Vol. 2", 9.9900000000000002, 10 },
                    { 8, 3, 3, "https://img.thriftbooks.com/api/images/m/5733979f44f82d7347b8d7718f996747462fe029.jpg", "Naruto, Vol. 1", 9.9900000000000002, 30 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Book_AuthorId",
                table: "Book",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Book_CategoryId",
                table: "Book",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_BookId",
                table: "Order",
                column: "BookId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Book");

            migrationBuilder.DropTable(
                name: "Author");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
