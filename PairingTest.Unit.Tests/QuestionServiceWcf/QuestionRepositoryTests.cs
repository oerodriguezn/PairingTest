using NUnit.Framework;
using PairingTest.Unit.Tests.QuestionServiceWcf.Stubs;
using QuestionServiceWcf;

namespace PairingTest.Unit.Tests.QuestionServiceWcf
{
    [TestFixture]
    public class QuestionRepositoryTests
    {
        [Test]
        public void ShouldGetExpectedQuestionnaire()
        {
            var questionRepository = new FakeQuestionRepository();

            var questionnaire = questionRepository.GetQuestionnaire();

            Assert.That(questionnaire.Title, Is.EqualTo("My expected questions"));
            Assert.That(questionnaire.Questions[0].QuestionText, Is.EqualTo("What is the capital of Cuba?"));
            Assert.That(questionnaire.Questions[1].QuestionText, Is.EqualTo("What is the capital of France?"));
            Assert.That(questionnaire.Questions[2].QuestionText, Is.EqualTo("What is the capital of Poland?"));
            Assert.That(questionnaire.Questions[3].QuestionText, Is.EqualTo("What is the capital of Germany?"));
        }
    }
}