using System;
using server.Dtos.Category;
using server.Models;

namespace server.Mappers;

public static class CategoryMapper
{
    public static CategoryDto ToCategoryDto(this Category category)
    {
        return new CategoryDto
        {
            Id = category.Id,
            IngredientId = category.IngredientId,
            Ingredient = category.Ingredient?.ToIngredientDto(),
            UserId = category.UserId,
        };
    }

    public static Category ToCategoryFromCreateDto(this CreateCategoryDto dto, string userId)
    {
        return new Category { IngredientId = dto.IngredientId, UserId = userId };
    }
}
