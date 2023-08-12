namespace CountIt.SharedLibrary.Ordering;

public static class QuickSort
{
    public static IList<T> Sort<T>(this IList<T> input) where T : IComparable<T>
    {
        if (!input.Any())
        {
            return input;
        }

        return input.Sort(0, input.Count - 1);
    }

    private static IList<T> Sort<T>(this IList<T> input, int leftIndex, int rightIndex) where T: IComparable<T>
    {
        var i = leftIndex;
        var j = rightIndex;
        var pivot = input[leftIndex];
        while (i <= j)
        {
            while (input[i].CompareTo(pivot) == -1)
            {
                i++;
            }

            while (input[j].CompareTo(pivot) == 1)
            {
                j--;
            }
            if (i <= j)
            {
                (input[i], input[j]) = (input[j], input[i]);
                i++;
                j--;
            }
        }

        if (leftIndex < j)
        {
            Sort(input, leftIndex, j);
        }

        if (i < rightIndex)
        {
            Sort(input, i, rightIndex);
        }

        return input;
    }
}