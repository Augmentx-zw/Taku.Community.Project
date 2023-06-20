using Moq;
using Taku.Community.Project.Domain;
using Taku.Community.Project.Domain.DomainEntities;
using Taku.Community.Project.Domain.QueryHandlers.SubcribedCommunityProjectDetails;

namespace YourNamespace.Tests
{
    public class GetSubcribedCommunityProjectByIdQueryHandlerTests
    {
        [Fact]
        public async Task Handle_ValidRequest_ReturnsSubcribedCommunityProject()
        {
            // Arrange
            var repositoryMock = new Mock<IRepository<SubcribedCommunityProject>>();

            var handler = new GetSubcribedCommunityProjectByIdQueryHandler(repositoryMock.Object);

            var query = new GetSubcribedCommunityProjectByIdQuery
            {
                SubcribedCommunityProjectId = Guid.NewGuid()
            };

            var expectedProject = new SubcribedCommunityProject
            {
                SubcribedCommunityProjectId = query.SubcribedCommunityProjectId,
            };

            repositoryMock.Setup(r => r.GetByIDAsync(query.SubcribedCommunityProjectId)).ReturnsAsync(expectedProject);

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.Equal(expectedProject, result);
            repositoryMock.Verify(r => r.GetByIDAsync(query.SubcribedCommunityProjectId), Times.Once);
        }
    }
}
