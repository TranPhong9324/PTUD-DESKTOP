using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab03
{
    internal class SinhVien
    {
        public string MSSV { get; set; }
        public string HoTen { get; set; }
        public bool GioiTinh { get; set; }
        public DateTime NgaySinh { get; set; }
        public string Lop { get; set; }
        public string SDT { get; set; }
        public string Email {  get; set; }
        public string DiaChi { get; set; }
       
        public string Hinh { get; set; }
       
        

        public SinhVien()
        {
            
        }
        //Phương thức tạo lập có tham số
        public SinhVien(string mssv, string ht, DateTime ngay, string dc, string lop, string hinh, bool gt, string sdt, string email)
        {
            this.MSSV = mssv;
            this.HoTen = ht;
            this.NgaySinh = ngay;
            this.DiaChi = dc;
            this.Lop = lop;
            this.Hinh = hinh;
            this.GioiTinh = gt;
            this.SDT = sdt;
            this.Email = email;
        }
    }
}

