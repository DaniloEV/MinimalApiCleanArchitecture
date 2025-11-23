using Application.Abstractions.Messaging;
using Application.Todos.Get;
using CleanArchitectureMinimalApi.Extensions;
using CleanArchitectureMinimalApi.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using SharedKernel;
using SharedKernel.Dto.Todos;

namespace CleanArchitectureMinimalApi.Endpoints.Todos
{
    internal sealed class Get : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapGet("todos",
            async (
                TodoResponse userId,
                IQueryHandler<GetTodosQuery, List<TodoResponse>> handler,
                CancellationToken cancellationToken) =>
            {

                var query = new GetTodosQuery(Guid.Parse("12020dc1-734b-4e3a-8dbf-654cbe770d2d"));

                Result<List<TodoResponse>> result = await handler.Handle(query, cancellationToken);

                return result.Match(Results.Ok, CustomResults.Problem);
            })
            .WithTags(Tags.Todos)
            .WithOpenApi(op =>
            {
                op.Summary = "Creates a new product";
                op.Description = "Adds a product to the catalog with details like name and price.";
                return op;
            });
            //.RequireAuthorization();
        }
    }
}
