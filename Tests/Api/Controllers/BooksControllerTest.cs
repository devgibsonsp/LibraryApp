using Api.Controllers;
using Presentation.Controllers;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace Presentation.Tests.Api.Controllers
{
    public class BooksControllerTests
    {
        private readonly Mock<ILogger<TestController>> _mockLogger;

        public BooksControllerTests()
        {
            // Initialize mock dependencies
            _mockLogger = new Mock<ILogger<TestController>>();
        }

        [Fact]
        public void Get_ReturnsTrue()
        {
            // Arrange
            var controller = new UserController(_mockLogger.Object);

            // Act
            var result = controller.Get();

            // Assert
            Assert.True(result); // Stubbed to check the return value is true
        }
    }
}