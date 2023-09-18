using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Money_Manager.Models;
using Money_Manager.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class AccountRepository: RepositoryBase<Account>, IAccountRepository
    {
        public AccountRepository(ApplicationContext context, ILogger logger)
            :base(context, logger)
        {
        }
        public override IQueryable<Account> FindByCondition(Expression<Func<Account, bool>> expression)
        {
            return _context.Set<Account>().Where(expression)
                .Include(acc=>acc.Currency)
                .Include(acc=>acc.AccountGroup)
                .AsNoTracking();
        }
    }
}
