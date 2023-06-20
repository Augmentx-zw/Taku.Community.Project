using Moq;
using Taku.Community.Project.Domain;
using Taku.Community.Project.Domain.CommandHandlers.AccountDetails;
using Taku.Community.Project.Domain.DomainEntities;

namespace Taku.Community.Project.Test
{
    public class AddAccountCommandHandlerTests
    {
        [Fact]
        public async Task Handle_ValidRequest_InsertsAccount()
        {
            // Arrange
            var uowMock = new Mock<IUnitOfWork>();
            var repositoryMock = new Mock<IRepository<Account>>();

            var handler = new AddAccountCommandHandler(uowMock.Object, repositoryMock.Object);

            var command = new AddAccountCommand
            {
                AccountId = Guid.NewGuid(),
                UserId = Guid.NewGuid(),
                Action = "SomeAction",
                Name = "John",
                Surname = "Doe",
                OldBalance = 100.0,
                NewBalance = 200.0,
                CreatedOn = DateTime.Now,
                UpdatedOn = DateTime.Now
            };

            // Act
            await handler.Handle(command, CancellationToken.None);

            // Assert
            repositoryMock.Verify(r => r.InsertAsync(It.IsAny<Account>()), Times.Once);
            uowMock.Verify(u => u.SaveAsync(), Times.Once);
        }
    }
}
