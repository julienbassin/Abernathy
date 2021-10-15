using System.Collections.Generic;
using System.Threading.Tasks;
using Abernathy.Demographics.Service.Controllers;
using Abernathy.Demographics.Service.Models.DTOs;
using Abernathy.Demographics.Service.Models.Entities;
using Abernathy.Demographics.Service.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Abernaty.Demographics.Test.Unit.ControllerTests
{
    //public class PatientControllerTest
    //{
    //    [Fact]
    //    public async Task TestGetAll()
    //    {
    //        // Arrange
    //        var mockService = new Mock<IPatientService>();
    //        mockService
    //            .Setup(x => x.GetAll())
    //            .ReturnsAsync(new List<PatientDto> { new PatientDto { Id = 1 } })
    //            .Verifiable();

    //        var controller = new PatientController(mockService.Object);

    //        // Act
    //        var result = await controller.Get();

    //        // Assert
    //        var actionResult =
    //            Assert.IsAssignableFrom<OkObjectResult>(result.Result);
    //        var objectResult =
    //            Assert.IsAssignableFrom<IEnumerable<PatientDto>>(actionResult.Value);

    //        mockService
    //            .Verify(x => x.GetAll(), Times.Once());
    //    }

    //    [Fact]
    //    public async Task TestGetAllNoEntities()
    //    {
    //        // Arrange
    //        var mockService = new Mock<IPatientService>();
    //        mockService
    //            .Setup(x => x.GetAll())
    //            .ReturnsAsync(new List<PatientDto>())
    //            .Verifiable();

    //        var controller = new PatientController(mockService.Object);

    //        // Act
    //        var result = await controller.Get();

    //        // Assert
    //        Assert.IsAssignableFrom<NotFoundObjectResult>(result.Result);

    //        mockService
    //            .Verify(x => x.GetAll(), Times.Once());
    //    }

    //    [Fact]
    //    public async Task TestGetIdInvalid()
    //    {
    //        // Arrange
    //        var controller = new PatientController(null);

    //        // Act
    //        var result = await controller.GetById(0);

    //        // Assert
    //        ObjectResult objectResponse = Assert.IsType<ObjectResult>(result);

    //        Assert.Equal(500, objectResponse.StatusCode);
    //    }

    //    [Fact]
    //    public async Task TestGetIdBad()
    //    {
    //        // Arrange
    //        var mockService = new Mock<IPatientService>();
    //        mockService
    //            .Setup(x => x.GetPatientById(666))
    //            .ReturnsAsync((PatientDto)null);

    //        var controller = new PatientController(mockService.Object);

    //        // Act
    //        var result = await controller.GetById(666);

    //        // Assert
    //        ObjectResult objectResponse = Assert.IsType<ObjectResult>(result);

    //        Assert.Equal(500, objectResponse.StatusCode);
    //    }

    //    [Fact]
    //    //public async Task TestGetIdValid()
    //    //{
    //    //    // Arrange
    //    //    var mockService = new Mock<IPatientService>();
    //    //    mockService
    //    //        .Setup(x => x.GetPatientById(5))
    //    //        .ReturnsAsync(new PatientDto { Id = 5 });

    //    //    var controller = new PatientController(mockService.Object);

    //    //    // Act
    //    //    var result = await controller.GetById(5);

    //    //    // Assert
    //    //    var actionResult =
    //    //        Assert.IsAssignableFrom<OkObjectResult>(result.Result);
    //    //    var objectResult =
    //    //        Assert.IsAssignableFrom<PatientDto>(actionResult.Value);

    //    //    mockService
    //    //        .Verify(x => x.GetPatientById(5), Times.Once);
    //    //}

    //    [Fact]
    //    public async Task TestPostModelNull()
    //    {
    //        // Arrange
    //        var controller = new PatientController(null);

    //        // Act
    //        var result = await controller.Add(null);

    //        // Assert
    //        Assert.IsAssignableFrom<BadRequestResult>(result);
    //    }

    //    [Fact]
    //    public async Task TestPostModelNotNull()
    //    {
    //        // Arrange
    //        var mockService = new Mock<IPatientService>();
    //        mockService
    //            .Setup(x => x.Create(It.IsAny<CreatedPatientDto>()))
    //            .ReturnsAsync(new PatientDto());

    //        var controller = new PatientController(mockService.Object);

    //        // Act
    //        var result = await controller.Add(new PatientDto());

    //        // Assert
    //        var actionResult =
    //            Assert.IsAssignableFrom<CreatedAtActionResult>(result);

    //        Assert.Equal("Get", actionResult.ActionName);

    //        var modelResult =
    //            Assert.IsAssignableFrom<Patient>(actionResult.Value);
    //    }

    //    [Theory]
    //    [InlineData(0)]
    //    [InlineData(-1)]
    //    public async Task TestPutIdBad(int testId)
    //    {
    //        // Arrange
    //        var controller = new PatientController(null);

    //        // Act
    //        var result = await controller.Update(testId, null);

    //        // Assert
    //        Assert.IsAssignableFrom<BadRequestResult>(result);
    //    }

    //    [Fact]
    //    public async Task TestPutModelNull()
    //    {
    //        // Arrange
    //        var controller = new PatientController(null);

    //        // Act
    //        var result = await controller.Update(1, null);

    //        // Assert
    //        Assert.IsAssignableFrom<BadRequestResult>(result);
    //    }

    //    [Fact]
    //    //public async Task TestControllerEntityNotFound()
    //    //{
    //    //    // Arrange
    //    //    var mockService = new Mock<IPatientService>();
    //    //    mockService
    //    //        .Setup(x => x.GetPatientById(5))
    //    //        .ReturnsAsync(new PatientDto { Id = 5, Age = 33 });

    //    //    var controller = new PatientController(mockService.Object);

    //    //    // Act
    //    //    var result = await controller.Update(1, new UpdatePatientDto());

    //    //    // Assert
    //    //    Assert.IsAssignableFrom<NotFoundResult>(result);
    //    //}
    //}
}
