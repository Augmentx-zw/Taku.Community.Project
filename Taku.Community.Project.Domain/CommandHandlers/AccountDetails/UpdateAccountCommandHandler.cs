using MediatR;
using Taku.Community.Project.Domain.DomainEntities;

namespace Taku.Community.Project.Domain.CommandHandlers.AccountDetails
{
    public class UpDateAccountCommand : IRequest
    {
        public Guid AccountId { get; set; }
        public string? Action { get; set; }
        public double OldBalance { get; set; }
        public double NewBalance { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }

    }
    public class UpdateAccountCommandHandler : IRequestHandler<UpDateAccountCommand>
    {
        private readonly IUnitOfWork _uow;
        private readonly IRepository<Account> _repository;

        public UpdateAccountCommandHandler(IUnitOfWork uow, IRepository<Account> repository)
        {
            _uow = uow;
            _repository = repository;
        }

        public async Task Handle(UpDateAccountCommand request, CancellationToken cancellationToken)
        {
            Account uAccount = await _repository.GetByIDAsync(request.AccountId);
            uAccount.Action = request.Action;
            uAccount.NewBalance = request.NewBalance;
            uAccount.OldBalance = request.OldBalance;
            uAccount.UpdatedOn = DateTime.Now;
            _repository.Update(uAccount);
            await _uow.SaveAsync();
        }

    }
}
