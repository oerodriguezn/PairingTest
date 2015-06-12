using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace QuestionnaireLibrary
{
    [DataContract]
    public class Questionnaire
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<Question> Questions { get; set; }
    }

    [DataContract]
    public class Question
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        [Required]
        [StringLength(50)]
        public string QuestionText { get; set; }

        [DataMember]
        public string UserAnswer { get; set; }

        [DataMember]
        public bool IsCorrect { get; set; }

        [DataMember]
        public string Answer { get; set; }
    }

    [DataContract]
    public class User
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public long Id { get; set; }
    }
}
