using Microsoft.Extensions.Configuration;

namespace HynixTask.Helpers
{
    public static class ConfigurationHelper
    {
        public static string GetSettingsElement()
        {
            return new ConfigurationBuilder()
                .AddJsonFile($"appsettings.json", true, true)
                .Build()["Data:Element"];
        }
    }
}