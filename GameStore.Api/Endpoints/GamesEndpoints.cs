using GameStore.Api.Entities;

namespace GameStore.Api.Endpoints;

public static class GamesEndpoints
{
  const string GetGameEndpointName = "GetGame";

  static List<Game> games = new()
{
    new Game()
    {
        Id = Guid.NewGuid(),
        Name = "Street Fighter II",
        Genre = "Fighting",
        Price = 19.99M,
        ReleaseDate = new DateTime(1991, 2, 1),
        ImageUri = "https://placehold.co/100"
    },
    new Game()
    {
        Id = Guid.NewGuid(),
        Name = "Final Fantasy XIV",
        Genre = "Roleplaying",
        Price = 59.99M,
        ReleaseDate = new DateTime(2010, 9, 30),
        ImageUri = "https://placehold.co/100"
    },
    new Game()
    {
        Id = Guid.NewGuid(),
        Name = "FIFA 23",
        Genre = "Sports",
        Price = 69.99M,
        ReleaseDate = new DateTime(2022, 9, 27),
        ImageUri = "https://placehold.co/100"
    }
};

  public static RouteGroupBuilder MapGamesEndpoints(this IEndpointRouteBuilder routes)
  {

    var group = routes.MapGroup("/games").WithParameterValidation();

    group.MapGet("/", () => games);

    group.MapGet("/{id}", (Guid id) =>
    {
      Game? game = games.Find(game => game.Id == id);

      if (game is null)
      {
        return Results.NotFound();
      }

      return Results.Ok(game);
    })
    .WithName(GetGameEndpointName);

    group.MapPost("/", (Game game) =>
    {
      game.Id = Guid.NewGuid();
      games.Add(game);

      return Results.CreatedAtRoute(GetGameEndpointName, new { id = game.Id }, game);
    });

    group.MapPatch("/{id}", (Guid id, Game inputGame) =>
    {
      Game? foundGame = games.Find(g => g.Id == id);

      if (foundGame == null)
      {
        return Results.NotFound();
      }

      foundGame.Name = inputGame.Name;
      foundGame.ImageUri = inputGame.ImageUri;
      foundGame.Price = inputGame.Price;
      foundGame.ReleaseDate = inputGame.ReleaseDate;
      foundGame.Genre = inputGame.Genre;


      return Results.NoContent();
    });

    group.MapDelete("/{id}", (Guid id) =>
    {
      int gameIndex = games.FindIndex(a => a.Id == id);
      if (gameIndex == -1)
      {
        return Results.NotFound();
      }

      games.RemoveAt(gameIndex);

      return Results.NoContent();
    });

    return group;
  }
}