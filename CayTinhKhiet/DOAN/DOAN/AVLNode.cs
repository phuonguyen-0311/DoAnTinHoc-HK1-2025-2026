using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocGhiFileCSV
{
    [Serializable]
    public class AVLNode
    {
        private int m_key;                      
        private string[] m_rowData;   
        private int m_height;         
        private AVLNode m_left;       
        private AVLNode m_right;
        public int Key
        {
            get { return this.m_key; }
            set { this.m_key = value; }
        }

        public string[] RowData
        {
            get { return this.m_rowData; }
            set { this.m_rowData = value; }
        }

        public int Height
        {
            get { return this.m_height; }
            set { this.m_height = value; }
        }

        public AVLNode Left
        {
            get { return this.m_left; }
            set { this.m_left = value; }
        }

        public AVLNode Right
        {
            get { return this.m_right; }
            set { this.m_right = value; }
        }
        public AVLNode(int key, string[] data)
        {
            this.m_key = key;
            this.m_rowData = data;
            this.m_height = 1; 
            this.m_left = null;
            this.m_right = null;
        }
    }
}
