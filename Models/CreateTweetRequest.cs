namespace kwetter_tweet.Models.Tweet;

public class CreateTweetRequest
{
    public string? description { get; set; }
    public int idUser { get; set; }
    public string? username { get; set; }
    public string? name { get; set; }
    public int totalLike { get; set; }
    public string? dateTime { get; set; }
    public string? userPic { get; set; }
}