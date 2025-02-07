using Shared.Dtos;

public interface IModelService<Dto, SearchT> where Dto : IModelDto where SearchT : ISearch
{
    public Task<List<Dto>> ReadAll();
    public Task<Dto> Read(int id);
    public Task<Dto> Create(Dto dto);
    public Task<Dto> Update(Dto dto);
    public System.Threading.Tasks.Task Delete(int id);
    public Task<List<Dto>> Search(SearchT search);
}
