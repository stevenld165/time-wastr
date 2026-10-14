using System;
using server.Dtos.Ingredient;
using server.Models;

namespace server.Interfaces;

public interface IIngredientService : IBaseService<Ingredient, CreateIngredientDto> { }
