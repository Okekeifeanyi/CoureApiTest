using CoureBeTest.Controllers;
using CoureBeTest.Core.Interface.IServices;
using CoureBeTest.API.DTOs;
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
                       .ReturnsAsync(new CountryLookupResponseDto
                       {
                           Number = "234803",
                           Country = new CountryDto
                           {
                               CountryCode = "234",
                               Name = "Nigeria",
                               CountryIso = "NG",
                               CountryDetails = new List<OperatorDto>
                               {
                                   new OperatorDto { Operator = "MTN Nigeria", OperatorCode = "MTN NG" }
                               }
                           }
                       });

            var controller = new CountryLookupController(mockService.Object);
            var dto = new CountryLookupRequestDto { PhoneNumber = "234803" };

            // Act
            var result = await controller.GetPhoneDetails(dto);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var response = Assert.IsType<CountryLookupResponseDto>(okResult.Value);
            Assert.Equal("234803", response.Number);
            Assert.Equal("Nigeria", response.Country.Name);
        }

        [Fact]
        public async Task GetPhoneDetails_ReturnsNotFound_WhenNull()
        {
            // Arrange
            var mockService = new Mock<ICountryLookupService>();
            mockService.Setup(x => x.LookupByPhone("999"))
                       .ReturnsAsync((CountryLookupResponseDto?)null);

            var controller = new CountryLookupController(mockService.Object);
            var dto = new CountryLookupRequestDto { PhoneNumber = "999" };

            // Act
            var result = await controller.GetPhoneDetails(dto);

            // Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }
    }
}
