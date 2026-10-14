namespace server.Models;

public class Activity : IUserOwned
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Desc { get; set; } = string.Empty;
    public int MinTime { get; set; }
    public bool IsPrioritized { get; set; }
    public int Enjoyment { get; set; }

    public List<Ingredient> Ingredients { get; set; } = [];

    public int? CategoryId { get; set; }
    public Category? Category { get; set; }

    public string UserId { get; set; } = string.Empty;
    public User? User { get; set; }
}
