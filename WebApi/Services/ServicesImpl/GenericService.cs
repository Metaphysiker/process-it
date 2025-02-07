using Shared.Dtos;

namespace WebApi.Services.ServicesImpl;

public class GenericService<Model, SearchT> : IModelService<IModelDto, ISearch>
{
    public Task<IModelDto> Create(IModelDto dto)
    {
        throw new NotImplementedException();
    }

    public System.Threading.Tasks.Task Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IModelDto> Read(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<IModelDto>> ReadAll()
    {
        throw new NotImplementedException();
    }

    public Task<List<IModelDto>> Search(ISearch search)
    {
        throw new NotImplementedException();
    }

    public Task<IModelDto> Update(IModelDto dto)
    {
        throw new NotImplementedException();
    }
}
