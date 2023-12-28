using GameStore.Api.Entities;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<Game> games = new(){
  new Game() {
    Id = 1,
    Name = "Street Fighter",
    Genre = "Fighter",
    Price = 20.00M,
    ImageUrl ="",
    ReleaseDate = new DateTime(1991, 3, 1)
  }
};




app.MapGet("/", () => games);

app.Run();
