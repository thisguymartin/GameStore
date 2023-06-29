using GameStore.Api.Entities;

namespace GameStore.Api.Repositories;

public interface IGamesRepository
{
    Game Create(Game game);
    void Delete(Guid id);
    Game? Get(Guid id);
    IEnumerable<Game> GetAll();
    void Update(Game updatedGame);
}
