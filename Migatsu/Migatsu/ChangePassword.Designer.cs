namespace Migatsu
{
    partial class ChangePassword
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textConfirmPassword = new System.Windows.Forms.TextBox();
            this.textNewPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textOldPassword = new System.Windows.Forms.TextBox();
            this.buttonChange = new System.Windows.Forms.Button();
            this.toolTipOldPassword = new System.Windows.Forms.ToolTip(this.components);
            this.labelOldPassword = new System.Windows.Forms.Label();
            this.labelNewPassword = new System.Windows.Forms.Label();
            this.labelConfirmPassword = new System.Windows.Forms.Label();
            this.toolTipNewPassword = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipConfirmPassword = new System.Windows.Forms.ToolTip(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.toolTipUpdate = new System.Windows.Forms.ToolTip(this.components);
            this.labelUpdatePassword = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.SteelBlue;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Change Your Password";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(47, 172);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Confirm Password";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(47, 119);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "New Password";
            // 
            // textConfirmPassword
            // 
            this.textConfirmPassword.Location = new System.Drawing.Point(50, 188);
            this.textConfirmPassword.Name = "textConfirmPassword";
            this.textConfirmPassword.Size = new System.Drawing.Size(188, 20);
            this.textConfirmPassword.TabIndex = 2;
            this.textConfirmPassword.UseSystemPasswordChar = true;
            this.textConfirmPassword.MouseHover += new System.EventHandler(this.textConfirmPassword_MouseHover);
            // 
            // textNewPassword
            // 
            this.textNewPassword.Location = new System.Drawing.Point(50, 135);
            this.textNewPassword.Name = "textNewPassword";
            this.textNewPassword.Size = new System.Drawing.Size(188, 20);
            this.textNewPassword.TabIndex = 1;
            this.textNewPassword.UseSystemPasswordChar = true;
            this.textNewPassword.MouseHover += new System.EventHandler(this.textNewPassword_MouseHover);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Old Password";
            // 
            // textOldPassword
            // 
            this.textOldPassword.Location = new System.Drawing.Point(51, 82);
            this.textOldPassword.Name = "textOldPassword";
            this.textOldPassword.Size = new System.Drawing.Size(188, 20);
            this.textOldPassword.TabIndex = 0;
            this.textOldPassword.UseSystemPasswordChar = true;
            this.textOldPassword.MouseHover += new System.EventHandler(this.textOldPassword_MouseHover);
            // 
            // buttonChange
            // 
            this.buttonChange.Location = new System.Drawing.Point(164, 241);
            this.buttonChange.Name = "buttonChange";
            this.buttonChange.Size = new System.Drawing.Size(75, 23);
            this.buttonChange.TabIndex = 3;
            this.buttonChange.Text = "Change";
            this.buttonChange.UseVisualStyleBackColor = true;
            this.buttonChange.Click += new System.EventHandler(this.buttonChange_Click);
            this.buttonChange.MouseHover += new System.EventHandler(this.buttonChange_MouseHover);
            // 
            // toolTipOldPassword
            // 
            this.toolTipOldPassword.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Warning;
            this.toolTipOldPassword.ToolTipTitle = "Invalid Password";
            // 
            // labelOldPassword
            // 
            this.labelOldPassword.AutoSize = true;
            this.labelOldPassword.Location = new System.Drawing.Point(245, 82);
            this.labelOldPassword.Name = "labelOldPassword";
            this.labelOldPassword.Size = new System.Drawing.Size(0, 13);
            this.labelOldPassword.TabIndex = 21;
            // 
            // labelNewPassword
            // 
            this.labelNewPassword.AutoSize = true;
            this.labelNewPassword.Location = new System.Drawing.Point(245, 135);
            this.labelNewPassword.Name = "labelNewPassword";
            this.labelNewPassword.Size = new System.Drawing.Size(0, 13);
            this.labelNewPassword.TabIndex = 22;
            // 
            // labelConfirmPassword
            // 
            this.labelConfirmPassword.AutoSize = true;
            this.labelConfirmPassword.Location = new System.Drawing.Point(245, 188);
            this.labelConfirmPassword.Name = "labelConfirmPassword";
            this.labelConfirmPassword.Size = new System.Drawing.Size(0, 13);
            this.labelConfirmPassword.TabIndex = 23;
            // 
            // toolTipNewPassword
            // 
            this.toolTipNewPassword.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Warning;
            this.toolTipNewPassword.ToolTipTitle = "Invalid Input";
            // 
            // toolTipConfirmPassword
            // 
            this.toolTipConfirmPassword.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Warning;
            this.toolTipConfirmPassword.ToolTipTitle = "Invalid Password";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(248, 241);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // toolTipUpdate
            // 
            this.toolTipUpdate.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTipUpdate.ToolTipTitle = "Update";
            // 
            // labelUpdatePassword
            // 
            this.labelUpdatePassword.AutoSize = true;
            this.labelUpdatePassword.Location = new System.Drawing.Point(252, 141);
            this.labelUpdatePassword.Name = "labelUpdatePassword";
            this.labelUpdatePassword.Size = new System.Drawing.Size(0, 13);
            this.labelUpdatePassword.TabIndex = 25;
            // 
            // ChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(371, 293);
            this.Controls.Add(this.labelUpdatePassword);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.labelConfirmPassword);
            this.Controls.Add(this.labelNewPassword);
            this.Controls.Add(this.labelOldPassword);
            this.Controls.Add(this.buttonChange);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textOldPassword);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textConfirmPassword);
            this.Controls.Add(this.textNewPassword);
            this.Controls.Add(this.label1);
            this.Name = "ChangePassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Password";
            this.Load += new System.EventHandler(this.ChangePassword_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textConfirmPassword;
        private System.Windows.Forms.TextBox textNewPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textOldPassword;
        private System.Windows.Forms.Button buttonChange;
        private System.Windows.Forms.ToolTip toolTipOldPassword;
        private System.Windows.Forms.Label labelOldPassword;
        private System.Windows.Forms.Label labelNewPassword;
        private System.Windows.Forms.Label labelConfirmPassword;
        private System.Windows.Forms.ToolTip toolTipNewPassword;
        private System.Windows.Forms.ToolTip toolTipConfirmPassword;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolTip toolTipUpdate;
        private System.Windows.Forms.Label labelUpdatePassword;
    }
}