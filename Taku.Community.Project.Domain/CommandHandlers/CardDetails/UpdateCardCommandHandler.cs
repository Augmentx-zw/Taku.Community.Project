using MediatR;
using Taku.Community.Project.Domain.DomainEntities;

namespace Taku.Community.Project.Domain.CommandHandlers.CardDetails
{
    public class UpDateCardCommand : IRequest
    {
        public Guid CardId { get; set; }
        public Guid UserId { get; set; }
        public Guid AccountId { get; set; }
        public string? CardName { get; set; }
        public int CardNumber { get; set; }
        public int CardCVV { get; set; }
        public DateTime UpdatedOn { get; set; }

    }
    public class UpdateCardCommandHandler : IRequestHandler<UpDateCardCommand>
    {
        private readonly IUnitOfWork _uow;
        private readonly IRepository<Card> _repository;

        public UpdateCardCommandHandler(IUnitOfWork uow, IRepository<Card> repository)
        {
            _uow = uow;
            _repository = repository;
        }

        public async Task Handle(UpDateCardCommand request, CancellationToken cancellationToken)
        {

            Card uCard = await _repository.GetByIDAsync(request.CardId);
            uCard.CardNumber = request.CardNumber;
            uCard.CardName = request.CardName;
            uCard.CardCVV = request.CardCVV;
            uCard.AccountId = request.AccountId;
            uCard.UpdatedOn = DateTime.Now;
            _repository.Update(uCard);
            await _uow.SaveAsync();
        }

       

    }
}
