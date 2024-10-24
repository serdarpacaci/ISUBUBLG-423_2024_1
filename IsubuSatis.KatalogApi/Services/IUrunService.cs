using IsubuSatis.KatalogApi.Dtos;

namespace IsubuSatis.KatalogApi.Services
{
    public interface IUrunService
    {
        Task<List<UrunDto>> GetUrunler();

        Task CreateOrUpdate(CreateOrUpdateUrunDto input);

        Task Sil(string id);

    }
}
