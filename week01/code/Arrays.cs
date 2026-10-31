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
        // TODO Problem 1 Start
        // Plan:
        // 1. Create a new double array of size 'length'.
        // 2. Loop from i = 0 to length - 1.
        // 3. Inside the loop, calculate each multiple by multiplying 'number' by (i + 1).
        // 4. Store the calculated multiple at index i in the array.
        // 5. Return the populated array.

        double[] result = new double[length];

        for (int i = 0; i < length; i++)
        {
            result[i] = number * (i + 1);
        }

        return result;
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
        // TODO Problem 2 Start
        // Plan:
        // 1. Check if the list is null, empty, or if amount is 0; if so, exit early.
        // 2. Normalize the amount using modulo (amount % data.Count) to handle shifts greater than the list size.
        // 3. Extract the sublist of the last 'amount' elements using GetRange.
        // 4. Remove those elements from the end of the original list using RemoveRange.
        // 5. Insert the extracted sublist at the beginning (index 0) of the list using InsertRange.

        if (data == null || data.Count == 0 || amount <= 0)
            return;

        amount %= data.Count;
        if (amount == 0)
            return;

        // Extract the last 'amount' elements
        List<int> tail = data.GetRange(data.Count - amount, amount);

        // Remove them from the end
        data.RemoveRange(data.Count - amount, amount);

        // Insert them at the front
        data.InsertRange(0, tail);
    }
}