
using Microsoft.EntityFrameworkCore;

namespace WebApi.Repositories.RepositoriesImpl;

public class GenericRepository<ModelT, SearchT> : IRepository<ModelT, SearchT>
    where ModelT : class, IModel
    where SearchT : ISearch
{
    private readonly DatabaseContext _db;

    public GenericRepository(DatabaseContext db)
    {
        _db = db;
    }

    public async Task<ModelT> Create(ModelT model)
    {
        await _db.AddAsync<ModelT>(model);
        await _db.SaveChangesAsync();
        return model;
    }

    public async System.Threading.Tasks.Task Delete(int id)
    {
        var model = await _db.FindAsync<ModelT>(id);
        _db.Remove(model);
        await _db.SaveChangesAsync();
    }

    public async Task<ModelT?> Read(int id)
    {
        var model = await _db.FindAsync<ModelT>(id);
        return model;
    }

    public async Task<List<ModelT>> ReadAll()
    {
        var models = await _db.Set<ModelT>().ToListAsync();
        return models;
    }

    public Task<List<ModelT>> Search(SearchT search)
    {
        throw new NotImplementedException();
    }

    public async Task<ModelT> Update(ModelT model)
    {
        _db.Update<ModelT>(model);
        await _db.SaveChangesAsync();
        return model;
    }
}
