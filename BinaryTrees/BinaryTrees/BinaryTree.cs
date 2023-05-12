using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTrees
{
    public class BinaryTree
    {
        private TreeNode root { get; set; }
        public void Insert(int data)
        {
            if (root != null)
            {
                root.Insert(data);
            }
            else
            {
                root = new TreeNode(data);
            }
        }

        public TreeNode Find(int data)
        {
            if (root != null)
            {
                return root.Find(data);
            }
            else
            {
                return null;
            }
        }

    }
}