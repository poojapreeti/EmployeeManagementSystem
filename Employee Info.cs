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

namespace EmployeeManagement
{
    public partial class Employee : Form
    {
        public Employee()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source = .\SQLEXPRESS;Initial Catalog=Employeedb;Integrated Security=True");

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();

            SqlCommand cmd = new SqlCommand("Insert into Emptab(id,employeename,age,email,salary,dob,benefits) values(@id,@employeename,@age,@email,@salary,@dob,@benefits)", con);

            cmd.Parameters.AddWithValue("id", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("employeename", textBox2.Text);
            cmd.Parameters.AddWithValue("age", textBox3.Text);
            cmd.Parameters.AddWithValue("email", textBox4.Text);
            cmd.Parameters.AddWithValue("salary", int.Parse(textBox5.Text));
            cmd.Parameters.AddWithValue("dob", DateTime.Parse(textBox6.Text));
            cmd.Parameters.AddWithValue("benefits", textBox7.Text);

            cmd.ExecuteNonQuery();

            con.Close();

            BindData();
        }

        private void Employee_Load(object sender, EventArgs e)
        {
            BindData();
        }

        void BindData()
        {
            SqlCommand cmd = new SqlCommand("Select * from Emptab", con);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.SelectCommand = cmd;

            DataTable dt = new DataTable();
            dt.Clear();
            da.Fill(dt);

            dataGridView1.DataSource = dt;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
        }

private void dataGridView1_CellClick(object sender,DataGridViewCellEventArgs e)
        {
            int index;
            index = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[index];
            textBox1.Text = row.Cells[0].Value.ToString();
            textBox2.Text = row.Cells[1].Value.ToString();
            textBox3.Text = row.Cells[2].Value.ToString();
            textBox4.Text = row.Cells[3].Value.ToString();
            textBox5.Text = row.Cells[4].Value.ToString();
            textBox6.Text = row.Cells[5].Value.ToString();
            textBox7.Text = row.Cells[6].Value.ToString();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();

            SqlCommand cmd2 = new SqlCommand("Update Emptab Set employeename=@employeename,age=@age,email=@email,salary=@salary,dob=@dob,benefits=@benefits where id=@id", con);
            cmd2.Parameters.AddWithValue("id", int.Parse(textBox1.Text));
            cmd2.Parameters.AddWithValue("employeename", textBox2.Text);
            cmd2.Parameters.AddWithValue("age", textBox3.Text);
            cmd2.Parameters.AddWithValue("email", textBox4.Text);
            cmd2.Parameters.AddWithValue("salary", int.Parse(textBox5.Text));
            cmd2.Parameters.AddWithValue("dob", DateTime.Parse(textBox6.Text));
            cmd2.Parameters.AddWithValue("benefits", textBox7.Text);

            cmd2.ExecuteNonQuery();

            con.Close();

            BindData();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();

            SqlCommand cmd3 = new SqlCommand("Delete from Emptab where id=@id",con);
            cmd3.Parameters.AddWithValue("id", textBox1.Text);

            cmd3.ExecuteNonQuery();

            con.Close() ;

            BindData();
        }
    }
}
