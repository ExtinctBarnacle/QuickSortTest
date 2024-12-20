// TODO
// add timer to measure sort time
// add filling of array of big length with random numbers
// run sort many times with arrays of different lengthes and check run time dependency on array length
// add other QuickSort implementations
// translate Two-pivot QuickSort algorithm from Java to C# (or look for automatic translator)
public class QuickSortClass
{
    static int[] prevArray;
    static int RecursiveDepth = 0;
    public static void Main(string[] args)
    {
        //int[] array = new int[11] { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 };
        int[] array = new int[11] { 2, 9, 6, 3, 4, 0, 5, 8, 7, 1, 10 };
        prevArray = CopyArrays(array);
        PrintArray(array, 0, 0);
        Quicksort(array, 0, array.Length - 1);
        PrintArray(array, 0 , 0);
    }
    static int PartitionFor(int[] array, int start, int end)
    {
        int marker = start; // divides left and right subarrays
        for (int i = start; i < end; i++)
        {
            if (array[i] < array[end]) // array[end] is pivot
            {
                (array[marker], array[i]) = (array[i], array[marker]);
                PrintArrayIfChanged(array, marker, i);
                marker += 1;
            }
        }
        // put pivot(array[end]) between left and right subarrays
        (array[marker], array[end]) = (array[end], array[marker]);
        PrintArrayIfChanged(array, marker, end);
        return marker;
    }

    static void Quicksort(int[] array, int start, int end)
    {
        if (start >= end)
            return;
        RecursiveDepth++;
        Console.WriteLine(RecursiveDepth);

        int pivot = PartitionFor(array, start, end);
        pivot = PartitionWhile(array, start, end);
        Quicksort(array, start, pivot - 1);
        Quicksort(array, pivot + 1, end);
    }
    static void PrintArrayIfChanged(int[] array, int i, int j)
    {
        if (!CompareArrays(array, prevArray))
        {
            PrintArray(array, i,j);
        }

        prevArray = CopyArrays(array);
    }
    static void PrintArray(int[] array, int i, int j)
    {
        for (int index = 0; index < array.Length; index++)
            if (index == i) Console.Write("х" + array[index] + " ");
        else if (index == j) Console.Write(array[index] + "х ");
        else Console.Write(array[index] + " ");
        Console.WriteLine("");
    }
    static bool CompareArrays (int[] array1, int[] array2)
    {
        for (int i = 0; i< array1.Length; i++)
        {
            if (array1[i] != array2[i]) return false;
        }
        return true;
    }
    static int[] CopyArrays(int[] source)
    {
        int [] dest = new int[source.Length];
        Array.Copy(source, dest, source.Length);
        //for (int i = 0; i < source.Length; i++)
        //{
        //    dest[i] = source[i];
        //}
        return dest;
    }
    private static int PartitionWhile(int[] array, int low, int high)
    {
        int pivot = array[(low + high) / 2];
        int i = low - 1;
        int j = high + 1;
        while (true)
        {
            do
            {
                i++;
            } while (array[i] < pivot);

            do
            {
                j--;
            } while (array[j] > pivot);

            if (i >= j)
                return j;

            Swap(array, i, j);
        }
    }

    private static void Swap(int[] array, int index1, int index2)
    {
        int temp = array[index1];
        array[index1] = array[index2];
        array[index2] = temp;
    }

}