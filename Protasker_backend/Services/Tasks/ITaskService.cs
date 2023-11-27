
namespace Protasker_backend
{
    public interface ITaskService
    {
        Task<ServiceResponse<List<TaskModel>>> GetTasks();
        Task<ServiceResponse<TaskModel>> GetTaskByID(int id);
        Task<ServiceResponse<CreateTaskDto>> CreateTask(CreateTaskDto createTaskDto);
        Task<ServiceResponse<UpdateTaskDto>> UpdateTask(UpdateTaskDto updateTaskDto);
        Task<ServiceResponse<DeleteTaskDto>> DeleteTask(DeleteTaskDto deleteTaskDto);  
    }
}