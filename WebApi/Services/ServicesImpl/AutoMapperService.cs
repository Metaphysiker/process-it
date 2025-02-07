using AutoMapper;

public class AutoMapperService
{

    public IMapper mapper { get; set; }

    public AutoMapperService()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Task, TaskDto>().ReverseMap();
        }
        );

        mapper = new Mapper(config);
    }
}
