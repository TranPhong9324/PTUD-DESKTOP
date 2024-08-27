using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VD2
{
    internal class GiaoVien
    {
        public string MaSo {  get; set; }
        public string HoTen { get; set; }
        public DateTime NgaySinh;
        public DanhMucMonHoc dsMonHoc;
        public string GioiTinh;
        public string[] NgoaiNgu;
        public string SoDT;
        public string Mail;
        public GiaoVien() 
        {
            dsMonHoc =new DanhMucMonHoc();
            NgoaiNgu = new string[10];
        }
        public GiaoVien(string maSo, string hoTen, DateTime ngaySinh, DanhMucMonHoc ds, string gt, string[] nn, string sdt, string mail)
        {
            this.MaSo = maSo;
            this.HoTen = hoTen;
            this.NgaySinh = ngaySinh;
            this.dsMonHoc = ds;
            this.GioiTinh = gt;
            this.NgoaiNgu = nn;
            this.SoDT = sdt;
            this.Mail = mail;
        }

        public override string ToString()
        {
            string s = "Mã số:" + MaSo + "\n" + "Họ tên" + HoTen + "\n" + "Ngày Sinh" + NgaySinh.ToString() + "\n" + "Giới Tính" + GioiTinh + "\n" + "Số ĐT" + SoDT + "\n" + "Mail:" + Mail + "\n";
            string sngoaingu = "Ngoại Ngữ:";
            foreach (string t in NgoaiNgu)
                sngoaingu += t + ";";
            string Monday = "Danh sách môn học:";
            foreach(MonHoc mh in dsMonHoc.ds)
                Monday += mh + ";";
            s += "\n" + sngoaingu + "\n" + Monday;
            return s;

            
                
        }
    }
}
