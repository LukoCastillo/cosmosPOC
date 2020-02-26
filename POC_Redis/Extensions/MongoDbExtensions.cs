using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using POC_Redis.Data;
using System;


namespace POC_Redis.Extensions
{
    public static class MongoDbExtensions
    {
        public static void AddMongoDbContext(
       this IServiceCollection services,
         IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetSection("MongoDb:ConnectionString").Value);
            var database = client.GetDatabase(configuration.GetSection("MongoDb:Database").Value);

            services.AddTransient<IMongoDatabase>(provider => database);
            services.AddTransient<IMongoClient>(provider => client);
            services.AddScoped<MongoDbContext>();
        }
    }
}
