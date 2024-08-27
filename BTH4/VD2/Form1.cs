using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VD2
{
    public partial class frmGiaoVien : Form
    {
        public frmGiaoVien()
        {
            InitializeComponent();
        }
        public void SetText(string s)
        {
            this.lblThongBao.Text = s;
        }
   
        private void frmGiaoVien_Load(object sender, EventArgs e)
        {
            string lienhe = "";
            this.linklbLienHe.Links.Add(0, lienhe.Length, lienhe);
            this.cboMaSo.SelectedItem = this.cboMaSo.Items[0];
        }
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void linklbLienHe_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string s = e.Link.LinkData.ToString();
            Process.Start(s);
        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            int i = this.lbDanhSachMH.SelectedItems.Count - 1;
            while (i >= 0)
            {
                this.lbMonHocDay.Items.Add(lbDanhSachMH.SelectedItems[i]);
                this.lbDanhSachMH.Items.Remove(lbDanhSachMH.SelectedItems[i]);
                i--;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int i = this.lbMonHocDay.SelectedItems.Count - 1;
            while(i >= 0)
            {
                this.lbDanhSachMH.Items.Add(lbMonHocDay.SelectedItems[i]);
                this.lbMonHocDay.Items.Remove(lbMonHocDay.SelectedItems[i]);
                i--;
            }    
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Reset();
        }
        public void Reset()
        {
            this.cboMaSo.Text = "";
            this.txtHoTen.Text = "";
            this.txtMail.Text = "";
            this.mtxtSoDT.Text = "";
            this.rdNam.Checked = true;
            // Bỏ chọn trên chklbNgoaiNgu
            for (int i = 0;i < chklbNgoaiNgu.Items.Count-1;i++)
            {
                chklbNgoaiNgu.SetItemChecked(i, false);
            }
            // Chuyển các môn từ lbMonHocDay sang lbDanhMucMH
            foreach (object ob in this.lbMonHocDay.Items)
                this.lbDanhSachMH.Items.Add(ob);
            this.lbMonHocDay.Items.Clear();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            frmGiaoVien frm = new frmGiaoVien();
            frm.SetText(GetGiaoVien().ToString());
            frm.ShowDialog();
        }
        public GiaoVien GetGiaoVien()
        {
            string gt = "Nam";
            if (rdNu.Checked)
                gt = "Nữ";
            GiaoVien gv = new GiaoVien();
            gv.MaSo = this.cboMaSo.Text;
            gv.GioiTinh = gt;
            gv.HoTen=this.txtHoTen.Text;
            gv.NgaySinh = this.dtpNgaySinh.Value;
            gv.Mail=this.txtMail.Text;
            gv.SoDT=this.mtxtSoDT.Text;
            //Lay thong tin ngoai ngu
            string ngoaingu = "";
            for(int i = 0; i<chklbNgoaiNgu.Items.Count-1;i++)
                if(chklbNgoaiNgu.GetItemChecked(i))
                    ngoaingu += chklbNgoaiNgu.Items[i]+";";
            gv.NgoaiNgu = ngoaingu.Split(';');
            // lay thong tin danh sach mon hoc
            DanhMucMonHoc mh = new DanhMucMonHoc();
            foreach (object ob in lbMonHocDay.Items)
                mh.Them(new MonHoc(ob.ToString())
            gv.dsMonHoc = mh;

            return gv;
        }
    }
}
