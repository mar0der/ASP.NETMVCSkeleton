namespace Events.Data.Contracts
{
    #region

    using Events.Models.Models;

    #endregion

    public interface IEventsData
    {
        IRepository<User> Users { get; }

        IRepository<Event> Events { get; }

        int SaveChanges();
    }
}