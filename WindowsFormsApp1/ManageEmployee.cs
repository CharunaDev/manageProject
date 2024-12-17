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
    public partial class ManageEmployee : Form
    {
        EmployeeManagementEntities context = new EmployeeManagementEntities();
        public ManageEmployee()
        {
            InitializeComponent();
           // var data = loadEmployee();
          //  dgvEmployee.DataSource = data;
        }

        public List<EmployeeDTO> loadEmployee()
        {
            return context.tblEmployees.Select(x => new EmployeeDTO
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Email = x.Email,
                PhoneNumber = x.PhoneNumber,
                JobTitle = x.JobTitle,
                Salary = x.Salary,
                DepartmentId = x.tblDepartment.Id,
                DepartmentName = x.tblDepartment.DepartmentName,
                HireDate = x.HireDate
            }).ToList();
        }

        private void dgvEmployee_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            //var data = dgvEmployee.Rows[e.RowIndex].DataBoundItem as dynamic;
            if (e.ColumnIndex == dgvEmployee.Columns["Delete"].Index && e.RowIndex >= 0)
            {
     
                int employeeId = (int)dgvEmployee.Rows[e.RowIndex].Cells["Id"].Value;
                //confirmation popup
                var confirmationResult = MessageBox.Show("Are you sure you want to delete this record?", "Confirm Delete", MessageBoxButtons.YesNo);
                if (confirmationResult == DialogResult.Yes)
                {
                    var employeeToDelete = context.tblEmployees.FirstOrDefault(x => x.Id == employeeId);

                    if (employeeToDelete != null)
                    {
                        // Delete the record
                        context.tblEmployees.Remove(employeeToDelete);
                        context.SaveChanges();

                        // Refresh the view
                        var data = loadEmployee();
                        dgvEmployee.DataSource = data;

                        MessageBox.Show("Employee deleted successfully!");
                    }
                    else
                    {
                        MessageBox.Show("Employee not found!");
                    }
                }
            }
            else
            {
                var data = dgvEmployee.Rows[e.RowIndex].DataBoundItem as EmployeeDTO;

                if (data != null)
                {
                    tbFirstName.Text = data.FirstName;
                    tbLastName.Text = data.LastName;
                    tbEmail.Text = data.Email;
                    tbJobTitle.Text = data.JobTitle;
                    tbPhoneNumber.Text = data.PhoneNumber;
                    tbSalary.Text = data.Salary.ToString("F2");
                    comboBox1.SelectedValue = data.DepartmentId;
                    dpHireDate.Value = data.HireDate ?? DateTime.Now;
                }
            }


            //var data = dgvEmployee.Rows[e.RowIndex].DataBoundItem as EmployeeDTO;

            //if (data != null)
            //{
            //    tbFirstName.Text = data.FirstName;
            //    tbLastName.Text = data.LastName;
            //    tbEmail.Text = data.Email;
            //    tbJobTitle.Text = data.JobTitle;
            //    tbPhoneNumber.Text = data.PhoneNumber;
            //    tbSalary.Text = data.Salary.ToString("F2"); ;
            //    comboBox1.SelectedValue = data.DepartmentId; 
            //    dpHireDate.Value = data.HireDate ?? DateTime.Now;

            //}
        }

        private void ManageEmployee_Load(object sender, EventArgs e)
        {
            //load employee data
            var data = loadEmployee();
            dgvEmployee.DataSource = data;
            //hide id
            if (dgvEmployee.Columns.Contains("Id"))
            {
                dgvEmployee.Columns["Id"].Visible = false;
            }
            else if (dgvEmployee.Columns.Contains("DepartmentId"))
            {
                dgvEmployee.Columns["DepartmentId"].Visible = false;
            }
            //load departments to dropdown
            var departments = context.tblDepartments.ToList();
            comboBox1.DataSource = departments;
            comboBox1.DisplayMember = "DepartmentName";
            comboBox1.ValueMember = "Id";
            //load select row btn
            AddButtonColumn(); 

        }
        private void AddButtonColumn()
        {
            if (!dgvEmployee.Columns.Contains("Action"))
            {
                DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn
                {
                    Name = "Action",
                    HeaderText = "Action",
                    Text = "Load",
                    UseColumnTextForButtonValue = true,
                    Width = 80
                };
                dgvEmployee.Columns.Insert(0, buttonColumn); 
            }
            if (!dgvEmployee.Columns.Contains("Delete"))
            {
                DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn
                {
                    Name = "Delete",
                    HeaderText = "Delete",
                    Text = "Delete",
                    UseColumnTextForButtonValue = true,
                    Width = 80
                };
                dgvEmployee.Columns.Add(deleteButtonColumn);
            }
        }


        private void btnLoadEmpData_Click(object sender, EventArgs e)
        {
            var data = loadEmployee();
            dgvEmployee.DataSource = data;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //get current employee details
            int selectedRowIndex = dgvEmployee.CurrentCell.RowIndex;

            if (selectedRowIndex >= 0) 
            {
                var selectedRow = dgvEmployee.Rows[selectedRowIndex];

                int employeeId = (int)selectedRow.Cells["Id"].Value;

                string firstName = tbFirstName.Text;
                string lastName = tbLastName.Text;
                string email = tbEmail.Text;
                string phoneNumber = tbPhoneNumber.Text;
                string jobTitle = tbJobTitle.Text;
                decimal salary = decimal.Parse(tbSalary.Text);
                int departmentId = (int)comboBox1.SelectedValue;
                DateTime hireDate = dpHireDate.Value;

                var entity = context.tblEmployees.FirstOrDefault(x => x.Id == employeeId);

                if (entity != null)
                {
                    entity.FirstName = firstName;
                    entity.LastName = lastName;
                    entity.Email = email;
                    entity.PhoneNumber = phoneNumber;
                    entity.JobTitle = jobTitle;
                    entity.Salary = salary;
                    entity.DepartmentId = departmentId;
                    entity.HireDate = hireDate;

                    context.SaveChanges();
                    //refresh table
                    var data = loadEmployee();
                    dgvEmployee.DataSource = data;

                    MessageBox.Show("Employee details updated successfully!");
                }
                else
                {
                    MessageBox.Show("Employee not found!");
                }
            }
            else
            {
                MessageBox.Show("Invalid Operation!");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        public void ClearAll()
        {
            tbFirstName.Clear();
            tbLastName.Clear();
            tbEmail.Clear();
            tbPhoneNumber.Clear();
            tbJobTitle.Clear();
            tbSalary.Clear();
            //tbDepartment.Clear();
            dpHireDate.Value = DateTime.Now;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            var newEmployee = new tblEmployee
            {
                FirstName = tbFirstName.Text,
                LastName = tbLastName.Text,
                Email = tbEmail.Text,
                PhoneNumber = tbPhoneNumber.Text,
                JobTitle = tbJobTitle.Text,
                Salary = decimal.TryParse(tbSalary.Text, out decimal salary) ? salary : 0,
                DepartmentId = (int)comboBox1.SelectedValue,
                HireDate = dpHireDate.Value,
                Active = true,
                CreateDate = DateTime.Now,
                LastUpdatedDate = DateTime.Now
            };
            context.tblEmployees.Add(newEmployee);

            try
            {
                context.SaveChanges(); 
                MessageBox.Show("Employee saved successfully!");
                //ClearFields(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving employee: " + ex.Message);
            }
        }
    }
}
