using System;
using Microsoft.AspNetCore.Identity;

namespace server.Models;

public class User : IdentityUser
{
    [PersonalData]
    public string DisplayName { get; set; } = string.Empty;

    [PersonalData]
    public List<Activity> Activities { get; set; } = [];

    [PersonalData]
    public List<Ingredient> Ingredients { get; set; } = [];

    [PersonalData]
    public List<Category> Categories { get; set; } = [];
}
