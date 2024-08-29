namespace WeatherAPI.Configs
{
    public class Cors
    {
        public string? Name { get; set; }
        public string[]? WebAddresses { get; set; }

        public static string NameDefault => "DefaultCors";
        public static string[] WebAddressesDefault => new[] { "http://localhost:4200" };
    }
}
