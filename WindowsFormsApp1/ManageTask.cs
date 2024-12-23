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
using WindowsFormsApp1.Model;

namespace WindowsFormsApp1
{
    public partial class ManageTask : Form
    {
        EmployeeManagementEntities _context = new EmployeeManagementEntities();
        public ManageTask()
        {
            InitializeComponent();
            LoadGridData();
            LoadTaskAssignData();
        }
        public List<Project> LoadProjects()
        {
            var projects = _context.tblProjects.Where(x => x.Active).Select(x => new Project
            {
                Id = x.Id,
                ProjectName = x.ProjectName
            }).ToList();
            return projects;
        }
        public List<Department> LoadDepartments()
        {
            return _context.tblDepartments.Where(x => x.Active?? false).Select(x => new Department
            {
                Id = x.Id,
                DepartmentName = x.DepartmentName,
            }).ToList();
        }
        public void LoadGridData()
        {
            var _prjList = LoadProjects();
            cmbProjectList.DataSource = _prjList;
            cmbProjectList.DisplayMember = "ProjectName";
            cmbProjectList.ValueMember = "Id";

            var _depList = LoadDepartments();
            cmbDepartment.DataSource = _depList;
            cmbDepartment.DisplayMember = "DepartmentName";
            cmbDepartment.ValueMember = "Id";

        }
        private void cmbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            var comboBox = sender as ComboBox;
            if (comboBox != null && dgvTasks.CurrentRow != null)
            {
                var selectedDepartmentId = (int)comboBox.SelectedValue;
                LoadEmployees(selectedDepartmentId, dgvTasks.CurrentRow.Index);
            }
        }
        private void LoadEmployees(int departmentId, int rowIndex)
        {
         
                var employees = _context.tblEmployees.Where(e => e.DepartmentId == departmentId).ToList();
                var employeeComboBox = (DataGridViewComboBoxCell)dgvTasks.Rows[rowIndex].Cells["cmbEmployees"];

                employeeComboBox.Value = null;

                employeeComboBox.DataSource = employees;
                employeeComboBox.DisplayMember = "FirstName"; 
                employeeComboBox.ValueMember = "Id"; 
        }

        public void cmbDepartment_ValueChanged(object sender, EventArgs e)
        {
            Console.WriteLine("Works!");
        }
        private void dgvTasks_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvTasks.Columns[e.ColumnIndex].Name == "cmbDepartment" && e.RowIndex >= 0)
            {
                OnDepartmentChanged(e.RowIndex);
            }
        }

        private void dgvTasks_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvTasks.IsCurrentCellDirty)
            {
                dgvTasks.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void OnDepartmentChanged(int rowIndex)
        {
            cmbEmployees.Items.Clear();
            int newValue = (int)dgvTasks.Rows[rowIndex].Cells["cmbDepartment"].Value;
            LoadEmployees(newValue, rowIndex);
        }
        public List<TaskAssign> LoadTaskData()
        {
            var tasklist = (from a in _context.tblTaskAssigns join
                            b in _context.tblEmployees on a.EmployeeId equals b.Id
                            join c in _context.tblProjects on a.ProjectId equals c.Id
                            select new TaskAssign { 
                                Id = a.Id,
                                ProjectName = c.ProjectName,
                                FirstName = b.FirstName,
                                AssignDate = a.AssignDate
                            }
                            ).OrderBy(x => x.ProjectName).ToList();
            return tasklist;
        }
        public void LoadTaskAssignData()
        {
            var _task = LoadTaskData();
            //dgvTaskList.DataSource = _task;
        }

        private void btnAssignTask_Click(object sender, EventArgs e)
        {
            try
            {
                int selectedProject = Convert.ToInt32(cmbProjectList.SelectedValue);
                DateTime assignDate = dtAssignDate.Value;
                foreach (DataGridViewRow row in dgvTasks.Rows)
                {
                    if (row.Cells["cmbEmployees"].Value == null) continue;

                    int employeeId = Convert.ToInt32(row.Cells["cmbEmployees"].Value);

                    var taskAssign = new tblTaskAssign
                    {
                        ProjectId = selectedProject,
                        EmployeeId = employeeId,
                        AssignDate = assignDate,
                        CreateDate = DateTime.Now
                    };
                    _context.tblTaskAssigns.Add(taskAssign);
                }
                _context.SaveChanges();

                MessageBox.Show("Task assignments saved successfully!");
                Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message, "Error!");
            }
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            this.Close();
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
        }

        public void Clear()
        {
            cmbProjectList.SelectedIndex = 0;
            dtAssignDate.Value = DateTime.Now;
            dgvTasks.Rows.Clear();
        }
    }
}
