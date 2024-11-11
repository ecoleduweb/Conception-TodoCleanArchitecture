﻿using CleanTodo.Application.Entities;

namespace CleanTodo.Domain.Interfaces;

public interface ITodoRepository
{
    Task<List<Todo>> GetAll();
    Task<Todo> Add(Todo item);
    Task ToggleCompleteStatus(Guid id);
    Task Delete(Guid id);
}