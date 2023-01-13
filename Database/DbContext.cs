using Microsoft.EntityFrameworkCore;
using kwetter_tweet.Models.Tweet;

namespace kwetter_tweet.DbContext;

public class ApplicationDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){}
    public DbSet<TweetEntity> tweets { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var tweetEntity = modelBuilder.Entity<TweetEntity>();
    }
}