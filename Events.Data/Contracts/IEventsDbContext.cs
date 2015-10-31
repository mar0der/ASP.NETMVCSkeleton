namespace Events.Data.Contracts
{
    public interface IEventsDbContext
    {
        int SaveChanges();
    }
}