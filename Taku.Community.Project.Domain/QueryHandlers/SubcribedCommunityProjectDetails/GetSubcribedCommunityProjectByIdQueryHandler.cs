using MediatR;
using Taku.Community.Project.Domain.DomainEntities;

namespace Taku.Community.Project.Domain.QueryHandlers.SubcribedCommunityProjectDetails
{
    public class GetSubcribedCommunityProjectByIdQuery : IRequest<SubcribedCommunityProject>
    {
        public Guid SubcribedCommunityProjectId { get; set; }
    }

    public class GetSubcribedCommunityProjectByIdQueryHandler : IRequestHandler<GetSubcribedCommunityProjectByIdQuery, SubcribedCommunityProject>
    {
        private readonly IRepository<SubcribedCommunityProject> _repo;

        public GetSubcribedCommunityProjectByIdQueryHandler(IRepository<SubcribedCommunityProject> repo)
        {
            _repo = repo;
        }

        public async Task<SubcribedCommunityProject> Handle(GetSubcribedCommunityProjectByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repo.GetByIDAsync(request.SubcribedCommunityProjectId);
        }
    }
}
