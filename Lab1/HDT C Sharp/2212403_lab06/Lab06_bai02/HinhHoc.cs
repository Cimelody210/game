using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab06_bai02
{
    public abstract class HinhHoc
    {
        protected double canh; 
        protected HinhHoc(Double cd)
        {
            canh = cd;
        }
        public abstract double TinhDienTich();
        public abstract void Xuat();
    }
}
