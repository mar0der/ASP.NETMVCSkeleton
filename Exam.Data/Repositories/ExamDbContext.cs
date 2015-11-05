namespace Exam.Data.Repositories
{
    using Exam.Data.Contracts;
    using Exam.Models.Models;

    using Microsoft.AspNet.Identity.EntityFramework;

    public class ExamDbContext : IdentityDbContext<User>, IExamDbContext
    {
        public ExamDbContext()
            : base("ExamDbContext", false)
        {
        }

        public static ExamDbContext Create()
        {
            return new ExamDbContext();
        }
    }
}