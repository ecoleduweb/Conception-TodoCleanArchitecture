using CleanTodo.Application.Service.Todo;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;



namespace CleanTodo.Application;
public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.AddScoped<ITodoService, TodoService>();

        return services;
    }
}