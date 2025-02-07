using Shared.Dtos;
using WebApi.Repositories;
using WebApi.Repositories.RepositoriesImpl;
using WebApi.Services.ServicesImpl;

namespace WebApi.Factories;

public class ModelServiceFactory
{
    private readonly DatabaseContext _db;
    private readonly DtoConverterFactory _dtoConverterFactory;

    public ModelServiceFactory(DtoConverterFactory dtoConverterFactory, DatabaseContext db)
    {
        _dtoConverterFactory = dtoConverterFactory;
        _db = db;
    }

    public object Create(Type type)
    {
        if (type == typeof(Task))
        {
            IRepository<Task, TaskSearch> repository = new GenericRepository<Task, TaskSearch>(_db);
            return new GenericService<Task, TaskDto, TaskSearch>(repository, _dtoConverterFactory);
        }
        throw new NotImplementedException();
    }
}
