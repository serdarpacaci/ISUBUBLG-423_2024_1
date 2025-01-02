using System.ComponentModel.DataAnnotations.Schema;

namespace IsubuSatis.Siparis.Domain
{
    [Table("SiparisUrunBilgi")]
    public class SiparisUrunBilgi : Entity<int>
    {
        public string UrunId { get; set; }
        public string UrunAdi { get; set; }
        public int Adet { get; set; }
        public decimal Fiyat { get; set; }
    }
}
