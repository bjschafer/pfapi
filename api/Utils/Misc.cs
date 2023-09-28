namespace api.Utils;

internal static class Misc
{
    /// <summary>
    ///     priority is given to env
    /// </summary>
    /// <param name="configuration"></param>
    /// <param name="settingName">If name contains ":", it's replaced with _</param>
    /// <param name="defaultValue">An optional default value to return if neither is set</param>
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

    internal static string? ValidatePagination(int page, int limit)
    {
        if (page < 1)
        {
            return $"Invalid page {page}: must be greater than zero.";
        }
        if (limit > 100)
        {
            return $"Limit {limit} too high; keep it below 100";
        }

        return null;
    }
}
