using NUnit.Framework;
using PairingTest.Web.Controllers;
using PairingTest.Web.Models;

namespace PairingTest.Unit.Tests.Web
{
    [TestFixture]
    public class QuestionnaireControllerTests
    {
        [Test]
        public void ShouldGetQuestions()
        {
            //Arrange
            var expectedTitle = "Geography Questions";
            var questionnaireController = new QuestionnaireController();

            //Act
            var result = (QuestionnaireLibrary.Questionnaire)questionnaireController.Index().ViewData.Model;
            
            //Assert
            Assert.That(result.Title, Is.EqualTo(expectedTitle));
        }
    }
}