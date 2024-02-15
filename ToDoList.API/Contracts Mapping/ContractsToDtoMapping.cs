using AutoMapper;
using ToDoList.API.Contracts.Task;
using ToDoList.Services.DTOs.Task;

namespace ToDoList.API.Contracts_Mapping;

public class ContractsToDtoMapping : Profile
{
    public ContractsToDtoMapping() 
    {
        TaskContractToDtoMaps();
    }
    private void TaskContractToDtoMaps()
    {
        CreateMap<TaskCreateContract, TaskCreateDto>();
        CreateMap<TaskUpdateContract, TaskUpdateDto>();
        CreateMap<TaskUpdateStatusContract, TaskUpdateStatusDto>();
    }
}
