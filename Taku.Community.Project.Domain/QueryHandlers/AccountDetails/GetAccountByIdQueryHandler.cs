using MediatR;
using Taku.Community.Project.Domain.DomainEntities;

namespace Taku.Community.Project.Domain.QueryHandlers.AccountDetails
{
    public class GetAccountByIdQuery : IRequest<Account>
    {
        public Guid AccountId { get; set; }
    }

    public class GetAccountByIdQueryHandler : IRequestHandler<GetAccountByIdQuery, Account>
    {
        private readonly IRepository<Account> _repo;

        public GetAccountByIdQueryHandler(IRepository<Account> repo)
        {
            _repo = repo;
        }

        public async Task<Account> Handle(GetAccountByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repo.GetByIDAsync(request.AccountId);
        }
    }
}
