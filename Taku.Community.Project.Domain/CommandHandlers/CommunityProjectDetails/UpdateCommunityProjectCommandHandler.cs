using MediatR;
using Taku.Community.Project.Domain.DomainEntities;

namespace Taku.Community.Project.Domain.CommandHandlers.CommunityProjectDetails
{
    public class UpDateCommunityProjectCommand : IRequest
    {
        public Guid ProjectId { get; set; }
        public string? Name { get; set; }
        public double FundsRequired { get; set; }
        public double FundsRaised { get; set; }
        public DateTime UpdatedOn { get; set; }

    }
    public class UpdateCommunityProjectCommandHandler : IRequestHandler<UpDateCommunityProjectCommand>
    {
        private readonly IUnitOfWork _uow;
        private readonly IRepository<CommunityProject> _repository;

        public UpdateCommunityProjectCommandHandler(IUnitOfWork uow, IRepository<CommunityProject> repository)
        {
            _uow = uow;
            _repository = repository;
        }

        public async Task Handle(UpDateCommunityProjectCommand request, CancellationToken cancellationToken)
        {
            var uCommunityProject = await _repository.GetByIDAsync(request.ProjectId);
            uCommunityProject.Name = request.Name;
            uCommunityProject.FundsRequired = request.FundsRequired;
            uCommunityProject.FundsRaised = request.FundsRaised;
            uCommunityProject.UpdatedOn = DateTime.Now;
            _repository.Update(uCommunityProject);
            await _uow.SaveAsync();
        }

       

    }
}
