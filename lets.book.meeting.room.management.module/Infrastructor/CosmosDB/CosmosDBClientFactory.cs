using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Configuration;
using static System.Net.WebRequestMethods;

namespace meetspace.room.management.module.Infrastructor.CosmosDB
{
    public class CosmosDBClientFactory : ICosmosDBClientFactory
    {
        private CosmosClient _client;
        private readonly IConfiguration _config;

        public CosmosDBClientFactory(IConfiguration config)
        {
            _config = config;
        }

        public CosmosClient Client
        {
            get
            {
                if (_client == null)
                {
                    CosmosClientOptions options = new()
                    {
                        HttpClientFactory = () => new HttpClient(new HttpClientHandler()
                        {
                            ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
                        }),
                        ConnectionMode = ConnectionMode.Gateway,
                    };

                    _client = new(_config["CosmosDb:AccountConnectionString"]);
                }
                return _client;
            }
        }
    }
}
