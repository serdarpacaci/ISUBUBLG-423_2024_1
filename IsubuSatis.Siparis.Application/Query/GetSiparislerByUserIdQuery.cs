using IsubuSatis.Siparis.Application.Query.Dtos;
using MediatR;

namespace IsubuSatis.Siparis.Application.Query
{
    public class GetSiparislerByUserIdQuery : IRequest<List<SiparisDto>>
    {
        public string UserId { get; set; }
    }

  
}
