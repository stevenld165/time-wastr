using System;
using server.Dtos.Category;
using server.Models;

namespace server.Interfaces;

public interface ICategoryService : IBaseService<Category, CreateCategoryDto> { }
