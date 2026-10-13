using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using server.Models;

namespace server.Data;

public class TimeWastrDbContext(DbContextOptions<TimeWastrDbContext> options)
    : IdentityDbContext<User>(options)
{
    public DbSet<Activity> Activities { get; set; } = null!;
    public DbSet<Ingredient> Ingredients { get; set; } = null!;
    public DbSet<Category> Categories { get; set; } = null!;
}
