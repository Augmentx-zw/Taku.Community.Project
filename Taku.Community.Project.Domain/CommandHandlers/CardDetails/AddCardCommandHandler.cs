using MediatR;
using Taku.Community.Project.Domain.DomainEntities;

namespace Taku.Community.Project.Domain.CommandHandlers.CardDetails
{
    public class AddCardCommand : IRequest
    {
        public Guid CardId { get; set; }
        public Guid UserId { get; set; }
        public Guid AccountId { get; set; }
        public string? CardName { get; set; }
        public int CardNumber { get; set; }
        public int CardCVV { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
    }

    public class AddCardCommandHandler : IRequestHandler<AddCardCommand>
    {
        private readonly IUnitOfWork _uow;
        private readonly IRepository<Card> _repository;

        public AddCardCommandHandler(IUnitOfWork uow, IRepository<Card> repository)
        {
            _uow = uow;
            _repository = repository;
        }

        public async Task Handle(AddCardCommand request, CancellationToken cancellationToken)
        {
           var initCard = new Card
            {
                CardId = Guid.NewGuid(),
                UserId = request.UserId,
                AccountId = request.AccountId,
                CardName = request.CardName,
                CardCVV = request.CardCVV,
                CardNumber = request.CardNumber,
                CreatedOn = DateTime.Now,
                UpdatedOn = DateTime.Now
            };
            await _repository.InsertAsync(initCard);
            await _uow.SaveAsync();
        }

      
    }
}
