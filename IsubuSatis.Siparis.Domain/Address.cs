using System.ComponentModel.DataAnnotations.Schema;

namespace IsubuSatis.Siparis.Domain
{
    [Table("Adres")]
    public class Address : Entity<int>
    {
        public string Sehir { get; set; }
        public string Ilce { get; set; }
        public string Mahalle { get; set; }
        public string Cadde { get; set; }
        public string BinaNo { get; set; }
        public string DaireNo { get; set; }

        public Address()
        {
        }

        public Address(string sehir,
            string ilce,
            string mahalle,
            string cadde,
            string binaNo,
            string daireNo)
        {
            Sehir = sehir;
            Ilce = ilce;
            Mahalle = mahalle;
            Cadde = cadde;
            BinaNo = binaNo;
            DaireNo = daireNo;
        }


    }
}
