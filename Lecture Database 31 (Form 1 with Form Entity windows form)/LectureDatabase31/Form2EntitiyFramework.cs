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
        private SampleDBEntities1 db = new SampleDBEntities1();
        public Form2EntitiyFramework()
        {
            InitializeComponent();
        }

        private void Form2EntitiyFramework_Load(object sender, EventArgs e)
        {
        }

        private void LoadData()
        {
            var users = db.Users.ToList();
            dataGridView1.DataSource = users;
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            var oldUser = db.Users.Where(m => m.Id == 8).FirstOrDefault();
           



            //db.Users.Add(newUser);
            //db.SaveChanges();

            db.Users.Remove(oldUser);
            db.SaveChanges();

            //db.Entry(oldUser).CurrentValues.SetValues(newUser);
            //db.SaveChanges();
            LoadData();
            MessageBox.Show("User edited successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        
    }
}
