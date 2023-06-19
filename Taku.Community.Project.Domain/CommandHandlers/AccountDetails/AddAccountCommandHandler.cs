using MediatR;
using Taku.Community.Project.Domain.DomainEntities;

namespace Taku.Community.Project.Domain.CommandHandlers.AccountDetails
{
    public class AddAccountCommand : IRequest
    {
        public Guid AccountId { get; set; }
        public Guid UserId { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Action { get; set; }
        public double OldBalance { get; set; }
        public double NewBalance { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
    }

    public class AddAccountCommandHandler : IRequestHandler<AddAccountCommand>
    {
        private readonly IUnitOfWork _uow;
        private readonly IRepository<Account> _repository;

        public AddAccountCommandHandler(IUnitOfWork uow, IRepository<Account> repository)
        {
            _uow = uow;
            _repository = repository;
        }

        public async Task Handle(AddAccountCommand request, CancellationToken cancellationToken)
        {
            var initAccount = new Account
            {
                AccountId = Guid.NewGuid(),
                UserId = request.UserId,
                Action = request.Action,
                Name = request.Name,
                Surname = request.Surname,
                OldBalance = request.OldBalance,
                NewBalance = request.NewBalance,
                CreatedOn = DateTime.Now,
                UpdatedOn = DateTime.Now
            };
            await _repository.InsertAsync(initAccount);
            await _uow.SaveAsync();
        }

       
    }
}
