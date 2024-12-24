using Presentation.Controllers;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace Presentation.Tests.Api.Controllers
{
    public class ReviewsControllerTests
    {
        private readonly Mock<ILogger<ReviewsController>> _mockLogger;

        public ReviewsControllerTests()
        {
            // Initialize mock dependencies
            _mockLogger = new Mock<ILogger<ReviewsController>>();
        }

        [Fact]
        public void Get_ReturnsTrue()
        {
            // Arrange
            var controller = new ReviewsController(_mockLogger.Object);

            // Act
            var result = controller.Get();

            // Assert
            Assert.True(result); // Stubbed to check the return value is true
        }
    }
}