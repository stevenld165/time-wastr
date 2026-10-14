using System;

namespace server.Models;

public class Category : IUserOwned
{
    public int Id { get; set; }

    public int? IngredientId { get; set; }
    public Ingredient? Ingredient { get; set; }

    public string UserId { get; set; } = string.Empty;
    public User? User { get; set; }

    public List<Activity> Activities { get; set; } = [];
}
