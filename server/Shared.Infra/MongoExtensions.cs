using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using MongoDB.ApplicationInsights.DependencyInjection;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace Shared.Infra
{
    public static class MongoExtensions
    {
        public static void ConfigureMongoClient(this WebApplicationBuilder builder)
        {
            builder.Services.AddMongoClient
            (
                builder.Configuration.GetConnectionString("MongoConnection")
            //.Replace("MONGO_USER", Environment.GetEnvironmentVariable("MONGO_USER"))
            //.Replace("MONGO_PASSWORD", Environment.GetEnvironmentVariable("MONGO_PASSWORD"))
            );
        }

        public static void ConfigureBSON()
        {
            BsonSerializer.RegisterSerializer(new GuidSerializer(GuidRepresentation.Standard));
            BsonDefaults.GuidRepresentationMode = GuidRepresentationMode.V3;
        }
    }
}
