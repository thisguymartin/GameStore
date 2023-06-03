using GameStore.Api.Entities;
using GameStore.Api.Repositories;

namespace GameStore.Api.Endpoints;

public static class GamesEndpoints
{
    const string GetGameEndpointName = "GetGame";




    public static RouteGroupBuilder MapGamesEndpoints(this IEndpointRouteBuilder routes)
    {
        InMemoryRepository repo = new();

        var group = routes.MapGroup("/games").WithParameterValidation();

        group.MapGet("/", () => repo.GetAll());

        group.MapGet("/{id}", (Guid id) =>
        {
            Game? game = repo.GetById(id);

            if (game is null)
            {
                return Results.NotFound();
            }

            return Results.Ok(game);
        })
        .WithName(GetGameEndpointName);

        group.MapPost("/", (Game game) =>
        {

            Game gameCreated = repo.CreateGame(game);

            return Results.CreatedAtRoute(GetGameEndpointName, new { id = gameCreated.Id }, gameCreated);
        });

        group.MapPatch("/{id}", (Guid id, Game inputGame) =>
        {
            Game? foundGame = repo.GetById(id);

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