using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnionArchitecture.Persistence.Migrations
{
    public partial class mig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Birthday = table.Column<DateTime>(type: "datetime", nullable: true),
                    Gender = table.Column<bool>(type: "bit", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PasswordStatus = table.Column<bool>(type: "bit", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CardLangs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LangId = table.Column<int>(type: "int", nullable: false),
                    CardId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardLangs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FileUpload",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DownloadKey = table.Column<Guid>(type: "uniqueidentifier", maxLength: 50, nullable: false),
                    TableName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TableId = table.Column<int>(type: "int", nullable: true),
                    DocType = table.Column<short>(type: "smallint", nullable: true),
                    FileName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Url = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: true),
                    CreateUserId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileUpload", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FileUploadSettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Extension = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ContentType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SizeInMegabyte = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileUploadSettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ShortName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MessageLangs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MessageId = table.Column<int>(type: "int", nullable: false),
                    LangId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageLangs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<short>(type: "smallint", nullable: false),
                    Definition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SpeCodes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RefId = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    OrderBy = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpeCodes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SystemLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequestUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccessToken = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    RefreshToken = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    LogOut = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "Birthday", "CreatedDate", "Email", "FirstName", "Gender", "LastName", "Password", "PasswordStatus", "Phone", "Status", "UpdatedDate", "Username" },
                values: new object[] { 1, new DateTime(1996, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 8, 4, 14, 59, 46, 487, DateTimeKind.Local).AddTicks(5054), "BuludluMoka@gmail.com", "Moka", true, "Buludlu", "Moka", true, "0502420288", true, new DateTime(2023, 8, 4, 14, 59, 46, 487, DateTimeKind.Local).AddTicks(5063), "Moka" });

            migrationBuilder.InsertData(
                table: "CardLangs",
                columns: new[] { "Id", "CardId", "CreatedDate", "LangId", "Status", "Type", "UpdatedDate", "Value" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, true, "SpeCode", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Aktiv" },
                    { 2, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, true, "SpeCode", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Deaktiv" }
                });

            migrationBuilder.InsertData(
                table: "FileUploadSettings",
                columns: new[] { "Id", "ContentType", "CreatedDate", "Extension", "SizeInMegabyte", "Status", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "text/plain", new DateTime(2023, 8, 4, 14, 59, 46, 487, DateTimeKind.Local).AddTicks(6673), ".txt", 10, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "application/pdf", new DateTime(2023, 8, 4, 14, 59, 46, 487, DateTimeKind.Local).AddTicks(6677), ".pdf", 10, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "application/vnd.ms-word", new DateTime(2023, 8, 4, 14, 59, 46, 487, DateTimeKind.Local).AddTicks(6679), ".doc", 10, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "application/vnd.openxmlformats-officedocument.wordprocessingml.document", new DateTime(2023, 8, 4, 14, 59, 46, 487, DateTimeKind.Local).AddTicks(6682), ".docx", 10, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "application/vnd.ms-excel", new DateTime(2023, 8, 4, 14, 59, 46, 487, DateTimeKind.Local).AddTicks(6683), ".xls", 10, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", new DateTime(2023, 8, 4, 14, 59, 46, 487, DateTimeKind.Local).AddTicks(6685), ".xlsx", 10, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, "image/png", new DateTime(2023, 8, 4, 14, 59, 46, 487, DateTimeKind.Local).AddTicks(6687), ".png", 10, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, "image/jpeg", new DateTime(2023, 8, 4, 14, 59, 46, 487, DateTimeKind.Local).AddTicks(6688), ".jpg", 10, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, "image/jpeg", new DateTime(2023, 8, 4, 14, 59, 46, 487, DateTimeKind.Local).AddTicks(6690), ".jpeg", 10, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, "image/gif", new DateTime(2023, 8, 4, 14, 59, 46, 487, DateTimeKind.Local).AddTicks(6691), ".gif", 10, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, "text/csv", new DateTime(2023, 8, 4, 14, 59, 46, 487, DateTimeKind.Local).AddTicks(6692), ".csv", 10, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "CreatedDate", "Name", "ShortName", "Status", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 8, 4, 14, 59, 46, 487, DateTimeKind.Local).AddTicks(7024), "Azerbaycan", "AZ", true, new DateTime(2023, 8, 4, 14, 59, 46, 487, DateTimeKind.Local).AddTicks(7025) },
                    { 2, new DateTime(2023, 8, 4, 14, 59, 46, 487, DateTimeKind.Local).AddTicks(7030), "English", "EN", true, new DateTime(2023, 8, 4, 14, 59, 46, 487, DateTimeKind.Local).AddTicks(7031) }
                });

            migrationBuilder.InsertData(
                table: "MessageLangs",
                columns: new[] { "Id", "CreatedDate", "LangId", "MessageId", "Status", "UpdatedDate", "Value" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 8, 4, 14, 59, 46, 487, DateTimeKind.Local).AddTicks(7442), 1, 1, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yadda saxlanıldı." },
                    { 2, new DateTime(2023, 8, 4, 14, 59, 46, 487, DateTimeKind.Local).AddTicks(7444), 1, 2, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Silindi" },
                    { 3, new DateTime(2023, 8, 4, 14, 59, 46, 487, DateTimeKind.Local).AddTicks(7446), 1, 3, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yadda saxlanılarkən xəta baş verdi." },
                    { 4, new DateTime(2023, 8, 4, 14, 59, 46, 487, DateTimeKind.Local).AddTicks(7447), 1, 4, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Qadağan olunmuş əməliyyat" },
                    { 5, new DateTime(2023, 8, 4, 14, 59, 46, 487, DateTimeKind.Local).AddTicks(7448), 1, 5, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Təsdiq olunmayıb" },
                    { 6, new DateTime(2023, 8, 4, 14, 59, 46, 487, DateTimeKind.Local).AddTicks(7449), 1, 6, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Məlumat tapılmadı." },
                    { 7, new DateTime(2023, 8, 4, 14, 59, 46, 487, DateTimeKind.Local).AddTicks(7451), 1, 7, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Artıq təsdiqlənib." },
                    { 8, new DateTime(2023, 8, 4, 14, 59, 46, 487, DateTimeKind.Local).AddTicks(7452), 1, 8, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Verilmiş məlumatlar uyğun deyil." },
                    { 9, new DateTime(2023, 8, 4, 14, 59, 46, 487, DateTimeKind.Local).AddTicks(7453), 1, 9, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Daxil etdiyiniz məlumat artıq bazada mövcuddur!" },
                    { 10, new DateTime(2023, 8, 4, 14, 59, 46, 487, DateTimeKind.Local).AddTicks(7454), 1, 10, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Məlumatlar dəyişdirilə bilməz." },
                    { 11, new DateTime(2023, 8, 4, 14, 59, 46, 487, DateTimeKind.Local).AddTicks(7456), 1, 11, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ulduzlu bölmələri doldurun." },
                    { 12, new DateTime(2023, 8, 4, 14, 59, 46, 487, DateTimeKind.Local).AddTicks(7457), 1, 12, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Xəta baş verdi." },
                    { 13, new DateTime(2023, 8, 4, 14, 59, 46, 487, DateTimeKind.Local).AddTicks(7458), 1, 13, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Göndərilən parametrlər düzgün deyil." },
                    { 14, new DateTime(2023, 8, 4, 14, 59, 46, 487, DateTimeKind.Local).AddTicks(7459), 1, 14, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rate Limitə çatıldı." },
                    { 15, new DateTime(2023, 8, 4, 14, 59, 46, 487, DateTimeKind.Local).AddTicks(7460), 1, 15, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "İstifadəçi adı və ya şifrəsi yanlışdır." },
                    { 16, new DateTime(2023, 8, 4, 14, 59, 46, 487, DateTimeKind.Local).AddTicks(7461), 1, 16, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Token vaxtı bitib." },
                    { 17, new DateTime(2023, 8, 4, 14, 59, 46, 487, DateTimeKind.Local).AddTicks(7463), 1, 17, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yanlış token" },
                    { 18, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 18, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Avtorizasiya xətası" },
                    { 19, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 19, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Şifrələr eyni deyil!" },
                    { 20, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 20, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Istifadəçi aktiv deyil!" },
                    { 21, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 21, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "İstifadəçi adı artıq mövcuddur!" },
                    { 22, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 22, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bu mail adresinə bağlı istifədəçi artıq mövcuddur!" },
                    { 23, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 23, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hesab kilidləndi" },
                    { 24, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 24, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Şifrədə min. 6 simvol, böyük-kiçik hərf və bir xüsusi simvol olmalıdır" },
                    { 25, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 25, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Diqqət! Bu şifrəni artıq istifadə etmisiniz. Zəhmət olmasa yeni şifrə daxil edin" },
                    { 26, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 26, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Server xətası" }
                });

            migrationBuilder.InsertData(
                table: "MessageLangs",
                columns: new[] { "Id", "CreatedDate", "LangId", "MessageId", "Status", "UpdatedDate", "Value" },
                values: new object[,]
                {
                    { 27, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Saved successfully." },
                    { 28, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Deleted" },
                    { 29, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 3, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Error occurred while saving." },
                    { 30, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 4, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Operation forbidden" },
                    { 31, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 5, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Not confirmed" },
                    { 32, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 6, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Data not found." },
                    { 33, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 7, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Already confirmed." },
                    { 34, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 8, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The provided information is not suitable." },
                    { 35, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 9, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The information you entered already exists in the database!" },
                    { 36, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 10, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Data cannot be modified." },
                    { 37, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 11, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Please fill in the starred sections." },
                    { 38, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 12, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "An error occurred." },
                    { 39, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 13, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The parameters sent are not correct." },
                    { 40, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 14, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rate limit reached." },
                    { 41, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 15, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The username or password is incorrect." },
                    { 42, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 16, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Token has expired." },
                    { 43, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 17, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Invalid token" },
                    { 44, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 18, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Authorization error" },
                    { 45, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 19, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Passwords are not the same!" },
                    { 46, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 20, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "User is not active!" },
                    { 47, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 21, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The username already exists!" },
                    { 48, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 22, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A user already exists with this email address!" },
                    { 49, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 23, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Account locked" },
                    { 50, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 24, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Password must contain min. 6 characters, upper-lower case letters and a special character" },
                    { 51, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 25, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Attention! You've already used this password. Please enter a new password" },
                    { 52, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 26, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Server error" },
                    { 53, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 1, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Успешно сохранено." },
                    { 54, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Удалено" },
                    { 55, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 3, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Произошла ошибка при сохранении." },
                    { 56, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 4, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Операция запрещена" },
                    { 57, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 5, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Не подтверждено" },
                    { 58, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 6, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Данные не найдены." },
                    { 59, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 7, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Уже подтверждено." },
                    { 60, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 8, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Предоставленная информация не подходит." },
                    { 61, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 9, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Введенная вами информация уже существует в базе данных!" },
                    { 62, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 10, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Данные нельзя изменить." },
                    { 63, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 11, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Пожалуйста, заполните обязательные поля." },
                    { 64, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 12, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Произошла ошибка." },
                    { 65, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 13, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Отправленные параметры некорректны." },
                    { 66, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 14, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Достигнут лимит скорости." },
                    { 67, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 15, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Имя пользователя или пароль неверны." },
                    { 68, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 16, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Срок действия токена истек." }
                });

            migrationBuilder.InsertData(
                table: "MessageLangs",
                columns: new[] { "Id", "CreatedDate", "LangId", "MessageId", "Status", "UpdatedDate", "Value" },
                values: new object[,]
                {
                    { 69, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 17, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Неверный токен" },
                    { 70, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 18, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ошибка авторизации" },
                    { 71, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 19, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Пароли не совпадают!" },
                    { 72, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 20, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Пользователь не активен!" },
                    { 73, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 21, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Имя пользователя уже существует!" },
                    { 74, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 22, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Пользователь уже существует с этим адресом электронной почты!" },
                    { 75, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 23, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Аккаунт заблокирован" },
                    { 76, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 24, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Пароль должен содержать мин. 6 символов, заглавные и строчные буквы и специальный символ" },
                    { 77, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 25, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Внимание! Вы уже использовали этот пароль. Пожалуйста, введите новый пароль" },
                    { 78, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 26, true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ошибка сервера" }
                });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "Code", "CreatedDate", "Definition", "Note", "Status", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, (short)1000, new DateTime(2023, 8, 4, 14, 59, 46, 487, DateTimeKind.Local).AddTicks(7236), "SaveSuccess", "", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, (short)4000, new DateTime(2023, 8, 4, 14, 59, 46, 487, DateTimeKind.Local).AddTicks(7240), "SaveFailure", "", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, (short)1001, new DateTime(2023, 8, 4, 14, 59, 46, 487, DateTimeKind.Local).AddTicks(7239), "Deleted", "", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, (short)4004, new DateTime(2023, 8, 4, 14, 59, 46, 487, DateTimeKind.Local).AddTicks(7243), "NotFound", "", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, (short)4001, new DateTime(2023, 8, 4, 14, 59, 46, 487, DateTimeKind.Local).AddTicks(7241), "BlockedOperation", "", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, (short)4002, new DateTime(2023, 8, 4, 14, 59, 46, 487, DateTimeKind.Local).AddTicks(7242), "NotApproved", "", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, (short)4005, new DateTime(2023, 8, 4, 14, 59, 46, 487, DateTimeKind.Local).AddTicks(7245), "AlreadyApproved", "", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, (short)4006, new DateTime(2023, 8, 4, 14, 59, 46, 487, DateTimeKind.Local).AddTicks(7246), "DataConflict", "", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, (short)4007, new DateTime(2023, 8, 4, 14, 59, 46, 487, DateTimeKind.Local).AddTicks(7247), "AlreadyExists", "", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, (short)4008, new DateTime(2023, 8, 4, 14, 59, 46, 487, DateTimeKind.Local).AddTicks(7249), "CannotBeChanged", "", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, (short)4009, new DateTime(2023, 8, 4, 14, 59, 46, 487, DateTimeKind.Local).AddTicks(7251), "FillRequiredFields", "", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, (short)4010, new DateTime(2023, 8, 4, 14, 59, 46, 487, DateTimeKind.Local).AddTicks(7252), "UnexpectedError", "", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13, (short)4011, new DateTime(2023, 8, 4, 14, 59, 46, 487, DateTimeKind.Local).AddTicks(7253), "InvalidRequestParameters", "", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, (short)4012, new DateTime(2023, 8, 4, 14, 59, 46, 487, DateTimeKind.Local).AddTicks(7254), "RateLimitReached", "", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15, (short)4013, new DateTime(2023, 8, 4, 14, 59, 46, 487, DateTimeKind.Local).AddTicks(7255), "UserNamePasswordIncorrect", "", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 16, (short)4014, new DateTime(2023, 8, 4, 14, 59, 46, 487, DateTimeKind.Local).AddTicks(7256), "TokenExpired", "", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 17, (short)4015, new DateTime(2023, 8, 4, 14, 59, 46, 487, DateTimeKind.Local).AddTicks(7258), "TokenIsInvalid", "", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 18, (short)4016, new DateTime(2023, 8, 4, 14, 59, 46, 487, DateTimeKind.Local).AddTicks(7259), "Unauthorized", "", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 19, (short)4017, new DateTime(2023, 8, 4, 14, 59, 46, 487, DateTimeKind.Local).AddTicks(7260), "ConfirmPasswordError", "", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 20, (short)4018, new DateTime(2023, 8, 4, 14, 59, 46, 487, DateTimeKind.Local).AddTicks(7261), "UserNotActive", "", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 21, (short)4019, new DateTime(2023, 8, 4, 14, 59, 46, 487, DateTimeKind.Local).AddTicks(7262), "UserNameAlreadyExists", "", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 22, (short)4020, new DateTime(2023, 8, 4, 14, 59, 46, 487, DateTimeKind.Local).AddTicks(7263), "EmailAlreadyExists", "", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 23, (short)4021, new DateTime(2023, 8, 4, 14, 59, 46, 487, DateTimeKind.Local).AddTicks(7264), "AccountLocked", "", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 24, (short)4022, new DateTime(2023, 8, 4, 14, 59, 46, 487, DateTimeKind.Local).AddTicks(7265), "PasswordValidation", "", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 25, (short)4023, new DateTime(2023, 8, 4, 14, 59, 46, 487, DateTimeKind.Local).AddTicks(7267), "OldPasswordError", "", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 26, (short)5000, new DateTime(2023, 8, 4, 14, 59, 46, 487, DateTimeKind.Local).AddTicks(7268), "InternalServerError", "", true, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "SpeCodes",
                columns: new[] { "Id", "Code", "CreatedDate", "OrderBy", "RefId", "Status", "Type", "UpdatedDate", "Value" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, true, "All", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Aktiv" },
                    { 2, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2, true, "All", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Deaktiv" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppUsers");

            migrationBuilder.DropTable(
                name: "CardLangs");

            migrationBuilder.DropTable(
                name: "FileUpload");

            migrationBuilder.DropTable(
                name: "FileUploadSettings");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "MessageLangs");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "SpeCodes");

            migrationBuilder.DropTable(
                name: "SystemLogs");

            migrationBuilder.DropTable(
                name: "UserTokens");
        }
    }
}
