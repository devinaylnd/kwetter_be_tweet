using Microsoft.EntityFrameworkCore;
using kwetter_tweet.DbContext;
using kwetter_tweet.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();
builder.Services.AddTransient<ITweetService, TweetService>();

builder.Host.ConfigureServices((context, collection) =>
{
    var connectionString = context.Configuration.GetConnectionString("DefaultConnection");
    builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseMySql(
        connectionString  ?? throw new InvalidOperationException(),
        ServerVersion.AutoDetect(connectionString)
    ));
});

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();
app.Run();