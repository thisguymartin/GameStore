using GameStore.Api.Entities;

const string GetGameEndpoint = "GetGame";

List<Game> games = new() {
    new Game()
    {
        Name = "Halo",
        Price = 19.99M,
        ImageUrl = "https://example.com/halo.jpg",
        Genre = "Shooter",
        ReleaseDate = new DateTime(2001, 11, 15)
    },
    new Game()
    {
        Name = "Halo 2",
        Price = 19.99M,
        ImageUrl = "https://example.com/halo2.jpg",
        Genre = "Shooter",
        ReleaseDate = new DateTime(2004, 11, 9)
    },
    new Game()
    {
        Name = "Halo 3",
        Price = 19.99M,
        ImageUrl = "https://example.com/halo3.jpg",
        Genre = "Shooter",
        ReleaseDate = new DateTime(2007, 9, 25)
    },
    new Game()
    {
        Name = "Halo 4",
        Price = 19.99M,
        ImageUrl = "https://example.com/halo4.jpg",
        Genre = "Shooter",
        ReleaseDate = new DateTime(2012, 11, 6)
    }
};

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/games", () => games);

app.MapGet("/games/{id}", (Guid id) =>
{
  Game? game = games.Find(gm => gm.Id == id);

  if (game is null)
  {
    return Results.NotFound();
  }

  return Results.Ok(game);
}).WithDisplayName(GetGameEndpoint);

app.MapPost("/games", (Game game) =>
{
  Guid newGuid = Guid.NewGuid();

  Game newGame = game;
  newGame.Id = newGuid;
  games.Add(newGame);

  return Results.CreatedAtRoute(GetGameEndpoint, new { id = newGame.Id }, newGame);
});

app.Run();
