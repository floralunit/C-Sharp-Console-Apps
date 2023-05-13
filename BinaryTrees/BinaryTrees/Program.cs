using BinaryTrees;
using BTreePrinter;
using BTreePrinter;

BinaryTree binaryTree = new BinaryTree();
BTree btr = new BTree();

Random rnd = new Random();
int x = 0;

for (int i = 1; i <= 12; i++)
{
    x = rnd.Next(1, 101);
    Console.Write($"{x} ");
    binaryTree.Insert(x);
    btr.Add(x);
}

Console.WriteLine();
binaryTree.PreorderTraversal();
Console.WriteLine();
btr.Root.Print();

int pipa;
Console.WriteLine("\nВведите число, которое нужно найти: ");
pipa = Convert.ToInt32(Console.ReadLine());
var node = binaryTree.Find(pipa);
Console.WriteLine(node?.key.ToString());


