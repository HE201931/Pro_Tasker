
namespace Protasker_backend
{
    public class UserService : IUserService
    {
        private readonly DataContext _DataContext;
        public UserService(DataContext dataContext)
        {
            this._DataContext = dataContext;
        }

        public async Task<ServiceResponse<List<UserModel>>> GetUsers()
        {
            ServiceResponse<List<UserModel>> serviceResponse = new ServiceResponse<List<UserModel>>();
            try
            {
                serviceResponse.Data = await this._DataContext.Users.ToListAsync();
            }
            catch(Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.ToString();
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<UserModel>> GetUserID(int id)
        {
            ServiceResponse<UserModel> serviceResponse = new ServiceResponse<UserModel>();

            try
            {
                List<UserModel> listUsers = await this._DataContext.Users.ToListAsync();
                serviceResponse.Data = listUsers.FirstOrDefault(u => u.Id == id)!;
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