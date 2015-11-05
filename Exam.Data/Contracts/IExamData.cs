namespace Exam.Data.Contracts
{
    using Exam.Models.Models;

    #region

    

    #endregion

    public interface IExamData
    {
        IRepository<User> Users { get; }

        IRepository<Event> Events { get; }

        int SaveChanges();
    }
}