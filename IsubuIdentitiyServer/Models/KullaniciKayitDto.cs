using System.ComponentModel.DataAnnotations;

namespace IsubuIdentitiyServer.Models
{
    public class KullaniciKayitDto
    {
        [Required]
        public string KullaniciAdi { get; set; }

        public string Eposta { get; set; }
        public string Sifre { get; set; }
    }
}
