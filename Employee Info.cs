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
using System.Data.SqlClient;

namespace EmployeeManagement
{
    public partial class EmployeeInfo : Form
    {
        public EmployeeInfo()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source = .\SQLEXPRESS;Initial Catalog=Employeedb;Integrated Security=True");

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select * from Emptab", con);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.SelectCommand = cmd;

            DataTable dt = new DataTable();
            dt.Clear();
            da.Fill(dt);

            dataGridView1.DataSource = dt;
        }
    }
}
