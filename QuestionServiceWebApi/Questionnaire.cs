using System.Collections.Generic;
using System.Runtime.Serialization;

namespace QuestionServiceWebApi
{
    [DataContract]
    public class Questionnaire
    {
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public IList<string> Questions { get; set; }
    }
}