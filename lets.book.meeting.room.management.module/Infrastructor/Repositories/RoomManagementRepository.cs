using meetspace.room.management.module.Core.Entities;
using meetspace.room.management.module.Infrastructor.CosmosDB;
using Microsoft.Azure.Cosmos;
using Newtonsoft.Json;

namespace meetspace.room.management.module.Infrastructor.Repositories
{
    public class RoomManagementRepository : IRoomManagementRepository
    {
        private readonly ICosmosDBClientFactory _clientFactory;

        public RoomManagementRepository(ICosmosDBClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<Room> CreateRoom(Room room)
        {
            var container = GetContainer();
            var serialize = JsonConvert.SerializeObject(room);
            return await container.CreateItemAsync(room, new PartitionKey(room.Name));
        }

        private Container GetContainer()
        {
            var database = GetDataBase("lets_book_meeting");
            return database.GetContainer("room_container");
        }

        private Database GetDataBase(string databaseName)
        {
            return _clientFactory.Client.GetDatabase(databaseName);
        }
    }
}
