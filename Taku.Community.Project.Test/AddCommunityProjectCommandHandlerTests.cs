using Moq;
using Taku.Community.Project.Domain;
using Taku.Community.Project.Domain.CommandHandlers.CommunityProjectDetails;
using Taku.Community.Project.Domain.DomainEntities;

namespace Taku.Community.Project.Test
{
    public class AddCommunityProjectCommandHandlerTests
    {
        [Fact]
        public async Task Handle_ValidRequest_InsertsCommunityProject()
        {
            // Arrange
            var uowMock = new Mock<IUnitOfWork>();
            var repositoryMock = new Mock<IRepository<CommunityProject>>();

            var handler = new AddCommunityProjectCommandHandler(uowMock.Object, repositoryMock.Object);

            var command = new AddCommunityProjectCommand
            {
                ProjectId = Guid.NewGuid(),
                Name = "Project Name",
                FundsRequired = 1000.0,
                FundsRaised = 500.0,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(30),
                CreatedOn = DateTime.Now,
                UpdatedOn = DateTime.Now
            };

            // Act
            await handler.Handle(command, CancellationToken.None);

            // Assert
            repositoryMock.Verify(r => r.InsertAsync(It.IsAny<CommunityProject>()), Times.Once);
            uowMock.Verify(u => u.SaveAsync(), Times.Once);
        }
    }
}
