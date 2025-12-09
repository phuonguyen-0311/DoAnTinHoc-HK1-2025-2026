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
    public class AVLTree
    {
        private AVLNode root;
        public AVLTree()
        {
            root = null;
        }
        private int GetHeight(AVLNode node)
        {
            return (node == null) ? 0 : node.Height;
        }
        private int GetBalance(AVLNode node)
        {
            return (node == null) ? 0 : GetHeight(node.Left) - GetHeight(node.Right);
        }
        private int Max(int a, int b)
        {
            return (a > b) ? a : b;
        }
        public int GetTreeHeight()
        {
            return GetHeight(root);
        }
        private AVLNode RightRotate(AVLNode y)
        {
            AVLNode x = y.Left;
            AVLNode T2 = x.Right;

            x.Right = y;
            y.Left = T2;

            y.Height = Max(GetHeight(y.Left), GetHeight(y.Right)) + 1;
            x.Height = Max(GetHeight(x.Left), GetHeight(x.Right)) + 1;

            return x; 
        }

        private AVLNode LeftRotate(AVLNode x)
        {
            AVLNode y = x.Right;
            AVLNode T2 = y.Left;

            y.Left = x;
            x.Right = T2;

            x.Height = Max(GetHeight(x.Left), GetHeight(x.Right)) + 1;
            y.Height = Max(GetHeight(y.Left), GetHeight(y.Right)) + 1;

            return y; 
        }
        public void Insert(int key, string[] data)
        {
            root = InsertRecursive(root, key, data);
        }
        private AVLNode InsertRecursive(AVLNode node, int key, string[] data)
        {
            if (node == null)
                return new AVLNode(key, data);
            if (key < node.Key)
                node.Left = InsertRecursive(node.Left, key, data);
            else if (key > node.Key)
                node.Right = InsertRecursive(node.Right, key, data);
            else
                return node; 
            
            node.Height = 1 + Max(GetHeight(node.Left), GetHeight(node.Right));
            int balance = GetBalance(node);
           
            if (balance > 1 && key < node.Left.Key) 
                return RightRotate(node);
            if (balance < -1 && key > node.Right.Key) 
                return LeftRotate(node);
            if (balance > 1 && key > node.Left.Key)
            {
                node.Left = LeftRotate(node.Left);
                return RightRotate(node);
            }
            if (balance < -1 && key < node.Right.Key)
            {
                node.Right = RightRotate(node.Right);
                return LeftRotate(node);
            }

            return node;
        }
        public string[] Find(int key)
        {
            return FindRecursive(root, key);
        }

        private string[] FindRecursive(AVLNode node, int key)
        {
            if (node == null) 
                return null;
            if (key < node.Key) 
                return FindRecursive(node.Left, key);
            else if (key > node.Key) 
                return FindRecursive(node.Right, key);
            else return node.RowData; 
        }
        public bool Update(int key, string[] newData)
        {
            return UpdateRecursive(root, key, newData);
        }
        private bool UpdateRecursive(AVLNode node, int key, string[] newData)
        {
            if (node == null) 
                return false;
            if (key < node.Key) 
                return UpdateRecursive(node.Left, key, newData);
            else if (key > node.Key) 
                return UpdateRecursive(node.Right, key, newData);
            else
            {
                node.RowData = newData; 
                return true;
            }
        }
        public void Delete(int key)
        {
            root = DeleteRecursive(root, key);
        }
        private AVLNode DeleteRecursive(AVLNode root, int key)
        {
            if (root == null) 
                return root;
            if (key < root.Key) 
                root.Left = DeleteRecursive(root.Left, key);
            else if (key > root.Key) 
                root.Right = DeleteRecursive(root.Right, key);
            else
            {
                if ((root.Left == null) || (root.Right == null))
                {
                    AVLNode temp = (root.Left != null) ? root.Left : root.Right;
                    if (temp == null)
                    {
                        temp = root;
                        root = null;
                    }
                    else root = temp;
                }
                else
                {
                    AVLNode temp = MinValueNode(root.Right);
                    root.Key = temp.Key;
                    root.RowData = temp.RowData;
                    root.Right = DeleteRecursive(root.Right, temp.Key);
                }
            }

            if (root == null) 
                return root;

            root.Height = 1 + Max(GetHeight(root.Left), GetHeight(root.Right));
            int balance = GetBalance(root);

            if (balance > 1 && GetBalance(root.Left) >= 0) 
                return RightRotate(root);
            if (balance > 1 && GetBalance(root.Left) < 0)
            {
                root.Left = LeftRotate(root.Left);
                return RightRotate(root);
            }
            if (balance < -1 && GetBalance(root.Right) <= 0) 
                return LeftRotate(root);
            if (balance < -1 && GetBalance(root.Right) > 0)
            {
                root.Right = RightRotate(root.Right);
                return LeftRotate(root);
            }

            return root;
        }

        private AVLNode MinValueNode(AVLNode node)
        {
            AVLNode current = node;
            while (current.Left != null) 
                current = current.Left;
            return current;
        }
        public List<string[]> GetSortedData()
        {
            List<string[]> list = new List<string[]>();
            InOrder(root, list);
            return list;
        }
        private void InOrder(AVLNode node, List<string[]> list)
        {
            if (node != null)
            {
                InOrder(node.Left, list);
                list.Add(node.RowData);
                InOrder(node.Right, list);
            }
        }
        public void PopulateTreeView(TreeView treeView)
        {
            treeView.Nodes.Clear();
            if (root != null)
            {
                TreeNode rootNode = new TreeNode(root.Key.ToString());
                treeView.Nodes.Add(rootNode);
                PopulateRecursive(root, rootNode);
            }
        }

        private void PopulateRecursive(AVLNode avlNode, TreeNode treeNode)
        {
            if (avlNode.Left != null)
            {
                TreeNode leftNode = new TreeNode(avlNode.Left.Key.ToString());
                treeNode.Nodes.Add(leftNode);
                PopulateRecursive(avlNode.Left, leftNode);
            }
            if (avlNode.Right != null)
            {
                TreeNode rightNode = new TreeNode(avlNode.Right.Key.ToString());
                treeNode.Nodes.Add(rightNode);
                PopulateRecursive(avlNode.Right, rightNode);
            }
        }
        public int CountTotalNodes()
        {
            return CountTotalNodesRecursive(root);
        }
        private int CountTotalNodesRecursive(AVLNode node)
        {
            if (node == null) 
                return 0;
            return 1 + CountTotalNodesRecursive(node.Left) + CountTotalNodesRecursive(node.Right);
        }
        public int CountLeafNodes()
        {
            return CountLeafRecursive(root);
        }
        private int CountLeafRecursive(AVLNode node)
        {
            if (node == null) 
                return 0;
            if (node.Left == null && node.Right == null) 
                return 1;
            return CountLeafRecursive(node.Left) + CountLeafRecursive(node.Right);
        }
        public int CountNodesWithOneChild()
        {
            return CountOneChildRecursive(root);
        }
        private int CountOneChildRecursive(AVLNode node)
        {
            if (node == null) 
                return 0;
            int count = 0;
            if ((node.Left != null && node.Right == null) || (node.Left == null && node.Right != null))
            {
                count = 1;
            }
            return count + CountOneChildRecursive(node.Left) + CountOneChildRecursive(node.Right);
        }
        public int CountNodesWithTwoChildren()
        {
            return CountTwoChildrenRecursive(root);
        }
        private int CountTwoChildrenRecursive(AVLNode node)
        {
            if (node == null) 
                return 0;
            int count = 0;
            if (node.Left != null && node.Right != null)
            {
                count = 1;
            }
            return count + CountTwoChildrenRecursive(node.Left) + CountTwoChildrenRecursive(node.Right);
        }
        public int CountNodesInLeftSubtree()
        {
            if (root == null) 
                return 0;
            return CountTotalNodesRecursive(root.Left);
        }
      public int CountNodesInRightSubtree()
        {
            if (root == null) 
                return 0;
            return CountTotalNodesRecursive(root.Right);
        }
        public long SumAmount()
        {
            return SumAmountRecursive(root);
        }
        private long SumAmountRecursive(AVLNode node)
        {
            if (node == null) 
                return 0;
            long currentAmount = 0;
            if (node.RowData != null && node.RowData.Length > 6)
            {
                string amountStr = node.RowData[6].Replace(",", "").Trim();
                long.TryParse(amountStr, out currentAmount);
            }

            return currentAmount + SumAmountRecursive(node.Left) + SumAmountRecursive(node.Right);
        }
        public List<List<int>> GetNodesByLevel()
        {
            List<List<int>> result = new List<List<int>>();
            if (root == null) 
                return result;
            Queue<AVLNode> queue = new Queue<AVLNode>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                int levelSize = queue.Count; 
                List<int> currentLevel = new List<int>();

                for (int i = 0; i < levelSize; i++)
                {
                    AVLNode node = queue.Dequeue();
                    currentLevel.Add(node.Key);
                    if (node.Left != null) 
                        queue.Enqueue(node.Left);
                    if (node.Right != null) 
                        queue.Enqueue(node.Right);
                }
                result.Add(currentLevel);
            }
            return result;
        }
    }
}
