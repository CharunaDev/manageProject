using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Data;
using WindowsFormsApp1.Model;

namespace WindowsFormsApp1
{
    public partial class ManageProject : Form
    {
        EmployeeManagementEntities _context = new EmployeeManagementEntities();
        public ManageProject()
        {
            InitializeComponent();
            LoadGridView();
        }
        public List<Project> LoadProjects()
        {
            return _context.tblProjects.Select(x => new Project
            {
                Id = x.Id,
                ProjectName = x.ProjectName,
                StartDate = x.StartDate,
                EndDate = x.EndDate,
                Active = x.Active,
                CreateDate = x.CreateDate,
                LastUpdatedDate = x.LastUpdatedDate
            }).ToList();
        }
        public void LoadGridView()
        {
            var list = LoadProjects();
            dvgProjects.DataSource = list;
            var empList = _context.tblEmployees.ToList();
            cmbEmployee.DataSource = empList;
            cmbEmployee.DisplayMember = "FirstName";
            cmbEmployee.ValueMember = "Id";
            Console.WriteLine(empList);


        }

        private void dvgProjects_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dvgProjects.CurrentCell.RowIndex != -1)
            {
                var selectedId = Convert.ToInt32(dvgProjects.CurrentRow.Cells["Id"].Value);
                var query = _context.tblProjects.Where(x => x.Id == selectedId).FirstOrDefault();
                if (query != null)
                {
                    var dropList = (from a in _context.tblProjects.Where(x => x.Id == selectedId)
                                    join
                                    b in _context.tblTaskAssigns on a.Id equals b.ProjectId
                                    join
                                    c in _context.tblEmployees on b.EmployeeId equals c.Id
                                    select new Employee { Id = c.Id, FirstName = c.FirstName }).ToList();

                    tbProjectId.Text = query.Id.ToString();
                    tbProjectName.Text = query.ProjectName.ToString();
                    cbActive.Checked = query.Active ?? false;
                    dtStartDate.Value = query.StartDate;
                    dtEndDate.Value = query.EndDate?? DateTime.Now;

                    cmbEmployee.DataSource = dropList;
                    cmbEmployee.DisplayMember = "FirstName";
                    cmbEmployee.ValueMember = "Id";
                }

            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                var project = new tblProject{

                    ProjectName = tbProjectName.Text,
                    Active = cbActive.Checked,
                    StartDate = dtStartDate.Value,
                    EndDate = dtEndDate.Value,
                    CreateDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                };
                _context.tblProjects.Add(project);
                _context.SaveChanges();

                var task = new tblTaskAssign
                {
                    ProjectId = project.Id,
                    EmployeeId = Convert.ToInt32(cmbEmployee.SelectedValue),
                    AssignedDate = DateTime.Now,
                    CreateDate = DateTime.Now
                };
                _context.tblTaskAssigns.Add(task);
                _context.SaveChanges();
                ClearData();
                LoadGridView();
                MessageBox.Show("Successfully Added!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message);
            }

        }
        public void ClearData()
        {
            tbProjectId.Text  = string.Empty;
            tbProjectName.Text = string.Empty;
            cmbEmployee.SelectedIndex = 0;
            dtStartDate.Value = DateTime.Now;
            dtEndDate.Value = DateTime.Now;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbProjectId.Text))
            {
                MessageBox.Show("Select a Row");
            }
            else
            {
                var selectedId = Convert.ToInt32(tbProjectId.Text);
                var query = _context.tblProjects.Where(x => x.Id == selectedId).FirstOrDefault();
                 query.ProjectName = tbProjectName.Text;
                 query.StartDate = dtStartDate.Value;
                 query.EndDate = dtEndDate.Value;
                 query.Active = cbActive.Checked;
                 query.LastUpdatedDate = DateTime.Now;
               // _context.tblProjects.Up(query);
                _context.SaveChanges();
                MessageBox.Show("Updated Successfully!");
                ClearData();
                LoadGridView();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int selectedId = Convert.ToInt32(tbProjectId.Text);
            var query = _context.tblProjects.Where(x => x.Id == selectedId).FirstOrDefault();
            //task delete
            var task = _context.tblTaskAssigns.Where(x => x.ProjectId == selectedId);
            foreach ( var taskAssign in task)
            {
                _context.tblTaskAssigns.Remove(taskAssign);
            }
            _context.tblProjects.Remove(query);
            _context.SaveChanges();
            MessageBox.Show("Deleted Successfully!");
           // ClearData();
            LoadGridView();
        }
    }
}
