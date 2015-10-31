namespace Events.Data.Repositories
{
    using Events.Data.Contracts;
    using Events.Models.Models;

    using Microsoft.AspNet.Identity.EntityFramework;

    public class EventsDbContext : IdentityDbContext<User>, IEventsDbContext
    {
        public EventsDbContext()
            : base("EventsDbContext", false)
        {
        }

        public static EventsDbContext Create()
        {
            return new EventsDbContext();
        }
    }
}