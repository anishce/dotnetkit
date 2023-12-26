namespace DataFacadeSolutionWeb.Helpers
{
    public class ConfigSetting : IConfigSetting
    {
        private readonly IConfiguration configuration = null!;

        public ConfigSetting(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public string GetConnectionString(string name)
        {
            return this.configuration.GetConnectionString(name) ?? string.Empty;
        }

        public T? GetValue<T>(string keys)
        {
            var configKeys = keys.Split(':');

            IConfigurationSection? configSection = this.configuration?.GetSection(configKeys[0]) ?? null;

            for (var i = 1; i < configKeys.Length; i++)
            {
                configSection = configSection?.GetSection(configKeys[i]) ?? null;
            }

            string? configValue = configSection?.Value;

            return configValue != null ? (T)(configValue as object) : default(T);
        }
    }
}
