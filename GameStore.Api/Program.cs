using GameStore.Api.Entities;

List<Game> games = new(){
    new Game {
        Id = 1,
        Name = "Dark Souls Remastered",
        Genre = "Action RPG",
        Price = 40.00M,
        ImageUrl = "http://placehold.co/100",
        ReleaseDate = new DateTime(2011, 9, 22)
    },
    new Game {
        Id = 2,
        Name = "Dark Souls II",
        Genre = "Action RPG",
        Price = 40.00M,
        ImageUrl = "http://placehold.co/100",
        ReleaseDate = new DateTime(2014, 3, 11)
    },
    new Game {
        Id = 3,
           Name = "Dark Souls III",
        Genre = "Action RPG",
        Price = 60.00M,
        ImageUrl = "http://placehold.co/100",
        ReleaseDate = new DateTime(2016, 3, 24)
    },
    new Game {
        Id = 4,
        Name = "Bloodborne",
        Genre = "Action RPG",
        Price = 50.00M,
        ImageUrl = "http://placehold.co/100",
        ReleaseDate = new DateTime(2015, 3, 24)
    },
    new Game {
        Id = 5,
        Name = "Sekiro: Shadows Die Twice",
        Genre = "Action-Adventure",
        Price = 60.00M,
        ImageUrl = "http://placehold.co/100",
        ReleaseDate = new DateTime(2019, 3, 22)
    }
};

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

const string GetGameEndPointName = "GetGame";

var group = app.MapGroup("/games").WithParameterValidation();

group.MapGet("/", () => games);

group.MapGet("/{id}", (int id) =>
{
    Game? game = games.Find(g => g.Id == id);
    if (game == null)
    {
        return Results.NotFound();
    }

    return Results.Ok(game);
}).WithName(GetGameEndPointName);


group.MapPost("/", (Game game) =>
{
    game.Id = games.Max(game => game.Id) + 1;
    games.Add(game);

    return Results.CreatedAtRoute(GetGameEndPointName, new { id = game.Id }, game);
});

group.MapPut("/{id}", (int id, Game game) =>
{
    Game? gameFound = games.Find(g => g.Id == id);
    if (gameFound is null)
    {
        return Results.NotFound();
    }

    gameFound.ImageUrl = game.ImageUrl;
    gameFound.Name = game.Name;
    gameFound.Description = game.Description;
    gameFound.Price = game.Price;
    gameFound.ReleaseDate = game.ReleaseDate;

    return Results.NoContent();
});

group.MapDelete("/{id}", (int id) =>
{
    Game? gameFound = games.Find(g => g.Id == id);
    if (gameFound is null)
    {
        return Results.NotFound();
    }
    games.Remove(gameFound);
    return Results.NoContent();
});

app.Run();
