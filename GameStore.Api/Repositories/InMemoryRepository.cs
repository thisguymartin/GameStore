// This code imports the GameStore.Api.Entities namespace.
using GameStore.Api.Entities;

// This code defines a namespace for the InMemoryRepository class.
namespace GameStore.Api.Repositories
{
    // This code defines the InMemoryRepository class.
    public class InMemoryRepository
    {
        // This code initializes a static list of Game objects.
        static List<Game> games = new()
    {
      // This code adds three Game objects to the list.
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

        // This code defines a method that returns all Game objects in the list.
        public IEnumerable<Game> GetAll()
        {
            return games;
        }

        // This code defines a method that returns a Game object with a specified ID.
        public Game? GetById(Guid id)
        {
            Game? game = games.Find(game => game.Id == id);

            return game;
        }

        // This code defines a method that adds a new Game object to the list.
        public Game CreateGame(Game game)
        {
            game.Id = Guid.NewGuid();
            games.Add(game);
            return game;
        }
    }
}