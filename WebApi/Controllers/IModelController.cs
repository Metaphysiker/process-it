using Microsoft.AspNetCore.Mvc;
using Shared.Dtos;

namespace WebApi.Controllers;

public interface IModelController<Dto, SearchT> where Dto : IModelDto where SearchT : ISearch
{
    public Task<ActionResult<List<Dto>>> ReadAll();
    public Task<ActionResult<Dto>> Read(int id);
    public Task<ActionResult<Dto>> Create([FromBody] Dto dto);
    public Task<ActionResult<Dto>> Update([FromBody] Dto dto);
    public Task<ActionResult> Delete(int id);
    public Task<ActionResult<PaginationDTO<Dto>>> Search([FromBody] SearchT search);
}
