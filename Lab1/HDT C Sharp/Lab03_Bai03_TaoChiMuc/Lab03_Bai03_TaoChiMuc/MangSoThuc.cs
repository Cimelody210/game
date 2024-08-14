using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab03_Bai03_TaoChiMuc
{
	internal class MangSoThuc
	{
		private double[] mang;
		private int soLuong;

		public int SoLuong
		{
			get { return soLuong; }
		}

		public double this[int vitri] 
		{
			get { return mang[vitri]; }
			set { mang[vitri] = value; }
		}
		public void Them(double so)
		{
			mang[soLuong] = so;
			soLuong++;
		}
	}
}
