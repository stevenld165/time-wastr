using System;
using server.Dtos.Activity;
using server.Models;

namespace server.Mappers;

public static class ActivityMapper
{
    public static ActivityDto ToActivityDto(this Activity activityModel)
    {
        return new ActivityDto
        {
            Id = activityModel.Id,
            Name = activityModel.Name,
            Desc = activityModel.Desc,
            MinTime = activityModel.MinTime,
            IsPrioritized = activityModel.IsPrioritized,
            Enjoyment = activityModel.Enjoyment,
            Ingredients = [.. activityModel.Ingredients.Select((i) => i.ToIngredientDto())],
            CategoryId = activityModel.CategoryId,
            UserId = activityModel.UserId,
        };
    }

    public static Activity ToActivityFromCreateDto(this CreateActivityDto createDto, string userId)
    {
        return new Activity
        {
            Name = createDto.Name,
            Desc = createDto.Desc,
            MinTime = createDto.MinTime,
            IsPrioritized = createDto.IsPrioritized,
            Enjoyment = createDto.Enjoyment,
            CategoryId = createDto.CategoryId,
            UserId = userId,
        };
    }
}
