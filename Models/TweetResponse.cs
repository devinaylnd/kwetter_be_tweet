namespace kwetter_tweet.Models.Tweet;

public class TweetResponse
{
    public int id { get; }
    public string? description { get; set; }
    public int idUser { get; set; }
    public string? username { get; set; }
    public string? name { get; set; }
    public int totalLike { get; set; }
    public string? dateTime { get; set; }
    public string? userPic { get; set; }

    public TweetResponse(TweetEntity tweet)
    {
        id = tweet.id;
        description = tweet.description;
        idUser = tweet.idUser;
        username = tweet.username;
        name = tweet.name;
        totalLike = tweet.totalLike;
        dateTime = tweet.dateTime;
        userPic = tweet.userPic;
    }
}