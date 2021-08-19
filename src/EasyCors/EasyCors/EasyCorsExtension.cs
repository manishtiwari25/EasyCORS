namespace EasyCORS
{
    using EasyCORS.Contracts;
    using EasyCORS.Helpers;
    using EasyCORS.Services;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    public static class EasyCorsExtension
    {
        public static void AddEasyCors(this IServiceCollection services)
        {
            services.AddScoped<IEasyCorsConfiguration>(o =>
            {
                var config = o.GetRequiredService<IConfiguration>();
                return new EasyCorsConfiguration(config);
            });

            var serviceProvider = services.BuildServiceProvider();
            var service = serviceProvider.GetService<IEasyCorsConfiguration>();

            var configData = service.GetConfiguration().GetAwaiter().GetResult();
            services.AddCors(options =>
            {
                foreach (var easyCORSConfig in configData)
                {
                    var configData = easyCORSConfig.Value;
                    if (configData.IsDefault)
                    {
                        options.AddDefaultPolicy(builder =>
                        {
                            EasyCorsHelpers.AddCORS(builder, configData);
                        });
                    }
                    else
                    {
                        options.AddPolicy(name: easyCORSConfig.Key, builder =>
                        {
                            EasyCorsHelpers.AddCORS(builder, configData);
                        });
                    }
                }
            });
        }
        public static void UseEasyCors(this IApplicationBuilder applicationBuilder)
        {
            var scope = applicationBuilder.ApplicationServices.CreateScope();
            var configuration = scope.ServiceProvider.GetService<IEasyCorsConfiguration>();
            if (configuration == null)
            {
                throw new ArgumentException("Please Add EasyCORS Service. example services.AddEasyCORS();");
            }
            applicationBuilder.UseCors();
        }
    }
}
