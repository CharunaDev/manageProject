using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Data;

namespace WindowsFormsApp1
{
    public partial class Login : Form
    {
        EmployeeManagementEntities context = new EmployeeManagementEntities();
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string userName = tbUserName.Text.Trim();
            string password = tbPassword.Text.Trim();
            try
            {
                var user = context.tblUsers.Where(x => x.Username == userName && x.Password == password && x.Active == true).FirstOrDefault();
                if(user != null)
                {
                    Dashboard dashboard = new Dashboard();
                    this.Hide();
                    dashboard.Show();
                }
                else
                {
                    MessageBox.Show("Invalid Operation!", "Failed!!!",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }catch(Exception ex)
            {
                MessageBox.Show("Error!" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void tbUserName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
