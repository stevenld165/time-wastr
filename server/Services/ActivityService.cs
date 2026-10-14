using System;
using Microsoft.EntityFrameworkCore;
using server.Data;
using server.Dtos.Activity;
using server.Interfaces;
using server.Models;

namespace server.Services;

public class ActivityService(TimeWastrDbContext _context)
    : BaseService<Activity, CreateActivityDto>(_context),
        IActivityService
{
    protected override void ApplyUpdate(Activity existing, CreateActivityDto model)
    {
        existing.Name = model.Name;
        existing.Desc = model.Desc;
        existing.MinTime = model.MinTime;
        existing.IsPrioritized = model.IsPrioritized;
        existing.Enjoyment = model.Enjoyment;
        existing.CategoryId = model.CategoryId;
    }
}
