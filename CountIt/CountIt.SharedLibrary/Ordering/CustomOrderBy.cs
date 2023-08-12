namespace CountIt.SharedLibrary.Ordering;

public static class CustomOrderBy
{
    public static IList<TSource> OrderBy<TSource, TKey>(this IList<TSource> input, Func<TSource, TKey> selector) where TKey : IComparable<TKey>
    {
        var lookup = input.ToDictionary(selector);
        var arr = input.Select(selector).ToArray();
        var sorted = arr.Sort();

        return sorted.Select(element => lookup[element]).ToList();
    }
}