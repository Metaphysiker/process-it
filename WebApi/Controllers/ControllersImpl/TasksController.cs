using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers;


[ApiController]
[Route("api/[controller]")]
public class TasksController : ControllerBase, IModelController<TaskDto, TaskSearch>
{
    public Task<ActionResult<TaskDto>> Create([FromBody] TaskDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<ActionResult> Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Task<ActionResult<TaskDto>> Read(int id)
    {
        throw new NotImplementedException();
    }

    public Task<ActionResult<List<TaskDto>>> ReadAll()
    {
        throw new NotImplementedException();
    }

    public Task<ActionResult<PaginationDto<TaskDto>>> Search([FromBody] TaskSearch search)
    {
        throw new NotImplementedException();
    }

    public Task<ActionResult<TaskDto>> Update([FromBody] TaskDto dto)
    {
        throw new NotImplementedException();
    }
}
