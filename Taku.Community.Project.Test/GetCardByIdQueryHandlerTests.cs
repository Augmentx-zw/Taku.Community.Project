using Moq;
using Taku.Community.Project.Domain;
using Taku.Community.Project.Domain.DomainEntities;
using Taku.Community.Project.Domain.QueryHandlers.CardDetails;

namespace YourNamespace.Tests
{
    public class GetCardByIdQueryHandlerTests
    {
        [Fact]
        public async Task Handle_ValidRequest_ReturnsCard()
        {
            // Arrange
            var repositoryMock = new Mock<IRepository<Card>>();

            var handler = new GetCardByIdQueryHandler(repositoryMock.Object);

            var query = new GetCardByIdQuery
            {
                CardId = Guid.NewGuid()
            };

            var expectedCard = new Card
            {
                CardId = query.CardId,
                // Set other properties as needed
            };

            repositoryMock.Setup(r => r.GetByIDAsync(query.CardId)).ReturnsAsync(expectedCard);

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.Equal(expectedCard, result);
            repositoryMock.Verify(r => r.GetByIDAsync(query.CardId), Times.Once);
        }
    }
}
