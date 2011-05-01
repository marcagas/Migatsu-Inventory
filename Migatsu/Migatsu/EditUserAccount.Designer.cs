namespace Migatsu
{
    partial class EditUserAccount
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
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.radioButtonAdministrator = new System.Windows.Forms.RadioButton();
            this.radioButtonStandardUser = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.labelUserPrivelege = new System.Windows.Forms.Label();
            this.labelUserName = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonDeactivate = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.labelDeactivate = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(53, 217);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(422, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Administrators have complete access to the system and can make any desired change" +
                "s.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(55, 171);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(280, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "that do not affect other users or the security of the system.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(53, 156);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(363, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Standard account users can use most software and change system settings";
            // 
            // radioButtonAdministrator
            // 
            this.radioButtonAdministrator.AutoSize = true;
            this.radioButtonAdministrator.Location = new System.Drawing.Point(37, 189);
            this.radioButtonAdministrator.Name = "radioButtonAdministrator";
            this.radioButtonAdministrator.Size = new System.Drawing.Size(85, 17);
            this.radioButtonAdministrator.TabIndex = 9;
            this.radioButtonAdministrator.TabStop = true;
            this.radioButtonAdministrator.Text = "Administrator";
            this.radioButtonAdministrator.UseVisualStyleBackColor = true;
            this.radioButtonAdministrator.CheckedChanged += new System.EventHandler(this.radioButtonAdministrator_CheckedChanged);
            // 
            // radioButtonStandardUser
            // 
            this.radioButtonStandardUser.AutoSize = true;
            this.radioButtonStandardUser.Location = new System.Drawing.Point(37, 128);
            this.radioButtonStandardUser.Name = "radioButtonStandardUser";
            this.radioButtonStandardUser.Size = new System.Drawing.Size(93, 17);
            this.radioButtonStandardUser.TabIndex = 8;
            this.radioButtonStandardUser.TabStop = true;
            this.radioButtonStandardUser.Text = "Standard User";
            this.radioButtonStandardUser.UseVisualStyleBackColor = true;
            this.radioButtonStandardUser.CheckedChanged += new System.EventHandler(this.radioButtonStandardUser_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.SteelBlue;
            this.label1.Location = new System.Drawing.Point(12, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 20);
            this.label1.TabIndex = 13;
            this.label1.Text = "Modify User ";
            // 
            // labelUserPrivelege
            // 
            this.labelUserPrivelege.AutoSize = true;
            this.labelUserPrivelege.Location = new System.Drawing.Point(34, 89);
            this.labelUserPrivelege.Name = "labelUserPrivelege";
            this.labelUserPrivelege.Size = new System.Drawing.Size(76, 13);
            this.labelUserPrivelege.TabIndex = 15;
            this.labelUserPrivelege.Text = "User Privelege";
            // 
            // labelUserName
            // 
            this.labelUserName.AutoSize = true;
            this.labelUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUserName.Location = new System.Drawing.Point(34, 71);
            this.labelUserName.Name = "labelUserName";
            this.labelUserName.Size = new System.Drawing.Size(126, 18);
            this.labelUserName.TabIndex = 14;
            this.labelUserName.Text = "Regent A. McAfee";
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(245, 263);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 16;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonDeactivate
            // 
            this.buttonDeactivate.Location = new System.Drawing.Point(164, 263);
            this.buttonDeactivate.Name = "buttonDeactivate";
            this.buttonDeactivate.Size = new System.Drawing.Size(75, 23);
            this.buttonDeactivate.TabIndex = 17;
            this.buttonDeactivate.Text = "Deactivate";
            this.buttonDeactivate.UseVisualStyleBackColor = true;
            this.buttonDeactivate.Click += new System.EventHandler(this.buttonDeactivate_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(326, 263);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 18;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip1.ToolTipTitle = "Success";
            // 
            // labelDeactivate
            // 
            this.labelDeactivate.AutoSize = true;
            this.labelDeactivate.Location = new System.Drawing.Point(183, 114);
            this.labelDeactivate.Name = "labelDeactivate";
            this.labelDeactivate.Size = new System.Drawing.Size(0, 13);
            this.labelDeactivate.TabIndex = 19;
            // 
            // EditUserAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(477, 324);
            this.Controls.Add(this.labelDeactivate);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonDeactivate);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.labelUserPrivelege);
            this.Controls.Add(this.labelUserName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.radioButtonAdministrator);
            this.Controls.Add(this.radioButtonStandardUser);
            this.Name = "EditUserAccount";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.EditUserAccount_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton radioButtonAdministrator;
        private System.Windows.Forms.RadioButton radioButtonStandardUser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelUserPrivelege;
        private System.Windows.Forms.Label labelUserName;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonDeactivate;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label labelDeactivate;
    }
}