using QuestionnaireContracts;
using QuestionnaireLibrary;
using QuestionServiceWcf;

namespace PairingTest.Unit.Tests.QuestionServiceWcf.Stubs
{
    public class FakeQuestionRepository : IQuestionRepository
    {
        public Questionnaire ExpectedQuestions { get; set; }
        public Questionnaire GetQuestionnaire()
        {
            return ExpectedQuestions;
        }
        public Questionnaire SaveAndValidateQuestionnaire(Questionnaire AnsweredQuestionnaire, User user)
        {
            return AnsweredQuestionnaire;
        }
    }
}