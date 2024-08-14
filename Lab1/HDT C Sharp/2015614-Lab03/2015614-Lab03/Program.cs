using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2015614_Lab03
{
	internal class Program
	{
		static void Main(string[] args)
		{
			PhanSo x = new PhanSo();
			x.TuSo = 1;
			x.MauSo = 2;

			double gtx = x.TinhGiaTri();
			Console.WriteLine("{0}/{1} = {2}", x.TuSo, x.MauSo, gtx);

			
			PhanSo y = new PhanSo(3, 4);
			double gty = y.TinhGiaTri();
			Console.WriteLine("{0}/{1} = {2}", y.TuSo, y.MauSo, gty);

			PhanSo z= y.NghichDao();
			double gtz = y.TinhGiaTri();
			Console.WriteLine("{0}/{1} = {2}", z.TuSo, z.MauSo, gtz);

			PhanSo k = new PhanSo(6, 9);

			PhanSo g = k.RutGon();
			Console.WriteLine("{0}/{1} = {2}/{3} = {4}",
								k.TuSo, k.MauSo,
								g.TuSo, g.MauSo,
								g.TinhGiaTri());
			Console.WriteLine(x.ToString());
			Console.WriteLine("{0} = {1}", y.ToString(), y.TinhGiaTri());

			Console.WriteLine(z);
			Console.WriteLine("{0} = {1} = {2}",
							k, g, g.TinhGiaTri());

			PhanSo e = new PhanSo();
			e.TuSo = 2;
			e.MauSo = 5;

			double gte = e.TinhGiaTri();
			Console.WriteLine("{0} = {1}", e, e.GiaTri);

			PhanSo d = new PhanSo(6, 4);
			PhanSo tich = d.Nhan(e);
			PhanSo nhanK = e.Nhan(3);
			Console.WriteLine("{0} * {1} = {2}", d, e, tich);
			Console.WriteLine("{0} * {1} = {2}", d, 3, nhanK);
		}
		
	}
}
