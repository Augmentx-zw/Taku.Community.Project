using MediatR;
using Taku.Community.Project.Domain.DomainEntities;

namespace Taku.Community.Project.Domain.QueryHandlers.SubcribedCommunityProjectDetails
{
    public class GetSubcribedCommunityProjectsByUserIdQuery : IRequest<IEnumerable<SubcribedCommunityProject>>
    {
        public Guid UserId { get; set; }
    }

    public class GetSubcribedCommunityProjectsByUserIdQueryHandler : IRequestHandler<GetSubcribedCommunityProjectsByUserIdQuery, IEnumerable<SubcribedCommunityProject>>
    {
        private readonly IRepository<SubcribedCommunityProject> _repo;

        public GetSubcribedCommunityProjectsByUserIdQueryHandler(IRepository<SubcribedCommunityProject> repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<SubcribedCommunityProject>> Handle(GetSubcribedCommunityProjectsByUserIdQuery request, CancellationToken cancellationToken)
        {
            return await _repo.GetAsync(c => c.UserId == request.UserId);
        }
    }
}
