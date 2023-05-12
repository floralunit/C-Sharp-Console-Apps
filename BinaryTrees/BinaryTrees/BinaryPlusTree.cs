using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTrees
{
    public class BinaryPlusTree
    {
        public int t { get; set; }     // минимальная степень дерева
        public BinaryPlusNode root { get; set; }   // указатель на корень дерева


        public BinaryPlusNode find_leaf(BinaryPlusTree T, int key)
        {
            if (T.root == null)
            {

            }
            var cur = T.root;
            while (cur.leaf != true)
            {
                for (int i = 0; i < cur.key_num; i++)
                {
                    if (i == cur.key_num || key < cur.key[i])
                    {
                        cur = cur.child[i];
                        break;
                    }
                }
            }
            return cur;
        }

        public bool insert(BinaryPlusTree T, int key)
        {
            var leaf = find_leaf(T, key);
            if (leaf.key.Contains(key))
                return false;

            // Ищем позицию для нового ключа 
            var pos = 0;
            while (pos < leaf.key_num && leaf.key[pos] < key)
                pos++;

            // Вставляем ключ
            for (int i = leaf.key_num; i > pos + 1; i--)
            {
                leaf.key[i] = leaf.key[i - 1];
            }
            leaf.key[pos] = key;
            leaf.key_num++;
            if (leaf.key_num == 2 * 5)
            {
                split(T, leaf);
            }              // t — степень дерева
            return true;
        }
        void split(BinaryPlusTree T, BinaryPlusNode node)
        {
            BinaryPlusNode new_node = new BinaryPlusNode(); // Создаем новый узел

            // Перенаправляем right и left указатели
            new_node.right = node.right;
            node.right.left = new_node;
            node.right = new_node;
            new_node.left = node;

            // Перемещаем t - 1 значений и соответствующих им указателей в new_node
            int mid_key = node.key[T.t];
            new_node.key_num = T.t - 1;
            node.key_num = T.t;
            for (int i = 0; i < new_node.key_num; i++)
            {
                new_node.key[i] = node.key[i + T.t + 1];
                new_node.child[i] = node.child[i + T.t + 1];
            }
            new_node.child[new_node.key_num] = node.child[2 * T.t];

            if (node.leaf)
            {
                new_node.key_num++;
                new_node.leaf = true;

                // Перемещаем в new_node оставшийся при разбиении элемент mid_key 
                for (int i = new_node.key_num - 1; i >= 1; i--)
                {
                    new_node.key[i] = new_node.key[i - 1];
                }
                new_node.key[0] = node.key[T.t];
            }

            if (node == T.root)
            {
                T.root = new BinaryPlusNode(); // Создаем новый корень T.root 
                T.root.key[0] = mid_key;
                T.root.child[0] = node;
                T.root.child[1] = new_node;
                T.root.key_num = 1;
                node.parent = T.root;
                new_node.parent = T.root;
            }
            else
            {
                new_node.parent = node.parent;
                BinaryPlusNode parent = node.parent;

                // Ищем позицию mid_key в отце 
                int pos = 0;
                while (pos < parent.key_num && parent.key[pos] < mid_key)
                {
                    pos++;
                }

                // Добавляем mid_key в отца и направляем ссылку из него на new_node 
                for (int i = parent.key_num; i >= pos + 1; i--)
                {
                    parent.key[i] = parent.key[i - 1];
                }
                for (int i = parent.key_num + 1; i >= pos + 2; i--)
                {
                    parent.child[i] = parent.child[i - 1];
                }
                parent.key[pos] = mid_key;
                parent.child[pos + 1] = new_node;
                parent.key_num++;

                if (parent.key_num == 2 * T.t)
                {
                    split(T, parent);
                }
            }
        }
    }


}
