using Moq;
using Taku.Community.Project.Domain;
using Taku.Community.Project.Domain.CommandHandlers.SubcribedCommunityProjectDetails;
using Taku.Community.Project.Domain.DomainEntities;

namespace Taku.Community.Project.Test
{
    public class AddSubcribedCommunityProjectCommandHandlerTests
    {
        [Fact]
        public async Task Handle_ValidRequest_InsertsSubcribedCommunityProject()
        {
            // Arrange
            var uowMock = new Mock<IUnitOfWork>();
            var repositoryMock = new Mock<IRepository<SubcribedCommunityProject>>();

            var handler = new AddSubcribedCommunityProjectCommandHandler(uowMock.Object, repositoryMock.Object);

            var command = new AddSubcribedCommunityProjectCommand
            {
                SubcribedCommunityProjectId = Guid.NewGuid(),
                ProjectId = Guid.NewGuid(),
                CardId = Guid.NewGuid(),
                UserId = Guid.NewGuid(),
                Recurring = true,
                RecurringDays = 7,
                Action = "SomeAction",
                Amount = 100.0,
                StartDate = DateTime.Now,
                NextDate = DateTime.Now.AddDays(7),
                CreatedOn = DateTime.Now,
                UpdatedOn = DateTime.Now
            };

            // Act
            await handler.Handle(command, CancellationToken.None);

            // Assert
            repositoryMock.Verify(r => r.InsertAsync(It.IsAny<SubcribedCommunityProject>()), Times.Once);
            uowMock.Verify(u => u.SaveAsync(), Times.Once);
        }
    }
}
