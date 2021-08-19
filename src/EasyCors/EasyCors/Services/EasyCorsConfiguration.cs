namespace EasyCORS.Services
{
    using EasyCORS.Contracts;
    using EasyCORS.Models;
    using Microsoft.Extensions.Configuration;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class EasyCorsConfiguration : IEasyCorsConfiguration
    {
        private readonly IConfiguration _config;

        public EasyCorsConfiguration(IConfiguration configuration)
        {
            _config = configuration;
        }
        public async ValueTask<Dictionary<string, Configuration>> GetConfiguration()
        {
            var stringData = _config[Configuration.ConfigSectionName];
            var configurationData = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, Configuration>>(stringData);
            return await Task.Run(() => configurationData);
        }
    }
}
