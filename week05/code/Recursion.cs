using System.Collections;

public static class Recursion
{
    /// <summary>
    /// #############
    /// # Problem 1 #
    /// #############
    /// Using recursion, find the sum of 1^2 + 2^2 + 3^2 + ... + n^2
    /// and return it.
    /// </summary>
    public static int SumSquaresRecursive(int n)
    {
        if (n <= 0)
            return 0;

        return n * n + SumSquaresRecursive(n - 1);
    }

    /// <summary>
    /// #############
    /// # Problem 2 #
    /// #############
    /// Using recursion, insert permutations of length
    /// 'size' from a list of 'letters' into the results list.
    /// </summary>
    public static void PermutationsChoose(List<string> results, string letters, int size, string word = "")
    {
        // Base case
        if (word.Length == size)
        {
            results.Add(word);
            return;
        }

        // Recursive case
        for (int i = 0; i < letters.Length; i++)
        {
            string nextLetter = letters[i].ToString();
            string remainingLetters = letters.Remove(i, 1);

            PermutationsChoose(results, remainingLetters, size, word + nextLetter);
        }
    }

    /// <summary>
    /// #############
    /// # Problem 3 #
    /// #############
    /// Count the number of ways to climb stairs using
    /// memoization.
    /// </summary>
    public static decimal CountWaysToClimb(int s, Dictionary<int, decimal>? remember = null)
    {
        // Initialize memoization dictionary
        if (remember == null)
            remember = new Dictionary<int, decimal>();

        // Base Cases
        if (s == 0)
            return 0;
        if (s == 1)
            return 1;
        if (s == 2)
            return 2;
        if (s == 3)
            return 4;

        // Return cached result if available
        if (remember.ContainsKey(s))
            return remember[s];

        // Recursive solution using the same dictionary
        decimal ways =
            CountWaysToClimb(s - 1, remember) +
            CountWaysToClimb(s - 2, remember) +
            CountWaysToClimb(s - 3, remember);

        // Store computed value
        remember[s] = ways;

        return ways;
    }

    /// <summary>
    /// #############
    /// # Problem 4 #
    /// #############
    /// Expand wildcard binary strings.
    /// </summary>
    public static void WildcardBinary(string pattern, List<string> results)
    {
        int index = pattern.IndexOf('*');

        // Base case
        if (index == -1)
        {
            results.Add(pattern);
            return;
        }

        // Replace wildcard with 0
        WildcardBinary(
            pattern[..index] + "0" + pattern[(index + 1)..],
            results);

        // Replace wildcard with 1
        WildcardBinary(
            pattern[..index] + "1" + pattern[(index + 1)..],
            results);
    }

    /// <summary>
    /// Use recursion to insert all paths that start at (0,0) and end at the
    /// 'end' square into the results list.
    /// </summary>
    public static void SolveMaze(
        List<string> results,
        Maze maze,
        int x = 0,
        int y = 0,
        List<ValueTuple<int, int>>? currPath = null)
    {
        // Initialize the path
        if (currPath == null)
        {
            currPath = new List<ValueTuple<int, int>>();
        }

        // Check whether this move is valid
        if (!maze.IsValidMove(currPath, x, y))
            return;

        // Add current position to the path
        currPath.Add((x, y));

        // Check if we reached the end
        if (maze.IsEnd(x, y))
        {
            results.Add(currPath.AsString());

            // Backtrack
            currPath.RemoveAt(currPath.Count - 1);
            return;
        }

        // Explore all four directions
        SolveMaze(results, maze, x + 1, y, currPath); // Right
        SolveMaze(results, maze, x - 1, y, currPath); // Left
        SolveMaze(results, maze, x, y + 1, currPath); // Down
        SolveMaze(results, maze, x, y - 1, currPath); // Up

        // Backtrack
        currPath.RemoveAt(currPath.Count - 1);
    }
}