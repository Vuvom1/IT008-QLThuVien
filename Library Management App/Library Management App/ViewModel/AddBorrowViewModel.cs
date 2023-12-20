using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_App.ViewModel
{

    public class Display
    {
        public string MaSach { get; set; }
        public string TenSach { get; set; }
        public int SL { get; set; }
        public int Dongia { get; set; }
        public int Tong { get; set; }
        public string Size { get; set; }
        public Display(string MaSach = "", string TenSach = "", string Size = "", int SL = 0, int Dongia = 0, int Tong = 0)
        {
            this.MaSach = MaSach;
            this.TenSach = TenSach;
            this.SL = SL;
            this.Tong = Tong;
            this.Size = Size;
            this.Dongia = Dongia;
        }
    }
    internal class AddBorrowViewModel
    {
    }
}
