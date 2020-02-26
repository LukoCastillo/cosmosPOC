using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;
using System;


namespace POC_Redis.Extensions
{
    public static class RedisExtensions
    {
        public static IServiceCollection AddRedisMultiplexer(
        this IServiceCollection services,
         string connectionString)
        {
            Lazy<ConnectionMultiplexer> lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
            {
                return ConnectionMultiplexer.Connect(connectionString);
            });

            return services.AddScoped<IConnectionMultiplexer>(provider => lazyConnection.Value);
        }
    }
}
