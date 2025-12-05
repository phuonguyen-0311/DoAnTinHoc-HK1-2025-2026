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
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.btnLoadAVL = new System.Windows.Forms.Button();
            this.treeView = new System.Windows.Forms.TreeView();
            this.txtNumber = new System.Windows.Forms.TextBox();
            this.btnVecay = new System.Windows.Forms.Button();
            this.btnShowLevelK = new System.Windows.Forms.Button();
            this.txtLevelK = new System.Windows.Forms.TextBox();
            this.btnShowStats = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // btnread
            // 
            this.btnread.Font = new System.Drawing.Font("Times New Roman", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnread.Location = new System.Drawing.Point(12, 12);
            this.btnread.Name = "btnread";
            this.btnread.Size = new System.Drawing.Size(150, 36);
            this.btnread.TabIndex = 0;
            this.btnread.Text = "Đọc File";
            this.btnread.UseVisualStyleBackColor = true;
            this.btnread.Click += new System.EventHandler(this.btnread_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(12, 150);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 82;
            this.dataGridView2.RowTemplate.Height = 33;
            this.dataGridView2.Size = new System.Drawing.Size(757, 371);
            this.dataGridView2.TabIndex = 1;
            // 
            // btnLoadAVL
            // 
            this.btnLoadAVL.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadAVL.Location = new System.Drawing.Point(205, 12);
            this.btnLoadAVL.Name = "btnLoadAVL";
            this.btnLoadAVL.Size = new System.Drawing.Size(237, 36);
            this.btnLoadAVL.TabIndex = 2;
            this.btnLoadAVL.Text = "Đọc File vào cây AVL";
            this.btnLoadAVL.UseVisualStyleBackColor = true;
            this.btnLoadAVL.Click += new System.EventHandler(this.btnLoadAVL_Click);
            // 
            // treeView
            // 
            this.treeView.Location = new System.Drawing.Point(786, 150);
            this.treeView.Name = "treeView";
            this.treeView.Size = new System.Drawing.Size(383, 371);
            this.treeView.TabIndex = 3;
            this.treeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_AfterSelect);
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
            this.btnShowLevelK.Location = new System.Drawing.Point(565, 78);
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
            this.txtLevelK.Location = new System.Drawing.Point(730, 78);
            this.txtLevelK.Name = "txtLevelK";
            this.txtLevelK.Size = new System.Drawing.Size(123, 34);
            this.txtLevelK.TabIndex = 7;
            // 
            // btnShowStats
            // 
            this.btnShowStats.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowStats.Location = new System.Drawing.Point(497, 12);
            this.btnShowStats.Name = "btnShowStats";
            this.btnShowStats.Size = new System.Drawing.Size(189, 36);
            this.btnShowStats.TabIndex = 8;
            this.btnShowStats.Text = "Thống kê cây";
            this.btnShowStats.UseVisualStyleBackColor = true;
            this.btnShowStats.Click += new System.EventHandler(this.btnShowStats_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(1181, 533);
            this.Controls.Add(this.btnShowStats);
            this.Controls.Add(this.txtLevelK);
            this.Controls.Add(this.btnShowLevelK);
            this.Controls.Add(this.btnVecay);
            this.Controls.Add(this.txtNumber);
            this.Controls.Add(this.treeView);
            this.Controls.Add(this.btnLoadAVL);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.btnread);
            this.Name = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnread;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button btnLoadAVL;
        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.TextBox txtNumber;
        private System.Windows.Forms.Button btnVecay;
        private System.Windows.Forms.Button btnShowLevelK;
        private System.Windows.Forms.TextBox txtLevelK;
        private System.Windows.Forms.Button btnShowStats;
    }
}

