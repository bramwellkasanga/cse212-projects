public static class Trees
{
    /// <summary>
    /// Given a sorted list (sortedNumbers), create a balanced BST.
    /// </summary>
    public static BinarySearchTree CreateTreeFromSortedList(int[] sortedNumbers)
    {
        var bst = new BinarySearchTree();
        InsertMiddle(sortedNumbers, 0, sortedNumbers.Length - 1, bst);
        return bst;
    }

    /// <summary>
    /// Recursively inserts the middle value of the current range into the BST,
    /// then does the same for the left and right halves.
    /// </summary>
    /// <param name="sortedNumbers">Input numbers that are already sorted.</param>
    /// <param name="first">The first index in the current range.</param>
    /// <param name="last">The last index in the current range.</param>
    /// <param name="bst">The Binary Search Tree to insert into.</param>
    private static void InsertMiddle(int[] sortedNumbers, int first, int last, BinarySearchTree bst)
    {
        // Base case: no values left to insert
        if (first > last)
        {
            return;
        }

        // Find the middle element
        int middle = (first + last) / 2;

        // Insert the middle value
        bst.Insert(sortedNumbers[middle]);

        // Recursively build the left subtree
        InsertMiddle(sortedNumbers, first, middle - 1, bst);

        // Recursively build the right subtree
        InsertMiddle(sortedNumbers, middle + 1, last, bst);
    }
}