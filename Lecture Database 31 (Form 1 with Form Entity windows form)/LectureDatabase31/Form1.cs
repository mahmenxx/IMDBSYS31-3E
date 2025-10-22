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
using System.Xml.Linq;

namespace LectureDatabase31
{
    public partial class Form1 : Form
    {
        private string connectionString = "Server=JULES-IRWIN\\SQLEXPRESS;Initial Catalog=SampleDB;Integrated Security=True;";
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sampleDBDataSet.Users' table. You can move, or remove it, as needed.
            this.usersTableAdapter.Fill(this.sampleDBDataSet.Users);

        }

        private void LoadData()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Users", conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Users (Name, Email) VALUES (@Name, @Email)", conn);
                cmd.Parameters.AddWithValue("@Name", txtname.Text);
                cmd.Parameters.AddWithValue("@Email", txtemail.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("User added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2EntitiyFramework form2 = new Form2EntitiyFramework();
            form2.ShowDialog();

        }   
    }
}
