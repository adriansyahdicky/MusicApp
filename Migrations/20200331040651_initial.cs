using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicRoom.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artists",
                columns: table => new
                {
                    ArtistID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArtistName = table.Column<string>(nullable: true),
                    AlbumName = table.Column<string>(nullable: true),
                    ImageURL = table.Column<string>(nullable: true),
                    ReleaseDate = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    SampleURL = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artists", x => x.ArtistID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Artists");
        }
    }
}
