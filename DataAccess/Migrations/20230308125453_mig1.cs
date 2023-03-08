using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class mig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "ID", "CreatedDate", "DeletedDate", "FileName", "FileType", "IsDeleted", "ModifiedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 3, 8, 15, 54, 53, 61, DateTimeKind.Local).AddTicks(3539), null, "ASP.NET Core Image", "Jpg", false, null },
                    { 2, new DateTime(2023, 3, 8, 15, 54, 53, 61, DateTimeKind.Local).AddTicks(3541), null, "Redis Deneme Makalesi", "png", false, null },
                    { 3, new DateTime(2023, 3, 8, 15, 54, 53, 61, DateTimeKind.Local).AddTicks(3542), null, "Docker Deneme Makalesi", "png", false, null }
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "ID", "CategoryId", "Content", "CreatedDate", "DeletedDate", "ImageId", "IsDeleted", "ModifiedDate", "Title", "ViewCount" },
                values: new object[] { 1, 1, "AspNet Core Deneme Makalesi Lorem ipsum dolor sit amet, consectetur adipiscing elit. Pellentesque eget posuere magna. Phasellus pulvinar ultrices maximus. Maecenas non porta ligula. In ac dui sollicitudin, elementum felis vitae, viverra diam. Donec ut dolor eu dolor mattis tristique. Sed commodo eu justo rutrum condimentum. Sed dolor tellus, bibendum sit amet erat ac, auctor facilisis nulla. Mauris feugiat enim sed eros tincidunt, a finibus ex iaculis. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Etiam mattis sit amet tellus at placerat. Nulla sagittis condimentum tortor, tincidunt tincidunt erat dictum at. Cras sit amet mi leo. Sed eu risus cursus, congue metus eu, convallis ante. Maecenas ac luctus tellus, a iaculis velit. Vestibulum porta accumsan nulla, ut ultricies neque pellentesque vitae. Duis nisl tellus, interdum vel rhoncus in, condimentum quis erat.\r\n\r\nQuisque vitae porta metus. Integer laoreet porta ligula vitae pharetra. Donec pharetra, ipsum in pellentesque auctor, urna turpis feugiat erat, non aliquam lacus odio id nunc. Curabitur porta in lacus id blandit. Nullam lorem dolor, lacinia in varius sed, consequat sollicitudin urna. Nulla facilisi", new DateTime(2023, 3, 8, 15, 54, 53, 61, DateTimeKind.Local).AddTicks(3472), null, 1, false, null, "AspNet Core Deneme Makalesi", 0 });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "ID", "CategoryId", "Content", "CreatedDate", "DeletedDate", "ImageId", "IsDeleted", "ModifiedDate", "Title", "ViewCount" },
                values: new object[] { 2, 2, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Pellentesque eget posuere magna. Phasellus pulvinar ultrices maximus. Maecenas non porta ligula. In ac dui sollicitudin, elementum felis vitae, viverra diam. Donec ut dolor eu dolor mattis tristique. Sed commodo eu justo rutrum condimentum. Sed dolor tellus, bibendum sit amet erat ac, auctor facilisis nulla. Mauris feugiat enim sed eros tincidunt, a finibus ex iaculis. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Etiam mattis sit amet tellus at placerat. Nulla sagittis condimentum tortor, tincidunt tincidunt erat dictum at. Cras sit amet mi leo. Sed eu risus cursus, congue metus eu, convallis ante. Maecenas ac luctus tellus, a iaculis velit. Vestibulum porta accumsan nulla, ut ultricies neque pellentesque vitae. Duis nisl tellus, interdum vel rhoncus in, condimentum quis erat.\r\n\r\nQuisque vitae porta metus. Integer laoreet porta ligula vitae pharetra. Donec pharetra, ipsum in pellentesque auctor, urna turpis feugiat erat, non aliquam lacus odio id nunc. Curabitur porta in lacus id blandit. Nullam lorem dolor, lacinia in varius sed, consequat sollicitudin urna. Nulla facilisi", new DateTime(2023, 3, 8, 15, 54, 53, 61, DateTimeKind.Local).AddTicks(3475), null, 2, false, null, "Redis Deneme Makalesi", 0 });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "ID", "CategoryId", "Content", "CreatedDate", "DeletedDate", "ImageId", "IsDeleted", "ModifiedDate", "Title", "ViewCount" },
                values: new object[] { 3, 3, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Pellentesque eget posuere magna. Phasellus pulvinar ultrices maximus. Maecenas non porta ligula. In ac dui sollicitudin, elementum felis vitae, viverra diam. Donec ut dolor eu dolor mattis tristique. Sed commodo eu justo rutrum condimentum. Sed dolor tellus, bibendum sit amet erat ac, auctor facilisis nulla. Mauris feugiat enim sed eros tincidunt, a finibus ex iaculis. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Etiam mattis sit amet tellus at placerat. Nulla sagittis condimentum tortor, tincidunt tincidunt erat dictum at. Cras sit amet mi leo. Sed eu risus cursus, congue metus eu, convallis ante. Maecenas ac luctus tellus, a iaculis velit. Vestibulum porta accumsan nulla, ut ultricies neque pellentesque vitae. Duis nisl tellus, interdum vel rhoncus in, condimentum quis erat.\r\n\r\nQuisque vitae porta metus. Integer laoreet porta ligula vitae pharetra. Donec pharetra, ipsum in pellentesque auctor, urna turpis feugiat erat, non aliquam lacus odio id nunc. Curabitur porta in lacus id blandit. Nullam lorem dolor, lacinia in varius sed, consequat sollicitudin urna. Nulla facilisi", new DateTime(2023, 3, 8, 15, 54, 53, 61, DateTimeKind.Local).AddTicks(3477), null, 3, false, null, "Docker Deneme Makalesi", 0 });

            migrationBuilder.CreateIndex(
                name: "IX_Articles_CategoryId",
                table: "Articles",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_ImageId",
                table: "Articles",
                column: "ImageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Images");
        }
    }
}
