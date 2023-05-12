class Node
{
    public int key;
    public Node left, right;

    public Node(int key)
    {
        this.key = key;
        left = right = null;
    }
}

public class BinaryTree
{
    private Node root;

    public BinaryTree()
    {
        root = null;
    }

    public void Insert(int key)
    {
        root = InsertRec(root, key);
    }

    private Node InsertRec(Node node, int key)
    {
        if (node == null)
        {
            node = new Node(key);
            return node;
        }

        if (key < node.key)
            node.left = InsertRec(node.left, key);
        else if (key > node.key)
            node.right = InsertRec(node.right, key);

        return node;
    }

    public void Inorder()
    {
        InorderRec(root);
    }

    private void InorderRec(Node node)
    {
        if (node != null)
        {
            InorderRec(node.left);
            Console.Write(node.key + " ");
            InorderRec(node.right);
        }
    }
}