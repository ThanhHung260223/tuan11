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

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        private SqlConnection connect;
        string _connectectionString = "Data Source=A209PC37;Initial Catalog=QL_SV;Integrated Security=True";

        public Form1()
        {
            InitializeComponent();
        }

        private void Them_Click(object sender, EventArgs e)
        {
            connect = new SqlConnection(_connectectionString);
            connect.Open();
            string insertString;
            insertString = "insert into SINHVIEN values(" + textBox1.Text + " , N'" + textBox2.Text + "')";
            SqlCommand cmd = new SqlCommand(insertString, connect);
            cmd.ExecuteNonQuery();
            connect.Close();
            MessageBox.Show("Thanh Cong!");
            Hienthi_Click(sender, e);
        }

        private void Xoa_Click(object sender, EventArgs e)
        {
            connect = new SqlConnection(_connectectionString);
            connect.Open();
            string deleteString;
            deleteString = "delete from SINHVIEN WHERE ID = " + textBox1.Text + "";
            SqlCommand cmd = new SqlCommand(deleteString, connect);
            cmd.ExecuteNonQuery();
            connect.Close();
            MessageBox.Show("Thanh Cong!");   
        }

        private void Sua_Click(object sender, EventArgs e)
        {
            connect = new SqlConnection(_connectectionString);
            connect.Open();
            string updateString;
            updateString = "update SINHVIEN set HOTEN = N'"+textBox2.Text+"' where ID = " + textBox1.Text +"";
            SqlCommand cmd = new SqlCommand(updateString, connect);
            cmd.ExecuteNonQuery();
            connect.Close();
            MessageBox.Show("Thanh Cong!");
        }

        private void Hienthi_Click(object sender, EventArgs e)
        {

            connect = new SqlConnection(_connectectionString);
            connect.Open();
            string selectString;
            selectString = "select * from SINHVIEN";
            SqlDataAdapter da = new SqlDataAdapter(selectString, connect);
            DataTable dataTable = new DataTable();

            da.Fill(dataTable);
            dataGridView1.DataSource = dataTable;            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int numrow;
            numrow = e.RowIndex;
            textBox1.Text = dataGridView1.Rows[numrow].Cells[0].Value.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //DateTime now = DateTime.Now;
            //string s = now.ToString(format);
            //textBox1.Text = s;
        }
    }
}
