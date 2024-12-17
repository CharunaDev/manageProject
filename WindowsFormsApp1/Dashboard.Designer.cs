namespace WindowsFormsApp1
{
    partial class Dashboard
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
            this.btnManageEmp = new System.Windows.Forms.Button();
            this.btnManageProjects = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnManageEmp
            // 
            this.btnManageEmp.Location = new System.Drawing.Point(289, 150);
            this.btnManageEmp.Name = "btnManageEmp";
            this.btnManageEmp.Size = new System.Drawing.Size(170, 23);
            this.btnManageEmp.TabIndex = 0;
            this.btnManageEmp.Text = "Manage Employees";
            this.btnManageEmp.UseVisualStyleBackColor = true;
            this.btnManageEmp.Click += new System.EventHandler(this.btnManageEmp_Click);
            // 
            // btnManageProjects
            // 
            this.btnManageProjects.Location = new System.Drawing.Point(289, 228);
            this.btnManageProjects.Name = "btnManageProjects";
            this.btnManageProjects.Size = new System.Drawing.Size(170, 23);
            this.btnManageProjects.TabIndex = 1;
            this.btnManageProjects.Text = "Manage Projects";
            this.btnManageProjects.UseVisualStyleBackColor = true;
            this.btnManageProjects.Click += new System.EventHandler(this.btnManageProjects_Click);
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnManageProjects);
            this.Controls.Add(this.btnManageEmp);
            this.Name = "Dashboard";
            this.Text = "Dashboard";
            this.Load += new System.EventHandler(this.Dashboard_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnManageEmp;
        private System.Windows.Forms.Button btnManageProjects;
    }
}