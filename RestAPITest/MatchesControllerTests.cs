using Microsoft.AspNetCore.Mvc;
using OurRestAPI.Controllers;
namespace RestAPITest
{
    public class MatchesControllerTests
    {
        public MatchesController _controller;

        [SetUp]
        public void Setup()
        {
            _controller = new MatchesController();
        }
        [Test]
        public void GetShouldReturnSuccessMessage()
        {
            // Act
            IActionResult result = _controller.Index();

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result, "Expected OkObjectResult");

            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);

            // Check the returned object
            dynamic? data = okResult.Value;
            Assert.IsNotNull(data as String);
        }
    }
}
