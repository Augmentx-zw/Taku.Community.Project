using MediatR;
using Taku.Community.Project.Domain.DomainEntities;

namespace Taku.Community.Project.Domain.QueryHandlers.CommunityProjectDetails
{
    public class GetCommunityProjectsQuery : IRequest<IEnumerable<CommunityProject>>
    {
    }

    public class GetCommunityProjectsQueryHandler : IRequestHandler<GetCommunityProjectsQuery, IEnumerable<CommunityProject>>
    {
        private readonly IRepository<CommunityProject> _repo;

        public GetCommunityProjectsQueryHandler(IRepository<CommunityProject> repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<CommunityProject>> Handle(GetCommunityProjectsQuery request, CancellationToken cancellationToken)
        {
            return await _repo.GetAsync();
        }
    }
}
