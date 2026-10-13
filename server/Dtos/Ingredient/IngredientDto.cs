using System;

namespace server.Dtos.Ingredient;

public class IngredientDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Icon { get; set; } = string.Empty;
    public string Color { get; set; } = string.Empty;

    public string UserId { get; set; } = string.Empty;
}
