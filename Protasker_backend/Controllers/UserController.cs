
namespace Protasker_backend
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _UserService;
        public UserController(IUserService UserService)
        {
            this._UserService = UserService;
        }

        /// <summary>
        /// </summary>
        /// <param name="id">Id de l'utilisateur recherché</param>
        /// <returns>L'utilisateur correspondante à l'id passé</returns>
        [HttpGet("/api/v1/user/{id}")]
        public async Task<ActionResult<ServiceResponse<TaskModel>>> GetUserById(int id)
        {
           return Ok(await this._UserService.GetUserID(id));            
        }

        /// <summary>
        /// </summary>
        /// <returns>Retourne touts les </returns>
        [HttpGet("/api/v1/users")]
        public async Task<ActionResult<ServiceResponse<TaskModel>>> GetUsers()
        {
            return Ok(await this._UserService.GetUsers());
        }
    }
}