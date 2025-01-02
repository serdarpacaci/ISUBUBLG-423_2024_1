using IsubuSatis.Siparis.Application.Query.Dtos;
using IsubuSatis.Siparis.Persistence;
using MediatR;

namespace IsubuSatis.Siparis.Application.Query.Handlers
{
    public class GetSiparislerbyUserIdQueryHandler : IRequestHandler<GetSiparislerByUserIdQuery, List<SiparisDto>>
    {
        private readonly SiparisDbContext siparisDbContext;

        public GetSiparislerbyUserIdQueryHandler(SiparisDbContext siparisDbContext)
        {
            this.siparisDbContext = siparisDbContext;
        }
        public Task<List<SiparisDto>> Handle(GetSiparislerByUserIdQuery request, CancellationToken cancellationToken)
        {
            //siparisDbContext.

            return Task.FromResult(new List<SiparisDto>());
        }
    }
}
