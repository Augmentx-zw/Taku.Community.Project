using MediatR;
using Taku.Community.Project.Domain.DomainEntities;

namespace Taku.Community.Project.Domain.QueryHandlers.CardDetails
{
    public class GetCardsByUserIdQuery : IRequest<IEnumerable<Card>>
    {
        public Guid UserId { get; set; }
    }

    public class GetCardsByUserIdQueryHandler : IRequestHandler<GetCardsByUserIdQuery, IEnumerable<Card>>
    {
        private readonly IRepository<Card> _repo;

        public GetCardsByUserIdQueryHandler(IRepository<Card> repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<Card>> Handle(GetCardsByUserIdQuery request, CancellationToken cancellationToken)
        {
            return await _repo.GetAsync(c => c.UserId == request.UserId);
        }
    }
}
