using System;
using server.Data;
using server.Dtos.Category;
using server.Interfaces;
using server.Models;

namespace server.Services;

public class CategoryService(TimeWastrDbContext _context)
    : BaseService<Category, CreateCategoryDto>(_context),
        ICategoryService
{
    protected override void ApplyUpdate(Category existing, CreateCategoryDto dto)
    {
        existing.IngredientId = dto.IngredientId;
    }
}
