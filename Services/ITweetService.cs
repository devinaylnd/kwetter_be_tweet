using kwetter_tweet.Models.Tweet;

namespace kwetter_tweet.Services;

public interface ITweetService
{
    Task<TweetEntity?> CreateTweet(TweetEntity data);
    Task<TweetEntity?> EditTweet(TweetEntity data);
    Task<TweetEntity?> GetTweetByTweetId(int id);
    Task<TweetEntity[]> GetTweetByUserId(int id);

    Task<TweetEntity[]> GetTweetBySearch(TweetEntity data);
    // Task<TweetEntity[]> GetTweets(IEnumerable<string> id);
    Task<bool> DeleteTweet(int id);
}