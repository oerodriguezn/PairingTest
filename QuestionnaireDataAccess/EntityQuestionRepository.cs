using QuestionnaireContracts;
using QuestionnaireLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuestionnaireDataAccess
{
    public class EntityQuestionRepository : IQuestionRepository
    {
        QuestionnaireModel ctx = new QuestionnaireModel();
        public QuestionnaireLibrary.Questionnaire GetQuestionnaire()
        {
            Questionnaire result = ctx.Questionnaire.FirstOrDefault <Questionnaire>();
            result.Questions = ctx.Questions.ToList<QuestionnaireLibrary.Question>();
            return result;
        }

        public QuestionnaireLibrary.Questionnaire SaveAndValidateQuestionnaire(QuestionnaireLibrary.Questionnaire AnsweredQuestionnaire, QuestionnaireLibrary.User user)
        {
            foreach (var item in AnsweredQuestionnaire.Questions)
            {
                var question = ctx.Questions.Find(item.Id);
                item.IsCorrect = item.UserAnswer.ToLower() == question.Answer.ToLower();
                UserAnswer ans = new UserAnswer();
                ans.Answer = item.UserAnswer;
                ans.IsCorrect = item.IsCorrect;
                ans.QuestionId = item.Id;
                ans.QuestionnaireId = AnsweredQuestionnaire.Id;
                ans.User = user.Name;
                ctx.UserAnswer.Add(ans);
            }
            ctx.SaveChanges();
            return AnsweredQuestionnaire;
        }
    }
}
