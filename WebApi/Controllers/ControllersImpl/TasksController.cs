using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers;
using WebApi.Factories;

[ApiController]
[Route("api/[controller]")]
public class TasksController : ControllerBase, IModelController<TaskDto, TaskSearch>
{
    private readonly ModelServiceFactory _modelServiceFactory;
    private IModelService<Task, TaskDto, TaskSearch> _service;
    public TasksController(ModelServiceFactory modelServiceFactory)
    {
        _modelServiceFactory = modelServiceFactory;
        _service = (IModelService<Task, TaskDto, TaskSearch>)_modelServiceFactory.Create(typeof(Task));
    }


    [HttpPost]
    async public Task<ActionResult<TaskDto>> Create([FromBody] TaskDto dto)
    {
        var savedModel = await _service.Create(dto);
        return Ok(savedModel);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await _service.Delete(id);
        return Ok();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TaskDto>> Read(int id)
    {
        var dto = await _service.Read(id);
        return Ok(dto);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TaskDto>>> ReadAll()
    {
        var dtos = await _service.ReadAll();
        return Ok(dtos);
    }

    [HttpPost("search")]
    public async Task<ActionResult<PaginationDto<TaskDto>>> Search([FromBody] TaskSearch search)
    {
        PaginationDto<TaskDto> paginationDto = new PaginationDto<TaskDto>();
        paginationDto.Data = (List<TaskDto>)await _service.Search(search);
        return Ok(paginationDto);
    }

    [HttpPut]
    public async Task<ActionResult<TaskDto>> Update([FromBody] TaskDto dto)
    {
        var updatedModel = await _service.Update(dto);
        return Ok(updatedModel);
    }
}
