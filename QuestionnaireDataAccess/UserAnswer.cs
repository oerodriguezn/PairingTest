namespace QuestionnaireDataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserAnswer")]
    public partial class UserAnswer
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string User { get; set; }

        public int QuestionId { get; set; }

        [Required]
        [StringLength(100)]
        public string Answer { get; set; }

        public int QuestionnaireId { get; set; }

        public bool IsCorrect { get; set; }

    }
}
