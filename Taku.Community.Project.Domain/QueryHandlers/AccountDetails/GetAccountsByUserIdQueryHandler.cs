using MediatR;
using Taku.Community.Project.Domain.DomainEntities;

namespace Taku.Community.Project.Domain.QueryHandlers.AccountDetails
{
    public class GetAccountsByUserIdQuery : IRequest<IEnumerable<Account>>
    {
        public Guid UserId { get; set; }
    }

    public class GetAccountsByUserIdQueryHandler : IRequestHandler<GetAccountsByUserIdQuery, IEnumerable<Account>>
    {
        private readonly IRepository<Account> _repo;

        public GetAccountsByUserIdQueryHandler(IRepository<Account> repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<Account>> Handle(GetAccountsByUserIdQuery request, CancellationToken cancellationToken)
        {
            return await _repo.GetAsync(c => c.UserId == request.UserId);
        }
    }
}
