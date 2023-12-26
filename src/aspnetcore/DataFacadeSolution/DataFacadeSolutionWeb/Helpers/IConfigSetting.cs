namespace DataFacadeSolutionWeb.Helpers
{
    public interface IConfigSetting
    {
        string GetConnectionString(string name);
        T? GetValue<T>(string keys);
    }
}