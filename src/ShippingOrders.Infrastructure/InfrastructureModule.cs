﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;
using MongoDB.Driver;
using ShippingOrders.Core.Repositories;
using ShippingOrders.Infrastructure.Persistence;
using ShippingOrders.Infrastructure.Persistence.Repositories;

namespace ShippingOrders.Infrastructure
{
    public static class InfrastructureModule
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {

            services.AddMongo()
                .AddRepositories();

            return services;
        }

        public static IServiceCollection AddMongo(this IServiceCollection services)
        {
            services.AddSingleton<MongoDbOptions>(sp =>
            {
                var configuration = sp.GetService<IConfiguration>();
                var options = new MongoDbOptions();

                configuration.GetSection("Mongo").Bind(options);

                return options;
            });

            services.AddSingleton<IMongoClient>(sp =>
            {
                var configuration = sp.GetService<IConfiguration>();
                var options = sp.GetService<MongoDbOptions>();

                var client =  new MongoClient(options.ConnectionString);
                var db = client.GetDatabase(options.Database);

                // Implementa as coisas no banco de dados.
                var dbSeed = new DbSeed(db);
                dbSeed.Populate();

                return client;

            });

            services.AddTransient(sp =>
            {
                BsonDefaults.GuidRepresentation = GuidRepresentation.Standard;

                var options = sp.GetService<MongoDbOptions>();
                var mongoClient = sp.GetService<IMongoClient>();

                var db = mongoClient.GetDatabase(options.Database);

                return db;

            });

            return services;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services) {
            services.AddScoped<IShippingOrderRepository, ShippingOrderRepository>();
            services.AddScoped<IShippingServiceRepository, ShippingServiceRepository>();

            return services;
        }

    }
}
