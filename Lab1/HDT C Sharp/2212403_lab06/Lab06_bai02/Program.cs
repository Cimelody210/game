using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Lab06_bai02
    
{
    public enum LoaiHinh { TatCa, HinhTron, HinhVuong, HinhChuNhat }
    internal class Program
    {
        static void Main(string[] args)
        {
            //HinhTron vong= new HinhTron(5);
            //HinhHoc tron = new HinhTron(5);
            //vong.Xuat();
            //tron.Xuat();
            //Console.WriteLine(vong.TinhDienTich());
            // Console.WriteLine(tron.TinhDienTich());
            HinhHoc tron = new HinhTron(5);
            HinhHoc vuong=new HinhVuong(5);
            HinhHoc cnh=new HinhChuNhat(5,3);
            tron.Xuat();
            vuong.Xuat();
            cnh.Xuat();
            DanhSachHinhHoc mang = new DanhSachHinhHoc();
            mang.NhapCoDinh();
            Console.WriteLine(" so hinh hoc trong danh sach{0}", mang.SoLuong);
            mang.Xuat();
            DanhSachHinhHoc dsHCN = mang.TimHinhTheoLoai(LoaiHinh.HinhChuNhat);
            dsHCN.Xuat();
            Console.WriteLine("==============================================");
            DanhSachHinhHoc hinhLon = mang.TimHinhCoDienTichLonNhat();
            hinhLon.Xuat();

            Console.WriteLine("===============================================");
            DanhSachHinhHoc hcnLon = dsHCN.TimHinhCoDienTichLonNhat();
            hcnLon.Xuat();
            mang.SaptangTheodienTich();
            Console.WriteLine("===============================================");
            mang.Xuat();
            Console.WriteLine("===============================================");
            DanhSachHinhHoc dsVuong = mang.TimHinhTheoLoai(LoaiHinh.HinhVuong);
            dsVuong.SaptangTheodienTich();
            dsVuong.Xuat();
        }
    }
}
