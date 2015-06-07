using QuestionnaireLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace QuestionnaireContracts
{
    [ServiceContract]
    public interface IQuestionService
    {
        [OperationContract]
        Questionnaire GetQuestionaire();

        [OperationContract]
        Questionnaire SaveAndValidateQuestionnaire(Questionnaire AnsweredQuestionnaire, User user);
    }

    public interface IQuestionRepository
    {
        Questionnaire GetQuestionnaire();

        Questionnaire SaveAndValidateQuestionnaire(Questionnaire AnsweredQuestionnaire, User user);
    }
}
