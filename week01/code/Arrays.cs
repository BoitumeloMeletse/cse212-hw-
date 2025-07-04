public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  
    /// For example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // PLAN:
        //
        // 1. Receive the starting number (number) and how many multiples to return (length).
        // 2. Create an array of size length to store the multiples.
        // 3. Use a for loop that counts from 0 to length-1:
        //      - at index i, store number * (i+1) in the array
        //      - this way, first element is number*1, second is number*2, etc.
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
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  
    /// The function modifies the existing list in place.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // PLAN:
        //
        // 1. Find the index where the rotation starts:
        //      - that is at data.Count - amount
        // 2. Split the list into two parts:
        //      - firstPart: elements from splitIndex to end
        //      - secondPart: elements from 0 to splitIndex
        // 3. Clear the original list.
        // 4. Add the elements from firstPart, then add the elements from secondPart
        //      - this rotates the list to the right by amount
        //
        // This works because we are re-using the input list instead of creating a new one.
        
        int splitIndex = data.Count - amount;
        var firstPart = data.GetRange(splitIndex, amount);
        var secondPart = data.GetRange(0, splitIndex);
        data.Clear();
        data.AddRange(firstPart);
        data.AddRange(secondPart);
    }
}
