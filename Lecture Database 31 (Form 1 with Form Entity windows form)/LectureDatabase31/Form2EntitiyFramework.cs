using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LectureDatabase31
{
    public partial class Form2EntitiyFramework : Form
    {
        private SampleDBEntities2 db = new SampleDBEntities2();
        public Form2EntitiyFramework()
        {
            InitializeComponent();
        }

        private void Form2EntitiyFramework_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sampleDBDataSet11.Users' table. You can move, or remove it, as needed.
            this.usersTableAdapter1.Fill(this.sampleDBDataSet11.Users);
            LoadData();
        }

        private void LoadData()
        {
            var users = db.Users.ToList();
            var roles = db.Roles.ToList();

            // set comboBox to roles rolename
            foreach(var role in roles)
            {
                comboBox1.Items.Add(role.roleName);
            }
            DataTable dt = new DataTable();

            // Define columns (It's often safer to use simpler names for binding, though spaces are allowed)
            dt.Columns.Add("UserId", typeof(int)); // Simpler name: UserId
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Email", typeof(string));
            dt.Columns.Add("Role", typeof(string));

            // Fill the DataTable
            foreach (var user in users)
            {
                // Make sure the data types match the column definition (e.g., user.Id must be int)
                dt.Rows.Add(user.Id, user.Name, user.Email, user.Roles?.roleName ?? "");
            }

            dataGridView1.DataSource = dt;
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            //var oldUser = db.Users.Where(m => m.Id == 8).FirstOrDefault();

            int roleId = Convert.ToInt32(comboBox1.SelectedIndex+1);

            var user = new Users()
            {
                Email = txtemail.Text,
                Name = txtname.Text,
                role_id = roleId,
            };

            db.Users.Add(user);

            db.SaveChanges();

            LoadData();
            MessageBox.Show("User added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.usersTableAdapter1.FillBy(this.sampleDBDataSet1.Users);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }
    }
}
