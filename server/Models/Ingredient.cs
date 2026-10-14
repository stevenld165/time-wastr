using System;

namespace server.Models;

public class Ingredient : IUserOwned
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Icon { get; set; } = string.Empty;
    public string Color { get; set; } = string.Empty;

    public string UserId { get; set; } = string.Empty;
    public User? User { get; set; }

    public Category? Category { get; set; }
    public List<Activity> Activities { get; set; } = [];
}
