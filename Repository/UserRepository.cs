using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Money_Manager.Models;
using Money_Manager.Repository;

namespace Repository
{
    internal class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(ApplicationContext context, ILogger logger)
            : base(context, logger)
        {

        }
        public async Task<User> GetByUsername(string username)
        {
            var result = await _context.Users.FirstOrDefaultAsync(u => u.UserName == username);
            if (result != null)
            {
                return result;
            }
            return null;
        }
    }
}
