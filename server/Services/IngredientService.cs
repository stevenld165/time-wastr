using System;
using Microsoft.EntityFrameworkCore;
using server.Data;
using server.Dtos.Ingredient;
using server.Interfaces;
using server.Models;

namespace server.Services;

public class IngredientService(TimeWastrDbContext _context)
    : BaseService<Ingredient, CreateIngredientDto>(_context),
        IIngredientService
{
    protected override void ApplyUpdate(Ingredient existing, CreateIngredientDto dto)
    {
        existing.Name = dto.Name;
        existing.Icon = dto.Icon;
        existing.Color = dto.Color;
    }
}
