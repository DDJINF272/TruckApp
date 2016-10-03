namespace Project
{
    partial class AddDepartment
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtDepartmentName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txtDepartmentDescription = new System.Windows.Forms.TextBox();
            this.cmbDepartmentSelect = new System.Windows.Forms.ComboBox();
            this.btnRemoveDepartment = new System.Windows.Forms.Button();
            this.btnUpdateDepatment = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtAddDepartmentDescription = new System.Windows.Forms.TextBox();
            this.txtAddDepartmentName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnAddDepartment = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(568, 329);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnUpdateDepatment);
            this.tabPage1.Controls.Add(this.btnRemoveDepartment);
            this.tabPage1.Controls.Add(this.cmbDepartmentSelect);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(560, 303);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Current Departments";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtDepartmentDescription);
            this.groupBox1.Controls.Add(this.txtDepartmentName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(6, 116);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(548, 184);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Selected Department Details";
            // 
            // txtDepartmentName
            // 
            this.txtDepartmentName.Location = new System.Drawing.Point(128, 30);
            this.txtDepartmentName.Name = "txtDepartmentName";
            this.txtDepartmentName.Size = new System.Drawing.Size(185, 20);
            this.txtDepartmentName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Department Name :";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(-2, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Department Description :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select Department :";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnAddDepartment);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(560, 303);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "New Department";
            this.tabPage2.UseVisualStyleBackColor = true;
            this.tabPage2.Click += new System.EventHandler(this.tabPage2_Click);
            // 
            // txtDepartmentDescription
            // 
            this.txtDepartmentDescription.Location = new System.Drawing.Point(128, 57);
            this.txtDepartmentDescription.Multiline = true;
            this.txtDepartmentDescription.Name = "txtDepartmentDescription";
            this.txtDepartmentDescription.Size = new System.Drawing.Size(414, 121);
            this.txtDepartmentDescription.TabIndex = 4;
            // 
            // cmbDepartmentSelect
            // 
            this.cmbDepartmentSelect.FormattingEnabled = true;
            this.cmbDepartmentSelect.Location = new System.Drawing.Point(125, 17);
            this.cmbDepartmentSelect.Name = "cmbDepartmentSelect";
            this.cmbDepartmentSelect.Size = new System.Drawing.Size(202, 21);
            this.cmbDepartmentSelect.TabIndex = 2;
            // 
            // btnRemoveDepartment
            // 
            this.btnRemoveDepartment.Location = new System.Drawing.Point(343, 48);
            this.btnRemoveDepartment.Name = "btnRemoveDepartment";
            this.btnRemoveDepartment.Size = new System.Drawing.Size(205, 27);
            this.btnRemoveDepartment.TabIndex = 3;
            this.btnRemoveDepartment.Text = "Remove Department";
            this.btnRemoveDepartment.UseVisualStyleBackColor = true;
            // 
            // btnUpdateDepatment
            // 
            this.btnUpdateDepatment.Location = new System.Drawing.Point(343, 15);
            this.btnUpdateDepatment.Name = "btnUpdateDepatment";
            this.btnUpdateDepatment.Size = new System.Drawing.Size(205, 27);
            this.btnUpdateDepatment.TabIndex = 4;
            this.btnUpdateDepatment.Text = "Update Department";
            this.btnUpdateDepatment.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtAddDepartmentDescription);
            this.groupBox2.Controls.Add(this.txtAddDepartmentName);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(6, 38);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(548, 184);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Department Details";
            // 
            // txtAddDepartmentDescription
            // 
            this.txtAddDepartmentDescription.Location = new System.Drawing.Point(128, 57);
            this.txtAddDepartmentDescription.Multiline = true;
            this.txtAddDepartmentDescription.Name = "txtAddDepartmentDescription";
            this.txtAddDepartmentDescription.Size = new System.Drawing.Size(414, 121);
            this.txtAddDepartmentDescription.TabIndex = 4;
            // 
            // txtAddDepartmentName
            // 
            this.txtAddDepartmentName.Location = new System.Drawing.Point(128, 30);
            this.txtAddDepartmentName.Name = "txtAddDepartmentName";
            this.txtAddDepartmentName.Size = new System.Drawing.Size(185, 20);
            this.txtAddDepartmentName.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Department Name :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(-2, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(124, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Department Description :";
            // 
            // btnAddDepartment
            // 
            this.btnAddDepartment.Location = new System.Drawing.Point(355, 228);
            this.btnAddDepartment.Name = "btnAddDepartment";
            this.btnAddDepartment.Size = new System.Drawing.Size(199, 27);
            this.btnAddDepartment.TabIndex = 5;
            this.btnAddDepartment.Text = "Add Department";
            this.btnAddDepartment.UseVisualStyleBackColor = true;
            // 
            // AddDepartment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 330);
            this.Controls.Add(this.tabControl1);
            this.Name = "AddDepartment";
            this.Text = "Manage Departments";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDepartmentName;
        private System.Windows.Forms.Button btnUpdateDepatment;
        private System.Windows.Forms.Button btnRemoveDepartment;
        private System.Windows.Forms.ComboBox cmbDepartmentSelect;
        private System.Windows.Forms.TextBox txtDepartmentDescription;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtAddDepartmentDescription;
        private System.Windows.Forms.TextBox txtAddDepartmentName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnAddDepartment;
    }
}