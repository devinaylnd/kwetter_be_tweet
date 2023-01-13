using System.Reflection.PortableExecutable;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using kwetter_tweet.DbContext;
using kwetter_tweet.Models.Tweet;

namespace kwetter_tweet.Services;

public class TweetService : ITweetService
{
    private ApplicationDbContext _context;  

    public TweetService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<TweetEntity?> CreateTweet(TweetEntity data)
    {
        try
        {
            var entry = _context.tweets.Add(data);
            await _context.SaveChangesAsync();
            return entry.Entity;
        }
        catch (Exception) { return null; }
    }

    public async Task<TweetEntity?> EditTweet(TweetEntity data)
    {
        try
        {
            EntityEntry<TweetEntity> entry = _context.Update(data);
            await _context.SaveChangesAsync();
            return entry.Entity;
        }
        catch (Exception) { return null; }
    }

    public async Task<TweetEntity?> GetTweetByTweetId(int id)
    {
        try
        {
            var tweet = await _context.tweets.Where(q => q.id == id).FirstOrDefaultAsync();
            return tweet;
        }
        catch (Exception) { return null; }
    }

    public async Task<TweetEntity[]> GetTweetByUserId(int id)
    {
        var tweet = await _context.tweets.Where(q => q.idUser == id).ToArrayAsync();
        return tweet;
    }

    public async Task<TweetEntity[]> GetTweetBySearch(TweetEntity data)
    {
        var tweet = await _context.tweets.Where(q => q.description.Contains(data.description)).ToArrayAsync();
        return tweet;
    }

    // public async Task<TweetEntity[]> GeTweets(IEnumerable<string> ids)
    // {
    //     var users = await _context.users.Where(q => ids.ToArray().Contains(q.users.id)).ToArrayAsync();
    //     return users;
    // }


    public async Task<bool> DeleteTweet(int id)
    {
        var tweet = await GetTweetByTweetId(id);
        if (tweet == null) return false; 

        _context.Remove(tweet);
        await _context.SaveChangesAsync();
        return true;
    }
}