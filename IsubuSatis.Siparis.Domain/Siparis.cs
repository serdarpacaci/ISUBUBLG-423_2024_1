using System.ComponentModel.DataAnnotations.Schema;

namespace IsubuSatis.Siparis.Domain
{
    [Table("Siparis")]
    public class Siparis : Entity<int>
    {
        public string UserId { get; set; }

        public Address Adres { get; set; }

        public DateTime SiparisTarihi { get; set; }
        public decimal SiparisTutari { get; set; }

        public List<SiparisUrunBilgi> SiparisUrunleri { get; set; }

    }
}
