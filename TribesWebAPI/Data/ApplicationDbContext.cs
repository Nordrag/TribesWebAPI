using Microsoft.EntityFrameworkCore;



public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

    public DbSet<User> Users { get; set; }
    public DbSet<EventModel> Events { get; set; }
    public DbSet<Subtags> Subtags { get; set; }
    public DbSet<JoinedEvents> RegisteredForEvents { get; set; }
    public DbSet<TagsUsed> UsedTags { get; set; }
    public DbSet<RequestedPeople> RequestedPeople { get; set; }
}

