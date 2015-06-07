using NUnit.Framework;
using QuestionServiceWcf;

namespace PairingTest.Unit.Tests.QuestionServiceWcf
{
    [TestFixture]
    public class QuestionRepositoryTests
    {
        [Test]
        public void ShouldGetExpectedQuestionnaire()
        {
            var questionRepository = new QuestionRepository();

            var questionnaire = questionRepository.GetQuestionnaire();

            Assert.That(questionnaire.Title, Is.EqualTo("Geography Questions"));
            Assert.That(questionnaire.Questions[0].QuestionText, Is.EqualTo("What is the capital of Cuba?"));
            Assert.That(questionnaire.Questions[1].QuestionText, Is.EqualTo("What is the capital of France?"));
            Assert.That(questionnaire.Questions[2].QuestionText, Is.EqualTo("What is the capital of Poland?"));
            Assert.That(questionnaire.Questions[3].QuestionText, Is.EqualTo("What is the capital of Germany?"));
        }
    }
}