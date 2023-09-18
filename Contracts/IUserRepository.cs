using Money_Manager.Models;

namespace Money_Manager.Repository
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        Task<User> GetByUsername(string username);
    }
}
