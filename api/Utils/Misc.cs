using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;

namespace api.Utils;

internal static class Misc
{
    /// <summary>
    ///     priority is given to env
    /// </summary>
    /// <param name="configuration"></param>
    /// <param name="settingName">If name contains ":", it's replaced with _</param>
    /// <returns></returns>
    internal static string AppSettingOrEnv(ConfigurationManager configuration, string settingName, string? defaultValue = null)
    {
        var appSetting = configuration[settingName];
        var env        = Environment.GetEnvironmentVariable(settingName.Replace(':', '_'));

        if (appSetting is null && env is null)
        {
            if (defaultValue is null)
            {
                throw new ArgumentException($"Couldn't find a value for setting {settingName}.");
            }
            return defaultValue;
        }

        return env ?? appSetting!;
    }

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
