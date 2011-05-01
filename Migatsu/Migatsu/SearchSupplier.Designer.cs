namespace Migatsu
{
    partial class SearchSupplier
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchSupplier));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.buttonGo = new System.Windows.Forms.Button();
            this.textBoxKeyword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxSearchBy = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dataGridViewSupplierList = new System.Windows.Forms.DataGridView();
            this.statusStripSuppliers = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelProducts = new System.Windows.Forms.ToolStripStatusLabel();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSupplierList)).BeginInit();
            this.statusStripSuppliers.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonGo
            // 
            this.buttonGo.Image = ((System.Drawing.Image)(resources.GetObject("buttonGo.Image")));
            this.buttonGo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonGo.Location = new System.Drawing.Point(490, 81);
            this.buttonGo.Name = "buttonGo";
            this.buttonGo.Size = new System.Drawing.Size(51, 23);
            this.buttonGo.TabIndex = 145;
            this.buttonGo.Text = "Go";
            this.buttonGo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonGo.UseVisualStyleBackColor = true;
            this.buttonGo.Click += new System.EventHandler(this.buttonGo_Click);
            // 
            // textBoxKeyword
            // 
            this.textBoxKeyword.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxKeyword.Location = new System.Drawing.Point(215, 83);
            this.textBoxKeyword.Name = "textBoxKeyword";
            this.textBoxKeyword.Size = new System.Drawing.Size(269, 31);
            this.textBoxKeyword.TabIndex = 144;
            this.textBoxKeyword.TextChanged += new System.EventHandler(this.textBoxKeyword_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(212, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 143;
            this.label2.Text = "Keyword";
            // 
            // comboBoxSearchBy
            // 
            this.comboBoxSearchBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSearchBy.FormattingEnabled = true;
            this.comboBoxSearchBy.Location = new System.Drawing.Point(48, 83);
            this.comboBoxSearchBy.Name = "comboBoxSearchBy";
            this.comboBoxSearchBy.Size = new System.Drawing.Size(146, 21);
            this.comboBoxSearchBy.TabIndex = 142;
            this.comboBoxSearchBy.SelectedIndexChanged += new System.EventHandler(this.comboBoxSearchBy_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 141;
            this.label1.Text = "Search by";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.SteelBlue;
            this.label7.Location = new System.Drawing.Point(23, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(122, 20);
            this.label7.TabIndex = 146;
            this.label7.Text = "Search Supplier";
            // 
            // dataGridViewSupplierList
            // 
            this.dataGridViewSupplierList.AllowUserToAddRows = false;
            this.dataGridViewSupplierList.AllowUserToDeleteRows = false;
            this.dataGridViewSupplierList.AllowUserToResizeColumns = false;
            this.dataGridViewSupplierList.AllowUserToResizeRows = false;
            this.dataGridViewSupplierList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewSupplierList.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridViewSupplierList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridViewSupplierList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewSupplierList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewSupplierList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewSupplierList.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewSupplierList.GridColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridViewSupplierList.Location = new System.Drawing.Point(0, 150);
            this.dataGridViewSupplierList.MultiSelect = false;
            this.dataGridViewSupplierList.Name = "dataGridViewSupplierList";
            this.dataGridViewSupplierList.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewSupplierList.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewSupplierList.RowHeadersVisible = false;
            this.dataGridViewSupplierList.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridViewSupplierList.RowTemplate.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.dataGridViewSupplierList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewSupplierList.Size = new System.Drawing.Size(555, 110);
            this.dataGridViewSupplierList.TabIndex = 147;
            this.dataGridViewSupplierList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewSupplierList_CellClick);
            // 
            // statusStripSuppliers
            // 
            this.statusStripSuppliers.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelProducts});
            this.statusStripSuppliers.Location = new System.Drawing.Point(0, 260);
            this.statusStripSuppliers.Name = "statusStripSuppliers";
            this.statusStripSuppliers.Size = new System.Drawing.Size(555, 22);
            this.statusStripSuppliers.TabIndex = 148;
            this.statusStripSuppliers.Text = "statusStrip1";
            // 
            // toolStripStatusLabelProducts
            // 
            this.toolStripStatusLabelProducts.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripStatusLabelProducts.Name = "toolStripStatusLabelProducts";
            this.toolStripStatusLabelProducts.Size = new System.Drawing.Size(61, 17);
            this.toolStripStatusLabelProducts.Text = "Suppliers: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(24, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(368, 13);
            this.label3.TabIndex = 170;
            this.label3.Text = "To select supplier, click on the list provided below and click the button \"Go\".\r\n" +
                "";
            // 
            // SearchSupplier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(555, 282);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.statusStripSuppliers);
            this.Controls.Add(this.dataGridViewSupplierList);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.buttonGo);
            this.Controls.Add(this.textBoxKeyword);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxSearchBy);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(571, 320);
            this.MinimumSize = new System.Drawing.Size(571, 320);
            this.Name = "SearchSupplier";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Suppliers";
            this.Load += new System.EventHandler(this.SearchSupplier_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSupplierList)).EndInit();
            this.statusStripSuppliers.ResumeLayout(false);
            this.statusStripSuppliers.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonGo;
        private System.Windows.Forms.TextBox textBoxKeyword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxSearchBy;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dataGridViewSupplierList;
        private System.Windows.Forms.StatusStrip statusStripSuppliers;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelProducts;
        private System.Windows.Forms.Label label3;
    }
}