namespace WebApi.Repositories;

public interface IRepository<Model, SearchT> where Model : class, IModel where SearchT : ISearch
{
    public Task<List<Model>> ReadAll();
    public Task<Model?> Read(int id);
    public Task<Model> Create(Model model);
    public Task<Model> Update(Model model);
    public System.Threading.Tasks.Task Delete(int id);
    public Task<List<Model>> Search(SearchT search);
}
