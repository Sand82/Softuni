public class Program
{
    public static void Main(String[] args)
    {
        int[] arr = new[] { 3, 8, 5, 4, 1, 6, 2, 7 };
        int[] sorted = MergeSort(arr);

        Console.WriteLine(String.Join(" ", sorted));
    }

    public static int[] MergeSort(int[] arr)
    {
        int[] result = MergeSort(arr, 0, arr.Length);
        return result;
    }

    public static int[] MergeSort(int[] arr, int start, int end)
    {
        if (end - start < 2)
        {
            return new int[] { arr[start] };
        }

        int middle = start + ((end - start) / 2);
        int[] left = MergeSort(arr, start, middle);
        int[] right = MergeSort(arr, middle, end);

        int[] result = new int[left.Length + right.Length];

        int indexLeft = 0;
        int indexRight = 0;
        int i = 0;

        for (; indexLeft < left.Length && indexRight < right.Length; i++)
        {
            if (left[indexLeft] < right[indexRight])
            {
                result[i] = left[indexLeft];
                indexLeft++;
            }
            else
            {
                result[i] = right[indexRight];
                indexRight++;
            }
        }

        while (indexLeft < left.Length)
        {
            result[i++] = left[indexLeft++];
        }

        while (indexRight < right.Length)
        {
            result[i++] = right[indexRight++];
        }

        return result;
    }
}
