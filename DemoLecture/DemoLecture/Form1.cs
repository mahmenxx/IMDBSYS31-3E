using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoLecture
{
    public partial class Form1 : Form
    {
        private static DemoDBEntities database = new DemoDBEntities();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        public void LoadData()
        {
            DataTable dataTable = new DataTable();

            dataTable.Columns.Add("User ID", typeof(int));
            dataTable.Columns.Add("Name", typeof(string));
            dataTable.Columns.Add("Email", typeof(string));
            dataTable.Columns.Add("Role", typeof(string));

            var users = database.User.ToList(); // SELECT * FROM User

            foreach (var user in users)
            {
                dataTable.Rows.Add(user.id, user.name, user.email, user.Role.roleName); // SELECT user.id, user.name, user.email, role.roleName FROM User INNER JOIN Role ON role.id = user.role_id
            }

            dataGridView1.DataSource = dataTable;

            var roles = database.Role.ToList();

            comboBox1.Items.Clear();
            foreach(var role in roles)
            {
                comboBox1.Items.Add(role.roleName);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //checks
            if (String.IsNullOrEmpty(txtEmail.Text))
            {
                MessageBox.Show("Input email first", "Missing field", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            var user = new User()
            {
                email = txtEmail.Text,
                name = txtName.Text,
                role_id = comboBox1.SelectedIndex + 1,
                age = 18
            };

            database.User.Add(user); // INSERT INTO

            database.SaveChanges();

            LoadData();

            MessageBox.Show("User added successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
