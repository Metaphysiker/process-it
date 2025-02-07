using Shared.Dtos;
using WebApi.DtoConverters;
using WebApi.Factories;
using WebApi.Repositories;

namespace WebApi.Services.ServicesImpl;

public class GenericService<ModelT, ModelDtoT, SearchT> : IModelService<ModelT, ModelDtoT, SearchT>
    where ModelT : class, IModel
    where ModelDtoT : IModelDto
    where SearchT : ISearch
{
    private readonly IRepository<ModelT, SearchT> _repository;
    private readonly DtoConverterFactory _dtoConverterFactory;
    private IDtoConverter<ModelDtoT, ModelT> _dtoConverter;

    public GenericService(IRepository<ModelT, SearchT> repository, DtoConverterFactory dtoConverterFactory)
    {
        _dtoConverterFactory = dtoConverterFactory;
        _repository = repository;
        _dtoConverter = (IDtoConverter<ModelDtoT, ModelT>)_dtoConverterFactory.CreateDtoConverter(typeof(ModelDtoT));
    }

    public async Task<ModelDtoT> Create(ModelDtoT dto)
    {
        var model = _dtoConverter.Convert(dto);
        var savedModel = await _repository.Create(model);
        return (ModelDtoT)_dtoConverter.Convert(savedModel);
    }

    public async System.Threading.Tasks.Task Delete(int id)
    {
        await _repository.Delete(id);
    }

    public async Task<ModelDtoT> Read(int id)
    {
        var model = await _repository.Read(id);
        return (ModelDtoT)_dtoConverter.Convert(model);
    }

    public async Task<IEnumerable<ModelDtoT>> ReadAll()
    {
        var models = await _repository.ReadAll();
        return _dtoConverter.Convert(models);

    }

    public Task<IEnumerable<ModelDtoT>> Search(SearchT search)
    {
        throw new NotImplementedException();
    }

    public async Task<ModelDtoT> Update(ModelDtoT dto)
    {
        var model = _dtoConverter.Convert(dto);
        var updatedModel = await _repository.Update(model);
        return (ModelDtoT)_dtoConverter.Convert(updatedModel);
    }
}
