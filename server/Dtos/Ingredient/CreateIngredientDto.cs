using System;

namespace server.Dtos.Ingredient;

public class CreateIngredientDto
{
    public string Name { get; set; } = string.Empty;
    public string Icon { get; set; } = string.Empty;
    public string Color { get; set; } = string.Empty;
}
