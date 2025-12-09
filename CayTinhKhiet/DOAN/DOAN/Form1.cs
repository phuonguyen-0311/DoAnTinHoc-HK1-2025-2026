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
        private AVLTree myTree;
        private Dictionary<int, List<string[]>> duplicateData;
        private string[] headers = { "Index", "City", "Date", "Card Type", "Exp Type", "Gender", "Amount" };
        public Form1()
        {
            InitializeComponent();
            myTree = new AVLTree();
            duplicateData = new Dictionary<int, List<string[]>>();
          
        }

       
        private void AddRecordToSystem(string[] rowData, bool showMessage)
        {
            if (rowData.Length < 7) 
                return;
            string amountRaw = rowData[6].Replace(",", "").Replace(".", "").Trim();
            long keyLong;
            if (!long.TryParse(amountRaw, out keyLong)) 
                return;
            int key = (int)keyLong;
            if (myTree.Find(key) != null)
            {
                if (!duplicateData.ContainsKey(key))
                    duplicateData[key] = new List<string[]>();
                duplicateData[key].Add(rowData);
                if (showMessage)
                {
                    MessageBox.Show($"Giá trị {key} đã tồn tại! Dữ liệu được thêm vào bảng danh sách liên kết.",
                                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ShowSpecificDuplicates(key);
                }
            }
            else
            {
                myTree.Insert(key, rowData);
                duplicateData[key] = new List<string[]>();
                duplicateData[key].Add(rowData);
                if (showMessage)
                {
                    MessageBox.Show("Thêm thành công vào cây chính!");
                    dgvDuplicates.DataSource = null;
                }
            }
        }
        private void ShowSpecificDuplicates(int key)
        {
            DataTable dtDup = new DataTable();
            foreach (var h in headers) dtDup.Columns.Add(h);
            if (duplicateData.ContainsKey(key))
            {
                foreach (var row in duplicateData[key])
                {
                    dtDup.Rows.Add(row);
                }
            }
            else
            {
            }
            dgvDuplicates.DataSource = dtDup;
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
            MessageBox.Show("Đã đọc thành công file CSV!");
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
            dgvMain.DataSource = dataTable;      
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
            myTree = new AVLTree();
            string[] headers = csvData[0];
            for (int i = 1; i < csvData.Count; i++)
            {
                string[] row = csvData[i];
                int key;
                if (int.TryParse(row[0], out key))
                {
                    myTree.Insert(key, row);
                }
            }
            MessageBox.Show("Đã nạp thành công dữ liệu vào cây AVL!");
            List<string[]> sortedData = myTree.GetSortedData();
            DataTable dataTable = new DataTable();
            foreach (string header in headers)
            {
                dataTable.Columns.Add(header);
            }
            foreach (string[] row in sortedData)
            {
                dataTable.Rows.Add(row);
            }
            dgvMain.DataSource = dataTable;          
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
            myTree = new AVLTree();            
            foreach (string s in numbersAsStrings)
            {
                int key;
                if (int.TryParse(s.Trim(), out key))
                {
                   
                    if (tempDataLookup.ContainsKey(key))
                    {
                        string[] realRowData = tempDataLookup[key];
                        myTree.Insert(key, realRowData); 
                    }
                    else
                    {
                        MessageBox.Show($"Bỏ qua: Không tìm thấy index {key} trong file CSV.");
                    }
                }
            }

            //myTree.PopulateTreeView(this.treeView);
           // this.treeView.ExpandAll();

            List<string[]> sortedData = myTree.GetSortedData();
            DataTable dataTable = new DataTable();
            foreach (string header in tempHeaders) { dataTable.Columns.Add(header); }
            foreach (string[] row in sortedData) { dataTable.Rows.Add(row); }
            dgvMain.DataSource = dataTable;

        }


        private void btnShowLevelK_Click(object sender, EventArgs e)
        {
            if (myTree.CountTotalNodes() == 0)
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
            List<List<int>> allLevels = myTree.GetNodesByLevel();
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
            dgvMain.DataSource = dtLevelK;
        }

        private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            int id;
            if (int.TryParse(e.Node.Text, out id))
            {
                var data = myTree.Find(id);
                if (data != null && data.Length >= 7)
                {
                    txtIndex.Text = data[0];
                    txtCity.Text = data[1];
                    DateTime d;
                    if (DateTime.TryParse(data[2], out d)) 
                        dtpDate.Value = d;
                    cboCardType.Text = data[3];
                    cboExpType.Text = data[4];
                    cboGender.Text = data[5];
                    txtAmount.Text = data[6];
                }
            }
        }
        private void cbDuplicateOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (duplicateData == null || duplicateData.Count == 0)
            //{
            //    MessageBox.Show("Chưa có dữ liệu trùng. Hãy nhấn 'Tạo Cây Tinh Khiết' trước.");
            //    return;
            //}

            string option = cbDuplicateOptions.SelectedItem.ToString();

            if (option == "Tìm giá trị trùng")
            {
                XuLy_TimGiaTriTrung();
            }
            else if (option == "Tìm số trùng nhiều nhất")
            {
                XuLy_TimSoTrungNhieuNhat();
            }
            else if (option == "Tìm số trùng ít nhất")
            {
                XuLy_TimSoTrungItNhat();
            }
            else if (option == "Liệt kê tất cả giá trị trùng")
            {
                XuLy_LietKeTatCa();
            }
        }
        private void XuLy_TimGiaTriTrung()
        {
            int val;
            if (!int.TryParse(txtDuplicateSearch.Text, out val))
            {
                MessageBox.Show("Vui lòng nhập một số Amount hợp lệ vào ô tìm kiếm.");
                return;
            }

            if (duplicateData.ContainsKey(val))
            {
                ShowRowsOnGrid(duplicateData[val]);
                MessageBox.Show($"Tìm thấy {duplicateData[val].Count} bản ghi trùng với giá trị {val}.");
            }
            else
            {
                MessageBox.Show($"Không có bản ghi nào trùng với giá trị {val} (hoặc nó chỉ xuất hiện 1 lần trong cây).");
            }
        }

        private void XuLy_TimSoTrungNhieuNhat()
        {
            if (duplicateData.Count == 0)
            {
                MessageBox.Show("Chưa có dữ liệu. Vui lòng nạp cây trước.");
                return;
            }
            int maxCount = 0;
            foreach (var list in duplicateData.Values)
            {
                if (list.Count > maxCount) maxCount = list.Count;
            }
            List<string[]> allMaxRows = new List<string[]>();
            string msg = $"Các giá trị trùng nhiều nhất ({maxCount} lần):\n";

            foreach (var kvp in duplicateData)
            {
                if (kvp.Value.Count == maxCount)
                {
                    msg += $"- Số tiền: {kvp.Key}\n";
                    allMaxRows.AddRange(kvp.Value);
                }
            }
            MessageBox.Show(msg);
            ShowRowsOnGrid(allMaxRows);
        }

        private void XuLy_TimSoTrungItNhat()
        {
            if (duplicateData.Count == 0) 
                return;
            int minCount = duplicateData.Values.Min(list => list.Count);
            var result = duplicateData.Where(x => x.Value.Count == minCount).ToList();
            string msg = $"Có {result.Count} giá trị trùng ít nhất ({minCount} lần):\n";
            List<string[]> allMinRows = new List<string[]>();
            int countDisplay = 0;
            foreach (var item in result)
            {
                 msg += $"{item.Key}, ";                
                allMinRows.AddRange(item.Value);
                countDisplay++;
            }
            //if (countDisplay >= 10) 
            //    msg += "...";
            MessageBox.Show(msg, "Kết quả trùng ít nhất");
            ShowRowsOnGrid(allMinRows);
        }
        private void XuLy_LietKeTatCa()
        {
            List<string[]> allDuplicates = new List<string[]>();
            foreach (var list in duplicateData.Values)
            {
                allDuplicates.AddRange(list);
            }

            ShowRowsOnGrid(allDuplicates);
            MessageBox.Show($"Tổng cộng có {allDuplicates.Count} dòng dữ liệu bị trùng lặp (không nằm trong cây).");
        }

        private void ShowRowsOnGrid(List<string[]> rows)
        {
            DataTable dt = new DataTable();
            foreach (string h in headers) 
                dt.Columns.Add(h);

            foreach (string[] row in rows)
            {
                DataRow dRow = dt.NewRow();
                for (int i = 0; i < Math.Min(row.Length, 7); i++) 
                    dRow[i] = row[i];
                dt.Rows.Add(dRow);
            }
            dgvMain.DataSource = dt;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int id;
            if (!int.TryParse(txtIndex.Text, out id))
            {
                MessageBox.Show("Index phải là số"); 
                return;
            }
            long amt;
            if (!long.TryParse(txtAmount.Text, out amt))
            {
                MessageBox.Show("Amount phải là số"); 
                return;
            }
            string[] rowData = new string[7];
            rowData[0] = txtIndex.Text;
            rowData[1] = txtCity.Text;
            rowData[2] = dtpDate.Value.ToString("dd-MMM-yy"); 
            rowData[3] = cboCardType.Text;
            rowData[4] = cboExpType.Text;
            rowData[5] = cboGender.Text;
            rowData[6] = txtAmount.Text;
            AddRecordToSystem(rowData, true);
            RefreshUI();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int id;
            if (!int.TryParse(txtIndex.Text, out id)) 
                return;
            int oldKey = -1;
            string[] oldRow = null;
            foreach (var kvp in duplicateData)
            {
                foreach (var row in kvp.Value)
                {
                    if (row[0] == id.ToString())
                    {
                        oldKey = kvp.Key;
                        oldRow = row;
                        break;
                    }
                }
                if (oldRow != null) 
                    break;
            }

            if (oldRow == null)
            {
                MessageBox.Show("Không tìm thấy dòng này để sửa!"); 
                return;
            }
            string newAmountStr = txtAmount.Text.Replace(",", "").Trim();
            long newAmountLong;
            long.TryParse(newAmountStr, out newAmountLong);
            int newKey = (int)newAmountLong;
            string[] newRowData = { txtIndex.Text, txtCity.Text, dtpDate.Value.ToString("dd-MMM-yy"),
                                    cboCardType.Text, cboExpType.Text, cboGender.Text, txtAmount.Text};

            if (oldKey == newKey)
            {
                List<string[]> list = duplicateData[oldKey];
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i][0] == id.ToString())
                    {
                        list[i] = newRowData;
                        break;
                    }
                }
                myTree.Update(oldKey, list[0]); 
                ShowSpecificDuplicates(oldKey);
            }
            else
            {
                duplicateData[oldKey].Remove(oldRow);
                if (duplicateData[oldKey].Count == 0)
                {
                    duplicateData.Remove(oldKey);
                    myTree.Delete(oldKey);
                }
                else 
                    myTree.Update(oldKey, duplicateData[oldKey][0]);
                AddRecordToSystem(newRowData, false);
                ShowSpecificDuplicates(newKey);
            }
            RefreshUI();
            MessageBox.Show("Cập nhật thành công.");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id;
            if (!int.TryParse(txtIndex.Text, out id))
            {
                MessageBox.Show("Vui lòng nhập Index chính xác của dòng cần xóa"); 
                return;
            }
            string amountRaw = txtAmount.Text.Replace(",", "").Replace(".", "").Trim();
            long amountLong;
            if (!long.TryParse(amountRaw, out amountLong))
            {
                MessageBox.Show("Vui lòng nhập Amount để tìm nhóm dữ liệu"); 
                return;
            }
            int key = (int)amountLong; 
            if (!duplicateData.ContainsKey(key))
            {
                MessageBox.Show("Không tìm thấy nhóm số tiền này"); 
                return;
            }
            List<string[]> listRows = duplicateData[key];
            string[] rowToDelete = null;
            foreach (var row in listRows)
            {
                if (row[0] == id.ToString())
                {
                    rowToDelete = row;
                    break;
                }
            }

            if (rowToDelete != null)
            {
                listRows.Remove(rowToDelete);
                MessageBox.Show($"Đã xóa dòng có Index {id} trong nhóm Amount {key}.");
                if (listRows.Count == 0)
                {
                    duplicateData.Remove(key);
                    myTree.Delete(key);
                }
                else
                {
                    myTree.Update(key, listRows[0]);
                }
                RefreshUI(); 
                ShowSpecificDuplicates(key); 
                MessageBox.Show($"Đã xóa dòng Index {id}.");
            }
            else
            {
                MessageBox.Show($"Không tìm thấy Index {id} trong nhóm Amount {key}.\n(Có thể bạn nhập sai Amount?)");
            }
        }

        private void btnExecuteAlgo_Click(object sender, EventArgs e)
        {
            if (myTree.CountTotalNodes() == 0)
            {
                MessageBox.Show("Cây đang rỗng. Vui lòng nạp dữ liệu!");
                return;
            }
            string opt = cbAlgorithms.SelectedItem?.ToString();
            string msg = "";
            switch (opt)
            {
                case "Đếm tổng số nút":
                    msg = $"Tổng số nút: {myTree.CountTotalNodes()}";
                    break;
                case "Đếm số nút lá":
                    msg = $"Số nút lá: {myTree.CountLeafNodes()}";
                    break;
                case "Đếm số nút cây con bên trái":
                    msg = $"Số nút bên trái (của gốc): {myTree.CountNodesInLeftSubtree()}";
                    break;
                case "Đếm số nút cây con bên phải":
                    msg = $"Số nút bên phải (của gốc): {myTree.CountNodesInRightSubtree()}";
                    break;
                case "Đếm nút có 1 con":
                    msg = $"Số nút 1 con: {myTree.CountNodesWithOneChild()}";
                    break;
                case "Đếm nút có 2 con":
                    msg = $"Số nút 2 con: {myTree.CountNodesWithTwoChildren()}";
                    break;
                case "Chiều cao cây":
                    msg = $"Chiều cao: {myTree.GetTreeHeight()}";
                    break;
                case "Tính tổng tiền (Amount)":
                    msg = $"Tổng tiền: {myTree.SumAmount()}";
                    break;
                default:
                    msg = "Vui lòng chọn thuật toán.";
                    break;
            }
            MessageBox.Show(msg);
        }
        private void RefreshUI()
        {
            // myTree.PopulateTreeView(treeView);

            DataTable dtMain = new DataTable();
            foreach (var h in headers) 
                dtMain.Columns.Add(h);
            foreach (var row in myTree.GetSortedData())
            {
                dtMain.Rows.Add(row);
            }
            dgvMain.DataSource = dtMain;
        }

        private void cbAlgorithms_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnCreatePureTree_Click(object sender, EventArgs e)
        {
            myTree = new AVLTree();
            duplicateData = new Dictionary<int, List<string[]>>();
            int amountColumnIndex = 6;

            try
            {
                List<string[]> csvData = ReadCSV.ReadCsvFile("Credit card transactions - India - Simple.csv");
                if (csvData.Count < 2) 
                    return;
                for (int i = 1; i < csvData.Count; i++)
                {
                    string[] row = csvData[i];
                    long keyLong;
                    if (row.Length > amountColumnIndex &&
                        long.TryParse(row[amountColumnIndex].Replace(",", "").Trim(), out keyLong))
                    {
                        int key = (int)keyLong;
                        if (myTree.Find(key) == null)
                        {
                            myTree.Insert(key, row);
                            duplicateData[key] = new List<string[]>();
                            duplicateData[key].Add(row);
                        }
                        else
                        {
                            if (!duplicateData.ContainsKey(key))
                                duplicateData[key] = new List<string[]>();
                            duplicateData[key].Add(row);
                        }
                    }
                }
                int totalRows = csvData.Count - 1;
                int uniqueNodes = myTree.CountTotalNodes(); 
                int duplicateRows = totalRows - uniqueNodes; 

                string report = $"1. Tổng số dòng đã đọc: {totalRows:N0}\n" + 
                                $"2. Số nút trên cây (Giá trị duy nhất): {uniqueNodes:N0}\n" +
                                $"3. Số lượng dòng bị trùng lặp: {duplicateRows:N0}\n\n";

                MessageBox.Show(report);

                RefreshUI();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void dgvMain_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void dgvMain_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) 
            {
                DataGridViewRow row = dgvMain.Rows[e.RowIndex];            
                txtIndex.Text = row.Cells[0].Value?.ToString();
                txtCity.Text = row.Cells[1].Value?.ToString();             
                cboCardType.Text = row.Cells[3].Value?.ToString();
                cboExpType.Text = row.Cells[4].Value?.ToString();
                cboGender.Text = row.Cells[5].Value?.ToString();
                txtAmount.Text = row.Cells[6].Value?.ToString();
            }
        }

        private void dgvDuplicates_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvDuplicates_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvDuplicates.Rows.Count)
            {
                DataGridViewRow row = dgvDuplicates.Rows[e.RowIndex];
                if (row.Cells[0].Value == null) 
                    return;
                txtIndex.Text = row.Cells[0].Value.ToString();
                txtCity.Text = row.Cells[1].Value.ToString();
                string dateStr = row.Cells[2].Value.ToString();
                DateTime d;
                if (DateTime.TryParse(dateStr, out d)) 
                    dtpDate.Value = d;

                cboCardType.Text = row.Cells[3].Value.ToString();
                cboExpType.Text = row.Cells[4].Value.ToString();
                cboGender.Text = row.Cells[5].Value.ToString();
                txtAmount.Text = row.Cells[6].Value.ToString();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (duplicateData.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để lưu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "CSV Files (*.csv)|*.csv|All Files (*.*)|*.*";
            sfd.FileName = "File sau khi Updated.csv";
            sfd.Title = "Lưu dữ liệu giao dịch";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter(sfd.FileName, false, Encoding.UTF8))
                    {
                        string headerLine = string.Join(",", headers);
                        sw.WriteLine(headerLine);
                        var sortedKeys = duplicateData.Keys.ToList();
                        sortedKeys.Sort();
                        foreach (int key in sortedKeys)
                        {
                            List<string[]> rows = duplicateData[key];
                            foreach (string[] row in rows)
                            {
                                string line = string.Join(",", row);
                                sw.WriteLine(line);
                            }
                        }
                    }

                    MessageBox.Show("Lưu file thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lưu file: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}

    

