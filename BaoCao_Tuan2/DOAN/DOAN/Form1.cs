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
        public Form1()
        {
            InitializeComponent();
            myAvlSubtree = new AVLTree();
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
            string csvFilePath= "Credit card transactions - India - Simple.csv";
            List<string[]> csvData = ReadCSV.ReadCsvFile(csvFilePath);

            if (csvData.Count < 1)
            {
                MessageBox.Show("Không có dữ liệu trong file CSV.");
                return;
            }
            myAvlSubtree=new AVLTree();
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
            //int totalNodes = myAvlSubtree.CountTotalNodes();
            //int leafNodes=myAvlSubtree.CountLeafNodes();
            //int leftSubtreeNodes=myAvlSubtree.CountNodesInLeftSubtree();
            //int rightSubtreeNodes=myAvlSubtree.CountNodesInRightSubtree();

            //string report=$"Đã nạp thành công dữ liệu vào cây AVL.\n\n"+
            //    $"THỐNG KẾ CÂY\n"+
            //    $"Tổng số nút: {totalNodes}\n"+
            //    $"Số nút lá: {leafNodes}\n"+
            //    $"Số nút trên cây con trái: {leftSubtreeNodes}\n" +
            //    $"Số nút trên cây con phải: {rightSubtreeNodes}";
            //MessageBox.Show(report, "Đã hoàn tất nạp cây");

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

        
    }
}

    

