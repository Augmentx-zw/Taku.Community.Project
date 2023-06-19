using MediatR;
using Taku.Community.Project.Domain.DomainEntities;

namespace Taku.Community.Project.Domain.CommandHandlers.AccountDetails
{
    public class DeleteAccountCommand : IRequest
    {
        public Guid AccountId { get; set; }
    }
    public class DeleteAccountCommandHandler : IRequestHandler<DeleteAccountCommand>
    {
        private readonly IUnitOfWork _uow;
        private readonly IRepository<Account> _repository;

        public DeleteAccountCommandHandler(IUnitOfWork uow, IRepository<Account> repository)
        {
            _uow = uow;
            _repository = repository;
        }

        public async Task Handle(DeleteAccountCommand request, CancellationToken cancellationToken)
        {
            var Account = await _repository.GetByIDAsync(request.AccountId);
            _repository.Delete(Account);
            await _uow.SaveAsync();
        }
       
    }
}
