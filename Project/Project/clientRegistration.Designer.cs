namespace Project
{
    partial class clientRegistration
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnStartRegister = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(35, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(370, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Your new account is only a few steps away ...";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(94, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(245, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Please click on Begin to become part of the family ";
            // 
            // btnStartRegister
            // 
            this.btnStartRegister.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnStartRegister.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartRegister.ForeColor = System.Drawing.SystemColors.Control;
            this.btnStartRegister.Location = new System.Drawing.Point(12, 69);
            this.btnStartRegister.Name = "btnStartRegister";
            this.btnStartRegister.Size = new System.Drawing.Size(411, 49);
            this.btnStartRegister.TabIndex = 2;
            this.btnStartRegister.Text = "Begin!";
            this.btnStartRegister.UseVisualStyleBackColor = false;
            this.btnStartRegister.Click += new System.EventHandler(this.btnStartRegister_Click);
            // 
            // clientRegistration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 126);
            this.Controls.Add(this.btnStartRegister);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "clientRegistration";
            this.Text = "Register Now";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnStartRegister;
    }
}