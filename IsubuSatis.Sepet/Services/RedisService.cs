using IsubuSatis.Sepet.Models;
using Microsoft.Extensions.Options;
using StackExchange.Redis;

namespace IsubuSatis.Sepet.Services
{
    public class RedisService
    {
        private readonly string host;
        private readonly int port;

        private ConnectionMultiplexer connectionMultiplexer;
        public RedisService(IOptions<RedisSettings> options)
        {
            host = options.Value.Host;
            port = options.Value.Port;

            Baglan();
        }

        public void Baglan() {
            var configuration = $"{host}:{port}";
            connectionMultiplexer = ConnectionMultiplexer.Connect(configuration);
        }

        public IDatabase GetDatabase(int db = 1)
        {
            return connectionMultiplexer.GetDatabase(db);
        }
    }
}
