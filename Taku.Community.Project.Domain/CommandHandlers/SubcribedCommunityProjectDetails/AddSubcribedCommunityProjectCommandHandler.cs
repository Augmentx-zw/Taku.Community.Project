using MediatR;
using Taku.Community.Project.Domain.DomainEntities;

namespace Taku.Community.Project.Domain.CommandHandlers.SubcribedCommunityProjectDetails
{
    public class AddSubcribedCommunityProjectCommand : IRequest
    {
        public Guid SubcribedCommunityProjectId { get; set; }
        public Guid ProjectId { get; set; }
        public Guid CardId { get; set; }
        public Guid UserId { get; set; }
        public bool Recurring { get; set; }
        public int RecurringDays { get; set; }
        public string? Action { get; set; }
        public double Amount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime NextDate { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
    }

    public class AddSubcribedCommunityProjectCommandHandler : IRequestHandler<AddSubcribedCommunityProjectCommand>
    {
        private readonly IUnitOfWork _uow;
        private readonly IRepository<SubcribedCommunityProject> _repository;

        public AddSubcribedCommunityProjectCommandHandler(IUnitOfWork uow, IRepository<SubcribedCommunityProject> repository)
        {
            _uow = uow;
            _repository = repository;
        }

        public async Task Handle(AddSubcribedCommunityProjectCommand request, CancellationToken cancellationToken)
        {
          
            var initSubcribedCommunityProject = new SubcribedCommunityProject
            {
                SubcribedCommunityProjectId = Guid.NewGuid(),
                UserId = request.UserId,
                ProjectId = request.ProjectId,
                Action = request.Action,
                CardId= request.CardId,
                Amount = request.Amount,
                Recurring = request.Recurring,
                RecurringDays = request.RecurringDays,
                StartDate = request.StartDate,
                NextDate = request.NextDate.AddDays(request.RecurringDays),
                CreatedOn = DateTime.Now,
                UpdatedOn = DateTime.Now
            };
            await _repository.InsertAsync(initSubcribedCommunityProject);
            await _uow.SaveAsync();
        }

       
    }
}
