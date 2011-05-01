namespace Migatsu
{
    partial class AddInventory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddInventory));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.linkLabelRemoveAllData = new System.Windows.Forms.LinkLabel();
            this.linkLabelDeleteSelectedItem = new System.Windows.Forms.LinkLabel();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.linkLabelClearFields = new System.Windows.Forms.LinkLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.linkLabelClearList = new System.Windows.Forms.LinkLabel();
            this.dataGridViewProductList = new System.Windows.Forms.DataGridView();
            this.buttonAddToList = new System.Windows.Forms.Button();
            this.textBoxPurchaseOrderNumber = new System.Windows.Forms.TextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.textBoxQuantityToAdd = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxSpecialFeature = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.textBoxModel = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.textBoxProductName = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxColor = new System.Windows.Forms.TextBox();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.textBoxSize = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxUnit = new System.Windows.Forms.TextBox();
            this.textBoxBrand = new System.Windows.Forms.TextBox();
            this.label34 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.textBoxSubCategory = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxCategory = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonSearchProduct = new System.Windows.Forms.Button();
            this.comboBoxWarehouse = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProductStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.textBoxSupplier = new System.Windows.Forms.TextBox();
            this.buttonSearchSupplier = new System.Windows.Forms.Button();
            this.toolTipError = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipSuccess = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProductList)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // linkLabelRemoveAllData
            // 
            this.linkLabelRemoveAllData.AutoSize = true;
            this.linkLabelRemoveAllData.Location = new System.Drawing.Point(594, 288);
            this.linkLabelRemoveAllData.Name = "linkLabelRemoveAllData";
            this.linkLabelRemoveAllData.Size = new System.Drawing.Size(90, 13);
            this.linkLabelRemoveAllData.TabIndex = 174;
            this.linkLabelRemoveAllData.TabStop = true;
            this.linkLabelRemoveAllData.Text = "[Remove all data]";
            this.linkLabelRemoveAllData.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelRemoveAllData_LinkClicked);
            // 
            // linkLabelDeleteSelectedItem
            // 
            this.linkLabelDeleteSelectedItem.AutoSize = true;
            this.linkLabelDeleteSelectedItem.Location = new System.Drawing.Point(3, 355);
            this.linkLabelDeleteSelectedItem.Name = "linkLabelDeleteSelectedItem";
            this.linkLabelDeleteSelectedItem.Size = new System.Drawing.Size(119, 13);
            this.linkLabelDeleteSelectedItem.TabIndex = 173;
            this.linkLabelDeleteSelectedItem.TabStop = true;
            this.linkLabelDeleteSelectedItem.Text = "[Delete selected item/s]";
            this.linkLabelDeleteSelectedItem.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelDeleteSelectedItem_LinkClicked);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(703, 326);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(81, 23);
            this.buttonCancel.TabIndex = 172;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.button8_Click);
            // 
            // linkLabelClearFields
            // 
            this.linkLabelClearFields.AutoSize = true;
            this.linkLabelClearFields.Location = new System.Drawing.Point(521, 288);
            this.linkLabelClearFields.Name = "linkLabelClearFields";
            this.linkLabelClearFields.Size = new System.Drawing.Size(67, 13);
            this.linkLabelClearFields.TabIndex = 171;
            this.linkLabelClearFields.TabStop = true;
            this.linkLabelClearFields.Text = "[Clear Fields]";
            this.linkLabelClearFields.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelClearFields_LinkClicked);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.Location = new System.Drawing.Point(524, 304);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(259, 10);
            this.pictureBox1.TabIndex = 170;
            this.pictureBox1.TabStop = false;
            // 
            // buttonSave
            // 
            this.buttonSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSave.Location = new System.Drawing.Point(610, 326);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(80, 23);
            this.buttonSave.TabIndex = 169;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // linkLabelClearList
            // 
            this.linkLabelClearList.AutoSize = true;
            this.linkLabelClearList.Location = new System.Drawing.Point(128, 355);
            this.linkLabelClearList.Name = "linkLabelClearList";
            this.linkLabelClearList.Size = new System.Drawing.Size(56, 13);
            this.linkLabelClearList.TabIndex = 168;
            this.linkLabelClearList.TabStop = true;
            this.linkLabelClearList.Text = "[Clear List]";
            this.linkLabelClearList.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelClearList_LinkClicked);
            // 
            // dataGridViewProductList
            // 
            this.dataGridViewProductList.AllowUserToAddRows = false;
            this.dataGridViewProductList.AllowUserToDeleteRows = false;
            this.dataGridViewProductList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewProductList.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridViewProductList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridViewProductList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewProductList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewProductList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewProductList.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewProductList.GridColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridViewProductList.Location = new System.Drawing.Point(0, 371);
            this.dataGridViewProductList.MultiSelect = false;
            this.dataGridViewProductList.Name = "dataGridViewProductList";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewProductList.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewProductList.RowHeadersVisible = false;
            this.dataGridViewProductList.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridViewProductList.RowTemplate.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.dataGridViewProductList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewProductList.Size = new System.Drawing.Size(813, 104);
            this.dataGridViewProductList.TabIndex = 167;
            // 
            // buttonAddToList
            // 
            this.buttonAddToList.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonAddToList.Location = new System.Drawing.Point(703, 250);
            this.buttonAddToList.Name = "buttonAddToList";
            this.buttonAddToList.Size = new System.Drawing.Size(80, 23);
            this.buttonAddToList.TabIndex = 166;
            this.buttonAddToList.Text = "Add to list";
            this.buttonAddToList.UseVisualStyleBackColor = true;
            this.buttonAddToList.Click += new System.EventHandler(this.buttonAddToList_Click);
            // 
            // textBoxPurchaseOrderNumber
            // 
            this.textBoxPurchaseOrderNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPurchaseOrderNumber.Location = new System.Drawing.Point(524, 193);
            this.textBoxPurchaseOrderNumber.Name = "textBoxPurchaseOrderNumber";
            this.textBoxPurchaseOrderNumber.Size = new System.Drawing.Size(258, 31);
            this.textBoxPurchaseOrderNumber.TabIndex = 165;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.Location = new System.Drawing.Point(521, 117);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(94, 13);
            this.label31.TabIndex = 164;
            this.label31.Text = "Assign a Supplier*";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(523, 179);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(128, 13);
            this.label23.TabIndex = 163;
            this.label23.Text = "Purchase Order Number*";
            // 
            // textBoxQuantityToAdd
            // 
            this.textBoxQuantityToAdd.BackColor = System.Drawing.SystemColors.Info;
            this.textBoxQuantityToAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxQuantityToAdd.Location = new System.Drawing.Point(524, 246);
            this.textBoxQuantityToAdd.Name = "textBoxQuantityToAdd";
            this.textBoxQuantityToAdd.Size = new System.Drawing.Size(173, 31);
            this.textBoxQuantityToAdd.TabIndex = 161;
            this.textBoxQuantityToAdd.TextChanged += new System.EventHandler(this.textBoxQuantityToAdd_TextChanged);
            this.textBoxQuantityToAdd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxQuantityToAdd_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(523, 230);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 160;
            this.label1.Text = "Quantity to add*";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label17.Location = new System.Drawing.Point(26, 48);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(219, 13);
            this.label17.TabIndex = 159;
            this.label17.Text = "Note: Asterisk (*) indicates mandatory field.";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxSpecialFeature);
            this.groupBox1.Controls.Add(this.label24);
            this.groupBox1.Controls.Add(this.textBoxModel);
            this.groupBox1.Controls.Add(this.label26);
            this.groupBox1.Controls.Add(this.textBoxProductName);
            this.groupBox1.Controls.Add(this.label29);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.textBoxColor);
            this.groupBox1.Controls.Add(this.textBoxDescription);
            this.groupBox1.Controls.Add(this.textBoxSize);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBoxUnit);
            this.groupBox1.Controls.Add(this.textBoxBrand);
            this.groupBox1.Controls.Add(this.label34);
            this.groupBox1.Controls.Add(this.label32);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.textBoxSubCategory);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textBoxCategory);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(29, 82);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(448, 242);
            this.groupBox1.TabIndex = 158;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Product details";
            // 
            // textBoxSpecialFeature
            // 
            this.textBoxSpecialFeature.Location = new System.Drawing.Point(263, 82);
            this.textBoxSpecialFeature.Name = "textBoxSpecialFeature";
            this.textBoxSpecialFeature.Size = new System.Drawing.Size(173, 20);
            this.textBoxSpecialFeature.TabIndex = 127;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(6, 25);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(80, 13);
            this.label24.TabIndex = 120;
            this.label24.Text = "Product Name*";
            // 
            // textBoxModel
            // 
            this.textBoxModel.Location = new System.Drawing.Point(9, 82);
            this.textBoxModel.Name = "textBoxModel";
            this.textBoxModel.Size = new System.Drawing.Size(119, 20);
            this.textBoxModel.TabIndex = 109;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(6, 66);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(35, 13);
            this.label26.TabIndex = 108;
            this.label26.Text = "Model";
            // 
            // textBoxProductName
            // 
            this.textBoxProductName.Location = new System.Drawing.Point(6, 41);
            this.textBoxProductName.Name = "textBoxProductName";
            this.textBoxProductName.Size = new System.Drawing.Size(430, 20);
            this.textBoxProductName.TabIndex = 110;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.Location = new System.Drawing.Point(6, 105);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(60, 13);
            this.label29.TabIndex = 114;
            this.label29.Text = "Description";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(262, 66);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 13);
            this.label6.TabIndex = 115;
            this.label6.Text = "Special Feature";
            // 
            // textBoxColor
            // 
            this.textBoxColor.Location = new System.Drawing.Point(360, 206);
            this.textBoxColor.Name = "textBoxColor";
            this.textBoxColor.Size = new System.Drawing.Size(76, 20);
            this.textBoxColor.TabIndex = 126;
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Location = new System.Drawing.Point(9, 121);
            this.textBoxDescription.Multiline = true;
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Size = new System.Drawing.Size(334, 57);
            this.textBoxDescription.TabIndex = 113;
            // 
            // textBoxSize
            // 
            this.textBoxSize.Location = new System.Drawing.Point(360, 163);
            this.textBoxSize.Name = "textBoxSize";
            this.textBoxSize.Size = new System.Drawing.Size(76, 20);
            this.textBoxSize.TabIndex = 125;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(133, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 112;
            this.label2.Text = "Brand";
            // 
            // textBoxUnit
            // 
            this.textBoxUnit.Location = new System.Drawing.Point(360, 120);
            this.textBoxUnit.Name = "textBoxUnit";
            this.textBoxUnit.Size = new System.Drawing.Size(76, 20);
            this.textBoxUnit.TabIndex = 124;
            // 
            // textBoxBrand
            // 
            this.textBoxBrand.Location = new System.Drawing.Point(136, 82);
            this.textBoxBrand.Name = "textBoxBrand";
            this.textBoxBrand.Size = new System.Drawing.Size(119, 20);
            this.textBoxBrand.TabIndex = 111;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label34.Location = new System.Drawing.Point(357, 147);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(26, 13);
            this.label34.TabIndex = 78;
            this.label34.Text = "Size";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.Location = new System.Drawing.Point(357, 190);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(32, 13);
            this.label32.TabIndex = 75;
            this.label32.Text = "Color";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(357, 105);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(26, 13);
            this.label16.TabIndex = 69;
            this.label16.Text = "Unit";
            // 
            // textBoxSubCategory
            // 
            this.textBoxSubCategory.Location = new System.Drawing.Point(6, 206);
            this.textBoxSubCategory.Name = "textBoxSubCategory";
            this.textBoxSubCategory.Size = new System.Drawing.Size(159, 20);
            this.textBoxSubCategory.TabIndex = 123;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(181, 190);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 61;
            this.label4.Text = "Category*";
            // 
            // textBoxCategory
            // 
            this.textBoxCategory.Location = new System.Drawing.Point(184, 206);
            this.textBoxCategory.Name = "textBoxCategory";
            this.textBoxCategory.Size = new System.Drawing.Size(159, 20);
            this.textBoxCategory.TabIndex = 122;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 190);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 63;
            this.label5.Text = "Sub Category";
            // 
            // buttonSearchProduct
            // 
            this.buttonSearchProduct.Image = ((System.Drawing.Image)(resources.GetObject("buttonSearchProduct.Image")));
            this.buttonSearchProduct.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSearchProduct.Location = new System.Drawing.Point(358, 57);
            this.buttonSearchProduct.Name = "buttonSearchProduct";
            this.buttonSearchProduct.Size = new System.Drawing.Size(119, 23);
            this.buttonSearchProduct.TabIndex = 157;
            this.buttonSearchProduct.Text = "Search a Product";
            this.buttonSearchProduct.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonSearchProduct.UseVisualStyleBackColor = true;
            this.buttonSearchProduct.Click += new System.EventHandler(this.button4_Click);
            // 
            // comboBoxWarehouse
            // 
            this.comboBoxWarehouse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxWarehouse.FormattingEnabled = true;
            this.comboBoxWarehouse.Location = new System.Drawing.Point(524, 73);
            this.comboBoxWarehouse.Name = "comboBoxWarehouse";
            this.comboBoxWarehouse.Size = new System.Drawing.Size(258, 21);
            this.comboBoxWarehouse.TabIndex = 156;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(521, 57);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(111, 13);
            this.label8.TabIndex = 155;
            this.label8.Text = "Assign a Warehouse*";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.SteelBlue;
            this.label7.Location = new System.Drawing.Point(25, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(135, 20);
            this.label7.TabIndex = 154;
            this.label7.Text = "Receive Inventory";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProductStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 478);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(813, 22);
            this.statusStrip1.TabIndex = 175;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProductStatus
            // 
            this.toolStripProductStatus.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripProductStatus.Name = "toolStripProductStatus";
            this.toolStripProductStatus.Size = new System.Drawing.Size(66, 17);
            this.toolStripProductStatus.Text = "Products: 0";
            // 
            // textBoxSupplier
            // 
            this.textBoxSupplier.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxSupplier.Location = new System.Drawing.Point(524, 136);
            this.textBoxSupplier.Name = "textBoxSupplier";
            this.textBoxSupplier.Size = new System.Drawing.Size(256, 31);
            this.textBoxSupplier.TabIndex = 176;
            // 
            // buttonSearchSupplier
            // 
            this.buttonSearchSupplier.Image = ((System.Drawing.Image)(resources.GetObject("buttonSearchSupplier.Image")));
            this.buttonSearchSupplier.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSearchSupplier.Location = new System.Drawing.Point(663, 107);
            this.buttonSearchSupplier.Name = "buttonSearchSupplier";
            this.buttonSearchSupplier.Size = new System.Drawing.Size(119, 23);
            this.buttonSearchSupplier.TabIndex = 177;
            this.buttonSearchSupplier.Text = "Search a Supplier";
            this.buttonSearchSupplier.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonSearchSupplier.UseVisualStyleBackColor = true;
            this.buttonSearchSupplier.Click += new System.EventHandler(this.buttonSearchSupplier_Click);
            // 
            // AddInventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(813, 500);
            this.Controls.Add(this.buttonSearchSupplier);
            this.Controls.Add(this.textBoxSupplier);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.linkLabelRemoveAllData);
            this.Controls.Add(this.linkLabelDeleteSelectedItem);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.linkLabelClearFields);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.linkLabelClearList);
            this.Controls.Add(this.dataGridViewProductList);
            this.Controls.Add(this.buttonAddToList);
            this.Controls.Add(this.textBoxPurchaseOrderNumber);
            this.Controls.Add(this.label31);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.textBoxQuantityToAdd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonSearchProduct);
            this.Controls.Add(this.comboBoxWarehouse);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(829, 538);
            this.MinimumSize = new System.Drawing.Size(829, 538);
            this.Name = "AddInventory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.AddInventory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProductList)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel linkLabelRemoveAllData;
        private System.Windows.Forms.LinkLabel linkLabelDeleteSelectedItem;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.LinkLabel linkLabelClearFields;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.LinkLabel linkLabelClearList;
        private System.Windows.Forms.DataGridView dataGridViewProductList;
        private System.Windows.Forms.Button buttonAddToList;
        private System.Windows.Forms.TextBox textBoxPurchaseOrderNumber;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox textBoxQuantityToAdd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxSpecialFeature;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox textBoxModel;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox textBoxProductName;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxColor;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.TextBox textBoxSize;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxUnit;
        private System.Windows.Forms.TextBox textBoxBrand;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox textBoxSubCategory;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxCategory;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonSearchProduct;
        private System.Windows.Forms.ComboBox comboBoxWarehouse;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripProductStatus;
        private System.Windows.Forms.TextBox textBoxSupplier;
        private System.Windows.Forms.Button buttonSearchSupplier;
        private System.Windows.Forms.ToolTip toolTipError;
        private System.Windows.Forms.ToolTip toolTipSuccess;
    }
}