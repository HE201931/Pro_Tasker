
namespace Protasker_backend
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<TaskModel, CreateTaskDto>();
            CreateMap<CreateTaskDto, TaskModel>();

            CreateMap<TaskModel, UpdateTaskDto>();
            CreateMap<UpdateTaskDto, TaskModel>();

            CreateMap<TaskModel, DeleteTaskDto>();
            CreateMap<DeleteTaskDto, TaskModel>();
        }
    }
}