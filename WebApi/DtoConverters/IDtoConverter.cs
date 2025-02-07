using Shared.Dtos;

namespace WebApi.DtoConverters;

public interface IDtoConverter<Dto, Model> where Dto : IModelDto where Model : IModel
{
    public Dto ConvertToDto(Model model);
    public Model ConvertToModel(Dto dto);
}
