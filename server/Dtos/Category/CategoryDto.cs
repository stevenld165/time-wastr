using System;
using server.Dtos.Ingredient;

namespace server.Dtos.Category;

public class CategoryDto
{
    public int Id { get; set; }

    public int? IngredientId { get; set; }
    public IngredientDto? Ingredient { get; set; }

    public string UserId { get; set; } = string.Empty;
}
