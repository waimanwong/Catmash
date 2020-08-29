using Microsoft.EntityFrameworkCore.Migrations;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text.Json;

namespace Catmash.Migrations
{
    public partial class InitImageTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                });

            SeedImageTable(migrationBuilder);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Images");
        }

        private void SeedImageTable(MigrationBuilder migrationBuilder)
        {
            var resourceName = "Catmash.Migrations.images.json";
            var assembly = Assembly.GetExecutingAssembly();

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                var json = reader.ReadToEnd();
                var images = JsonSerializer.Deserialize<ImageCollection>(json).images;

                foreach(var image in images)
                {
                    migrationBuilder.InsertData(
                        table: "Images",
                        columns: new[] { "Id", "Url" },
                        values: new object[] { image.id, image.url });
                }
            }
        }

        private class ImageCollection
        {
            public List<Image> images { get; set; }
        }

        private class Image
        {
            public string id { get; set; }
            public string url { get; set; }
        }
    }
}
