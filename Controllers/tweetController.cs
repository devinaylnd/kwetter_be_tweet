using Microsoft.AspNetCore.Mvc;
using kwetter_tweet.Services;
using kwetter_tweet.DbContext;
using kwetter_tweet.Models.Tweet;

namespace kwetter_tweet.Controllers;

[ApiController]
[Route("[controller]")]
public class TweetController : ControllerBase
{
    private readonly ITweetService _service;

    public TweetController(ILogger<TweetController> logger, IConfiguration configuration, ApplicationDbContext context, ITweetService service)
    {
        _service = service;
    }

    [HttpPost]
    [Route("create")]
    public async Task<ActionResult<TweetResponse>> CreateTweet(CreateTweetRequest data)
    {
        var tweet = await _service.CreateTweet(new TweetEntity
        {
            description = data.description,
            idUser = data.idUser,
            username = data.username,
            name = data.name,
            totalLike = data.totalLike,
            dateTime = data.dateTime,
            userPic = data.userPic
        });

        if (tweet == null) { return BadRequest(); }
        return Ok(new TweetResponse(tweet));
    }

    [HttpPut]
    [Route("edit")]
    public async Task<ActionResult<TweetResponse>> EditTweet(EditTweetRequest data)
    {
        var tweet = await _service.EditTweet(new TweetEntity
        {
            id = data.id,
            description = data.description,
            idUser = data.idUser,
            username = data.username,
            name = data.name,
            totalLike = data.totalLike,
            dateTime = data.dateTime,
            userPic = data.userPic
        });

        if (tweet == null) { return NotFound(); }
        return Ok(new TweetResponse(tweet));
    }

    [HttpGet]
    [Route("tweet-{id}")]
    public async Task<ActionResult<TweetResponse>> GetTweetByTweetId(int id)
    {
        var tweet = await _service.GetTweetByTweetId(id);

        if (tweet == null) { return NotFound(); }
        return Ok(new TweetResponse(tweet));
    }

    [HttpGet]
    [Route("user-{id}")]
    public async Task<ActionResult<IEnumerable<TweetResponse>>> GetTweetByUserId(int id)
    {
        var tweets = await _service.GetTweetByUserId(id);
        if (tweets == null) { return NotFound(); }
        return Ok(tweets.Select(tweet => new TweetResponse(tweet)));
    }

    [HttpGet]
    [Route("getTweetBySearch")]
    public async Task<ActionResult<TweetResponse>> GetTweetBySearch(GetTweetBySearchRequest data)
    {
        var tweets = await _service.GetTweetBySearch(new TweetEntity
        {
            description = data.description,
        });

        if (tweets == null) { return NotFound(); }
        return Ok(tweets.Select(tweet => new TweetResponse(tweet)));
    }

    // [HttpGet]
    // [Route("all")]
    // public async Task<ActionResult<IEnumerable<TweetResponse>>> GetTweets([FromQuery] IEnumerable<string> categoryIds)
    // {
    //     var tweets = await _service.GetTweets(categoryIds);
    //     return Ok(tweets.Select(tweet => new TweetResponse(tweet)));
    // }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> DeleteTweet(int id)
    {
        var tweet = await _service.DeleteTweet(id);

        if (!tweet) { return NotFound(); }
        return Ok();
    }
}
