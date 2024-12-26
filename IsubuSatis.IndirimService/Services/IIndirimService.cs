using IsubuSatis.IndirimService.Models;

namespace IsubuSatis.IndirimService.Services
{
	public interface IIndirimService
	{
		Task<List<Indirim>> GetAllIndirim();
		Task<Indirim> GetById(int id);
		Task Kaydet(Indirim indirim);
		Task Guncelle(Indirim indirim);
		Task Sil(int id);
	}
}
