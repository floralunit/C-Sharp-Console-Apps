using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTrees
{
    public class TreeNode
    {
        public TreeNode left { get; set; }
        public TreeNode right { get; set; }
        public int key { get; set; }
        public TreeNode(int value)
        {
            key = value;
        }

        public void Insert(int value)
        {
            if (value >= key)
            {   
                if (right == null)
                {
                    right = new TreeNode(value);
                }
                else
                {
                    right.Insert(value);
                }
            }
            else
            {
                if (left == null)
                {
                    left = new TreeNode(value);
                }
                else
                {
                    left.Insert(value);
                }
            }
        }
        public TreeNode Find(int value)
        {

            TreeNode currentNode = this;

            while (currentNode != null)
            {
                if (value == currentNode.key)
                {
                    return currentNode;
                }
                else if (value > currentNode.key)
                {
                    currentNode = currentNode.right;
                }
                else
                {
                    currentNode = currentNode.left;
                }
            }

            return null;
        }

        public void PreOrderTraversal()
        {
            Console.Write(key + " ");

            if (left != null)
                left.PreOrderTraversal();

            if (right != null)
                right.PreOrderTraversal();
        }

    }
}
