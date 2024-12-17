using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {

        }

        private void btnManageEmp_Click(object sender, EventArgs e)
        {
            this.Close();
            ManageEmployee manageEmployee = new ManageEmployee();
            manageEmployee.Show();
        }

        private void btnManageProjects_Click(object sender, EventArgs e)
        {
            this.Close();
            ManageProject manageProject = new ManageProject();
            manageProject.Show();
        }
    }
}
