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
            //if the root is not null then we call the find method on the root
            if (root != null)
            {
                // call node method Find
                return root.Find(data);
            }
            else
            {//the root is null so we return null, nothing to find
                Console.WriteLine("root not found");
                return null;
            }
        }
        public void PreorderTraversal()
        {
            if (root != null)
                root.PreOrderTraversal();
        }

    }
}