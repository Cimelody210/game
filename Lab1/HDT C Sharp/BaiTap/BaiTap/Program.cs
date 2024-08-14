using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTap
{
	internal class Program
	{
		static void Main(string[] args)
		{
			HinhTron[] hinhTrons = new HinhTron[] 
			{
				new HinhTron(5.75, "Xanh"),
				new HinhTron(23, "Do"),
				new HinhTron(9.12, "Vang"),
				new HinhTron(238.7635, "Tim")
			};
			double[] tyLeBienDoi = { 30, 7.5, 13.36, 2.71 };
			for (int i = 0; i < hinhTrons.Length; i++)
			{
				hinhTrons[i].BienDoiTyLe(tyLeBienDoi[i]);
			}

			var sortedByArea = hinhTrons.OrderBy(h => h.TinhDienTich()).ToArray();
			Console.WriteLine("Hinh tron sap xep theo dien tich (tang dan):");
			foreach (var h in sortedByArea)
			{
				Console.WriteLine(h);
			}

			Console.WriteLine();

			var sortedByCircumference = hinhTrons.OrderByDescending(h => h.TinhChuVi()).ToArray();
			Console.WriteLine("Hinh tron sap xep theo chu vi (giam dan):");
			foreach (var h in sortedByCircumference)
			{
				Console.WriteLine(h);
			}

			double totalCircumference = hinhTrons.Sum(h => h.TinhChuVi());
			double totalArea = hinhTrons.Sum(h => h.TinhDienTich());

			Console.WriteLine();
			Console.WriteLine($"Tong chu vi: {totalCircumference:F2}");
			Console.WriteLine($"Tong dien tích: {totalArea:F2}");

		}
	}
}
