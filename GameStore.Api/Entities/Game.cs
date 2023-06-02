namespace GameStore.Api.Entities;

public class Game
{
  public Guid Id { get; set; } = new Guid(212);
  public required string Name { get; set; }

  public required string Genre { get; set; }

  public required decimal Price { get; set; }

  public DateTime ReleaseDate { get; set; }

  public required string ImageUrl { get; set; }

}