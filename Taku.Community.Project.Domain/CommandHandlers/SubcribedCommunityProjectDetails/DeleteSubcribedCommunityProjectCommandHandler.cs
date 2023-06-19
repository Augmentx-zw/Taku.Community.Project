using MediatR;
using Taku.Community.Project.Domain.DomainEntities;

namespace Taku.Community.Project.Domain.CommandHandlers.SubcribedCommunityProjectDetails
{
    public class DeleteSubcribedCommunityProjectCommand : IRequest
    {
        public Guid SubcribedCommunityProjectId { get; set; }
    }
    public class DeleteSubcribedCommunityProjectCommandHandler : IRequestHandler<DeleteSubcribedCommunityProjectCommand>
    {
        private readonly IUnitOfWork _uow;
        private readonly IRepository<SubcribedCommunityProject> _repository;

        public DeleteSubcribedCommunityProjectCommandHandler(IUnitOfWork uow, IRepository<SubcribedCommunityProject> repository)
        {
            _uow = uow;
            _repository = repository;
        }

        public async Task Handle(DeleteSubcribedCommunityProjectCommand request, CancellationToken cancellationToken)
        {
            var SubcribedCommunityProject = await _repository.GetByIDAsync(request.SubcribedCommunityProjectId);
            _repository.Delete(SubcribedCommunityProject);
            await _uow.SaveAsync();
        }

      
    }
}
