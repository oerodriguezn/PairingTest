using System.Collections.Generic;
using QuestionnaireLibrary;
using QuestionnaireContracts;

namespace QuestionServiceWcf
{
    public class QuestionRepository : IQuestionRepository
    {
        public Questionnaire GetQuestionnaire()
        {
            return new Questionnaire
            {
                Title = "Geography Questions",
                Questions = new List<Question>
                                           {
                                               new Question(){Id=1,QuestionText="What is the capital of Cuba?"},
                                                new Question(){Id=2,QuestionText="What is the capital of France?"},
                                                new Question(){Id=3,QuestionText="What is the capital of Poland?"},
                                                new Question(){Id=4,QuestionText="What is the capital of Germany?"}
                                           }
            };
        }

        public Questionnaire SaveAndValidateQuestionnaire(Questionnaire AnsweredQuestionnaire,User user)
        {
            foreach (var item in AnsweredQuestionnaire.Questions)
            {
                switch (item.Id)
                {
                    case 1:
                        if(item.UserAnswer.ToLower() == "habana")
                            item.IsCorrect = true;
                        break;
                    case 2:
                        if (item.UserAnswer.ToLower() == "paris")
                            item.IsCorrect = true;
                        break;
                    case 3:
                        if (item.UserAnswer.ToLower() == "habana")
                            item.IsCorrect = true;
                        break;
                    case 4:
                        if (item.UserAnswer.ToLower() == "berlin")
                            item.IsCorrect = true;
                        break;
                    default:
                        item.IsCorrect = false;
                        break;
                }
            }
            return AnsweredQuestionnaire;
        }
    }
}