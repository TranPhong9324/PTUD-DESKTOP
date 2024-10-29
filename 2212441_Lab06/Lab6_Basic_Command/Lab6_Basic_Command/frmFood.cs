using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab6_Basic_Command
{
    public partial class frmFood : Form
    {
        public frmFood()
        {
            InitializeComponent();
        }

        private void dgvFood_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmFood_Load(object sender, EventArgs e)
        {
           
        }
        public void LoadFood(int ID)
        {
            // Tạo chuỗi kết nối đến cơ sở dữ liệu
            string connectionString = "server=.; database=RestaurantManagement; Integrated Security=true;";
            SqlConnection sqlConnection = new SqlConnection(connectionString);


            // Tạo đối tượng SqlCommand để thực thi câu lệnh SQL
            SqlCommand sqlCommand = sqlConnection.CreateCommand();

            // Thiết lập lệnh truy vấn để lấy tên danh mục theo ID
            sqlCommand.CommandText = "SELECT Name FROM Category WHERE ID = " + ID;

            // Mở kết nối đến cơ sở dữ liệu
            sqlConnection.Open();

            // Thực thi câu lệnh và lấy giá trị trả về
            string catName = sqlCommand.ExecuteScalar().ToString();

            // Gán tên danh mục cho tiêu đề của form
            this.Text = "Danh sách các món ăn thuộc nhóm: " + catName;

            sqlCommand.CommandText = "SELECT * FROM Food WHERE FoodCategoryID = " + ID;
            SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
            DataTable dt = new DataTable("Food");
            da.Fill(dt);
            dgvFood.DataSource = dt;
            sqlConnection.Close();
            sqlConnection.Dispose();
            da.Dispose();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void dgvFood_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }
    }
}
