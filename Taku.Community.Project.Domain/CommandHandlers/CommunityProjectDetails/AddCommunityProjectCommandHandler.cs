using MediatR;
using Taku.Community.Project.Domain.DomainEntities;

namespace Taku.Community.Project.Domain.CommandHandlers.CommunityProjectDetails
{
    public class AddCommunityProjectCommand : IRequest
    {
        public Guid ProjectId { get; set; }
        public string? Name { get; set; }
        public double FundsRequired { get; set; }
        public double FundsRaised { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
    }

    public class AddCommunityProjectCommandHandler : IRequestHandler<AddCommunityProjectCommand>
    {
        private readonly IUnitOfWork _uow;
        private readonly IRepository<CommunityProject> _repository;

        public AddCommunityProjectCommandHandler(IUnitOfWork uow, IRepository<CommunityProject> repository)
        {
            _uow = uow;
            _repository = repository;
        }

        public async Task Handle(AddCommunityProjectCommand request, CancellationToken cancellationToken)
        {
            var initCommunityProject = new CommunityProject
            {
                ProjectId = Guid.NewGuid(),
                Name = request.Name,
                FundsRequired = request.FundsRequired,
                FundsRaised = request.FundsRaised,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                CreatedOn = DateTime.Now,
                UpdatedOn = DateTime.Now
            };
            await _repository.InsertAsync(initCommunityProject);
            await _uow.SaveAsync();
        }

    }
}
