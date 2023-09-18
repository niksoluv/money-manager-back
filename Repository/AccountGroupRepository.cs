using Entities.Models;
using Microsoft.Extensions.Logging;
using Money_Manager.Models;
using Money_Manager.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class AccountGroupRepository: RepositoryBase<AccountGroup>, IAccountGroupRepository
    {
        public AccountGroupRepository(ApplicationContext context, ILogger logger):
            base(context, logger)
        {
            
        }
    }
}
