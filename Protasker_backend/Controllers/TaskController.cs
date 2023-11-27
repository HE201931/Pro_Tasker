
namespace Protasker_backend
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _TaskService;
        public TaskController(ITaskService taskService)
        {
            this._TaskService = taskService;
        }

        /// <summary>
        /// </summary>
        /// <returns>Retourne toutes les tâches existantes</returns>
        [HttpGet("/api/v1/tasks")]
        public async Task<ActionResult<ServiceResponse<List<TaskModel>>>> GetTasks()
        {
            return Ok(await this._TaskService.GetTasks());
        }

        /// <summary>
        /// </summary>
        /// <param name="id">Id de la tâche recherchée</param>
        /// <returns>La tâche correspondante à l'id passé</returns>
        [HttpGet("/api/v1/tasks/{id}")]
        public async Task<ActionResult<ServiceResponse<TaskModel>>> GetTaskById(int id)
        {
            return Ok(await this._TaskService.GetTaskByID(id));
        }

        /// <summary>
        /// </summary>
        /// <param name="taskModel">La nouvelle tâche insérée dans la base de données</param>
        /// <returns>La nouvelle tâche créée</returns>
        [HttpPost("/api/v1/tasks")]
        public async Task<ActionResult<ServiceResponse<CreateTaskDto>>> CreateTask(CreateTaskDto createTaskDto)
        {
            return Ok(await this._TaskService.CreateTask(createTaskDto)); 
        }

        /// <summary>
        /// Met à jour les données d'une tâche. Un DTO serait plus adapté.
        /// </summary>
        /// <param name="taskModel">La tâche à mettre à jour</param>
        /// <returns>La tâche mise à jour</returns>
        [HttpPut("/api/v1/tasks")]
        public async Task<ActionResult<ServiceResponse<UpdateTaskDto>>> UpdateTask(UpdateTaskDto taskModel)
        {
            return Ok(await this._TaskService.UpdateTask(taskModel));        
        }

        /// <summary>
        /// Permet de supprimer une tâche
        /// </summary>
        /// <param name="id">Id de la tâche à supprimer</param>
        /// <returns>Les données de la tâche supprimée</returns>
        [HttpDelete("/api/v1/tasks")]
        public async Task<ActionResult<ServiceResponse<DeleteTaskDto>>> DeleteTask(DeleteTaskDto deleteTaskDto)
        {
            return Ok(await this._TaskService.DeleteTask(deleteTaskDto));         
        }
    }
}