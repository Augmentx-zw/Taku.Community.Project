using MediatR;
using Taku.Community.Project.Domain.DomainEntities;

namespace Taku.Community.Project.Domain.QueryHandlers.CommunityProjectDetails
{
    public class GetCommunityProjectByIdQuery : IRequest<CommunityProject>
    {
        public Guid ProjectId { get; set; }
    }

    public class GetCommunityProjectByIdQueryHandler : IRequestHandler<GetCommunityProjectByIdQuery, CommunityProject>
    {
        private readonly IRepository<CommunityProject> _repo;

        public GetCommunityProjectByIdQueryHandler(IRepository<CommunityProject> repo)
        {
            _repo = repo;
        }

        public async Task<CommunityProject> Handle(GetCommunityProjectByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repo.GetByIDAsync(request.ProjectId);
        }
    }
}
