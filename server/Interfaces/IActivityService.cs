using System;
using server.Dtos.Activity;
using server.Models;

namespace server.Interfaces;

public interface IActivityService : IBaseService<Activity, CreateActivityDto> { }
