using System.Windows.Forms;

namespace WindowsFormsApp1
{
    partial class ManageTask
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvTasks = new System.Windows.Forms.DataGridView();
            this.plAddTask = new System.Windows.Forms.Panel();
            this.cmbProjectList = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtAssignDate = new System.Windows.Forms.DateTimePicker();
            this.cmbDepartment = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.cmbEmployees = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.btnAssignTask = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTasks)).BeginInit();
            this.plAddTask.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvTasks
            // 
            this.dgvTasks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTasks.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cmbDepartment,
            this.cmbEmployees});
            this.dgvTasks.Location = new System.Drawing.Point(25, 16);
            this.dgvTasks.Name = "dgvTasks";
            this.dgvTasks.Size = new System.Drawing.Size(245, 333);
            this.dgvTasks.TabIndex = 0;
            // 
            // plAddTask
            // 
            this.plAddTask.Controls.Add(this.dgvTasks);
            this.plAddTask.Location = new System.Drawing.Point(30, 74);
            this.plAddTask.Name = "plAddTask";
            this.plAddTask.Size = new System.Drawing.Size(748, 352);
            this.plAddTask.TabIndex = 1;
            // 
            // cmbProjectList
            // 
            this.cmbProjectList.FormattingEnabled = true;
            this.cmbProjectList.Location = new System.Drawing.Point(143, 34);
            this.cmbProjectList.Name = "cmbProjectList";
            this.cmbProjectList.Size = new System.Drawing.Size(157, 21);
            this.cmbProjectList.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Select a Project";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(339, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Assign Date";
            // 
            // dtAssignDate
            // 
            this.dtAssignDate.Location = new System.Drawing.Point(424, 34);
            this.dtAssignDate.Name = "dtAssignDate";
            this.dtAssignDate.Size = new System.Drawing.Size(200, 20);
            this.dtAssignDate.TabIndex = 5;
            // 
            // cmbDepartment
            // 
            this.cmbDepartment.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.cmbDepartment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbDepartment.HeaderText = "Departments";
            this.cmbDepartment.Name = "cmbDepartment";
            // cmbEmployees
            // 
            this.cmbEmployees.HeaderText = "Employees";
            this.cmbEmployees.Name = "cmbEmployees";
            this.cmbEmployees.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.cmbEmployees.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // btnAssignTask
            // 
            this.btnAssignTask.Location = new System.Drawing.Point(692, 31);
            this.btnAssignTask.Name = "btnAssignTask";
            this.btnAssignTask.Size = new System.Drawing.Size(75, 23);
            this.btnAssignTask.TabIndex = 6;
            this.btnAssignTask.Text = "Assign Task";
            this.btnAssignTask.UseVisualStyleBackColor = true;
            this.btnAssignTask.Click += new System.EventHandler(this.btnAssignTask_Click);
            // 
            // ManageTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnAssignTask);
            this.Controls.Add(this.dtAssignDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbProjectList);
            this.Controls.Add(this.plAddTask);
            this.Name = "ManageTask";
            this.Text = "MangeTask";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTasks)).EndInit();
            this.plAddTask.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTasks;
        private Panel plAddTask;
        private ComboBox cmbProjectList;
        private Label label1;
        private DataGridViewComboBoxColumn cmbDepartment;
        private DataGridViewComboBoxColumn cmbEmployees;
        private Label label2;
        private DateTimePicker dtAssignDate;
        private Button btnAssignTask;
    }
}