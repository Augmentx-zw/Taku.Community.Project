using MediatR;
using Taku.Community.Project.Domain.DomainEntities;

namespace Taku.Community.Project.Domain.CommandHandlers.CardDetails
{
    public class DeleteCardCommand : IRequest
    {
        public Guid CardId { get; set; }
    }
    public class DeleteCardCommandHandler : IRequestHandler<DeleteCardCommand>
    {
        private readonly IUnitOfWork _uow;
        private readonly IRepository<Card> _repository;

        public DeleteCardCommandHandler(IUnitOfWork uow, IRepository<Card> repository)
        {
            _uow = uow;
            _repository = repository;
        }

        public async Task Handle(DeleteCardCommand request, CancellationToken cancellationToken)
        {
            var card = await _repository.GetByIDAsync(request.CardId);
            _repository.Delete(card);
            await _uow.SaveAsync();
        }
    }
}
