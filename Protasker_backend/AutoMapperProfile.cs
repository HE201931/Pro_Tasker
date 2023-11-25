
namespace Protasker_backend
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<TaskModel, CreateTaskDto>();
            CreateMap<CreateTaskDto, TaskModel>();
        }
    }
}