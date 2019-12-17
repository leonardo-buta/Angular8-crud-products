using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using Products.Domain.Models;

namespace Products.Infra.Data.Mappings
{
    public class ProductMap
    {
        public static void Configure()
        {
            BsonClassMap.RegisterClassMap<Product>(cm =>
            {
                cm.AutoMap();
                cm.MapMember(c => c.Price).SetSerializer(new DecimalSerializer(BsonType.Decimal128));
            });
        }
    }
}
