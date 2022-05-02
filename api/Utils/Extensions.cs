using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq.Expressions;

namespace api.Utils;

internal static class Extensions
{
    internal static string ToTitleCase(this string s) =>
        CultureInfo.InvariantCulture.TextInfo.ToTitleCase(s.ToLower());
    internal static IQueryable<TSource> WhereIf<TSource>([NotNull] this IQueryable<TSource> source, [NotNull] bool condition, [NotNull] Expression<Func<TSource, bool>> predicate)
    {
        return condition ? source.Where(predicate) : source;
    }
    internal static IQueryable<TSource> WhereIfs<TSource>([NotNull] this IQueryable<TSource> source, [NotNull] Expression<Func<bool>> condition, [NotNull] Expression<Func<TSource, bool>> predicate)
    {
        var finalResult = condition.Compile()();
        return source.WhereIf(finalResult, predicate);
    }
}
