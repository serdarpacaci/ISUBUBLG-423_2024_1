namespace IsubuSatis.Sepet.Models
{
    public class SepetDto
    {
        public string UserId { get; set; }
        public List<SepetItemDto> Urunler { get; set; }

        public decimal SepetTutari => Urunler.Sum(x => x.Adet * x.Fiyat);

        public SepetDto()
        {
            Urunler = new List<SepetItemDto>(); 
        }
    }


    public class SepetItemDto
    {
        public Guid UrunId { get; set; }
        public string UrunAdi { get; set; }

        public int Adet { get; set; }
        public decimal Fiyat { get; set; }
        public bool SeciliMi { get; set; }

    }
}
