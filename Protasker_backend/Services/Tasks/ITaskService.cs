
namespace Protasker_backend
{
    public interface ITaskService
    {
        Task<ServiceResponse<List<TaskModel>>> GetTasks();
        Task<ServiceResponse<TaskModel>> GetTaskByID(int id);
        Task<ServiceResponse<TaskModel>> CreateTask(TaskModel taskModel);
        Task<ServiceResponse<TaskModel>> UpdateTask(TaskModel taskModel);
        Task<ServiceResponse<TaskModel>> DeleteTask(int id);  
    }
}