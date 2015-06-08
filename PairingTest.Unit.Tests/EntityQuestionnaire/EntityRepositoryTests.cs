using NUnit.Framework;
using PairingTest.Unit.Tests.QuestionServiceWcf.Stubs;
using QuestionnaireLibrary;
using QuestionServiceWcf;
using System.Linq;

namespace PairingTest.Unit.Tests.EntityRepository
{
    [TestFixture, Category("UnitTest")]
    [TestFixture(0,"","","","")]
    [TestFixture(1, "habana", "", "", "")]
    [TestFixture(2, "habana", "paris", "", "")]
    public class EntityRepositoryTests
    {
        private string Answer1;
        private string Answer2;
        private string Answer3;
        private string Answer4;
        private int CorrectAnswers;
        public EntityRepositoryTests(int CorrectAnswers, string Answer1, string Answer2, string Answer3, string Answer4)
        {
            this.Answer1 = Answer1;
            this.Answer2 = Answer2;
            this.Answer3 = Answer3;
            this.Answer4 = Answer4;
            this.CorrectAnswers = CorrectAnswers;
        }
        [Test]
        public void EFrepositoryShouldGetQuestions()
        {
            //Arrange
            var QuestionRepository = new QuestionnaireDataAccess.EntityQuestionRepository();
            var questionService = new QuestionService(QuestionRepository);

            //Act
            var questions = questionService.GetQuestionaire();

            //Assert
            Assert.IsTrue(questions.Questions.Count ==4);
           
        }
        [Test]
        public void EFrepositoryValidateQuestionsAnswer()
        {
            //Arrange
            var QuestionRepository = new QuestionnaireDataAccess.EntityQuestionRepository();

            var questionService = new QuestionService(QuestionRepository);
            //Act
            var questions = questionService.GetQuestionaire();

            questions.Questions.ElementAt(0).UserAnswer = Answer1;
            questions.Questions.ElementAt(1).UserAnswer = Answer2;
            questions.Questions.ElementAt(2).UserAnswer = Answer3;
            questions.Questions.ElementAt(3).UserAnswer = Answer4;

            questionService.SaveAndValidateQuestionnaire(questions, new User() { Name = "test" });

            Assert.AreEqual(CorrectAnswers, questions.Questions.Where(p => p.IsCorrect).Count());
        }
    }
}