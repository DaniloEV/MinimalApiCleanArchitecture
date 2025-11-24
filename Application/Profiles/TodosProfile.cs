using AutoMapper;
using SharedKernel.Dto.Todos;
namespace Application.Profiles
{
    public class TodosProfile : Profile
    {
        public TodosProfile()
        {
            CreateMap<TodoResponse, TodoResponseDto>().ReverseMap();
        }
    }
}
