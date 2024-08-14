using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTap
{
	internal class HinhTron
	{
		private double _bankinh;
		private string _mau;

		public double BanKinh
		{
			get { return _bankinh; }
			set { _bankinh = value; }
			}
		public string MauSac
		{ 
			get { return _mau; } 
		set { _mau = value;}
		}
		public HinhTron() { }
		public HinhTron(double bankinh) { BanKinh = bankinh; }
		public HinhTron(double bk, string mau) {BanKinh = bk; MauSac = mau;}	

		public void BienDoiTyLe (double tyle)
		{
			BanKinh *= tyle;
		}
		public double TinhChuVi()
		{ 
			return 2 * Math.PI * BanKinh;
		}
		public double TinhDienTich()
		{
			return Math.PI * BanKinh * BanKinh;
		}
		public override string ToString()
		{
			return $"Ban kinh: {BanKinh}, Mau: {MauSac}, Chu vi: {TinhChuVi():F2}, Dien Tich:{TinhDienTich():F2}";
		}
	}
}
