using IsubuSatis.Siparis.Application.Commands.Dtos;
using MediatR;

namespace IsubuSatis.Siparis.Application.Commands
{
    public class CreateSiparisCommand : IRequest<CreateSiparisDto>
    {
        public string UserId { get; set; }
        public List<SiparisItemDto> SiparisUrunleri { get; set; }
        public AddressDto Address { get; set; }
    }
}
