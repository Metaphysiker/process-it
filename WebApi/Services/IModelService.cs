using Shared.Dtos;

public interface IModelService<Model, Dto, SearchT> where Model : IModel where Dto : IModelDto where SearchT : ISearch
{
    public Task<IEnumerable<Dto>> ReadAll();
    public Task<Dto> Read(int id);
    public Task<Dto> Create(Dto dto);
    public Task<Dto> Update(Dto dto);
    public System.Threading.Tasks.Task Delete(int id);
    public Task<IEnumerable<Dto>> Search(SearchT search);
}
