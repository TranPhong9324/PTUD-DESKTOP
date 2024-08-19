using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ListBox
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int itemsselect = lbDanhsach.SelectedItems.Count - 1;
            for (int i = itemsselect; i >= 0; i--)
            {
                lbDanhsachchon.Items.Add(lbDanhsach.SelectedItems[i]);
                lbDanhsach.Items.Remove(lbDanhsach.SelectedItems[i]);
                // lstDanhsach.Items.RemoveAt(lstDanhsach.SelectedIndices[i]);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int i = lbDanhsachchon.SelectedItems.Count - 1;
            while (i >= 0)
            {
                lbDanhsachchon.Items.RemoveAt(lbDanhsachchon.SelectedIndices[i]);
                i--;
            }
        }
    }
}
