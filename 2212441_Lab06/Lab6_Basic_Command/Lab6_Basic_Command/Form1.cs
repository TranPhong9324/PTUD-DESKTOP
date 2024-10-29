using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;

namespace Lab6_Basic_Command
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            // Tạo chuỗi kết nối đến cơ sở dữ liệu RestaurantManagement
            string connectionString = "server=PC814; database=RestaurantManagement; Integrated Security=true;";

            // Tạo đối tượng kết nối
            SqlConnection sqlConnection
         = new SqlConnection(connectionString);

            // Tạo đối tượng thực thi lệnh
            SqlCommand sqlCommand = sqlConnection.CreateCommand();

            // Thiết lập lệnh truy vấn để lấy dữ liệu từ bảng Category
            string query = "SELECT ID, Name, Type FROM Category";
            sqlCommand.CommandText = query;

            // Mở kết nối đến cơ sở dữ liệu
            sqlConnection.Open();

            // Thực thi lệnh và trả về một đối tượng SqlDataReader
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            // Gọi hàm để hiển thị dữ liệu lên giao diện
            this.DisplayCategory(sqlDataReader);

            // Đóng kết nối
            sqlConnection.Close();
        }
        private void DisplayCategory(SqlDataReader reader)
        {
            // Xóa tất cả các dòng hiện tại trong ListView
            lvCategory.Items.Clear();

            // Đọc từng dòng dữ liệu từ SqlDataReader
            while (reader.Read())
            {
                // Tạo một dòng mới trong ListView
                ListViewItem item = new ListViewItem(reader["ID"].ToString());

                // Thêm dòng mới vào ListView
                lvCategory.Items.Add(item);

                // Bổ sung các thông tin khác cho ListViewItem
                item.SubItems.Add(reader["Name"].ToString());
                item.SubItems.Add(reader["Type"].ToString());
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Tạo chuỗi kết nối đến cơ sở dữ liệu
            string connectionString = "server=.; database=RestaurantManagement; Integrated Security=true;";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            // Tạo đối tượng SqlCommand để thực thi câu lệnh SQL
            SqlCommand sqlCommand = sqlConnection.CreateCommand();

            // Thiết lập câu lệnh SQL để chèn dữ liệu vào bảng Category
            sqlCommand.CommandText = "INSERT INTO Category (Name, [Type]) VALUES (N'" + txtName.Text + "', '" + txtType.Text + "')";

            // Mở kết nối đến cơ sở dữ liệu
            sqlConnection.Open();

            // Thực thi câu lệnh SQL và trả về số lượng hàng bị ảnh hưởng
            int numberOfRowsAffected = sqlCommand.ExecuteNonQuery();

            // Đóng kết nối
            sqlConnection.Close();

            // Kiểm tra kết quả thực thi
            if (numberOfRowsAffected == 1)
            {
                // Hiển thị thông báo thêm thành công
                MessageBox.Show("Thêm nhóm món ăn thành công");

                // Làm mới dữ liệu trên giao diện
                btnLoad.PerformClick();

                // Xóa dữ liệu trong các textbox
                txtName.Text = "";
                txtType.Text = "";
            }
            else
            {
                // Hiển thị thông báo lỗi
                MessageBox.Show("Đã có lỗi xảy ra. Vui lòng thử lại");
            }
        }

        private void lvCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lvCategory_Click(object sender, EventArgs e)
        {
            // Lấy dòng được chọn trong ListView
            ListViewItem item = lvCategory.SelectedItems[0];

            // Hiển thị dữ liệu lên TextBox
            txtID.Text = item.Text;
            txtName.Text = item.SubItems[1].Text;
            txtType.Text = item.SubItems[1].Text == "0" ? "Thức uống" : "Đồ ăn";

            // Hiển thị nút cập nhật và xóa
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
                // Tạo chuỗi kết nối đến cơ sở dữ liệu
                string connectionString = "server=.; database=RestaurantManagement; Integrated Security=true;";
                SqlConnection sqlConnection = new SqlConnection(connectionString);


                // Tạo đối tượng SqlCommand để thực thi câu lệnh SQL
                SqlCommand sqlCommand = sqlConnection.CreateCommand();

                // Thiết lập lệnh truy vấn để cập nhật dữ liệu trong bảng Category
                sqlCommand.CommandText = "UPDATE Category SET Name = N'" + txtName.Text + "', [Type] = '" + txtType.Text + "' WHERE ID = " + txtID.Text;

                // Mở kết nối   đến cơ sở dữ liệu
                sqlConnection.Open();

                // Thực thi câu lệnh SQL và trả về số lượng hàng bị ảnh hưởng
                int numberOfRowsAffected = sqlCommand.ExecuteNonQuery();

                // Đóng kết nối
                sqlConnection.Close();

                // Kiểm tra kết quả thực thi
                if (numberOfRowsAffected == 1)
                {
                    // Cập nhật lại dữ liệu trên ListView
                    ListViewItem item = lvCategory.SelectedItems[0];
                    item.SubItems[1].Text = txtName.Text;
                    item.SubItems[2].Text = txtType.Text;

                    // Xóa các ô nhập
                    txtID.Text = "";
                    txtName.Text = "";
                    txtType.Text = "";

                    // Disable các nút xóa và cập nhật
                    btnUpdate.Enabled = false;
                    btnDelete.Enabled = false;


                    MessageBox.Show("Cập nhật nhóm món ăn thành công");
                }
                else
                {
                    MessageBox.Show("Đã có lỗi xảy ra.Vui lòng thử lại");
                }
            }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Tạo chuỗi kết nối đến cơ sở dữ liệu
            string connectionString = "server=.; database=RestaurantManagement; Integrated Security=true;";
            SqlConnection sqlConnection = new SqlConnection(connectionString);


            // Tạo đối tượng SqlCommand để thực thi câu lệnh SQL
            SqlCommand sqlCommand = sqlConnection.CreateCommand();

            // Thiết lập lệnh truy vấn để xóa dữ liệu từ bảng Category
            sqlCommand.CommandText = "DELETE FROM Category WHERE ID = " + txtID.Text;

            // Mở kết nối đến cơ sở dữ liệu
            sqlConnection.Open();

            // Thực thi lệnh và trả về số lượng hàng bị ảnh hưởng
            int numberOfRowsAffected = sqlCommand.ExecuteNonQuery();

            // Đóng kết nối
            sqlConnection.Close();
            if (numberOfRowsAffected == 1)
            {
                // Xóa dòng đã chọn khỏi ListView
                lvCategory.SelectedItems[0].Remove();

                // Xóa các ô nhập
                txtID.Text = "";
                txtName.Text = "";
                txtType.Text = "";

                // Disable các nút xóa và cập nhật
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;


                // Hiển thị thông báo xóa thành công
                MessageBox.Show("Xóa nhóm món ăn thành công");
            }
            else
            {
                // Hiển thị thông báo lỗi
                MessageBox.Show("Đã có lỗi xảy ra. Vui lòng thử lại");
            }
        }

        private void tsmDelete_Click(object sender, EventArgs e)
        {
            if(lvCategory.SelectedItems.Count > 0) 
                btnDelete.PerformClick();
        }

        private void tsmViewFood_Click(object sender, EventArgs e)
        {
            if(txtID.Text !="")
            {
                frmFood foodForm= new frmFood();
                foodForm.Show(this);
                foodForm.LoadFood(Convert.ToInt32(txtID.Text));
            }    
        }
    }
}
