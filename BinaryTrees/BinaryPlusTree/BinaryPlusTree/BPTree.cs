using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryPlusTree
{
    public class BPTree
    {
        private int MAX = 5;
        public Node root { get; set; }

        public BPTree()
        {
            root = null;
        }

        // Search operation
        public void Search(int x)
        {
            if (root == null)
            {
                Console.WriteLine("Tree is empty");
            }
            else
            {
                Node cursor = root;
                while (cursor.IS_LEAF == false)
                {
                    for (int i = 0; i < cursor.size; i++)
                    {
                        if (x < cursor.key[i])
                        {
                            cursor = cursor.ptr[i];
                            break;
                        }
                        if (i == cursor.size - 1)
                        {
                            cursor = cursor.ptr[i + 1];
                            break;
                        }
                    }
                }
                for (int i = 0; i < cursor.size; i++)
                {
                    if (cursor.key[i] == x)
                    {
                        Console.WriteLine("Found");
                        return;
                    }
                }
                Console.WriteLine("Not found");
            }
        }

        // Insert Operation
        public void Insert(int x)
        {
            if (root == null)
            {
                root = new Node();
                root.key[0] = x;
                root.IS_LEAF = true;
                root.size = 1;
            }
            else
            {
                Node cursor = root;
                Node? parent = null;
                while (!cursor.IS_LEAF)
                {
                    parent = cursor;
                    for (int i = 0; i < cursor.size; i++)
                    {
                        if (x < cursor.key[i])
                        {
                            cursor = cursor.ptr[i];
                            break;
                        }
                        if (i == cursor.size - 1)
                        {
                            cursor = cursor.ptr[i + 1];
                            break;
                        }
                    }
                }
                if (cursor.size < MAX)
                {
                    int i = 0;
                    while (x > cursor.key[i] && i < cursor.size)
                        i++;
                    for (int j = cursor.size; j > i; j--)
                    {
                        cursor.key[j] = cursor.key[j - 1];
                    }
                    cursor.key[i] = x;
                    cursor.size++;
                    cursor.ptr[cursor.size] = cursor.ptr[cursor.size - 1];
                    cursor.ptr[cursor.size - 1] = null;
                }
                else
                {
                    Node newLeaf = new Node();
                    int[] virtualNode = new int[MAX + 1];
                    for (int v = 0; v < MAX; v++)
                    {
                        virtualNode[v] = cursor.key[v];
                    }
                    int i = 0, j;
                    while (x > virtualNode[i] && i < MAX)
                    {
                        i++;
                    }
                    for (j = MAX; j > i; j--)
                    {
                        virtualNode[j] = virtualNode[j - 1];
                    }
                    virtualNode[i] = x;
                    newLeaf.IS_LEAF = true;
                    cursor.size = (MAX + 1) / 2;
                    newLeaf.size = MAX + 1 - (MAX + 1) / 2;
                    cursor.ptr[cursor.size] = newLeaf;
                    newLeaf.ptr[newLeaf.size] = cursor.ptr[MAX];
                    cursor.ptr[MAX] = null;
                    for (i = 0; i < cursor.size; i++)
                    {
                        cursor.key[i] = virtualNode[i];
                    }
                    for (i = 0, j = cursor.size; i < newLeaf.size; i++, j++)
                    {
                        newLeaf.key[i] = virtualNode[j];
                    }
                    if (cursor == root)
                    {
                        Node newRoot = new Node();
                        newRoot.key[0] = newLeaf.key[0];
                        newRoot.ptr[0] = cursor;
                        newRoot.ptr[1] = newLeaf;
                        newRoot.IS_LEAF = false;
                        newRoot.size = 1;
                        root = newRoot;
                    }
                    else
                    {
                        InsertInternal(newLeaf.key[0], parent, newLeaf);
                    }
                }
            }
        }

        // Insert Operation
        public void InsertInternal(int x, Node cursor, Node child)
        {
            if (cursor.size < MAX)
            {
                int i = 0;
                while (x > cursor.key[i] && i < cursor.size)
                {
                    i++;
                }
                for (int j = cursor.size; j > i; j--)
                {
                    cursor.key[j] = cursor.key[j - 1];
                }
                for (int j = cursor.size + 1; j > i + 1; j--)
                {
                    cursor.ptr[j] = cursor.ptr[j - 1];
                }
                cursor.key[i] = x;
                cursor.size++;
                cursor.ptr[i + 1] = child;
            }
            else
            {
                Node newInternal = new Node();
                int[] virtualKey = new int[MAX + 1];
                Node[] virtualPtr = new Node[MAX + 2];
                for (int v = 0; v < MAX; v++)
                {
                    virtualKey[v] = cursor.key[v];
                }
                for (int c = 0; c < MAX + 1; c++)
                {
                    virtualPtr[c] = cursor.ptr[c];
                }
                int i = 0, j;
                while (x > virtualKey[i] && i < MAX)
                {
                    i++;
                }
                for (int t = MAX; t > i; t--)
                {
                    virtualKey[t] = virtualKey[t - 1];
                }
                virtualKey[i] = x;
                for (int t = MAX + 1; t > i + 1; t--)
                {
                    virtualPtr[t] = virtualPtr[t - 1];
                }
                virtualPtr[i + 1] = child;
                newInternal.IS_LEAF = false;
                cursor.size = (MAX + 1) / 2;
                newInternal.size = MAX - (MAX + 1) / 2;
                for (i = 0, j = cursor.size + 1; i < newInternal.size; i++, j++)
                {
                    newInternal.key[i] = virtualKey[j];
                }
                for (i = 0, j = cursor.size + 1; i < newInternal.size + 1; i++, j++)
                {
                    newInternal.ptr[i] = virtualPtr[j];
                }
                if (cursor == root)
                {
                    Node newRoot = new Node();
                    newRoot.key[0] = cursor.key[cursor.size];
                    newRoot.ptr[0] = cursor;
                    newRoot.ptr[1] = newInternal;
                    newRoot.IS_LEAF = false;
                    newRoot.size = 1;
                    root = newRoot;
                }
                else
                {
                    InsertInternal(cursor.key[cursor.size], FindParent(root, cursor), newInternal);
                }
            }
        }

        // Find the parent
        public Node FindParent(Node cursor, Node child)
        {
            Node parent = null;
            if (cursor.IS_LEAF || cursor.ptr[0].IS_LEAF)
            {
                return null;
            }
            for (int i = 0; i < cursor.size + 1; i++)
            {
                if (cursor.ptr[i] == child)
                {
                    parent = cursor;
                    return parent;
                }
                else
                {
                    parent = FindParent(cursor.ptr[i], child);
                    if (parent != null)
                        return parent;
                }
            }
            return parent;
        }

        // Print the tree
        //1 + p1 * (1 + 4n + n * (4) + 1 + 2 + p2 * (1 + 5n + n * (1 + 4)))
        public void Display(Node treeRoot)
        {
            if (treeRoot != null)
            {
                for (int i = 0; i < treeRoot.size; i++)
                {
                    Console.Write(treeRoot.key[i] + " ");
                }
                Console.WriteLine();
                if (treeRoot.IS_LEAF != true)
                {
                    for (int i = 0; i < treeRoot.size + 1; i++)
                    {
                        Console.WriteLine("level = " + i);
                        Display(treeRoot.ptr[i]);
                    }
                }
            }
        }

        // Get the root
        public Node GetRoot()
        {
            return root;
        }
    }
}
