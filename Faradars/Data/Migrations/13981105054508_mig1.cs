using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Faradars.Data.Migrations
{
    public partial class mig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 128);

            migrationBuilder.CreateTable(
                name: "dargahPardakhts",
                columns: table => new
                {
                    DargahPardakht_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DargahPardakht_NameBank = table.Column<string>(maxLength: 100, nullable: true),
                    DargahPardakht_Code = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dargahPardakhts", x => x.DargahPardakht_ID);
                });

            migrationBuilder.CreateTable(
                name: "hotels",
                columns: table => new
                {
                    Hotel_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name_Hotel = table.Column<string>(maxLength: 100, nullable: false),
                    Adres = table.Column<string>(maxLength: 350, nullable: true),
                    Jozeyat_Gheymat = table.Column<long>(nullable: false),
                    ZamanShoroa = table.Column<DateTime>(nullable: false),
                    ZamanPayan = table.Column<DateTime>(nullable: false),
                    Faal = table.Column<bool>(nullable: false),
                    Tozihat = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hotels", x => x.Hotel_ID);
                });

            migrationBuilder.CreateTable(
                name: "ostanHotels",
                columns: table => new
                {
                    Ostan_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Ostan_Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ostanHotels", x => x.Ostan_ID);
                });

            migrationBuilder.CreateTable(
                name: "tanzimatEmails",
                columns: table => new
                {
                    Eamil_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Eamil_EmailSend = table.Column<string>(maxLength: 100, nullable: true),
                    Eamil_Password = table.Column<string>(maxLength: 100, nullable: true),
                    Eamil_UserName = table.Column<string>(maxLength: 100, nullable: true),
                    Eamil_Port = table.Column<string>(maxLength: 100, nullable: true),
                    Eamil_Smtp = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tanzimatEmails", x => x.Eamil_ID);
                });

            migrationBuilder.CreateTable(
                name: "tedadStarehs",
                columns: table => new
                {
                    TedadStareh_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TedadStareh_Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tedadStarehs", x => x.TedadStareh_ID);
                });

            migrationBuilder.CreateTable(
                name: "tedadTakhtHotels",
                columns: table => new
                {
                    TedadTakh_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TedadTakh_Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tedadTakhtHotels", x => x.TedadTakh_ID);
                });

            migrationBuilder.CreateTable(
                name: "zarfyatOtaghHotels",
                columns: table => new
                {
                    ZarfyatOtagh_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ZarfyatOtagh_Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_zarfyatOtaghHotels", x => x.ZarfyatOtagh_ID);
                });

            migrationBuilder.CreateTable(
                name: "emkanatHotels",
                columns: table => new
                {
                    Emkanat_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Emkanat_Name = table.Column<string>(maxLength: 100, nullable: false),
                    Emkanat_Icon = table.Column<string>(maxLength: 100, nullable: false),
                    Emkanat_IdHotel = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_emkanatHotels", x => x.Emkanat_ID);
                    table.ForeignKey(
                        name: "FK_emkanatHotels_hotels_Emkanat_IdHotel",
                        column: x => x.Emkanat_IdHotel,
                        principalTable: "hotels",
                        principalColumn: "Hotel_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "nazarats",
                columns: table => new
                {
                    Nazarat_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nazarat_Name = table.Column<string>(maxLength: 100, nullable: false),
                    Nazarat_Matn = table.Column<string>(maxLength: 200, nullable: false),
                    Nazarat_Zaman = table.Column<string>(maxLength: 100, nullable: false),
                    Nazarat_HotelID = table.Column<int>(nullable: false),
                    Nazarat_Email = table.Column<string>(maxLength: 100, nullable: false),
                    Nazarat_Emtyaz = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nazarats", x => x.Nazarat_ID);
                    table.ForeignKey(
                        name: "FK_nazarats_hotels_Nazarat_HotelID",
                        column: x => x.Nazarat_HotelID,
                        principalTable: "hotels",
                        principalColumn: "Hotel_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "rezervHotels",
                columns: table => new
                {
                    Rezerv_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Rezerv_IDHotel = table.Column<int>(nullable: false),
                    Rezerv_Jensiat = table.Column<int>(nullable: false),
                    Rezerv_Name = table.Column<string>(maxLength: 100, nullable: true),
                    Rezerv_NameKhanevadgi = table.Column<string>(maxLength: 100, nullable: true),
                    Rezerv_Codemeli = table.Column<string>(maxLength: 10, nullable: true),
                    Rezerv_Mobile = table.Column<string>(maxLength: 11, nullable: true),
                    Rezerv_Email = table.Column<string>(maxLength: 100, nullable: true),
                    Rezerv_TeadadNafarat = table.Column<int>(nullable: false),
                    Rezerv_TeadadOthagh = table.Column<int>(nullable: false),
                    Rezerv_Vorod = table.Column<DateTime>(nullable: false),
                    Rezerv_Khoroj = table.Column<DateTime>(nullable: false),
                    Rezerv_Mablagh = table.Column<long>(nullable: false),
                    Rezerv_Vazeyt = table.Column<bool>(nullable: false),
                    Rezerv_Roz = table.Column<int>(nullable: false),
                    Rezerv_IP = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rezervHotels", x => x.Rezerv_ID);
                    table.ForeignKey(
                        name: "FK_rezervHotels_hotels_Rezerv_IDHotel",
                        column: x => x.Rezerv_IDHotel,
                        principalTable: "hotels",
                        principalColumn: "Hotel_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tasavirHotels",
                columns: table => new
                {
                    Tasavir_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Tasavir_Name = table.Column<string>(maxLength: 100, nullable: false),
                    Tasavir_IDHotel = table.Column<int>(nullable: false),
                    Tasavir_Asli = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tasavirHotels", x => x.Tasavir_ID);
                    table.ForeignKey(
                        name: "FK_tasavirHotels_hotels_Tasavir_IDHotel",
                        column: x => x.Tasavir_IDHotel,
                        principalTable: "hotels",
                        principalColumn: "Hotel_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "jozeyatHotels",
                columns: table => new
                {
                    Jozeyat_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Jozeyat_HotelID = table.Column<int>(nullable: false),
                    Jozeyat_ZarfiatOtaghID = table.Column<int>(nullable: false),
                    Jozeyat_TedadTakhtID = table.Column<int>(nullable: false),
                    Jozeyat_OstanID = table.Column<int>(nullable: false),
                    Jozeyat_TedadStareID = table.Column<int>(nullable: false),
                    Jozeyat_Teadad = table.Column<int>(nullable: false),
                    ZarfyatOtaghHotel = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_jozeyatHotels", x => x.Jozeyat_ID);
                    table.ForeignKey(
                        name: "FK_jozeyatHotels_hotels_Jozeyat_HotelID",
                        column: x => x.Jozeyat_HotelID,
                        principalTable: "hotels",
                        principalColumn: "Hotel_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_jozeyatHotels_ostanHotels_Jozeyat_OstanID",
                        column: x => x.Jozeyat_OstanID,
                        principalTable: "ostanHotels",
                        principalColumn: "Ostan_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_jozeyatHotels_tedadStarehs_Jozeyat_TedadStareID",
                        column: x => x.Jozeyat_TedadStareID,
                        principalTable: "tedadStarehs",
                        principalColumn: "TedadStareh_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_jozeyatHotels_tedadTakhtHotels_Jozeyat_TedadTakhtID",
                        column: x => x.Jozeyat_TedadTakhtID,
                        principalTable: "tedadTakhtHotels",
                        principalColumn: "TedadTakh_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_jozeyatHotels_zarfyatOtaghHotels_ZarfyatOtaghHotel",
                        column: x => x.ZarfyatOtaghHotel,
                        principalTable: "zarfyatOtaghHotels",
                        principalColumn: "ZarfyatOtagh_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "pardakhtHotels",
                columns: table => new
                {
                    Pardakh_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Pardakh_IDHotel = table.Column<int>(nullable: false),
                    Pardakh_ZamanVariz = table.Column<DateTime>(nullable: false),
                    Pardakh_Pigiry = table.Column<string>(maxLength: 30, nullable: false),
                    Pardakh_Mablagh = table.Column<long>(nullable: false),
                    Pardakh_Vazeiat = table.Column<bool>(nullable: false),
                    Pardakh_Trakonesh = table.Column<string>(maxLength: 50, nullable: true),
                    Pardakh_Marjaa = table.Column<string>(maxLength: 50, nullable: false),
                    Pardakh_Rezerv = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pardakhtHotels", x => x.Pardakh_ID);
                    table.ForeignKey(
                        name: "FK_pardakhtHotels_hotels_Pardakh_IDHotel",
                        column: x => x.Pardakh_IDHotel,
                        principalTable: "hotels",
                        principalColumn: "Hotel_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_pardakhtHotels_rezervHotels_Pardakh_Rezerv",
                        column: x => x.Pardakh_Rezerv,
                        principalTable: "rezervHotels",
                        principalColumn: "Rezerv_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_emkanatHotels_Emkanat_IdHotel",
                table: "emkanatHotels",
                column: "Emkanat_IdHotel");

            migrationBuilder.CreateIndex(
                name: "IX_jozeyatHotels_Jozeyat_HotelID",
                table: "jozeyatHotels",
                column: "Jozeyat_HotelID");

            migrationBuilder.CreateIndex(
                name: "IX_jozeyatHotels_Jozeyat_OstanID",
                table: "jozeyatHotels",
                column: "Jozeyat_OstanID");

            migrationBuilder.CreateIndex(
                name: "IX_jozeyatHotels_Jozeyat_TedadStareID",
                table: "jozeyatHotels",
                column: "Jozeyat_TedadStareID");

            migrationBuilder.CreateIndex(
                name: "IX_jozeyatHotels_Jozeyat_TedadTakhtID",
                table: "jozeyatHotels",
                column: "Jozeyat_TedadTakhtID");

            migrationBuilder.CreateIndex(
                name: "IX_jozeyatHotels_ZarfyatOtaghHotel",
                table: "jozeyatHotels",
                column: "ZarfyatOtaghHotel");

            migrationBuilder.CreateIndex(
                name: "IX_nazarats_Nazarat_HotelID",
                table: "nazarats",
                column: "Nazarat_HotelID");

            migrationBuilder.CreateIndex(
                name: "IX_pardakhtHotels_Pardakh_IDHotel",
                table: "pardakhtHotels",
                column: "Pardakh_IDHotel");

            migrationBuilder.CreateIndex(
                name: "IX_pardakhtHotels_Pardakh_Rezerv",
                table: "pardakhtHotels",
                column: "Pardakh_Rezerv");

            migrationBuilder.CreateIndex(
                name: "IX_rezervHotels_Rezerv_IDHotel",
                table: "rezervHotels",
                column: "Rezerv_IDHotel");

            migrationBuilder.CreateIndex(
                name: "IX_tasavirHotels_Tasavir_IDHotel",
                table: "tasavirHotels",
                column: "Tasavir_IDHotel");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "dargahPardakhts");

            migrationBuilder.DropTable(
                name: "emkanatHotels");

            migrationBuilder.DropTable(
                name: "jozeyatHotels");

            migrationBuilder.DropTable(
                name: "nazarats");

            migrationBuilder.DropTable(
                name: "pardakhtHotels");

            migrationBuilder.DropTable(
                name: "tanzimatEmails");

            migrationBuilder.DropTable(
                name: "tasavirHotels");

            migrationBuilder.DropTable(
                name: "ostanHotels");

            migrationBuilder.DropTable(
                name: "tedadStarehs");

            migrationBuilder.DropTable(
                name: "tedadTakhtHotels");

            migrationBuilder.DropTable(
                name: "zarfyatOtaghHotels");

            migrationBuilder.DropTable(
                name: "rezervHotels");

            migrationBuilder.DropTable(
                name: "hotels");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
