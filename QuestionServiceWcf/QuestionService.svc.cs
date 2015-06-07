using QuestionnaireContracts;
using QuestionnaireDataAccess;
using QuestionnaireLibrary;
using System;
using Utils;

namespace QuestionServiceWcf
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _questionRepository;

        public QuestionService()
            : this(new EntityQuestionRepository())
        {
        }

        public QuestionService(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }

        public Questionnaire GetQuestionaire()
        {
            try
            {
                return _questionRepository.GetQuestionnaire();
            }
            catch (Exception ex)
            {
                LogHelper.Log("Error at GetQuestionaire", ex);
                throw;
            }

        }

       

        public Questionnaire SaveAndValidateQuestionnaire(Questionnaire AnsweredQuestionnaire,User user)
        {
            try
            {
                return _questionRepository.SaveAndValidateQuestionnaire(AnsweredQuestionnaire, user);
            }
            catch (Exception ex)
            {
                LogHelper.Log("Error at SaveAndValidateQuestionnaire", ex);
                throw;
            }
           
        }
    }
}
