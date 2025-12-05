using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace DocGhiFileCSV
{
    public partial class Form1 : Form
    {
        private AVLTree myAvlSubtree;
        private Dictionary<int, string[]> masterDataLookup;
        private string[] masterHeaders;

        public Form1()
        {
            InitializeComponent();
            myAvlSubtree = new AVLTree();
       
            //this.treeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_AfterSelect);
           // this.btnVecay.Click += new System.EventHandler(this.btnVecay_Click);
           // this.btnShowStats.Click += new System.EventHandler(this.btnShowStats_Click);
           //// this.btnShowLevels.Click += new System.EventHandler(this.btnShowLevels_Click);
           // this.btnShowLevelK.Click += new System.EventHandler(this.btnShowLevelK_Click);
        }
       

        private void btnread_Click(object sender, EventArgs e)
        {
            string csvFilePath = "Credit card transactions - India - Simple.csv";
            List<string[]> csvData = ReadCSV.ReadCsvFile(csvFilePath);

            if (csvData.Count < 1)
            {
                MessageBox.Show("Không có dữ liệu trong file CSV.");
                return;
            }

            DataTable dataTable = new DataTable();

            string[] headers = csvData[0];

            foreach (string header in headers)
            {
                dataTable.Columns.Add(header);
            }

            for (int i = 1; i < csvData.Count; i++)
            {
                dataTable.Rows.Add(csvData[i]);
            }

            dataGridView2.DataSource = dataTable;
      
        }

        private void btnLoadAVL_Click(object sender, EventArgs e)
        {
            string csvFilePath = "Credit card transactions - India - Simple.csv";
            List<string[]> csvData = ReadCSV.ReadCsvFile(csvFilePath);

            if (csvData.Count < 1)
            {
                MessageBox.Show("Không có dữ liệu trong file CSV.");
                return;
            }
            myAvlSubtree = new AVLTree();
            string[] headers = csvData[0];
            for (int i = 1; i < csvData.Count; i++)
            {
                string[] row = csvData[i];
                int key;
                if (int.TryParse(row[0], out key))
                {
                    myAvlSubtree.Insert(key, row);
                }
            }
            MessageBox.Show("Đã nạp thành công dữ liệu vào cây AVL!");
            List<string[]> sortedData = myAvlSubtree.GetSortedData();
            DataTable dataTable = new DataTable();
            foreach (string header in headers)
            {
                dataTable.Columns.Add(header);
            }
            foreach (string[] row in sortedData)
            {
                dataTable.Rows.Add(row);
            }
            dataGridView2.DataSource = dataTable;
           
        }

        private void btnVecay_Click(object sender, EventArgs e)
        {
            string inputText = txtNumber.Text; 
            if (string.IsNullOrWhiteSpace(inputText))
            {
                MessageBox.Show("Vui lòng nhập 1 dãy số vào ô TextBox.");
                return;
            }

            Dictionary<int, string[]> tempDataLookup = new Dictionary<int, string[]>();
            string[] tempHeaders = null;
            try
            {
                List<string[]> csvData = ReadCSV.ReadCsvFile("Credit card transactions - India - Simple.csv");
                if (csvData.Count < 1) return;
                tempHeaders = csvData[0];

                for (int i = 1; i < csvData.Count; i++)
                {
                    string[] row = csvData[i];
                    int key;
                    if (int.TryParse(row[0], out key)) 
                    {
                        if (!tempDataLookup.ContainsKey(key))
                        {
                            tempDataLookup.Add(key, row);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi đọc file cho Demo: {ex.Message}");
                return;
            }
          
            string[] numbersAsStrings = inputText.Split(',');
            myAvlSubtree = new AVLTree(); 
           
            foreach (string s in numbersAsStrings)
            {
                int key;
                if (int.TryParse(s.Trim(), out key))
                {
                   
                    if (tempDataLookup.ContainsKey(key))
                    {
                        string[] realRowData = tempDataLookup[key];
                        myAvlSubtree.Insert(key, realRowData); 
                    }
                    else
                    {
                        MessageBox.Show($"Bỏ qua: Không tìm thấy index {key} trong file CSV.");
                    }
                }
            }

            myAvlSubtree.PopulateTreeView(this.treeView);
            this.treeView.ExpandAll();

            List<string[]> sortedData = myAvlSubtree.GetSortedData();
            DataTable dataTable = new DataTable();
            foreach (string header in tempHeaders) { dataTable.Columns.Add(header); }
            foreach (string[] row in sortedData) { dataTable.Rows.Add(row); }
            dataGridView2.DataSource = dataTable;

        }

        private void btnShowStats_Click(object sender, EventArgs e)
        {
            if (myAvlSubtree.CountTotalNodes() == 0)
            {
                MessageBox.Show("Cây đang rỗng.", "Chưa có dữ liệu");
                return;
            }
            int totalNodes = myAvlSubtree.CountTotalNodes();
            int leafNodes = myAvlSubtree.CountLeafNodes();
            int treeHeight = myAvlSubtree.GetTreeHeight();
            int leftSubtreeNodes = myAvlSubtree.CountNodesInLeftSubtree();
            int rightSubtreeNodes = myAvlSubtree.CountNodesInRightSubtree();

            string report = $" THỐNG KÊ CÂY AVL \n\n" +
                            $"Tổng số nút: {totalNodes}\n" +
                            $"Số nút lá: {leafNodes}\n" +
                            $"Chiều cao của cây: {treeHeight}\n" +
                            $"Số nút trên cây con trái: {leftSubtreeNodes}\n" +
                            $"Số nút trên cây con phải: {rightSubtreeNodes}";
            MessageBox.Show(report, "Báo cáo thống kê");
        }

        private void btnShowLevelK_Click(object sender, EventArgs e)
        {
            if (myAvlSubtree.CountTotalNodes() == 0)
            {
                MessageBox.Show("Cây đang rỗng.");
                return;
            }

            int k;
            if (!int.TryParse(txtLevelK.Text, out k))
            {
                MessageBox.Show("Vui lòng nhập một số vào ô 'Tầng K'.");
                return;
            }

            List<List<int>> allLevels = myAvlSubtree.GetNodesByLevel();

            if (k < 0 || k >= allLevels.Count)
            {
                int maxLevel = allLevels.Count - 1;
                MessageBox.Show($"Tầng {k} không tồn tại (Max: {maxLevel}).");
                return;
            }

            List<int> keysAtLevelK = allLevels[k];
            string nodesOnThisLevel = string.Join(", ", keysAtLevelK);
            MessageBox.Show($"Các nút ở Tầng {k} là:\n\n{nodesOnThisLevel}");

            Dictionary<int, string[]> tempLookup = new Dictionary<int, string[]>();
            string[] headers = null;

            try
            {
                string csvFilePath = "Credit card transactions - India - Simple.csv";
                List<string[]> csvData = ReadCSV.ReadCsvFile(csvFilePath);

                if (csvData.Count > 0)
                {
                    headers = csvData[0]; 
                    for (int i = 1; i < csvData.Count; i++)
                    {
                        string[] row = csvData[i];
                        int key;
                        
                        if (int.TryParse(row[0], out key))
                        {
                            if (!tempLookup.ContainsKey(key))
                            {
                                tempLookup.Add(key, row);
                            }
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Không đọc được dữ liệu chi tiết từ file.");
                return;
            }

            DataTable dtLevelK = new DataTable();

            if (headers != null)
            {
                foreach (string h in headers)
                {
                    dtLevelK.Columns.Add(h);
                }
            }

            foreach (int key in keysAtLevelK)
            {
                if (tempLookup.ContainsKey(key))
                {
                    dtLevelK.Rows.Add(tempLookup[key]);
                }
            }
            dataGridView2.DataSource = dtLevelK;
        }

        private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node == null) return;
            string keyString = e.Node.Text;

            int keyToFind;
            if (!int.TryParse(keyString, out keyToFind)) return;

            string[] foundData = myAvlSubtree.Find(keyToFind);

            if (foundData != null)
            {
             
                List<string> headers = new List<string>();
                foreach (DataGridViewColumn col in dataGridView2.Columns)
                {
                    headers.Add(col.HeaderText);
                }

                dataGridView2.DataSource = null;
                dataGridView2.Rows.Clear();
                dataGridView2.Columns.Clear();

                foreach (string h in headers)
                {
                    dataGridView2.Columns.Add(h, h);
                }

                dataGridView2.Rows.Add(foundData);
            }
        }
    }
}

    

