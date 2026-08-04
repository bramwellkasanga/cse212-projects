public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        Data = data;
    }

    /// <summary>
    /// Inserts a value into the Binary Search Tree.
    /// Duplicate values are not inserted.
    /// </summary>
    public void Insert(int value)
    {
        // Do not insert duplicates
        if (value == Data)
        {
            return;
        }

        if (value < Data)
        {
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else
        {
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    /// <summary>
    /// Determines whether the specified value exists in the tree.
    /// </summary>
    public bool Contains(int value)
    {
        if (value == Data)
            return true;

        if (value < Data)
        {
            if (Left is null)
                return false;

            return Left.Contains(value);
        }
        else
        {
            if (Right is null)
                return false;

            return Right.Contains(value);
        }
    }

    /// <summary>
    /// Returns the height of the tree rooted at this node.
    /// </summary>
    public int GetHeight()
    {
        int leftHeight = Left == null ? 0 : Left.GetHeight();
        int rightHeight = Right == null ? 0 : Right.GetHeight();

        return Math.Max(leftHeight, rightHeight) + 1;
    }
}