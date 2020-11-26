namespace EasyCORS.Services
{
    using EasyCORS.Contracts;
    using EasyCORS.Models;
    using Microsoft.Extensions.Configuration;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class EasyCorsConfiguration : IEasyCorsConfiguration
    {
        private IConfiguration _config;

        public EasyCorsConfiguration(IConfiguration configuration)
        {
            _config = configuration;
        }
        public async ValueTask<Dictionary<string, Configuration>> GetConfiguration()
        {
            var configurationData = new Dictionary<string, Configuration>();
            _config.GetSection(Configuration.ConfigSectionName).Bind(_config);
            return await Task.Run(() => configurationData);
        }
    }
}
