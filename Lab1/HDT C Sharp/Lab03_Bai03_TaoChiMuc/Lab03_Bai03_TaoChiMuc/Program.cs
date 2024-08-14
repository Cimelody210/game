using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab03_Bai03_TaoChiMuc
{
	internal class Program
	{
		static void Main(string[] args)
		{
			MangSoThuc array = new MangSoThuc();
			array.Them(10.5);
			array.Them(3.0);
			array.Them(1.75);
			array.Them(100.2);
			array.Them(-6.04);
			array.Them(3.33);
			array.Them(-89.345);
			array.Them(-12.19);
			array.Them(Math.Round(Math.PI, 3));

			array.Them(Math.Round(Math.E, 3));

			double giaTri = array[3];
			Console.WriteLine("array[3]= {0}", giaTri);
			for (int i = 0; i < array.SoLuong;  i++)
			{
				Console.WriteLine("{0}\t", array[i]);
			}
			array[6] = 10.077;

			for (int i = 0;i < array.SoLuong;i++)
			{
				Console.WriteLine("{0}\t", array[i]);
			}
		}
	}
}
