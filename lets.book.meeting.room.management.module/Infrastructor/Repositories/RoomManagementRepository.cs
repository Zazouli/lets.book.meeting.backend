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
            return await container.CreateItemAsync(room, new PartitionKey(room.Id));
        }

        public Room? GetById(string roomId)
        {
            var container = GetContainer();
            return container.GetItemLinqQueryable<Room>(true)
                .Where(room => room.Id == roomId)
                .FirstOrDefault();
        }

        public List<Room> GetAll()
        {
            var container = GetContainer();
            return container.GetItemLinqQueryable<Room>(true)
                .ToList();
        }

        public List<Room> GetRoomsByIds(List<string> roomIds)
        {
            var container = GetContainer();
            return container.GetItemLinqQueryable<Room>(true)
                .Where(r => roomIds.Contains(r.Id))
                .ToList();
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
