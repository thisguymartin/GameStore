using GameStore.Api.Entities;

namespace GameStore.Api.Repositories;

public class InMemGamesRepository : IGamesRepository
{
  private readonly List<Game> games = new()
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

  public IEnumerable<Game> GetAll()
  {
    return games;
  }

  public Game? Get(Guid id)
  {
    return games.Find(game => game.Id == id);
  }

  public Game Create(Game game)
  {
    game.Id = Guid.NewGuid();
    games.Add(game);

    return game;
  }

  public void Update(Game updatedGame)
  {
    var index = games.FindIndex(game => game.Id == updatedGame.Id);
    games[index] = updatedGame;
  }

  public void Delete(Guid id)
  {
    var index = games.FindIndex(game => game.Id == id);
    games.RemoveAt(index);
  }
}