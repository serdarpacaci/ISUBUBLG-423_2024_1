using IsubuSatis.Siparis.Application.Dtos;

namespace IsubuSatis.Siparis.Application.Commands.Dtos
{
    public class SiparisItemDto : EntityDto<int>
    {
        public Guid UrunId { get; set; }
        public string UrunAdi { get; set; }
        public string FotografUrl { get; set; }
        public int Adet { get; set; }
        public decimal Fiyat { get; set; }
    }
}
