namespace QuestionnaireDataAccess
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using QuestionnaireLibrary;

    public partial class QuestionnaireModel : DbContext
    {
        public QuestionnaireModel()
            : base("name=QuestionnaireModelConn")
        {
            this.Configuration.ProxyCreationEnabled = false;
            this.Configuration.LazyLoadingEnabled = false;
        }

        public virtual DbSet<Questionnaire> Questionnaire { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<UserAnswer> UserAnswer { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Questionnaire>().ToTable("Questionnaire");
            modelBuilder.Entity<Question>().ToTable("Questions");
            modelBuilder.Entity<Questionnaire>().Ignore(t => t.Questions);
            modelBuilder.Entity<Question>().Ignore(t => t.UserAnswer);
            modelBuilder.Entity<Question>().Ignore(t => t.IsCorrect);
            
        }
    }
}
