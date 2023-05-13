using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryPlusTree
{
    public class Node
    {
        private int MAX = 5;
        public bool IS_LEAF { get; set; }
        public int[] key { get; set; } // массив чисел этого узла
        public int size { get; set; } // количество чисел в этом узле
        public Node[] ptr { get; set; }  // массив детей этого узла

        public Node()
        {
            key = new int[MAX];
            ptr = new Node[MAX + 1];
        }

};

}
