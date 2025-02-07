using Shared.Dtos;
using WebApi.DtoConverters;
using WebApi.DtoConverters.DtoConvertersImpl;

namespace WebApi.Factories;

public class DtoConverterFactory
{
    private readonly AutoMapperService _autoMapperService;

    public DtoConverterFactory(AutoMapperService autoMapperService)
    {
        _autoMapperService = autoMapperService;
    }

    public object CreateDtoConverter(Type type)
    {
        if (type == typeof(TaskDto))
        {
            return new TaskDtoConverter(_autoMapperService);
        }
        throw new NotImplementedException();
    }
}
