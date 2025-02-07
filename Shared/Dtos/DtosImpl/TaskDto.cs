using Shared.Dtos;

public class TaskDto : IModelDto
{
    public int Id { get; set; }
    public String Name { get; set; } = String.Empty;
}
