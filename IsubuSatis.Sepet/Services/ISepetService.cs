using IsubuSatis.Sepet.Models;

namespace IsubuSatis.Sepet.Services
{
    public interface ISepetService
    {
        Task<SepetDto> GetSepet(string userId);

        Task SepetiKaydet(SepetDto sepetDto);

        Task SepetiBosalt(string userId);
    }
}
