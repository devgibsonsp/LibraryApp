using Presentation.Controllers;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace Presentation.Tests.Api.Controllers
{
    public class UserControllerTests
    {
        private readonly Mock<ILogger<UserController>> _mockLogger;

        public UserControllerTests()
        {
            // Initialize mock dependencies
            _mockLogger = new Mock<ILogger<UserController>>();
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