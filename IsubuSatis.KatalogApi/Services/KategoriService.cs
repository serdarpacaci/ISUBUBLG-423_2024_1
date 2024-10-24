using IsubuSatis.KatalogApi.Dtos;
using IsubuSatis.KatalogApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace IsubuSatis.KatalogApi.Services
{
    public class MongoDbTables
    {
        public static string KategoriTable = "kategori"; 
    }
    public class KategoriService : IKategoriService
    {
        private readonly IMongoCollection<Kategori> _kategoriCollection;
        private readonly MongoDbSettings _mongoDbSettings;

        public KategoriService(IOptions<MongoDbSettings> setting)
        {
            var client = new MongoClient(setting.Value.ConnectionUrl);
            var database = client.GetDatabase(setting.Value.Database);
            _kategoriCollection = database.GetCollection<Kategori>(MongoDbTables.KategoriTable);

        }
        public async Task CreateOrUpdate(CreateOrUpdateKategoriDto input)
        {
            if (input.Id is null)
            {
                await Create(input);
            }
            else
            {
                await Update(input);
            }

        }

        private async Task Update(CreateOrUpdateKategoriDto input)
        {
            throw new NotImplementedException();
        }

        private async Task Create(CreateOrUpdateKategoriDto input)
        {
            _
        }

        public Task<List<KategoriDto>> GetKategoriler()
        {
            throw new NotImplementedException();
        }

        public Task Sil(string id)
        {
            throw new NotImplementedException();
        }
    }
}
