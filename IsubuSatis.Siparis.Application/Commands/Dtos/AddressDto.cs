using IsubuSatis.Siparis.Application.Dtos;

namespace IsubuSatis.Siparis.Application.Commands.Dtos
{
    public class AddressDto : EntityDto<int>
    {
        public string Sehir { get; set; }
        public string Ilce { get; set; }
        public string Mahalle { get; set; }
        public string Cadde { get; set; }
        public string BinaNo { get; set; }
        public string DaireNo { get; set; }
    }
}
