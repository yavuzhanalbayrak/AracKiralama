using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebProje.Migrations
{
    /// <inheritdoc />
    public partial class kurulum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "araclar",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    marka = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    yil = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    renk = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    aracResmi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tur = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    durum = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sahibi = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_araclar", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "kiralama",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    kullaniciId = table.Column<int>(type: "int", nullable: true),
                    aracId = table.Column<int>(type: "int", nullable: true),
                    aracAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    aracModeli = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kiralama", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "kullanici",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    kullaniciAdi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    sifre = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    rol = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kullanici", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "araclar");

            migrationBuilder.DropTable(
                name: "kiralama");

            migrationBuilder.DropTable(
                name: "kullanici");
        }
    }
}
