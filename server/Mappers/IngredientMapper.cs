using System;
using Npgsql.Replication;
using server.Dtos.Ingredient;
using server.Models;

namespace server.Mappers;

public static class IngredientMapper
{
    public static IngredientDto ToIngredientDto(this Ingredient ingredientModel)
    {
        return new IngredientDto
        {
            Id = ingredientModel.Id,
            Name = ingredientModel.Name,
            Icon = ingredientModel.Icon,
            Color = ingredientModel.Color,
            UserId = ingredientModel.UserId,
        };
    }

    public static Ingredient ToIngredientFromCreateDto(
        this CreateIngredientDto createDto,
        string userId
    )
    {
        return new Ingredient
        {
            Name = createDto.Name,
            Icon = createDto.Icon,
            Color = createDto.Color,
            UserId = userId,
        };
    }
}
