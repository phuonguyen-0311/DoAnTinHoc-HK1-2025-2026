using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.IO;

namespace DocGhiFileCSV
{
    class ReadCsv
    {
        static List<string[]> ReadCsvFile(string filePath)
        {
            List<string[]> rows = new List<string[]>();

            try
            {
                // Doc tat ca cac dong tu tep CSV
                string[] lines = File.ReadAllLines(filePath);

                //Xu ly tung dong va tach bang dau phay de lay cac gia tri
                foreach (string line in lines)
                {
                    string[] values = line.Split(',');

                    // Them cac gia tri vao danh sach cac hang
                    rows.Add(values);
                }

                Console.WriteLine("CSV file read successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            return rows;
        }
        static void WriteCsvFile(string filePath, List<string[]> data)
        {
            try
            {
                List<string> lines = new List<string>();
                foreach (string[] row in data)
                {
                    // Noi cac gia tri lai bang dau phay
                    string line = string.Join(",", row);
                    lines.Add(line);
                }

                // Ghi tat cac cac dong vao tep
                File.WriteAllLines(filePath, lines);

                Console.WriteLine($"Ghi tep CSV '{filePath}' thanh cong!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Da xay ra loi khi ghi: {ex.Message}");
            }
        }

        static void Main()
        {
            string csvFilePath = "data_clean.csv";

            //Goi phuong thuc de doc va xu ly xu lieu file CSV
            List<string[]> csvData = ReadCsvFile(csvFilePath);

            //hien thi du lieu da doc
            foreach (string[] row in csvData)
            {
                Console.WriteLine(string.Join(", ", row));
            }

            string destinationFilePath = "data_clean_copy.csv";

            WriteCsvFile(destinationFilePath, csvData);
        }
    }
}