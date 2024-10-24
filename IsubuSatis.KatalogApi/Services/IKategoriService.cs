using IsubuSatis.KatalogApi.Dtos;

namespace IsubuSatis.KatalogApi.Services
{
    public interface IKategoriService
    {
        Task<List<KategoriDto>> GetKategoriler();

        Task CreateOrUpdate(CreateOrUpdateKategoriDto input);

        Task Sil(string id);

    }
}
