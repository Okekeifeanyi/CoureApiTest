using CoureBeTest.Controllers;
using CoureBeTest.Core.Interface.IServices;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace CoureBeTest.Tests.Controllers
{
    public class CountryLookupControllerTests
    {
        [Fact]
        public async Task GetPhoneDetails_ReturnsOk_WhenDataFound()
        {
            // Arrange
            var mockService = new Mock<ICountryLookupService>();
            mockService.Setup(x => x.LookupByPhone("234803"))
                       .ReturnsAsync(new { number = "234803" });

            var controller = new CountryLookupController(mockService.Object);

            // Act
            var result = await controller.GetPhoneDetails("234803");

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task GetPhoneDetails_ReturnsNotFound_WhenNull()
        {
            // Arrange
            var mockService = new Mock<ICountryLookupService>();
            mockService.Setup(x => x.LookupByPhone("999"))
                       .ReturnsAsync((object)null);

            var controller = new CountryLookupController(mockService.Object);

            // Act
            var result = await controller.GetPhoneDetails("999");

            // Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }
    }
}
