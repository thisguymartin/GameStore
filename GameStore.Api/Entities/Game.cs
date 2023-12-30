using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.Api.Entities;

public class Game
{
    public int Id { get; set; }
    [Required]
    [StringLength(50)]
    public required string Name { get; set; }
    [Required]
    public string? Description { get; set; }
    [Required]
    [StringLength(20)]
    public required string Genre { get; set; }
    [Range(1, 100)]
    public required decimal Price { get; set; }
    public DateTime ReleaseDate { get; set; }
    [Required]
    [Url]
    public required string ImageUrl { get; set; }
}