namespace WeatherAPI.Configs
{
    public class Cors
    {
        public string? Name { get; set; } = null;
        public string[]? WebAddresses { get; set; } = null;

        public static string NameDefault => "DefaultCors";
        public static string[] WebAddressesDefault => new[] { "http://localhost:4200" };
    }
}
