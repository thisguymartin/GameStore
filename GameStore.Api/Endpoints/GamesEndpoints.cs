using GameStore.Api.Entities;
using GameStore.Api.Repositories;

namespace GameStore.Api.Endpoints;

public static class GamesEndpoints
{
  const string GetGameEndpointName = "GetGame";

  public static RouteGroupBuilder MapGamesEndpoints(this IEndpointRouteBuilder routes)
  {

    var group = routes.MapGroup("/games").WithParameterValidation();

    group.MapGet("/", (IGamesRepository repo) => repo.GetAll().Select(game => game.AsDto()));

    group.MapGet("/{id}", (IGamesRepository repo, Guid id) =>
    {
      Game? game = repo.Get(id);

      if (game is null)
      {
        return Results.NotFound();
      }

      return Results.Ok(game.AsDto());
    })
    .WithName(GetGameEndpointName);

    group.MapPost("/", (IGamesRepository repo, CrateGameDto gameDto) =>
    {

      Game gameCreated = repo.Create(game);

      return Results.CreatedAtRoute(GetGameEndpointName, new { id = gameCreated.Id }, gameCreated);
    });

    group.MapPatch("/{id}", (IGamesRepository repo, Guid id, Game inputGame) =>
    {
      Game? foundGame = repo.Get(id);

      if (foundGame == null)
      {
        return Results.NotFound();
      }

      repo.Update(inputGame);

      return Results.NoContent();
    });

    group.MapDelete("/{id}", (IGamesRepository repo, Guid id) =>
    {

      repo.Delete(id);

      return Results.NoContent();
    });

    return group;
  }
}