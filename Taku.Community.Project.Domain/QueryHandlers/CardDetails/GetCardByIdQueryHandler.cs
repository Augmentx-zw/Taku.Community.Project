using MediatR;
using Taku.Community.Project.Domain.DomainEntities;

namespace Taku.Community.Project.Domain.QueryHandlers.CardDetails
{
    public class GetCardByIdQuery : IRequest<Card>
    {
        public Guid CardId { get; set; }
    }

    public class GetCardByIdQueryHandler : IRequestHandler<GetCardByIdQuery, Card>
    {
        private readonly IRepository<Card> _repo;

        public GetCardByIdQueryHandler(IRepository<Card> repo)
        {
            _repo = repo;
        }

        public async Task<Card> Handle(GetCardByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repo.GetByIDAsync(request.CardId);
        }
    }
}
