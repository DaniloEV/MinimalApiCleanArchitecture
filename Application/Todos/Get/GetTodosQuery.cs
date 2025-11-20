using Application.Abstractions.Messaging;
using SharedKernel.Dto.Todos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Todos.Get
{
    public sealed record GetTodosQuery(Guid UserId) : IQuery<List<TodoResponse>>;
}
