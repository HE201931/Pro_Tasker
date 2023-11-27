
namespace Protasker_backend
{
    public class TaskService : ITaskService
    {
        private readonly DataContext _DataContext;
        private readonly IMapper _Mapper;

        public TaskService(DataContext dataContext, IMapper mapper)
        {
            this._DataContext = dataContext;
            this._Mapper = mapper;
        }

        public async Task<ServiceResponse<CreateTaskDto>> CreateTask(CreateTaskDto createTaskDto)
        {
            ServiceResponse<CreateTaskDto> serviceResponse = new ServiceResponse<CreateTaskDto>();
            try
            {

                await this._DataContext.AddAsync(_Mapper.Map<TaskModel>(createTaskDto));
                await this._DataContext.SaveChangesAsync();
                serviceResponse.Data = createTaskDto;
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
                serviceResponse.Data = await this._DataContext.Tasks
                .Join(this._DataContext.Users, task => task.UserID, user => user.Id, (task, user) => new TaskModel
                {
                    Id = task.Id,
                    UserID = task.UserID,
                    UserModel = user,
                    Libelle = task.Libelle,
                    Status = task.Status
                }
                
                ).ToListAsync();
   
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
                List<TaskModel> taskList = await this._DataContext.Tasks
                .Join(this._DataContext.Users, task => task.UserID, user => user.Id, (task, user) => new TaskModel
                {
                    Id = task.Id,
                    UserID = task.UserID,
                    UserModel = user,
                    Libelle = task.Libelle,
                    Status = task.Status
                }               
                ).ToListAsync();
                serviceResponse.Data = taskList.FirstOrDefault(t => t.Id == id)!;
            }
            catch(Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.ToString();
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<UpdateTaskDto>> UpdateTask(UpdateTaskDto updateTaskDto)
        {
            ServiceResponse<UpdateTaskDto> serviceResponse = new ServiceResponse<UpdateTaskDto>();
            try
            {
                TaskModel taskModel = _Mapper.Map<TaskModel>(updateTaskDto);
                List<TaskModel> taskList = await this._DataContext.Tasks.ToListAsync();
                TaskModel taskToUpdate = taskList.FirstOrDefault(t => t.Id == updateTaskDto.Id)!;
                taskToUpdate.Status = updateTaskDto.Status;
                taskToUpdate.Libelle = updateTaskDto.Libelle;
                serviceResponse.Data = updateTaskDto;
                await this._DataContext.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.ToString();
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<DeleteTaskDto>> DeleteTask(DeleteTaskDto deleteTaskDto)
        {   
            ServiceResponse<DeleteTaskDto> serviceResponse = new ServiceResponse<DeleteTaskDto>();
            try
            {
                TaskModel taskToDelete = await this._DataContext.Tasks.FirstOrDefaultAsync(t => t.Id == deleteTaskDto.Id)?? throw new NullReferenceException("Not found");
                TaskModel taskDeleted = new TaskModel()
                {
                    Id = taskToDelete.Id,
                    UserID = taskToDelete.UserID,
                    Libelle = taskToDelete.Libelle,
                    Status = taskToDelete.Status
                };
                this._DataContext.Tasks.Remove(taskToDelete);
                await this._DataContext.SaveChangesAsync();
                serviceResponse.Data = deleteTaskDto;
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