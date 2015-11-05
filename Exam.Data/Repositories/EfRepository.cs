namespace Exam.Data.Repositories
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;

    using Exam.Data.Contracts;

    public class EfRepository<T> : IRepository<T>
        where T : class
    {
        private readonly ExamDbContext context;

        private readonly IDbSet<T> set;

        public EfRepository(ExamDbContext context)
        {
            if (context == null)
            {
                throw new ArgumentException("An instance of DbContext is required!");
            }

            this.context = context;
            this.set = context.Set<T>();
        }

        public IQueryable<T> All()
        {
            return this.set;
        }

        public T Find(object id)
        {
            return this.set.Find(id);
        }

        public void Add(T entry)
        {
            this.ChangeState(entry, EntityState.Added);
        }

        public void Update(T entry)
        {
            this.ChangeState(entry, EntityState.Modified);
        }

        public void Delete(T entry)
        {
            this.ChangeState(entry, EntityState.Deleted);
        }

        public void Delete(object id)
        {
            var entity = this.Find(id);
            this.Delete(entity);
        }

        public void Detach(T entry)
        {
            DbEntityEntry entity = this.context.Entry(entry);
            this.ChangeState(entry, EntityState.Detached);
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }

        private void ChangeState(T entity, EntityState state)
        {
            var entry = this.context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this.set.Attach(entity);
            }

            entry.State = state;
        }
    }
}