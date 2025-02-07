
using Microsoft.EntityFrameworkCore;

namespace WebApi.Repositories.RepositoriesImpl;

public class GenericRepository : IRepository<IModel, ISearch>
{
    private readonly DatabaseContext _db;

    public GenericRepository(DatabaseContext db)
    {
        _db = db;
    }

    async public Task<IModel> Create(IModel model)
    {
        await _db.AddAsync(model);
        await _db.SaveChangesAsync();
        return model;
    }

    async public Task<IModel> Update(IModel model)
    {
        model.UpdatedAt = DateTime.Now;
        _db.Update(model);
        await _db.SaveChangesAsync();
        return model;
    }

    async public System.Threading.Tasks.Task Delete(int id)
    {
        var model = await _db.FindAsync<IModel>(id);
        if (model != null)
        {
            _db.Remove(model);
        }
        await _db.SaveChangesAsync();
    }

    async public Task<IModel?> Read(int id)
    {
        var model = await _db.FindAsync<IModel>(id);
        return model;
    }

    async public Task<List<IModel>> ReadAll()
    {
        var models = _db.Set<IModel>();
        return await models.ToListAsync();
    }

    public Task<List<IModel>> Search(ISearch search)
    {
        throw new NotImplementedException();
    }


}
