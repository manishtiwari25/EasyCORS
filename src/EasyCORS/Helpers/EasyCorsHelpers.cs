namespace EasyCORS.Helpers
{
    using EasyCORS.Models;
    using Microsoft.AspNetCore.Cors.Infrastructure;
    using System;
    using System.Linq;
    internal class EasyCorsHelpers
    {
        internal static void AddCORS(CorsPolicyBuilder builder, Configuration configData)
        {
            if (!string.IsNullOrEmpty(configData.AllowedOrigins))
            {
                if (configData.AllowedOrigins == "*")
                {
                    builder.AllowAnyOrigin();
                }
                else
                {
                    var allowedOrigins = configData.AllowedOrigins.Split(",", StringSplitOptions.RemoveEmptyEntries);
                    builder.WithOrigins(allowedOrigins);
                }
            }
            if (!string.IsNullOrEmpty(configData.AllowedMethods))
            {
                if (configData.AllowedMethods == "*")
                {
                    builder.AllowAnyMethod();
                }
                else
                {
                    var allowedMethods = configData.AllowedMethods.Split(",", StringSplitOptions.RemoveEmptyEntries);
                    builder.WithMethods(allowedMethods);
                }
            }
            if (!string.IsNullOrEmpty(configData.AllowedHeaders))
            {
                if (configData.AllowedHeaders == "*")
                {
                    builder.WithHeaders();
                }
                else
                {
                    var allowedHeaders = configData.AllowedHeaders.Split(",", StringSplitOptions.RemoveEmptyEntries);
                    builder.WithHeaders(allowedHeaders);
                }
            }
            if (!string.IsNullOrEmpty(configData.AllowedExposedHeaders))
            {
                var allowedExposedHeaders = configData.AllowedExposedHeaders.Split(",", StringSplitOptions.RemoveEmptyEntries);
                if (allowedExposedHeaders.Any())
                {
                    builder.WithExposedHeaders(allowedExposedHeaders);
                }
            }
            if (configData.IsAllowedCredentials && configData.AllowedOrigins != "*")
            {
                builder.AllowCredentials();
            }
            else builder.DisallowCredentials();
        }
    }
}
