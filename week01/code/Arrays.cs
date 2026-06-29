public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // Plan for Problem 1:
        // 1. Create an array that will hold exactly 'length' values.
        // 2. Loop through each position in the array.
        // 3. Store the current multiple of the starting number at that position.
        // 4. Return the completed array.

        double[] multiples = new double[length];

        for (int i = 0; i < length; i++)
        {
            multiples[i] = number * (i + 1);
        }

        return multiples;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // Plan for Problem 2:
        // 1. If the list is empty or the rotation amount is zero, do nothing.
        // 2. Find the effective number of positions to move by using the amount modulo the list size.
        // 3. Remove the last 'shift' elements from the list.
        // 4. Insert those removed elements at the front of the list.
        // 5. The list is now rotated to the right in place.

        if (data.Count <= 1)
        {
            return;
        }

        int shift = amount % data.Count;
        if (shift == 0)
        {
            return;
        }

        List<int> movedItems = data.GetRange(data.Count - shift, shift);
        data.RemoveRange(data.Count - shift, shift);
        data.InsertRange(0, movedItems);
    }
}
