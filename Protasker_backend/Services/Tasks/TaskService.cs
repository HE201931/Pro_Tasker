
namespace Protasker_backend
{
    public class TaskService : ITaskService
    {
        private readonly DataContext _DataContext;
        public TaskService(DataContext dataContext)
        {
            this._DataContext = dataContext;
        }

        public async Task<ServiceResponse<TaskModel>> CreateTask(TaskModel taskModel)
        {
            ServiceResponse<TaskModel> serviceResponse = new ServiceResponse<TaskModel>();
            try
            {
                await this._DataContext.AddAsync(taskModel);
                serviceResponse.Data = taskModel;
            }
            catch(Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.ToString();
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<TaskModel>>> GetTasks()
        {
            ServiceResponse<List<TaskModel>> serviceResponse = new ServiceResponse<List<TaskModel>>();
            try
            {
                serviceResponse.Data = await this._DataContext.Tasks.ToListAsync();
            }
            catch(Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.ToString();
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<TaskModel>> GetTaskByID(int id)
        {
            ServiceResponse<TaskModel> serviceResponse = new ServiceResponse<TaskModel>();
            try
            {
                List<TaskModel> taskList = await this._DataContext.Tasks.ToListAsync();
                serviceResponse.Data = taskList.FirstOrDefault(t => t.Id == id)!;
            }
            catch(Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.ToString();
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<TaskModel>> UpdateTask(TaskModel taskModel)
        {
            ServiceResponse<TaskModel> serviceResponse = new ServiceResponse<TaskModel>();
            try
            {
                List<TaskModel> taskList = await this._DataContext.Tasks.ToListAsync();
                TaskModel taskToUpdate = taskList.FirstOrDefault(t => t.Id == taskModel.Id)!;
                taskToUpdate.Status = taskModel.Status;
                taskToUpdate.Libelle = taskModel.Libelle;
                serviceResponse.Data = taskToUpdate;
            }
            catch(Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.ToString();
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<TaskModel>> DeleteTask(int id)
        {   
            ServiceResponse<TaskModel> serviceResponse = new ServiceResponse<TaskModel>();
            try
            {
                TaskModel taskToDelete = await this._DataContext.Tasks.FirstOrDefaultAsync(t => t.Id == id);
                TaskModel taskDeleted = new TaskModel()
                {
                    Id = taskToDelete.Id,
                    UserID = taskToDelete.UserID,
                    Libelle = taskToDelete.Libelle,
                    Status = taskToDelete.Status
                };
                this._DataContext.Tasks.Remove(taskToDelete);
                serviceResponse.Data = taskDeleted;
            }
            catch(Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.ToString();
            }
            return serviceResponse;
        }
    }
}