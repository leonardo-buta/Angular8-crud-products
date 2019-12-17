using MongoDB.Bson;
using MongoDB.Bson.Serialization.Conventions;
using Products.Infra.Data.Mappings;

namespace Products.Infra.IoC
{
    public class MongoDbConfiguration
    {
        public static void RegisterMongoDbConfigurations()
        {
            // Uses GUID
            BsonDefaults.GuidRepresentation = GuidRepresentation.CSharpLegacy;

            // Need to be called before doing the mappings
            RegisterConventions();

            // Configure mappings
            MongoDbMappings.Configure();
        }

        private static void RegisterConventions()
        {
            var pack = new ConventionPack
            {
                new CamelCaseElementNameConvention()
            };
            ConventionRegistry.Register("Conventions", pack, t => true);
        }
    }
}
