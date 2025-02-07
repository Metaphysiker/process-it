namespace WebApi.DtoConverters.DtoConvertersImpl;

public class TaskDtoConverter : IDtoConverter<TaskDto, Task>
{
    public TaskDto ConvertToDto(Task model)
    {
        TaskDto dto = new TaskDto();
        dto.Id = model.Id;
        return dto;
    }

    public Task ConvertToModel(TaskDto dto)
    {
        throw new NotImplementedException();
    }
}
