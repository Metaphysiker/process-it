namespace WebApi.DtoConverters.DtoConvertersImpl;

public class TaskDtoConverter : IDtoConverter<TaskDto, Task>
{
    private readonly AutoMapperService _autoMapperService;

    public TaskDtoConverter(AutoMapperService autoMapperService)
    {
        _autoMapperService = autoMapperService;
    }
    public TaskDto Convert(Task model)
    {
        var dto = _autoMapperService.mapper.Map<TaskDto>(model);
        return dto;
    }

    public IEnumerable<TaskDto> Convert(IEnumerable<Task> models)
    {
        var dtos = models.Select(model => _autoMapperService.mapper.Map<TaskDto>(model));
        return dtos;
    }

    public Task Convert(TaskDto dto)
    {
        var model = _autoMapperService.mapper.Map<Task>(dto);
        return model;
    }

    public IEnumerable<Task> Convert(IEnumerable<TaskDto> dtos)
    {
        var models = dtos.Select(dto => _autoMapperService.mapper.Map<Task>(dto));
        return models;
    }
}
