namespace DocGhiFileCSV
{
    partial class Form1
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
            this.btnread = new System.Windows.Forms.Button();
            this.dgvMain = new System.Windows.Forms.DataGridView();
            this.btnLoadAVL = new System.Windows.Forms.Button();
            this.txtNumber = new System.Windows.Forms.TextBox();
            this.btnVecay = new System.Windows.Forms.Button();
            this.btnShowLevelK = new System.Windows.Forms.Button();
            this.txtLevelK = new System.Windows.Forms.TextBox();
            this.txtDuplicateSearch = new System.Windows.Forms.TextBox();
            this.cbDuplicateOptions = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboGender = new System.Windows.Forms.ComboBox();
            this.cboExpType = new System.Windows.Forms.ComboBox();
            this.cboCardType = new System.Windows.Forms.ComboBox();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.txtIndex = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnExecuteAlgo = new System.Windows.Forms.Button();
            this.cbAlgorithms = new System.Windows.Forms.ComboBox();
            this.dgvDuplicates = new System.Windows.Forms.DataGridView();
            this.btnCreatePureTree = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDuplicates)).BeginInit();
            this.SuspendLayout();
            // 
            // btnread
            // 
            this.btnread.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnread.Location = new System.Drawing.Point(12, 12);
            this.btnread.Name = "btnread";
            this.btnread.Size = new System.Drawing.Size(121, 36);
            this.btnread.TabIndex = 0;
            this.btnread.Text = "Đọc File";
            this.btnread.UseVisualStyleBackColor = true;
            this.btnread.Click += new System.EventHandler(this.btnread_Click);
            // 
            // dgvMain
            // 
            this.dgvMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMain.Location = new System.Drawing.Point(549, 78);
            this.dgvMain.Name = "dgvMain";
            this.dgvMain.RowHeadersWidth = 82;
            this.dgvMain.RowTemplate.Height = 33;
            this.dgvMain.Size = new System.Drawing.Size(727, 270);
            this.dgvMain.TabIndex = 1;
            this.dgvMain.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMain_CellClick);
            this.dgvMain.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMain_CellContentClick);
            // 
            // btnLoadAVL
            // 
            this.btnLoadAVL.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadAVL.Location = new System.Drawing.Point(159, 12);
            this.btnLoadAVL.Name = "btnLoadAVL";
            this.btnLoadAVL.Size = new System.Drawing.Size(237, 36);
            this.btnLoadAVL.TabIndex = 2;
            this.btnLoadAVL.Text = "Đọc File vào cây AVL";
            this.btnLoadAVL.UseVisualStyleBackColor = true;
            this.btnLoadAVL.Click += new System.EventHandler(this.btnLoadAVL_Click);
            // 
            // txtNumber
            // 
            this.txtNumber.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumber.Location = new System.Drawing.Point(168, 78);
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Size = new System.Drawing.Size(347, 34);
            this.txtNumber.TabIndex = 4;
            // 
            // btnVecay
            // 
            this.btnVecay.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVecay.Location = new System.Drawing.Point(14, 78);
            this.btnVecay.Name = "btnVecay";
            this.btnVecay.Size = new System.Drawing.Size(128, 36);
            this.btnVecay.TabIndex = 5;
            this.btnVecay.Text = "Vẽ cây";
            this.btnVecay.UseVisualStyleBackColor = true;
            this.btnVecay.Click += new System.EventHandler(this.btnVecay_Click);
            // 
            // btnShowLevelK
            // 
            this.btnShowLevelK.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowLevelK.Location = new System.Drawing.Point(894, 17);
            this.btnShowLevelK.Name = "btnShowLevelK";
            this.btnShowLevelK.Size = new System.Drawing.Size(150, 36);
            this.btnShowLevelK.TabIndex = 6;
            this.btnShowLevelK.Text = "Xuất tầng K";
            this.btnShowLevelK.UseVisualStyleBackColor = true;
            this.btnShowLevelK.Click += new System.EventHandler(this.btnShowLevelK_Click);
            // 
            // txtLevelK
            // 
            this.txtLevelK.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLevelK.Location = new System.Drawing.Point(1066, 19);
            this.txtLevelK.Name = "txtLevelK";
            this.txtLevelK.Size = new System.Drawing.Size(123, 34);
            this.txtLevelK.TabIndex = 7;
            // 
            // txtDuplicateSearch
            // 
            this.txtDuplicateSearch.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDuplicateSearch.Location = new System.Drawing.Point(236, 201);
            this.txtDuplicateSearch.Name = "txtDuplicateSearch";
            this.txtDuplicateSearch.Size = new System.Drawing.Size(109, 34);
            this.txtDuplicateSearch.TabIndex = 10;
            // 
            // cbDuplicateOptions
            // 
            this.cbDuplicateOptions.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDuplicateOptions.FormattingEnabled = true;
            this.cbDuplicateOptions.Items.AddRange(new object[] {
            "Tìm giá trị trùng",
            "Tìm số trùng nhiều nhất",
            "Tìm số trùng ít nhất",
            "Liệt kê tất cả giá trị trùng"});
            this.cbDuplicateOptions.Location = new System.Drawing.Point(236, 143);
            this.cbDuplicateOptions.Name = "cbDuplicateOptions";
            this.cbDuplicateOptions.Size = new System.Drawing.Size(221, 33);
            this.cbDuplicateOptions.TabIndex = 11;
            this.cbDuplicateOptions.SelectedIndexChanged += new System.EventHandler(this.cbDuplicateOptions_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 204);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(212, 25);
            this.label1.TabIndex = 12;
            this.label1.Text = "Nhập giá trị cần tìm";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboGender);
            this.groupBox1.Controls.Add(this.cboExpType);
            this.groupBox1.Controls.Add(this.cboCardType);
            this.groupBox1.Controls.Add(this.dtpDate);
            this.groupBox1.Controls.Add(this.txtAmount);
            this.groupBox1.Controls.Add(this.txtCity);
            this.groupBox1.Controls.Add(this.txtIndex);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(14, 265);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(386, 309);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin giao dịch";
            // 
            // cboGender
            // 
            this.cboGender.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboGender.FormattingEnabled = true;
            this.cboGender.Items.AddRange(new object[] {
            "F",
            "M"});
            this.cboGender.Location = new System.Drawing.Point(114, 227);
            this.cboGender.Name = "cboGender";
            this.cboGender.Size = new System.Drawing.Size(193, 28);
            this.cboGender.TabIndex = 24;
            // 
            // cboExpType
            // 
            this.cboExpType.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboExpType.FormattingEnabled = true;
            this.cboExpType.Items.AddRange(new object[] {
            "Bills",
            "Food",
            "Entertainment",
            "Grocery",
            "Fuel"});
            this.cboExpType.Location = new System.Drawing.Point(114, 193);
            this.cboExpType.Name = "cboExpType";
            this.cboExpType.Size = new System.Drawing.Size(193, 28);
            this.cboExpType.TabIndex = 23;
            // 
            // cboCardType
            // 
            this.cboCardType.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCardType.FormattingEnabled = true;
            this.cboCardType.Items.AddRange(new object[] {
            "Gold",
            "Silver",
            "Platinum",
            "Signature"});
            this.cboCardType.Location = new System.Drawing.Point(114, 155);
            this.cboCardType.Name = "cboCardType";
            this.cboCardType.Size = new System.Drawing.Size(193, 28);
            this.cboCardType.TabIndex = 14;
            // 
            // dtpDate
            // 
            this.dtpDate.CalendarFont = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDate.Location = new System.Drawing.Point(114, 113);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(255, 30);
            this.dtpDate.TabIndex = 14;
            // 
            // txtAmount
            // 
            this.txtAmount.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmount.Location = new System.Drawing.Point(114, 261);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(131, 28);
            this.txtAmount.TabIndex = 22;
            // 
            // txtCity
            // 
            this.txtCity.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCity.Location = new System.Drawing.Point(114, 79);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(255, 28);
            this.txtCity.TabIndex = 21;
            // 
            // txtIndex
            // 
            this.txtIndex.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIndex.Location = new System.Drawing.Point(114, 37);
            this.txtIndex.Name = "txtIndex";
            this.txtIndex.Size = new System.Drawing.Size(109, 28);
            this.txtIndex.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(5, 229);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 22);
            this.label8.TabIndex = 20;
            this.label8.Text = "Gender";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(5, 263);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 22);
            this.label7.TabIndex = 19;
            this.label7.Text = "Amount";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(5, 195);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 22);
            this.label6.TabIndex = 18;
            this.label6.Text = "Exp Type";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(5, 159);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 22);
            this.label5.TabIndex = 17;
            this.label5.Text = "Card Type";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 121);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 22);
            this.label4.TabIndex = 16;
            this.label4.Text = "Date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(5, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 22);
            this.label3.TabIndex = 15;
            this.label3.Text = "City";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(5, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 22);
            this.label2.TabIndex = 14;
            this.label2.Text = "Index";
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(5, 589);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(101, 36);
            this.btnAdd.TabIndex = 14;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Location = new System.Drawing.Point(263, 589);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(101, 36);
            this.btnEdit.TabIndex = 15;
            this.btnEdit.Text = "Sửa";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(128, 589);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(101, 36);
            this.btnDelete.TabIndex = 16;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnExecuteAlgo
            // 
            this.btnExecuteAlgo.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExecuteAlgo.Location = new System.Drawing.Point(482, 12);
            this.btnExecuteAlgo.Name = "btnExecuteAlgo";
            this.btnExecuteAlgo.Size = new System.Drawing.Size(132, 36);
            this.btnExecuteAlgo.TabIndex = 17;
            this.btnExecuteAlgo.Text = "Thực hiện";
            this.btnExecuteAlgo.UseVisualStyleBackColor = true;
            this.btnExecuteAlgo.Click += new System.EventHandler(this.btnExecuteAlgo_Click);
            // 
            // cbAlgorithms
            // 
            this.cbAlgorithms.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbAlgorithms.FormattingEnabled = true;
            this.cbAlgorithms.Items.AddRange(new object[] {
            "Đếm tổng số nút",
            "Đếm số nút lá",
            "Đếm số nút cây con bên trái",
            "Đếm số nút cây con bên phải",
            "Đếm nút có 1 con",
            "Đếm nút có 2 con",
            "Chiều cao cây",
            "Tính tổng tiền (Amount)"});
            this.cbAlgorithms.Location = new System.Drawing.Point(629, 17);
            this.cbAlgorithms.Name = "cbAlgorithms";
            this.cbAlgorithms.Size = new System.Drawing.Size(193, 28);
            this.cbAlgorithms.TabIndex = 25;
            this.cbAlgorithms.SelectedIndexChanged += new System.EventHandler(this.cbAlgorithms_SelectedIndexChanged);
            // 
            // dgvDuplicates
            // 
            this.dgvDuplicates.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDuplicates.Location = new System.Drawing.Point(549, 386);
            this.dgvDuplicates.Name = "dgvDuplicates";
            this.dgvDuplicates.RowHeadersWidth = 82;
            this.dgvDuplicates.RowTemplate.Height = 33;
            this.dgvDuplicates.Size = new System.Drawing.Size(727, 285);
            this.dgvDuplicates.TabIndex = 26;
            this.dgvDuplicates.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDuplicates_CellClick);
            this.dgvDuplicates.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDuplicates_CellContentClick);
            // 
            // btnCreatePureTree
            // 
            this.btnCreatePureTree.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreatePureTree.Location = new System.Drawing.Point(12, 140);
            this.btnCreatePureTree.Name = "btnCreatePureTree";
            this.btnCreatePureTree.Size = new System.Drawing.Size(205, 36);
            this.btnCreatePureTree.TabIndex = 27;
            this.btnCreatePureTree.Text = "Tạo cây tinh khiết";
            this.btnCreatePureTree.UseVisualStyleBackColor = true;
            this.btnCreatePureTree.Click += new System.EventHandler(this.btnCreatePureTree_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(405, 589);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(110, 36);
            this.btnSave.TabIndex = 28;
            this.btnSave.Text = "Lưu File";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(1309, 686);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCreatePureTree);
            this.Controls.Add(this.dgvDuplicates);
            this.Controls.Add(this.cbAlgorithms);
            this.Controls.Add(this.btnExecuteAlgo);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbDuplicateOptions);
            this.Controls.Add(this.txtDuplicateSearch);
            this.Controls.Add(this.txtLevelK);
            this.Controls.Add(this.btnShowLevelK);
            this.Controls.Add(this.btnVecay);
            this.Controls.Add(this.txtNumber);
            this.Controls.Add(this.btnLoadAVL);
            this.Controls.Add(this.dgvMain);
            this.Controls.Add(this.btnread);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDuplicates)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnread;
        private System.Windows.Forms.DataGridView dgvMain;
        private System.Windows.Forms.Button btnLoadAVL;
        private System.Windows.Forms.TextBox txtNumber;
        private System.Windows.Forms.Button btnVecay;
        private System.Windows.Forms.Button btnShowLevelK;
        private System.Windows.Forms.TextBox txtLevelK;
        private System.Windows.Forms.TextBox txtDuplicateSearch;
        private System.Windows.Forms.ComboBox cbDuplicateOptions;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboCardType;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.TextBox txtIndex;
        private System.Windows.Forms.ComboBox cboGender;
        private System.Windows.Forms.ComboBox cboExpType;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnExecuteAlgo;
        private System.Windows.Forms.ComboBox cbAlgorithms;
        private System.Windows.Forms.DataGridView dgvDuplicates;
        private System.Windows.Forms.Button btnCreatePureTree;
        private System.Windows.Forms.Button btnSave;
    }
}

