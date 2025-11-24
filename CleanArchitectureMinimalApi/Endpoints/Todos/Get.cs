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
        //MapToApiVersion hará para saber las versiones y por cual debe ir
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapGet("todos",
                async (
                    Guid userId,
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
                    op.Summary = "Esto es un ejemplo de resumen";
                    op.Description = "Y una descripción.";
                    return op;
                }).MapToApiVersion(1);
                //.RequireAuthorization();


            app.MapGet("todos",
                async (
                    Guid userId,
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
                    op.Summary = "Esto es un ejemplo de resumen V2";
                    op.Description = "Y una descripción V2.";
                    return op;
                }).MapToApiVersion(2);
        }
    }
}
