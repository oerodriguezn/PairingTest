using NUnit.Framework;
using PairingTest.Web.Controllers;
using PairingTest.Web.Models;
using System.Linq;

namespace PairingTest.Unit.Tests.Web
{
    [TestFixture, Category("IntegrationTest")]
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
        [Test]
        public void SaveAndValidateQuestionnaire()
        {
            //Arrange
            var questionnaireController = new QuestionnaireController();
            var expectedQuestionnaire = (QuestionnaireLibrary.Questionnaire)questionnaireController.Index().ViewData.Model;
            expectedQuestionnaire.Questions.ForEach(p => p.UserAnswer = "Bad");
            //Act
            var result = (QuestionnaireLibrary.Questionnaire)questionnaireController.Index(expectedQuestionnaire).ViewData.Model;

            //Assert
            Assert.IsTrue(result.Questions.Where(p=>p.IsCorrect).Count() == 0);
        }
    }
}