namespace EasyCORS.Models
{
    public class Configuration
    {
        public const string ConfigSectionName = "EasyCors";
        public string AllowedOrigins { get; set; }
        public string AllowedHeaders { get; set; }
        public string AllowedExposedHeaders { get; set; }
        public string AllowedMethods { get; set; }
        public bool IsAllowedCredentials { get; set; }
        public bool IsDefault { get; set; }
    }
}
