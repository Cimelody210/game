using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2212403_lab06_bai01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HinhTru tru = new HinhTru(5,10);
            HinhTron tron = tru;
            tru.Ve();
            tron.Ve();
            //Console.WriteLine(tron.TinhChu());
           // Console.WriteLine(tru.TinhChu());
           // Console.WriteLine(tron.TinhDienTich());
            //Console.WriteLine(tru.TinhDienTich());
            HinhTru ong=(HinhTru) tron;
            Console.WriteLine(ong.TinhDienTich());

        }
    }
}
