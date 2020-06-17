using System;

public class Solution
{
    public static int[] MergeArrays(int[] myArray, int[] alicesArray)
    {
        int newLength = myArray.Length + alicesArray.Length;
        // Combine the sorted arrays into one large sorted array
        int[] merged = new int[newLength];
        
        int my = 0;
        int alice = 0;
        
      
        for (int i = 0; i < newLength; i++) {
            if (my >= myArray.Length) {
                //myarray exhausted
                if (alice >= alicesArray.Length) {
                    //both are exhausted
                    return merged;
                }
                merged[i] = alicesArray[alice];
                alice++;
            }
            
            else if (alice >= alicesArray.Length) {
                //Alice array exhausted
                merged[i] = myArray[my];
                my++;
            }
            
            else if (myArray[my] < alicesArray[alice]) {
                merged[i] = myArray[my];
                my++;
            }
            else {
                merged[i] = alicesArray[alice];
                alice++;
            }
        }
        return merged;
    }


















    // Tests

    [Fact]
    public void BothArraysAreEmptyTest()
    {
        var myArray = new int[] { };
        var alicesArray = new int[] { };
        var expected = new int[] { };
        var actual = MergeArrays(myArray, alicesArray);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void FirstArrayIsEmptyTest()
    {
        var myArray = new int[] { };
        var alicesArray = new int[] { 1, 2, 3 };
        var expected = new int[] { 1, 2, 3 };
        var actual = MergeArrays(myArray, alicesArray);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void SecondArrayIsEmptyTest()
    {
        var myArray = new int[] { 5, 6, 7 };
        var alicesArray = new int[] { };
        var expected = new int[] { 5, 6, 7 };
        var actual = MergeArrays(myArray, alicesArray);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void BothArraysHaveSomeNumbersTest()
    {
        var myArray = new int[] { 2, 4, 6 };
        var alicesArray = new int[] { 1, 3, 7 };
        var expected = new int[] { 1, 2, 3, 4, 6, 7 };
        var actual = MergeArrays(myArray, alicesArray);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ArraysAreDifferentLengthsTest()
    {
        var myArray = new int[] { 2, 4, 6, 8 };
        var alicesArray = new int[] { 1, 7 };
        var expected = new int[] { 1, 2, 4, 6, 7, 8 };
        var actual = MergeArrays(myArray, alicesArray);
        Assert.Equal(expected, actual);
    }

    public static void Main(string[] args)
    {
        TestRunner.RunTests(typeof(Solution));
    }
}
