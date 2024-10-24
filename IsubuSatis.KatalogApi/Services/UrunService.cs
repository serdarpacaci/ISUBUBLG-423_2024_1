using AutoMapper;
using IsubuSatis.KatalogApi.Dtos;
using IsubuSatis.KatalogApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace IsubuSatis.KatalogApi.Services
{
    public class UrunService : IUrunService
    {
        private readonly IMongoCollection<Kategori> _kategoriCollection;
        private readonly IMongoCollection<Urun> _urunCollection;
        private readonly MongoDbSettings _mongoDbSettings;
        private readonly IMapper _mapper;

        public UrunService(IOptions<MongoDbSettings> setting,
            IMapper mapper)
        {
            var client = new MongoClient(setting.Value.ConnectionUrl);
            var database = client.GetDatabase(setting.Value.Database);
            _urunCollection = database.GetCollection<Urun>(MongoDbTables.UrunTable);
            _kategoriCollection = database.GetCollection<Kategori>(MongoDbTables.KategoriTable);

            _mapper = mapper;
        }
        public async Task CreateOrUpdate(CreateOrUpdateUrunDto input)
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

        private async Task Update(CreateOrUpdateUrunDto input)
        {
            var kategori = _urunCollection.AsQueryable()
                .Where(x => x.Id == input.Id)
                .FirstOrDefault();

            _mapper.Map(input, kategori);

            await _urunCollection.ReplaceOneAsync(
                Builders<Urun>.Filter.Eq(x => x.Id, input.Id), kategori);
        }

        private async Task Create(CreateOrUpdateUrunDto input)
        {
            var urun = _mapper.Map<Urun>(input);
            urun.EklenmeTarihi = DateTime.Now;

            await _urunCollection.InsertOneAsync(urun);
        }

        public async Task<List<UrunDto>> GetUrunler()
        {
            var urunler = await _urunCollection.AsQueryable()
                .ToListAsync();

            var kategoriIdList = urunler
                .Select(x => x.KategoriId)
                .Distinct()
                .ToList();

            var kategoriler = _kategoriCollection.AsQueryable()
                .Where(x => kategoriIdList.Contains(x.Id));

            var urunDtoList = _mapper.Map<List<UrunDto>>(urunler);

            urunDtoList.ForEach(x =>
            {
                x.KategoriAdi = kategoriler
                .Where(y => y.Id == x.KategoriId)
                .Select(y => y.Ad)
                .FirstOrDefault() ?? "Belirlenmemiş";
            }
            );
            return urunDtoList;
        }

        public async Task Sil(string id)
        {
            await _urunCollection.DeleteOneAsync(
                Builders<Urun>.Filter.Eq(x => x.Id, id));
        }
    }
}
