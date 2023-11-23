
namespace Protasker_backend
{
    public interface IUserService
    {
        Task<ServiceResponse<List<UserModel>>> GetUsers();
        Task<ServiceResponse<UserModel>> GetUserID(int id);
    }
}