using Microsoft.Azure.Cosmos;

namespace meetspace.room.management.module.Infrastructor.CosmosDB
{
    public interface ICosmosDBClientFactory
    {
        CosmosClient Client { get; }
    }
}