namespace Exam.Data.Contracts
{
    #region

    using System.Linq;

    #endregion

    public interface IRepository<T>
        where T : class
    {
        IQueryable<T> All();

        T Find(object id);

        void Add(T entry);

        void Update(T entry);

        void Delete(T entity);

        void Delete(object id);

        void Detach(T entity);
    }
}