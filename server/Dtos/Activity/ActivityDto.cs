using System;
using server.Dtos.Ingredient;
using server.Models;

namespace server.Dtos.Activity;

public class ActivityDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Desc { get; set; } = string.Empty;
    public int MinTime { get; set; }
    public bool IsPrioritized { get; set; }
    public int Enjoyment { get; set; }

    public List<IngredientDto> Ingredients { get; set; } = [];

    public int? CategoryId { get; set; }

    public string UserId { get; set; } = string.Empty;
}
