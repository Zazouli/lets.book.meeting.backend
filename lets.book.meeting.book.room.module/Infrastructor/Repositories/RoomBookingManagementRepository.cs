using meetspace.room.management.module.Core.Entities;
using meetspace.room.management.module.Infrastructor.CosmosDB;
using Microsoft.Azure.Cosmos;
using Newtonsoft.Json;

namespace meetspace.room.management.module.Infrastructor.Repositories
{
    public class RoomBookingManagementRepository : IRoomBookingManagementRepository
    {
        private readonly ICosmosDBClientFactory _clientFactory;

        public RoomBookingManagementRepository(ICosmosDBClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<BookingRoom> CreateBooking(BookingRoom bookingRoom)
        {
            var container = GetContainer();
            var serialize = JsonConvert.SerializeObject(bookingRoom);
            return await container.CreateItemAsync(bookingRoom, new PartitionKey(bookingRoom.Id));
        }

        public List<BookingRoom> GetBookedByMeetingDuration(DateTimeOffset dateNow, int meetingDuration)
        {
            var container = GetContainer();
            return container.GetItemLinqQueryable<BookingRoom>(true)
                .Where(b => (b.StartDate > dateNow &&
                            b.StartDate < dateNow.AddHours(meetingDuration)) ||
                            (b.EndDate < dateNow.AddHours(meetingDuration) &&
                            b.EndDate > dateNow))
                .ToList();
        }

        public List<BookingRoom> GetCurrentUserBooking(string userEmail, DateTime from)
        {
            var container = GetContainer();
            from = DateTime.Now.AddHours(-1000);
            return container.GetItemLinqQueryable<BookingRoom>(true)
                .Where(b => b.UserEmail == userEmail &&
                b.StartDate > from)
                .ToList();
        }

        private Container GetContainer()
        {
            var database = GetDataBase("lets_book_meeting");
            return database.GetContainer("booking_room_container");
        }

        private Database GetDataBase(string databaseName)
        {
            return _clientFactory.Client.GetDatabase(databaseName);
        }
    }
}
