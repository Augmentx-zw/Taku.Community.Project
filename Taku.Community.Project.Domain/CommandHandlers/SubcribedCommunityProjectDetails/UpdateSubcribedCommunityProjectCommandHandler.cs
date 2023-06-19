using MediatR;
using Taku.Community.Project.Domain.DomainEntities;

namespace Taku.Community.Project.Domain.CommandHandlers.SubcribedCommunityProjectDetails
{
    public class UpDateSubcribedCommunityProjectCommand : IRequest
    {
        public Guid SubcribedCommunityProjectId { get; set; }
        public bool Recurring { get; set; }
        public int RecurringDays { get; set; }
        public string? Action { get; set; }
        public double Amount { get; set; }
        public DateTime NextDate { get; set; }
        public DateTime UpdatedOn { get; set; }

    }
    public class UpdateSubcribedCommunityProjectCommandHandler : IRequestHandler<UpDateSubcribedCommunityProjectCommand>
    {
        private readonly IUnitOfWork _uow;
        private readonly IRepository<SubcribedCommunityProject> _repository;

        public UpdateSubcribedCommunityProjectCommandHandler(IUnitOfWork uow, IRepository<SubcribedCommunityProject> repository)
        {
            _uow = uow;
            _repository = repository;
        }

        public async Task Handle(UpDateSubcribedCommunityProjectCommand request, CancellationToken cancellationToken)
        {
            SubcribedCommunityProject uSubcribedCommunityProject = await _repository.GetByIDAsync(request.SubcribedCommunityProjectId);
            uSubcribedCommunityProject.Action = request.Action;
            uSubcribedCommunityProject.Amount = request.Amount;
            uSubcribedCommunityProject.Recurring = request.Recurring;
            uSubcribedCommunityProject.RecurringDays = request.RecurringDays;
            uSubcribedCommunityProject.NextDate = request.NextDate;
            uSubcribedCommunityProject.UpdatedOn = DateTime.Now;
            _repository.Update(uSubcribedCommunityProject);
            await _uow.SaveAsync();
        }


    }
}
