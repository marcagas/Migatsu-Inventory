namespace Migatsu
{
    partial class ChangePin
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
            this.labelUpdatePIN = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.labelConfirmPIN = new System.Windows.Forms.Label();
            this.labelNewPIN = new System.Windows.Forms.Label();
            this.labelCurrentPIN = new System.Windows.Forms.Label();
            this.buttonChange = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textCurrentPIN = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textConfirmPIN = new System.Windows.Forms.TextBox();
            this.textNewPIN = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.toolTipErrorPin = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipSuccessPin = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // labelUpdatePIN
            // 
            this.labelUpdatePIN.AutoSize = true;
            this.labelUpdatePIN.Location = new System.Drawing.Point(252, 130);
            this.labelUpdatePIN.Name = "labelUpdatePIN";
            this.labelUpdatePIN.Size = new System.Drawing.Size(0, 13);
            this.labelUpdatePIN.TabIndex = 38;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(248, 230);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 31;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // labelConfirmPIN
            // 
            this.labelConfirmPIN.AutoSize = true;
            this.labelConfirmPIN.Location = new System.Drawing.Point(245, 177);
            this.labelConfirmPIN.Name = "labelConfirmPIN";
            this.labelConfirmPIN.Size = new System.Drawing.Size(0, 13);
            this.labelConfirmPIN.TabIndex = 37;
            // 
            // labelNewPIN
            // 
            this.labelNewPIN.AutoSize = true;
            this.labelNewPIN.Location = new System.Drawing.Point(245, 124);
            this.labelNewPIN.Name = "labelNewPIN";
            this.labelNewPIN.Size = new System.Drawing.Size(0, 13);
            this.labelNewPIN.TabIndex = 36;
            // 
            // labelCurrentPIN
            // 
            this.labelCurrentPIN.AutoSize = true;
            this.labelCurrentPIN.Location = new System.Drawing.Point(245, 71);
            this.labelCurrentPIN.Name = "labelCurrentPIN";
            this.labelCurrentPIN.Size = new System.Drawing.Size(0, 13);
            this.labelCurrentPIN.TabIndex = 35;
            // 
            // buttonChange
            // 
            this.buttonChange.Location = new System.Drawing.Point(164, 230);
            this.buttonChange.Name = "buttonChange";
            this.buttonChange.Size = new System.Drawing.Size(75, 23);
            this.buttonChange.TabIndex = 30;
            this.buttonChange.Text = "Change";
            this.buttonChange.UseVisualStyleBackColor = true;
            this.buttonChange.Click += new System.EventHandler(this.buttonChange_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 34;
            this.label2.Text = "Current PIN*";
            // 
            // textCurrentPIN
            // 
            this.textCurrentPIN.Location = new System.Drawing.Point(51, 71);
            this.textCurrentPIN.Name = "textCurrentPIN";
            this.textCurrentPIN.Size = new System.Drawing.Size(188, 20);
            this.textCurrentPIN.TabIndex = 26;
            this.textCurrentPIN.UseSystemPasswordChar = true;
            this.textCurrentPIN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textCurrentPIN_KeyPress);
            this.textCurrentPIN.MouseHover += new System.EventHandler(this.textCurrentPIN_MouseHover);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(47, 161);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 13);
            this.label7.TabIndex = 33;
            this.label7.Text = "Confirm PIN*";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(47, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 32;
            this.label5.Text = "New PIN*";
            // 
            // textConfirmPIN
            // 
            this.textConfirmPIN.Location = new System.Drawing.Point(50, 177);
            this.textConfirmPIN.Name = "textConfirmPIN";
            this.textConfirmPIN.Size = new System.Drawing.Size(188, 20);
            this.textConfirmPIN.TabIndex = 29;
            this.textConfirmPIN.UseSystemPasswordChar = true;
            this.textConfirmPIN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textConfirmPIN_KeyPress);
            this.textConfirmPIN.MouseHover += new System.EventHandler(this.textConfirmPIN_MouseHover);
            // 
            // textNewPIN
            // 
            this.textNewPIN.Location = new System.Drawing.Point(50, 124);
            this.textNewPIN.Name = "textNewPIN";
            this.textNewPIN.Size = new System.Drawing.Size(188, 20);
            this.textNewPIN.TabIndex = 28;
            this.textNewPIN.UseSystemPasswordChar = true;
            this.textNewPIN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textNewPIN_KeyPress);
            this.textNewPIN.MouseHover += new System.EventHandler(this.textNewPIN_MouseHover);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.SteelBlue;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 20);
            this.label1.TabIndex = 27;
            this.label1.Text = "Change Your PIN";
            // 
            // toolTipErrorPin
            // 
            this.toolTipErrorPin.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Warning;
            this.toolTipErrorPin.ToolTipTitle = "Invalid";
            // 
            // toolTipSuccessPin
            // 
            this.toolTipSuccessPin.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // ChangePin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(361, 288);
            this.Controls.Add(this.labelUpdatePIN);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.labelConfirmPIN);
            this.Controls.Add(this.labelNewPIN);
            this.Controls.Add(this.labelCurrentPIN);
            this.Controls.Add(this.buttonChange);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textCurrentPIN);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textConfirmPIN);
            this.Controls.Add(this.textNewPIN);
            this.Controls.Add(this.label1);
            this.Name = "ChangePin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ChangePin";
            this.Load += new System.EventHandler(this.ChangePin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelUpdatePIN;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label labelConfirmPIN;
        private System.Windows.Forms.Label labelNewPIN;
        private System.Windows.Forms.Label labelCurrentPIN;
        private System.Windows.Forms.Button buttonChange;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textCurrentPIN;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textConfirmPIN;
        private System.Windows.Forms.TextBox textNewPIN;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolTip toolTipErrorPin;
        private System.Windows.Forms.ToolTip toolTipSuccessPin;
    }
}