using Moq;
using Taku.Community.Project.Domain;
using Taku.Community.Project.Domain.DomainEntities;
using Taku.Community.Project.Domain.QueryHandlers.AccountDetails;

namespace YourNamespace.Tests
{
    public class GetAccountByIdQueryHandlerTests
    {
        [Fact]
        public async Task Handle_ValidRequest_ReturnsAccount()
        {
            // Arrange
            var repositoryMock = new Mock<IRepository<Account>>();

            var handler = new GetAccountByIdQueryHandler(repositoryMock.Object);

            var query = new GetAccountByIdQuery
            {
                AccountId = Guid.NewGuid()
            };

            var expectedAccount = new Account
            {
                AccountId = query.AccountId,
                // Set other properties as needed
            };

            repositoryMock.Setup(r => r.GetByIDAsync(query.AccountId)).ReturnsAsync(expectedAccount);

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.Equal(expectedAccount, result);
            repositoryMock.Verify(r => r.GetByIDAsync(query.AccountId), Times.Once);
        }
    }
}
