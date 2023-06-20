using Moq;
using Taku.Community.Project.Domain;
using Taku.Community.Project.Domain.CommandHandlers.CardDetails;
using Taku.Community.Project.Domain.DomainEntities;

namespace Taku.Community.Project.Test
{
    public class AddCardCommandHandlerTests
    {
        [Fact]
        public async Task Handle_ValidRequest_InsertsCard()
        {
            // Arrange
            var uowMock = new Mock<IUnitOfWork>();
            var repositoryMock = new Mock<IRepository<Card>>();

            var handler = new AddCardCommandHandler(uowMock.Object, repositoryMock.Object);

            var command = new AddCardCommand
            {
                CardId = Guid.NewGuid(),
                UserId = Guid.NewGuid(),
                AccountId = Guid.NewGuid(),
                CardName = "Card Name",
                CardNumber = 123456789,
                CardCVV = 123,
                CreatedOn = DateTime.Now,
                UpdatedOn = DateTime.Now
            };

            // Act
            await handler.Handle(command, CancellationToken.None);

            // Assert
            repositoryMock.Verify(r => r.InsertAsync(It.IsAny<Card>()), Times.Once);
            uowMock.Verify(u => u.SaveAsync(), Times.Once);
        }
    }
}
