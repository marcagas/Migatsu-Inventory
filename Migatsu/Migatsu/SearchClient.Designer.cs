namespace Migatsu
{
    partial class SearchClient
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchClient));
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridViewClientList = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.buttonGo = new System.Windows.Forms.Button();
            this.textBoxKeyword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxSearchBy = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.statusStripSuppliers = new System.Windows.Forms.StatusStrip();
            this.toolStripTotalClients = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClientList)).BeginInit();
            this.statusStripSuppliers.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(24, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(357, 13);
            this.label3.TabIndex = 178;
            this.label3.Text = "To select client, click on the list provided below and click the button \"Go\".\r\n";
            // 
            // dataGridViewClientList
            // 
            this.dataGridViewClientList.AllowUserToAddRows = false;
            this.dataGridViewClientList.AllowUserToDeleteRows = false;
            this.dataGridViewClientList.AllowUserToResizeColumns = false;
            this.dataGridViewClientList.AllowUserToResizeRows = false;
            this.dataGridViewClientList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewClientList.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridViewClientList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridViewClientList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewClientList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewClientList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewClientList.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewClientList.GridColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridViewClientList.Location = new System.Drawing.Point(0, 149);
            this.dataGridViewClientList.MultiSelect = false;
            this.dataGridViewClientList.Name = "dataGridViewClientList";
            this.dataGridViewClientList.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewClientList.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewClientList.RowHeadersVisible = false;
            this.dataGridViewClientList.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridViewClientList.RowTemplate.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.dataGridViewClientList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewClientList.Size = new System.Drawing.Size(555, 110);
            this.dataGridViewClientList.TabIndex = 177;
            this.dataGridViewClientList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewClientList_CellClick);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.SteelBlue;
            this.label7.Location = new System.Drawing.Point(23, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 20);
            this.label7.TabIndex = 176;
            this.label7.Text = "Search Client";
            // 
            // buttonGo
            // 
            this.buttonGo.Image = ((System.Drawing.Image)(resources.GetObject("buttonGo.Image")));
            this.buttonGo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonGo.Location = new System.Drawing.Point(490, 80);
            this.buttonGo.Name = "buttonGo";
            this.buttonGo.Size = new System.Drawing.Size(51, 23);
            this.buttonGo.TabIndex = 175;
            this.buttonGo.Text = "Go";
            this.buttonGo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonGo.UseVisualStyleBackColor = true;
            this.buttonGo.Click += new System.EventHandler(this.buttonGo_Click);
            // 
            // textBoxKeyword
            // 
            this.textBoxKeyword.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxKeyword.Location = new System.Drawing.Point(215, 82);
            this.textBoxKeyword.Name = "textBoxKeyword";
            this.textBoxKeyword.Size = new System.Drawing.Size(269, 31);
            this.textBoxKeyword.TabIndex = 174;
            this.textBoxKeyword.TextChanged += new System.EventHandler(this.textBoxKeyword_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(212, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 173;
            this.label2.Text = "Keyword";
            // 
            // comboBoxSearchBy
            // 
            this.comboBoxSearchBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSearchBy.FormattingEnabled = true;
            this.comboBoxSearchBy.Location = new System.Drawing.Point(48, 82);
            this.comboBoxSearchBy.Name = "comboBoxSearchBy";
            this.comboBoxSearchBy.Size = new System.Drawing.Size(146, 21);
            this.comboBoxSearchBy.TabIndex = 172;
            this.comboBoxSearchBy.SelectedIndexChanged += new System.EventHandler(this.comboBoxSearchBy_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 171;
            this.label1.Text = "Search by";
            // 
            // statusStripSuppliers
            // 
            this.statusStripSuppliers.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTotalClients});
            this.statusStripSuppliers.Location = new System.Drawing.Point(0, 260);
            this.statusStripSuppliers.Name = "statusStripSuppliers";
            this.statusStripSuppliers.Size = new System.Drawing.Size(555, 22);
            this.statusStripSuppliers.TabIndex = 179;
            this.statusStripSuppliers.Text = "statusStrip1";
            // 
            // toolStripTotalClients
            // 
            this.toolStripTotalClients.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripTotalClients.Name = "toolStripTotalClients";
            this.toolStripTotalClients.Size = new System.Drawing.Size(76, 17);
            this.toolStripTotalClients.Text = "Total Clients:";
            // 
            // SearchClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(555, 282);
            this.Controls.Add(this.statusStripSuppliers);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridViewClientList);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.buttonGo);
            this.Controls.Add(this.textBoxKeyword);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxSearchBy);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(571, 320);
            this.MinimumSize = new System.Drawing.Size(571, 320);
            this.Name = "SearchClient";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.SearchClient_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClientList)).EndInit();
            this.statusStripSuppliers.ResumeLayout(false);
            this.statusStripSuppliers.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridViewClientList;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button buttonGo;
        private System.Windows.Forms.TextBox textBoxKeyword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxSearchBy;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.StatusStrip statusStripSuppliers;
        private System.Windows.Forms.ToolStripStatusLabel toolStripTotalClients;
    }
}