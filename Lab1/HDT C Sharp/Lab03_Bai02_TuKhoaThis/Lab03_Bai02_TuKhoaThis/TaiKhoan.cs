using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab03_Bai02_TuKhoaThis
{
	internal class TaiKhoan
	{
		private int maTk;
		private int soDu;

		public int MaSoTK
		{ get { return maTk; } }

		public int SoDu
		{ get { return soDu; } }

		public TaiKhoan (int maTk, int soDu)
		{ 
		this.maTk = maTk; 
		this.soDu = soDu;
		}

		public void GuiTien(int soTien)
		{
			this.soDu += soTien;
		}

		public bool RutTien(int soTien)
		{
			if (soDu >= soTien)
			{
				this.soDu -= soTien;
				return true;
			}
			else
			{
				Console.WriteLine("Tai khoan khong co du tien");
				return false;
			}
		}

		public bool ChuyenKhoan(int soTien, TaiKhoan toiTk)
		{
			var thanhCong = this.RutTien(soTien);
			if (thanhCong)
				toiTk.GuiTien(soTien);

			return thanhCong;
		}
		public override string ToString()
		{
			return string.Format("Tai khoan {0} co so du {1}",
								maTk, soDu);
		}
	}
}
