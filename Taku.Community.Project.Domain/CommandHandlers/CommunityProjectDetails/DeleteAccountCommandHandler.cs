using MediatR;
using Taku.Community.Project.Domain.DomainEntities;

namespace Taku.Community.Project.Domain.CommandHandlers.CommunityProjectDetails
{
    public class DeleteCommunityProjectCommand : IRequest
    {
        public Guid ProjectId { get; set; }
    }
    public class DeleteCommunityProjectCommandHandler : IRequestHandler<DeleteCommunityProjectCommand>
    {
        private readonly IUnitOfWork _uow;
        private readonly IRepository<CommunityProject> _repository;

        public DeleteCommunityProjectCommandHandler(IUnitOfWork uow, IRepository<CommunityProject> repository)
        {
            _uow = uow;
            _repository = repository;
        }

        public async Task Handle(DeleteCommunityProjectCommand request, CancellationToken cancellationToken)
        {
            var CommunityProject = await _repository.GetByIDAsync(request.ProjectId);
            _repository.Delete(CommunityProject);
            await _uow.SaveAsync();
        }

    }
}
