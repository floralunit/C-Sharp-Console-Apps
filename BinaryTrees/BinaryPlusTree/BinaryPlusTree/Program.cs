using BinaryPlusTree;

BPTree node = new BPTree();

Random rnd = new Random();
int x = 0;

for (int i = 1; i <= 12; i++)
{
    x = rnd.Next(1, 101);
    Console.Write($"{x} ");
    node.Insert(x);
}

Console.WriteLine();
node.Display(node.GetRoot());


int pipa;
Console.WriteLine("\nВведите число, которое нужно найти: ");
pipa = Convert.ToInt32(Console.ReadLine());
node.Search(pipa);
//Console.WriteLine(node?.key.ToString());
