using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2015614_Lab03
{
	internal class PhanSo
	{
		public int TuSo;
		public int MauSo;

		public PhanSo() { }
		public PhanSo(int tu, int mau)
		{
			TuSo = tu;
			MauSo = mau;
		}

		public double TinhGiaTri()
		{
			return (double)TuSo / MauSo;
		}
		public PhanSo NghichDao()
		{
			return new PhanSo(MauSo, TuSo);
		}

		public PhanSo RutGon()
		{
			int uc = ToanHoc.UCLN(TuSo, MauSo);
			return new PhanSo(TuSo / uc, MauSo / uc);
		}

		public override string ToString()
		{
			return string.Format("{0}/{1}", TuSo, MauSo);
		}

		/*private int _tu;
		private int _mau;
		public int TuSo
		{
			get { return _tu; }
			set { _tu = value; }
		}
		public int MauSo
		{ 
			get { return _mau; } 
			set
			{
				if (value == 0)
					_mau = 1;
				else
					_mau = value;
			}
		}*/
		public double GiaTri
		{
			get { return TinhGiaTri(); }
		}
		public PhanSo Nhan(int k)
		{
			return new PhanSo(TuSo * k, MauSo);
		}

		public PhanSo Nhan(PhanSo x)
		{
			return new PhanSo(TuSo * x.TuSo, MauSo * x.MauSo);
		}
	}
	
}
