using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTrees
{
    public class BinaryPlusNode
    {
        public bool leaf { get; set; }      // является ли узел листом
        public int key_num { get; set; }    // количество ключей узла
        public int[] key { get; set; }    // ключи узла
        public BinaryPlusNode parent { get; set; }    // указатель на отца
        public BinaryPlusNode[] child { get; set; }    // указатели на детей узла
        public BinaryPlusNode left { get; set; }       // указатель на левого брата
        public BinaryPlusNode right { get; set; }     // указатель на правого брата



    }
}
