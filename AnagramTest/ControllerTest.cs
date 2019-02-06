using System;
using System.Collections.Generic;
using NUnit.Framework;
using Moq;
using System.Web.Http.Results;



namespace AnagramTest
{
   
    [TestFixture]
    public class ControllerTest
    {
        private Mock<AnagramRepository.IAnagramRepository> _mockRepo;
        private Mock<Anagram.Business.IAnagramCalculatorBusiness> _mockBusiness; 
        
        private Anagram.Controllers.AnagramController _controller;

        [SetUp]
        public void Init()
        {
            _mockRepo = new Mock<AnagramRepository.IAnagramRepository>();
            _mockBusiness = new Mock<Anagram.Business.IAnagramCalculatorBusiness>();
            _controller = new Anagram.Controllers.AnagramController(_mockBusiness.Object);
        }

        
        [Test]
        public void Controller_ReturnsBadRequestIfCallWithoutValue()
        {
            //Arrange
            _mockBusiness.Setup(x => x.GetFormattedAnagrams(String.Empty))
                .Returns(new Anagram.Models.AnagramDataModel(new List<string>(), 0));

            //Act 
            BadRequestErrorMessageResult result = _controller.Get(String.Empty) as BadRequestErrorMessageResult;

            //Assert
            Assert.AreEqual("Value is mandatory", result.Message);
        }

        [Test]
        public void Controller_ReturnsOkResultIfWordHasValue()
        {
            //Arrange
            _mockBusiness.Setup(x => x.GetFormattedAnagrams(String.Empty))
                .Returns(new Anagram.Models.AnagramDataModel(new List<string>(), 0));

            //Act
            OkNegotiatedContentResult<Anagram.Models.AnagramDataModel> result =
               _controller.Get("test") as OkNegotiatedContentResult<Anagram.Models.AnagramDataModel>;

            //Assert
            Assert.NotNull(result);
        }
    }
}
