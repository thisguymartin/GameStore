using System.ComponentModel.DataAnnotations;

namespace GameStore.Api;

public class Dtos
{

  public record GameDto(
    Guid id,
    string Name,
    string Genre,
    decimal Price,
    DateTime ReleaseDate,
    string ImageUri
  );

  public record CreateGameDto(
    [Required][StringLength(50)] string Name,
    string Genre,
    [Required][Range(1, 100)] decimal Price,
    DateTime ReleaseDate,
    [Url][StringLength(100)] string ImageUri
  );

  public record UpdateGameDto(
  [Required][StringLength(50)] string Name,
  string Genre,
  [Required][Range(1, 100)] decimal Price,
  DateTime ReleaseDate,
  [Url][StringLength(100)] string ImageUri
);

}