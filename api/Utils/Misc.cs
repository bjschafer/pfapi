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
}
