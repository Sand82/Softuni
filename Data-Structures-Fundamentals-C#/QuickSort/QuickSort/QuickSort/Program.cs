public class Program
{
    public static void Main(string[] args)
    {
        var arr = new[] { 3, 2, 4, 5, 1 };
        var sorted = QuickSort(arr, 0, arr.Length);

        Console.WriteLine(String.Join(" ", sorted));
    }

    public static int[] QuickSort(int[] arr, int start, int end)
    {
        if (start < end)
        {
            int pavot = Partion(arr, start, end);
            QuickSort(arr, start, pavot);
            QuickSort(arr, pavot + 1, end);
        }

        return arr;
    }

    public static void Swap(int[] arr, int i, int j)
    {
        int temp = arr[i];
        arr[i] = arr[j];
        arr[j] = temp;
    }

    public static int Partion(int[] arr, int start, int end)
    {
        int pavot = arr[start];
        int swapIndex = start;

        for (int i = start + 1; i < end; i++)
        {
            int currElement = arr[i];

            if (currElement < pavot)
            {
                swapIndex++;
                Swap(arr, i, swapIndex);
            }
        }

        Swap(arr, start, swapIndex);
        return swapIndex;
    }

}