using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Day7Lab.Migrations
{
    /// <inheritdoc />
    public partial class m1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KHACH_HANG",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaKhachHang = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    HoTenKhachHang = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Email = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    MaKhau = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    DienThoai = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    NgayDangKy = table.Column<DateTime>(type: "datetime", nullable: true),
                    TrangThai = table.Column<byte>(type: "tinyint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__KHACH_HA__3214EC2716DEDCD0", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "LOAI_SAN_PHAM",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaLoai = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    TenLoai = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    TrangThai = table.Column<byte>(type: "tinyint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__LOAI_SAN__3214EC27DDC9A147", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "QUAN_TRI",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaiKhoan = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: true),
                    MatKhau = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    TrangThai = table.Column<byte>(type: "tinyint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__QUAN_TRI__3214EC27838A5F38", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "HOA_DON",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaHoaDon = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    MaKhaHang = table.Column<int>(type: "int", nullable: true),
                    NgayHoaDon = table.Column<DateTime>(type: "datetime", nullable: true),
                    NgayNhan = table.Column<DateTime>(type: "datetime", nullable: true),
                    HoTenKhachHang = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Email = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    DienThoai = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    TongTriGia = table.Column<double>(type: "float", nullable: true),
                    TrangThai = table.Column<byte>(type: "tinyint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__HOA_DON__3214EC27F2B2A746", x => x.ID);
                    table.ForeignKey(
                        name: "FK__HOA_DON__MaKhaHa__33D4B598",
                        column: x => x.MaKhaHang,
                        principalTable: "KHACH_HANG",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "SAN_PHAM",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaSanPham = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    TenSanPham = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    HinhAnh = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SoLuong = table.Column<int>(type: "int", nullable: true),
                    DonGia = table.Column<double>(type: "float", nullable: true),
                    MaLoai = table.Column<int>(type: "int", nullable: true),
                    TrangThai = table.Column<byte>(type: "tinyint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__SAN_PHAM__3214EC27160EACCA", x => x.ID);
                    table.ForeignKey(
                        name: "FK__SAN_PHAM__MaLoai__2B3F6F97",
                        column: x => x.MaLoai,
                        principalTable: "LOAI_SAN_PHAM",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "CT_HOA_DON",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HoaDonID = table.Column<int>(type: "int", nullable: true),
                    SanPhamID = table.Column<int>(type: "int", nullable: true),
                    SoLuongMua = table.Column<int>(type: "int", nullable: true),
                    DonGiaMua = table.Column<double>(type: "float", nullable: true),
                    ThanhTien = table.Column<double>(type: "float", nullable: true),
                    TrangThai = table.Column<byte>(type: "tinyint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CT_HOA_D__3214EC27CE99679B", x => x.ID);
                    table.ForeignKey(
                        name: "FK__CT_HOA_DO__HoaDo__36B12243",
                        column: x => x.HoaDonID,
                        principalTable: "HOA_DON",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK__CT_HOA_DO__SanPh__37A5467C",
                        column: x => x.SanPhamID,
                        principalTable: "SAN_PHAM",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CT_HOA_DON_HoaDonID",
                table: "CT_HOA_DON",
                column: "HoaDonID");

            migrationBuilder.CreateIndex(
                name: "IX_CT_HOA_DON_SanPhamID",
                table: "CT_HOA_DON",
                column: "SanPhamID");

            migrationBuilder.CreateIndex(
                name: "IX_HOA_DON_MaKhaHang",
                table: "HOA_DON",
                column: "MaKhaHang");

            migrationBuilder.CreateIndex(
                name: "UQ__HOA_DON__835ED13A71FAE05C",
                table: "HOA_DON",
                column: "MaHoaDon",
                unique: true,
                filter: "[MaHoaDon] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UQ__KHACH_HA__1F031876FD7BA43B",
                table: "KHACH_HANG",
                column: "DienThoai",
                unique: true,
                filter: "[DienThoai] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UQ__KHACH_HA__88D2F0E4F09C71EA",
                table: "KHACH_HANG",
                column: "MaKhachHang",
                unique: true,
                filter: "[MaKhachHang] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UQ__KHACH_HA__A9D1053400A0055E",
                table: "KHACH_HANG",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UQ__LOAI_SAN__730A5758114F4AF7",
                table: "LOAI_SAN_PHAM",
                column: "MaLoai",
                unique: true,
                filter: "[MaLoai] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UQ__QUAN_TRI__D5B8C7F01A99EE30",
                table: "QUAN_TRI",
                column: "TaiKhoan",
                unique: true,
                filter: "[TaiKhoan] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_SAN_PHAM_MaLoai",
                table: "SAN_PHAM",
                column: "MaLoai");

            migrationBuilder.CreateIndex(
                name: "UQ__SAN_PHAM__FAC7442C235FEF00",
                table: "SAN_PHAM",
                column: "MaSanPham",
                unique: true,
                filter: "[MaSanPham] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CT_HOA_DON");

            migrationBuilder.DropTable(
                name: "QUAN_TRI");

            migrationBuilder.DropTable(
                name: "HOA_DON");

            migrationBuilder.DropTable(
                name: "SAN_PHAM");

            migrationBuilder.DropTable(
                name: "KHACH_HANG");

            migrationBuilder.DropTable(
                name: "LOAI_SAN_PHAM");
        }
    }
}
