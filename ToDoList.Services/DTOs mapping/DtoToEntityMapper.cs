using AutoMapper;
using ToDoList.Services.DTOs.Task;

namespace ToDoList.Services.DTOs_mapping;

public class DtoToEntityMapper : Profile
{
    public DtoToEntityMapper() 
    {
        TaskDtoToEntity();
    }
    private void TaskDtoToEntity()
    {
        CreateMap<TaskCreateDto, Domain.Entities.Task>();
        CreateMap<TaskUpdateDto, Domain.Entities.Task>();
    }
}
