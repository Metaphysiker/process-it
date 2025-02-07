using Shared.Dtos;

namespace WebApi.DtoConverters;

public interface IDtoConverter<ModelDtoT, ModelT> where ModelDtoT : IModelDto where ModelT : IModel
{
    public ModelDtoT Convert(ModelT model);
    public IEnumerable<ModelDtoT> Convert(IEnumerable<ModelT> models);
    public ModelT Convert(ModelDtoT dto);
    public IEnumerable<ModelT> Convert(IEnumerable<ModelDtoT> dtos);
}
