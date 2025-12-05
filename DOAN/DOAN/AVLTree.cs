using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        public AVLNode()
        {
            this.m_key = 0;
            this.m_rowData = null;
            this.m_height = 0;
            this.m_left = null;
            this.m_right = null;
        }
        public AVLNode(int d, string[] data)
        {
            this.m_key = d;
            this.m_rowData = data;
            this.m_height = 1; 
            this.m_left = null;
            this.m_right = null;
        }
    }
    public class AVLTree
    {
        private AVLNode root;
        public AVLTree()
        {
            root = null;
        }

        private int GetHeight(AVLNode N)
        {
            if (N == null)
                return 0;
            return N.Height;
        }
        public int GetTreeHeight()
        {
            return GetHeight(root);
        }
        private int Max(int a, int b)
        {
            return (a > b) ? a : b;
        }
        private AVLNode RightRorate(AVLNode y)
        {
            AVLNode x = y.Left;
            AVLNode T2 = x.Right;
            x.Right = y;
            y.Left = T2;
            y.Height = Max(GetHeight(y.Left), GetHeight(y.Right)) + 1;
            x.Height = Max(GetHeight(x.Left), GetHeight(x.Right)) + 1;
            return x;
        }
        private AVLNode LeftRorate(AVLNode x)
        {
            AVLNode y = x.Right;
            AVLNode T2 = y.Left;
            y.Left = x;
            x.Right = T2;
            x.Height = Max(GetHeight(x.Left), GetHeight(x.Right)) + 1;
            y.Height = Max(GetHeight(y.Left), GetHeight(y.Right)) + 1;
            return y;
        }
        private int GetBalance(AVLNode N)
        {
            if (N == null)
                return 0;
            return GetHeight(N.Left) - GetHeight(N.Right);
        }
        public void Insert(int key, string[] data)
        {
            root = InsertRecursive(root, key, data);
        }
        private AVLNode InsertRecursive(AVLNode node, int key, string[] data)
        {
            if (node == null)
                return (new AVLNode(key, data));
            if (key < node.Key)
                node.Left = InsertRecursive(node.Left, key, data);
            else if (key > node.Key)
                node.Right = InsertRecursive(node.Right, key, data);
            else
                return node;
            node.Height = 1 + Max(GetHeight(node.Left), GetHeight(node.Right));
            int balance = GetBalance(node);

            if (balance > 1 && key < node.Left.Key)
                return RightRorate(node);

            if (balance < -1 && key > node.Right.Key)
                return LeftRorate(node);

            if (balance > 1 && key > node.Left.Key)
            {
                node.Left = LeftRorate(node.Left);
                return RightRorate(node);
            }

            if (balance < -1 && key < node.Right.Key)
            {
                node.Right = RightRorate(node.Right);
                return LeftRorate(node);
            }
            return node;
        }
        public List<string[]> GetSortedData()
        {
            List<string[]> sortedList = new List<string[]>();
            InOrder(root, sortedList);
            return sortedList;
        }
        private void InOrder(AVLNode node, List<string[]> sortedList)
        {
            if (node != null)
            {
                InOrder(node.Left, sortedList);
                sortedList.Add(node.RowData);
                InOrder(node.Right, sortedList);
            }
        }
        public List<List<int>> GetNodesByLevel()
        {
            List<List<int>> allLevels = new List<List<int>>();
            if (root == null) return allLevels;
            Queue<AVLNode> queue = new Queue<AVLNode>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                List<int> currentLevelList = new List<int>();
                int levelSize = queue.Count;
                for (int i = 0; i < levelSize; i++)
                {
                    AVLNode currentNode = queue.Dequeue();
                    currentLevelList.Add(currentNode.Key);
                    if (currentNode.Left != null) queue.Enqueue(currentNode.Left);
                    if (currentNode.Right != null) queue.Enqueue(currentNode.Right);
                }
                allLevels.Add(currentLevelList);
            }
            return allLevels;
        }
        //Ham dem tong so nut tren cay
        private int CountTotalNodesRecursive(AVLNode node)
        {
            if (node == null)
                return 0;
            return 1 + CountTotalNodesRecursive(node.Left) + CountTotalNodesRecursive(node.Right);
        }
        public int CountTotalNodes()
        {
            return CountTotalNodesRecursive(root);
        }
        //Ham dem so nut la
        private int CountLeafNodesRecursive(AVLNode node)
        {
            if (node == null)
                return 0;
            if (node.Left == null && node.Right == null)
                return 1;
            return CountLeafNodesRecursive(node.Left) + CountLeafNodesRecursive(node.Right);
        }
        public int CountLeafNodes()
        {
            return CountLeafNodesRecursive(root);
        }
        //Ham dem so nut cay con trai
        public int CountNodesInLeftSubtree()
        {
            if (root == null)
                return 0;
            return CountTotalNodesRecursive(root.Left);
        }
        //Ham dem so nut cay con phai
        public int CountNodesInRightSubtree()
        {
            if (root == null)
                return 0;
            return CountTotalNodesRecursive(root.Right);
        }
        public string[] Find(int key)
        {
            return FindRecursive(root, key);
        }
        private string[] FindRecursive(AVLNode node, int key)
        {
            if (node == null) return null;
            if (key < node.Key) return FindRecursive(node.Left, key);
            else if (key > node.Key) return FindRecursive(node.Right, key);
            else return node.RowData;
        }
        public void PopulateTreeView(TreeView treeViewControl)
        {
            treeViewControl.Nodes.Clear();
            if (root != null)
            {
                var rootTreeNode = new TreeNode(root.Key.ToString());
                treeViewControl.Nodes.Add(rootTreeNode);
                PopulateTreeViewRecursive(root, rootTreeNode);
            }
        }
        private void PopulateTreeViewRecursive(AVLNode avlNode, TreeNode treeNode)
        {
            if (avlNode.Left != null)
            {
                var leftTreeNode = new TreeNode(avlNode.Left.Key.ToString());
                treeNode.Nodes.Add(leftTreeNode);
                PopulateTreeViewRecursive(avlNode.Left, leftTreeNode);
            }
            if (avlNode.Right != null)
            {
                var rightTreeNode = new TreeNode(avlNode.Right.Key.ToString());
                treeNode.Nodes.Add(rightTreeNode);
                PopulateTreeViewRecursive(avlNode.Right, rightTreeNode);
            }
        }

    }
}
