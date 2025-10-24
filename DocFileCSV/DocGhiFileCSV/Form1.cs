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
        public Form1()
        {
            InitializeComponent();
        }
       
        private void btnread_Click(object sender, EventArgs e)
        {
            string csvFilePath = "Credit card transactions - India - Simple.csv";
            List<string[]> csvData = ReadCSV.ReadCsvFile(csvFilePath);

            if (csvData.Count < 1)
            {
                MessageBox.Show("Khong có du lieu trong tep CSV.");
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
    }
}

    

