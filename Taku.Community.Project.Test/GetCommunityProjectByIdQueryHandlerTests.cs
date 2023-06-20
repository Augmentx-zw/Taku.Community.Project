using Moq;
using Taku.Community.Project.Domain;
using Taku.Community.Project.Domain.DomainEntities;
using Taku.Community.Project.Domain.QueryHandlers.CommunityProjectDetails;

namespace Taku.Community.Project.Test
{
    public class GetCommunityProjectByIdQueryHandlerTests
    {
        [Fact]
        public async Task Handle_ValidRequest_ReturnsCommunityProject()
        {
            // Arrange
            var repositoryMock = new Mock<IRepository<CommunityProject>>();

            var handler = new GetCommunityProjectByIdQueryHandler(repositoryMock.Object);

            var query = new GetCommunityProjectByIdQuery
            {
                ProjectId = Guid.NewGuid()
            };

            var expectedProject = new CommunityProject
            {
                ProjectId = query.ProjectId,
            };

            repositoryMock.Setup(r => r.GetByIDAsync(query.ProjectId)).ReturnsAsync(expectedProject);

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.Equal(expectedProject, result);
            repositoryMock.Verify(r => r.GetByIDAsync(query.ProjectId), Times.Once);
        }
    }
}
